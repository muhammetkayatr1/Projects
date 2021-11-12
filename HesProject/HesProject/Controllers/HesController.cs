using HesProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HesProject.Controllers
{
    [Authorize]
    public class HesController : Controller
    {
        string Baseurl = "https://hesservis.turkiye.gov.tr/services/g2g/saglik/hes";

        private readonly AppDbContext _context;

        public HesController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CheckEmployeeHesCode()
        {
            return View();
        }

        
        public async Task<IActionResult> CheckEmployeeHesCode(string hes, string tc, string status)
        {
            ApiAuth login = new ApiAuth
            {
                userName = "HALICUNI-G2G-HES",
                password = "nYfc3VVSue3uEugPBv"
            };
            HesQuery search = new HesQuery
            {
                hes_code = hes
            };
            var jsonSearch = JsonConvert.SerializeObject(search);
            var content = new StringContent(jsonSearch.ToString(), Encoding.UTF8, "application/json");
            HesResult hesResult = new HesResult();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl + "/check-employee-hes-code");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue(
        "Basic", Convert.ToBase64String(
            System.Text.ASCIIEncoding.ASCII.GetBytes(
               $"{login.userName}:{login.password}")));
                HttpResponseMessage res = await client.PostAsync(Baseurl + "/check-employee-hes-code", content);
                if (res.IsSuccessStatusCode)
                {
                    var searchResponse = res.Content.ReadAsStringAsync().Result;
                    hesResult = (JsonConvert.DeserializeObject<HesResult>(searchResponse));
                    if (_context.Person.FirstOrDefault(i => i.tc == tc) == null)
                    {
                        Person person = new Person();
                        person.tc = tc;
                        person.hes = hes;
                        person.status = status;
                        person.durum = hesResult.current_health_status;
                        _context.Add(person);
                        await _context.SaveChangesAsync();
                        ViewBag.Result = "Bilgileriniz başarı ile kaydedilmiştir.";
                    }
                    else
                    {
                        ViewBag.Result = "Girdiğiniz TC numarası daha önce sisteme kaydedilmiştir.";
                    }
                }
                else
                {
                    ViewBag.Result = "Girdiğiniz Hes Kodu hatalı veya aktif değildir.";
                }
            }

            return View();
        }

        public IActionResult CheckHesCodePlus()
        {
            return View();
        }

        public async Task<IActionResult> CheckHesCodePlus(string hes, string tc, string status)
        {
            ApiAuth login = new ApiAuth
            {
                userName = "HALICUNI-G2G-HES",
                password = "nYfc3VVSue3uEugPBv"
            };
            HesQuery search = new HesQuery
            {
                hes_code = hes
            };
            var jsonSearch = JsonConvert.SerializeObject(search);
            var content = new StringContent(jsonSearch.ToString(), Encoding.UTF8, "application/json");
            HesResult hesResult = new HesResult();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl + "/check-hes-code-plus");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue(
        "Basic", Convert.ToBase64String(
            System.Text.ASCIIEncoding.ASCII.GetBytes(
               $"{login.userName}:{login.password}")));
                HttpResponseMessage res = await client.PostAsync(Baseurl + "/check-hes-code-plus", content);
                if (res.IsSuccessStatusCode)
                {
                    var searchResponse = res.Content.ReadAsStringAsync().Result;
                    hesResult = (JsonConvert.DeserializeObject<HesResult>(searchResponse));
                    if (_context.Person.FirstOrDefault(i => i.tc == tc) == null)
                    {
                        Person person = new Person();
                        person.tc = tc;
                        person.hes = hes;
                        person.status = status;
                        person.durum = hesResult.current_health_status;
                        _context.Add(person);
                        await _context.SaveChangesAsync();
                        ViewBag.Result = "Bilgileriniz başarı ile kaydedilmiştir.";
                    }
                    else
                    {
                        ViewBag.Result = "Girdiğiniz TC numarası daha önce sisteme kaydedilmiştir.";
                    }
                }
                else
                {
                    ViewBag.Result = "Girdiğiniz Hes Kodu hatalı veya aktif değildir.";
                }
            }

            return View();
        }


        public async Task<IActionResult> HesSearch(string hes, string tc, string status)
        {
            ApiAuth login = new ApiAuth
            {
                userName = "HALICUNI-G2G-HES",
                password = "nYfc3VVSue3uEugPBv"
            };
            HesQuery search = new HesQuery
            {
                hes_code = hes
            };
            var jsonSearch = JsonConvert.SerializeObject(search);
            var content = new StringContent(jsonSearch.ToString(), Encoding.UTF8, "application/json");
            HesResult hesResult = new HesResult();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl + "/check-employee-hes-code");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue(
        "Basic", Convert.ToBase64String(
            System.Text.ASCIIEncoding.ASCII.GetBytes(
               $"{login.userName}:{login.password}")));
                HttpResponseMessage res = await client.PostAsync(Baseurl + "/check-employee-hes-code", content);
                if (res.IsSuccessStatusCode)
                {
                    var searchResponse = res.Content.ReadAsStringAsync().Result;
                    hesResult = (JsonConvert.DeserializeObject<HesResult>(searchResponse));
                    if (_context.Person.FirstOrDefault(i => i.tc == tc) == null)
                    {
                        Person person = new Person();
                        person.tc = tc;
                        person.hes = hes;
                        person.status = status;
                        person.durum = hesResult.current_health_status;
                        return View(person);
                    }
                    else
                    {
                        ViewBag.Result = "Girdiğiniz TC numarası daha önce sisteme kaydedilmiştir.";
                    }
                }
                else
                {
                    ViewBag.Result = "Girdiğiniz Hes Kodu hatalı veya aktif değildir.";
                }
            }

            return View();
        }

    }
}
