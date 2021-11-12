using BL.Repository;
using BL.Repository.ConcreateRepositories;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SCPDashboard.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Net;
using Microsoft.Extensions.Logging;

namespace SCPDashboard.Controllers
{
    [Authorize]
    public class LogController : Controller
    {
        readonly LogRepository _LogRepository;
        public LogController(IRepository<Log> LogRepository)
        {
            _LogRepository = (LogRepository)LogRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var x = _LogRepository.Get();
            List<LogFromJson> logs = new List<LogFromJson>();
            foreach (var item in x)
            {
                LogFromJson data = ExtensionMethods.FromJson<LogFromJson>(item.LogDetails);

               
                logs.Add(data);
            }
            return View(logs);
        }

        public JsonResult getSms(string SmsCode)
        {
            var token = Token().Result;
            SmsResult smsResult = (SmsResult)Sms(token, SmsCode).Result;
            return Json(smsResult);

        }

        public static async Task<string> Token()
        {
            string Baseurl = "https://selfservis.halic.edu.tr/webapi/";
            ApiUser user = new ApiUser
            {
                userName = "selfservis@halic.edu.tr",
                password = "1q2W3e4R5*_"
            };
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            ApiToken tokenKey = new ApiToken();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl + "api/Auth/login");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var Res = client.PostAsync(Baseurl + "api/Auth/login", content).Result;
                if (Res.IsSuccessStatusCode)
                {
                    var TokenResponse = Res.Content.ReadAsStringAsync().Result;
                    tokenKey = JsonConvert.DeserializeObject<ApiToken>(TokenResponse);
                }

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenKey.data.token);
            }


            return tokenKey.data.token;
        }

        public static async Task<object> Sms(string token, string SmsCode)
        {
            string Baseurl = "https://selfservis.halic.edu.tr/webapi/";
            SmsResponse smsResponse = new SmsResponse
            {
                referenceNumber = SmsCode
            };
            var json = JsonConvert.SerializeObject(smsResponse);
            var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            SmsResult smsResult = new SmsResult();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl + "api/SelfServisOperation/smsreportdetail");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var Res =  client.PostAsync(Baseurl + "api/SelfServisOperation/smsreportdetail", content).Result;
                if (Res.IsSuccessStatusCode)
                {
                    var smsApiResponse = Res.Content.ReadAsStringAsync().Result;
                    smsResult = (JsonConvert.DeserializeObject<SmsResult>(smsApiResponse));
                }
                else
                {
                   
                }
            }


            return smsResult;


        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Log model)
        {
            _LogRepository.Add(model);
            _LogRepository.Save();
            return RedirectToAction("Index");
        }

        string Baseurl = "https://selfservis.halic.edu.tr/webapi/";
       
    }
}
