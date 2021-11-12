using HesProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Quartz;
using Quartz.Impl;
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

    public class CheckHesCodesController : Controller
    {
        string Baseurl = "https://hesservis.turkiye.gov.tr/services/g2g/saglik/hes";

        private readonly AppDbContext _context;

        public CheckHesCodesController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }




        //public class ShowDateTimeJob : IJob
        //{
        //    public Task Execute(IJobExecutionContext contextJob)
        //    {
        //        CheckHesCodesController checkHesCodesController = new CheckHesCodesController();
        //        var now = DateTime.Now.ToString("HH : mm : ss");
        //        checkHesCodesController.HesCodesSearch();
        //        return Task.CompletedTask;
        //    }
        //}

        //public static class SchedulerHelper
        //{
        //    public static async void SchedulerSetup()
        //    {
        //        var _scheduler = await new StdSchedulerFactory().GetScheduler();
        //        await _scheduler.Start();

        //        var showDateTimeJob = JobBuilder.Create<ShowDateTimeJob>()
        //            .WithIdentity("ShowDateTimeJob")
        //            .Build();
        //        var trigger = TriggerBuilder.Create()
        //            .WithIdentity("ShowDateTimeJob")
        //            .StartNow()
        //            .WithSimpleSchedule(builder => builder.WithIntervalInMinutes(1).RepeatForever()) //.WithCronSchedule("*/1 * * * *")
        //            .Build();

        //        var result = await _scheduler.ScheduleJob(showDateTimeJob, trigger);
        //    }

        //}

        //public  void HesCodesSearch()
        //{
        //    ProlizData prolizData = _context.ProlizData.FirstOrDefault(i => i.TCKIMLIKNO == "23677801824");
        //    prolizData.HESKOD = "";
        //    _context.ProlizData.Update(prolizData);
        //    _context.SaveChanges();
        //}



        public async Task<IActionResult> HesCodesSearch()
        {
            foreach (var item in _context.ProlizData.Where(i => i.HESKOD != null))
            {
                item.HESKOD = item.HESKOD.Replace("-", "");
                item.HESKOD = item.HESKOD.Replace(" ", "");
                _context.ProlizData.Update(item);
            }

            _context.SaveChanges();
            List<HesQuery> hesCodes = new List<HesQuery>();
            List<HesResultPlus> employeeCodes = new List<HesResultPlus>();
            EmployeCodesList employeCodesLists = new EmployeCodesList();
            List<HesQuery> listSearch = new List<HesQuery>();
            foreach (var item in _context.ProlizData.Where(i => i.HESKOD != null))
            {
                HesQuery hesCode = new HesQuery { hes_code = item.HESKOD };
                listSearch.Add(hesCode);
                if (listSearch.Count % 3 == 0)
                {
                    SearchCollective searchCollective = new SearchCollective();
                    searchCollective.searches = listSearch;
                    ApiAuth login = new ApiAuth
                    {
                        userName = "HALICUNI-G2G-HES",
                        password = "nYfc3VVSue3uEugPBv"
                    };
                    var jsonSearch = JsonConvert.SerializeObject(listSearch);
                    var content = new StringContent(jsonSearch.ToString(), Encoding.UTF8, "application/json");
                    Codes searchResult = new Codes();
                    try
                    {

                        using (var client = new HttpClient())
                        {
                            client.BaseAddress = new Uri(Baseurl + "/check-hes-codes-plus");
                            client.DefaultRequestHeaders.Clear();
                            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(
                    "Basic", Convert.ToBase64String(
                        System.Text.ASCIIEncoding.ASCII.GetBytes(
                           $"{login.userName}:{login.password}")));
                            HttpResponseMessage Res = await client.PostAsync(Baseurl + "/check-hes-codes-plus", content);

                            if (Res.IsSuccessStatusCode)
                            {
                                var SearchResponse = Res.Content.ReadAsStringAsync().Result;
                                SearchResponse[1].ToString();
                                var sonuc = JsonConvert.DeserializeObject(SearchResponse);
                                var jtkon = Newtonsoft.Json.Linq.JToken.Parse(sonuc.ToString());
                                jtkon.Count();
                                var tokenResult = jtkon.SelectToken("success_map");
                                var errorResult = jtkon.SelectToken("unsuccess_map");
                                foreach (var hcode in listSearch)
                                {
                                    var data = tokenResult.SelectToken(hcode.hes_code);
                                    var dataUnSucces = errorResult.SelectToken(hcode.hes_code);
                                    HesResultPlus employee = new HesResultPlus();
                                    if (data != null)
                                    {
                                        employee = JsonConvert.DeserializeObject<HesResultPlus>(data.ToString()); // geçici çözüm bu şekildedir.
                                        employeeCodes.Add(employee);
                                        employeCodesLists.employeeCodes = employeeCodes;
                                        HesQuery hesCode1 = new HesQuery();
                                        hesCode1.hes_code = hcode.hes_code;
                                        hesCodes.Add(hesCode1);
                                        employeCodesLists.hesCode = hesCodes;
                                    }
                                    else if (dataUnSucces != null)
                                    {
                                        employee.result = dataUnSucces.ToString();
                                        employeeCodes.Add(employee);
                                        employeCodesLists.employeeCodes = employeeCodes;
                                        HesQuery hesCode1 = new HesQuery();
                                        hesCode1.hes_code = hcode.hes_code;
                                        hesCodes.Add(hesCode1);
                                        employeCodesLists.hesCode = hesCodes;
                                    }
                                    else
                                    {
                                        employeeCodes.Add(null);
                                        employeCodesLists.employeeCodes = employeeCodes;
                                        HesQuery hesCode1 = new HesQuery();
                                        hesCode1.hes_code = hcode.hes_code;
                                        hesCodes.Add(hesCode1);
                                        employeCodesLists.hesCode = hesCodes;
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        ViewBag.Result = e.Message;
                        return View();
                    }
                    listSearch.Clear();
                }
            }
            if (listSearch.Count < 500)
            {
                SearchCollective searchCollective = new SearchCollective();
                searchCollective.searches = listSearch;
                ApiAuth login = new ApiAuth
                {
                    userName = "HALICUNI-G2G-HES",
                    password = "nYfc3VVSue3uEugPBv"
                };
                var jsonSearch = JsonConvert.SerializeObject(listSearch);
                var content = new StringContent(jsonSearch.ToString(), Encoding.UTF8, "application/json");
                Codes searchResult = new Codes();
                try
                {

                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(Baseurl + "/check-hes-codes-plus");
                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue(
                "Basic", Convert.ToBase64String(
                    System.Text.ASCIIEncoding.ASCII.GetBytes(
                       $"{login.userName}:{login.password}")));
                        HttpResponseMessage Res = await client.PostAsync(Baseurl + "/check-hes-codes-plus", content);

                        if (Res.IsSuccessStatusCode)
                        {
                            var SearchResponse = Res.Content.ReadAsStringAsync().Result;
                            SearchResponse[1].ToString();
                            var sonuc = JsonConvert.DeserializeObject(SearchResponse);
                            var jtkon = Newtonsoft.Json.Linq.JToken.Parse(sonuc.ToString());
                            jtkon.Count();
                            var tokenResult = jtkon.SelectToken("success_map");
                            var errorResult = jtkon.SelectToken("unsuccess_map");
                            foreach (var hcode in listSearch)
                            {
                                var data = tokenResult.SelectToken(hcode.hes_code);
                                var dataUnSucces = errorResult.SelectToken(hcode.hes_code);

                                HesResultPlus employee = new HesResultPlus();
                                if (data != null)
                                {
                                    employee = JsonConvert.DeserializeObject<HesResultPlus>(data.ToString()); // geçici çözüm bu şekildedir.
                                    employeeCodes.Add(employee);
                                    employeCodesLists.employeeCodes = employeeCodes;
                                    HesQuery hesCode1 = new HesQuery();
                                    hesCode1.hes_code = hcode.hes_code;
                                    hesCodes.Add(hesCode1);
                                    employeCodesLists.hesCode = hesCodes;
                                }
                                else if (dataUnSucces != null)
                                {
                                    employee.result = dataUnSucces.ToString();
                                    employeeCodes.Add(employee);
                                    employeCodesLists.employeeCodes = employeeCodes;
                                    HesQuery hesCode1 = new HesQuery();
                                    hesCode1.hes_code = hcode.hes_code;
                                    hesCodes.Add(hesCode1);
                                    employeCodesLists.hesCode = hesCodes;
                                }
                                else
                                {
                                    employeeCodes.Add(null);
                                    employeCodesLists.employeeCodes = employeeCodes;
                                    HesQuery hesCode1 = new HesQuery();
                                    hesCode1.hes_code = hcode.hes_code;
                                    hesCodes.Add(hesCode1);
                                    employeCodesLists.hesCode = hesCodes;
                                }
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    ViewBag.Result = e.Message;
                    return View();
                }
                listSearch.Clear();
            }

            var a = employeCodesLists;
            int x = 0;
            try
            {
                foreach (var item in a.hesCode)
                {

                    foreach (var bData in _context.ProlizData.Where(i => i.HESKOD.Replace(" ", "") == item.hes_code))
                    {
                        if (employeCodesLists.employeeCodes[x] != null)
                        {
                            if (employeCodesLists.employeeCodes[x].result == null)
                            {
                                bData.durum = employeCodesLists.employeeCodes[x].current_health_status;
                                bData.expiration_date = employeCodesLists.employeeCodes[x].expiration_date;
                                bData.current_health_status = employeCodesLists.employeeCodes[x].current_health_status;
                                bData.masked_identity_number = employeCodesLists.employeeCodes[x].masked_identity_number;
                                bData.masked_firstname = employeCodesLists.employeeCodes[x].masked_firstname;
                                bData.masked_lastname = employeCodesLists.employeeCodes[x].masked_lastname;
                                bData.is_vaccinated = employeCodesLists.employeeCodes[x].is_vaccinated;
                                bData.is_immune = employeCodesLists.employeeCodes[x].is_immune;
                                bData.is_test_data_shared = employeCodesLists.employeeCodes[x].is_test_data_shared;
                                bData.last_negative_test_date = employeCodesLists.employeeCodes[x].last_negative_test_date;
                            }

                            else if (employeCodesLists.employeeCodes[x].result == "hescodehasbeenexpired")
                            {
                                bData.durum = "Hes Kodunun Süresi Dolmuştur";
                                bData.expiration_date = null;
                                bData.current_health_status = null;
                                bData.masked_identity_number = null;
                                bData.masked_firstname = null;
                                bData.masked_lastname = null;
                                bData.is_vaccinated = null;
                                bData.is_immune = null;
                                bData.is_test_data_shared = null;
                                bData.last_negative_test_date = null;
                            }
                            else if (employeCodesLists.employeeCodes[x].result == "hescodenotfound")
                            {
                                bData.durum = "Hes Kodu Hatalıdır";
                                bData.expiration_date = null;
                                bData.current_health_status = null;
                                bData.masked_identity_number = null;
                                bData.masked_firstname = null;
                                bData.masked_lastname = null;
                                bData.is_vaccinated = null;
                                bData.is_immune = null;
                                bData.is_test_data_shared = null;
                                bData.last_negative_test_date = null;
                            }

                        }
                        else
                        {
                            bData.durum = "Farklı Hata Oluştu";
                            bData.expiration_date = null;
                            bData.current_health_status = null;
                            bData.masked_identity_number = null;
                            bData.masked_firstname = null;
                            bData.masked_lastname = null;
                            bData.is_vaccinated = null;
                            bData.is_immune = null;
                            bData.is_test_data_shared = null;
                            bData.last_negative_test_date = null;
                        }

                        _context.ProlizData.Update(bData);
                    }

                    x++;
                }
            }
            catch (Exception e)
            {
                ViewBag.Result = e.Message;
                return View();
            }


            ViewBag.Result = "Sorgulama işlemi başarı ile tamamlandı.";

            foreach (var item in _context.ProlizData.Where(i => i.HESKOD == null))
            {
                item.durum = "Hes Kodu Bildirilmemiştir";
                _context.ProlizData.Update(item);
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                ViewBag.Result = e.Message + " Veritabanı Hatası";
                return View();
            }
            return RedirectToAction("Index", "Admin");
        }



    }
}
