using HesOperation.ProlizOperation;
using HesOperation.Uyumsoft;
using HesProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HesProject.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        string HesUrl = "https://hesservis.turkiye.gov.tr/services/g2g/saglik/hes";
        string Baseurl = "https://selfservis.halic.edu.tr/webapi/";

        private readonly AppDbContext _context;
        private readonly KonfidesDbContext _contextKonfides;

        public EmployeeController(AppDbContext context, KonfidesDbContext contextKonfides)
        {
            _context = context;
            _contextKonfides = contextKonfides;
        }
        //    public IActionResult Index()
        //    {
        //        //var Ssn = new SqlParameter("@Ssn", "2367780182");
        //        //var BlackList = new SqlParameter("@Blacklist", "0");
        //        //var Safe = new SqlParameter("@Safe", 1);

        //        //var Ssn = 23677801824;
        //        //var BlackList = false;
        //        //var Safe = false;

        //        //try
        //        //{

        //        //    var sonuc = _contextKonfides.Database.ExecuteSqlRaw($"exec sp_External_CardBlacklisting_ForHesCodeIntegration {Ssn}, {BlackList}, {Safe}");
        //        //}
        //        //catch (Exception ex)
        //        //{
        //        //    var r = ex.Message;
        //        //}

        //        return View(); 
        //    }

        //    public async Task<IActionResult> Token(string loginError)
        //    {

        //        Login user = new Login
        //        {
        //            userName = "selfservis@halic.edu.tr",
        //            password = "1q2W3e4R5*_"
        //        };
        //        var jsonUser = JsonConvert.SerializeObject(user);
        //        var content = new StringContent(jsonUser.ToString(), Encoding.UTF8, "application/json");
        //        Token tokenKey = new Token();
        //        using (var client = new HttpClient())
        //        {
        //            client.BaseAddress = new Uri(Baseurl + "api/Auth/login");
        //            client.DefaultRequestHeaders.Clear();
        //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //            HttpResponseMessage Res = await client.PostAsync(Baseurl + "api/Auth/login", content);
        //            if (Res.IsSuccessStatusCode)
        //            {
        //                var TokenResponse = Res.Content.ReadAsStringAsync().Result;
        //                tokenKey = JsonConvert.DeserializeObject<Token>(TokenResponse);

        //            }

        //            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenKey.data.token);
        //        }
        //        if (loginError == "UserNotFound")
        //        {
        //            ViewBag.loginError = "Girdiğiniz TC Numarasına Ait Kullanıcı Bulunamadı!";
        //        }
        //        HttpContext.Session.SetString("token", tokenKey.data.token);
        //        return View(tokenKey);
        //    }



        //    public async Task<IActionResult> PersonEmployeeInfo(string tc)
        //    {

        //        var token = HttpContext.Session.GetString("token");
        //        SearchIdentityNumber identityNuber = new SearchIdentityNumber
        //        {
        //            identityNumber = tc
        //        };
        //        var jsonIdentityNumber = JsonConvert.SerializeObject(identityNuber);
        //        var content = new StringContent(jsonIdentityNumber.ToString(), Encoding.UTF8, "application/json");
        //        PersonEmployeeInfo personEmployeeInfo = new PersonEmployeeInfo();
        //        using (var client = new HttpClient())
        //        {

        //            client.BaseAddress = new Uri(Baseurl + "api/SelfServisOperation/getemployeeInfo");
        //            client.DefaultRequestHeaders.Clear();
        //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        //            HttpResponseMessage Res = await client.PostAsync(Baseurl + "api/SelfServisOperation/getemployeeInfo", content);
        //            if (Res.IsSuccessStatusCode)
        //            {
        //                var PersonEmployeeInfoResponse = Res.Content.ReadAsStringAsync().Result;
        //                personEmployeeInfo = (JsonConvert.DeserializeObject<List<PersonEmployeeInfo>>(PersonEmployeeInfoResponse))[0];
        //                HttpContext.Session.SetString("personEmployeeInfo", PersonEmployeeInfoResponse);

        //            }
        //            else
        //            {

        //                return RedirectToAction("Token", "Employee", new { loginError = "UserNotFound" });
        //            }
        //        }


        //        return RedirectToAction("EmployeeInfo", "Employee");
        //    }

        //    public IActionResult EmployeeInfo(string Error)
        //    {
        //        if (Error == "HesCodeNotFound")
        //        {
        //            ViewBag.HesCodeError = "Girdiğiniz Hes Kodu hatalıdır veya aktif değildir.";
        //        }
        //        else if (Error == "HesCodeNotMatch")
        //        {
        //            ViewBag.HesCodeError = "Girdiğiniz Hes Kodu kimlik bilgileriniz ile uyuşmamaktadır.";
        //        }
        //        PersonEmployeeInfo personEmployeeInfo = new PersonEmployeeInfo();
        //        personEmployeeInfo = (JsonConvert.DeserializeObject<List<PersonEmployeeInfo>>(HttpContext.Session.GetString("personEmployeeInfo")))[0];
        //        WebClient x = new WebClient();
        //        byte[] s = x.DownloadData("https://erprapor.halic.edu.tr/ShowImages.aspx?RegisterId=" + personEmployeeInfo.registerId);
        //        bool NotFound;//
        //        if (s.Length > 529)
        //        {
        //            NotFound = true;
        //            ViewBag.Image = NotFound;

        //        }
        //        else
        //        {
        //            NotFound = false;
        //            ViewBag.Image = NotFound;
        //        }

        //        Person person = new Person();
        //        person = _context.Person.FirstOrDefault(i => i.tc == personEmployeeInfo.tcKimlikNo);
        //        if (person != null)
        //        {
        //            ViewBag.Tc = person.tc;
        //            ViewBag.Hes = person.hes;
        //            ViewBag.Status = person.status;
        //            if (person.durum == "RISKLESS")
        //            {
        //                ViewBag.Durum = "Riskli Değil";
        //            }
        //            else if (person.durum == "RISKY")
        //            {
        //                ViewBag.Durum = "Riskli";
        //            }
        //        }


        //        return View(personEmployeeInfo);

        //    }

        //    public async Task<IActionResult> Close()
        //    {
        //        foreach (var cookie in Request.Cookies.Keys)
        //        {
        //            Response.Cookies.Delete(cookie);
        //        }
        //        //HttpContext.Session.Clear();
        //        return RedirectToAction("Index", "Home");
        //    }


        //    public async Task<IActionResult> CheckEmployeeHesCode(string hes, string tc, string status)
        //    {
        //        hes = hes.ToUpper();
        //        hes = hes.Replace(" ", "");
        //        hes = hes.Replace("-", "");
        //        PersonEmployeeInfo personEmployeeInfo = new PersonEmployeeInfo();
        //        personEmployeeInfo = (JsonConvert.DeserializeObject<List<PersonEmployeeInfo>>(HttpContext.Session.GetString("personEmployeeInfo")))[0];
        //        WebClient x = new WebClient();
        //        byte[] s = x.DownloadData("https://erprapor.halic.edu.tr/ShowImages.aspx?RegisterId=" + personEmployeeInfo.registerId);
        //        bool NotFound;//
        //        if (s.Length > 529)
        //        {
        //            NotFound = true;
        //            ViewBag.Image = NotFound;

        //        }
        //        else
        //        {
        //            NotFound = false;
        //            ViewBag.Image = NotFound;
        //        }


        //        ApiAuth login = new ApiAuth
        //        {
        //            userName = "HALICUNI-G2G-HES",
        //            password = "nYfc3VVSue3uEugPBv"
        //        };
        //        HesQuery search = new HesQuery
        //        {
        //            hes_code = hes
        //        };
        //        var jsonSearch = JsonConvert.SerializeObject(search);
        //        var content = new StringContent(jsonSearch.ToString(), Encoding.UTF8, "application/json");
        //        HesResultPlus hesResult = new HesResultPlus();
        //        using (var client = new HttpClient())
        //        {
        //            client.BaseAddress = new Uri(Baseurl + "/check-hes-code-plus");
        //            client.DefaultRequestHeaders.Clear();
        //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //            client.DefaultRequestHeaders.Authorization =
        //new AuthenticationHeaderValue(
        //    "Basic", Convert.ToBase64String(
        //        System.Text.ASCIIEncoding.ASCII.GetBytes(
        //           $"{login.userName}:{login.password}")));
        //            HttpResponseMessage res = await client.PostAsync(HesUrl + "/check-hes-code-plus", content);
        //            if (res.IsSuccessStatusCode)
        //            {
        //                var searchResponse = res.Content.ReadAsStringAsync().Result;
        //                hesResult = (JsonConvert.DeserializeObject<HesResultPlus>(searchResponse));

        //                ViewBag.Tc = tc;
        //                ViewBag.Hes = hes;
        //                ViewBag.Status = status;
        //                ViewBag.Durum = hesResult.current_health_status;
        //                ViewBag.is_vaccinated = hesResult.is_vaccinated;
        //                ViewBag.is_immune = hesResult.is_immune;
        //                ViewBag.is_test_data_shared = hesResult.is_test_data_shared;
        //                ViewBag.last_negative_test_date = hesResult.last_negative_test_date;
        //                ViewBag.expiration_date = hesResult.expiration_date;
        //                ViewBag.current_health_status = hesResult.current_health_status;
        //                ViewBag.masked_identity_number = hesResult.masked_identity_number;
        //                ViewBag.masked_firstname = hesResult.masked_firstname;
        //                ViewBag.masked_lastname = hesResult.masked_lastname;

        //                if (personEmployeeInfo.tcKimlikNo.Substring(8, 3) != hesResult.masked_identity_number.Substring(8, 3))
        //                {
        //                    return RedirectToAction("EmployeeInfo", "Employee", new { Error = "HesCodeNotMatch" });
        //                }

        //                if (hesResult.is_vaccinated == null)
        //                {
        //                    ViewBag.ResultErrorVaccinated = "HES uygulamasından onay verilmedi!";
        //                    return View(personEmployeeInfo);
        //                }
        //                return View(personEmployeeInfo);
        //            }
        //            else
        //            {
        //                return RedirectToAction("EmployeeInfo", "Employee", new { Error = "HesCodeNotFound" });
        //            }
        //            return View(personEmployeeInfo);
        //        }
        //    }

        //    public async Task<IActionResult> HesCodeSave(Person person)
        //    {
        //        PersonEmployeeInfo personEmployeeInfo = new PersonEmployeeInfo();
        //        personEmployeeInfo = (JsonConvert.DeserializeObject<List<PersonEmployeeInfo>>(HttpContext.Session.GetString("personEmployeeInfo")))[0];
        //        WebClient x = new WebClient();
        //        byte[] s = x.DownloadData("https://erprapor.halic.edu.tr/ShowImages.aspx?RegisterId=" + personEmployeeInfo.registerId);
        //        bool NotFound;//
        //        if (s.Length > 529)
        //        {
        //            NotFound = true;
        //            ViewBag.Image = NotFound;

        //        }
        //        else
        //        {
        //            NotFound = false;
        //            ViewBag.Image = NotFound;
        //        }

        //        var Ssn = person.tc;
        //        var BlackList = false;
        //        if (person.current_health_status == "RISKY")
        //        {
        //            BlackList = true;
        //        }
        //        var Safe = false;
        //        try
        //        {
        //            var sonuc = _contextKonfides.Database.ExecuteSqlRaw($"exec sp_External_CardBlacklisting_ForHesCodeIntegration_v2 {Ssn}, {BlackList}, {Safe}");
        //            if (BlackList == true)
        //            {
        //                person.IsBlocked = true;
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            person.IsBlocked = false;
        //            person.Description = ex.Message;
        //            //var r = ex.Message;
        //        }

        //        _context.Add(person);
        //                    await _context.SaveChangesAsync();


        //        return View(personEmployeeInfo);
        //    }
        //var token = new Uyumsoft.Token();
        //token.UserName = "webservice";
        //token.Password = "1q2w3e4r5!_";
        //token.BranchCode = "0";
        //token.BranchId = 0;
        //token.CoId = 0;
        //token.BranchDesc = "0";
        //token.DeviceId = "0";

        //var value = new Uyumsoft.EmployeeIn();
        //value.TC_KimlikNo = "23677801824";
        //value.SorguTarihi = DateTime.Now;

        //var con = new Uyumsoft.ServiceRequestOfEmployeeIn();
        //con.Token = token;
        //con.Value = value;
        //con.PageIndex = 0;
        //con.PageSize = 0;
        //con.Attachment = "0";

        //var result = new Uyumsoft.SCHServiceSoapClient(Uyumsoft.SCHServiceSoapClient.EndpointConfiguration.SCHServiceSoap);
        //var data = result.GetEmployee(con).Value[0];
        //EmployeeInfo employeeInfo = new EmployeeInfo();
        //employeeInfo = JsonConvert.DeserializeObject<EmployeeInfo>(data);

        public IActionResult Index(string Error)
        {

            if (Error == "NotFound")
            {
                ViewBag.Error = "Giridiğin T.C. kimlik numarasına ait kişi bulunamadı.";
            }
            else if (Error == "Again")
            {
                ViewBag.Error = "Daha önce ankete katıldınız.";
            }
            return View();
        }
      
        public IActionResult EmployeeInfo(string tc)
        {
            IUyumsoftServiceManager mng = new UyumsoftServiceManager();

            var dataProliz = mng.GetEmployee(tc);

            if (dataProliz.Adı == null)
            {
                return RedirectToAction("Index", "Employee", new { Error = "NotFound" });
            }

            EmployeeInfo employee = new EmployeeInfo();

            //employee.Adı = dataProliz.Adı;
            //employee.Soyadı = dataProliz.Soyadı;
            employee.TcKimlikNo = dataProliz.TcKimlikNo;
            //employeeVaccinated.Staff = dataProliz.Gorev;
            //employeeVaccinated.Tip = dataProliz.IstihdamTuru;
            //employeeVaccinated.Phone = dataProliz.Phone;
            //employeeVaccinated.Email = dataProliz.EMail;
            //employeeVaccinated.Gender = dataProliz.Cinsiyet;
            //employeeVaccinated.Location = dataProliz.IsyeriAdi;
            //employeeVaccinated.Picture = "https://erprapor.halic.edu.tr/ShowImages.aspx?RegisterId=" + Convert.ToString(dataProliz.RegisterId);


            //WebClient x = new WebClient();
            //byte[] s = x.DownloadData(employeeVaccinated.Picture);
            //bool NotFound;//
            //if (s.Length > 529)
            //{
            //    NotFound = true;
            //    ViewBag.Image = NotFound;

            //}
            //else
            //{
            //    NotFound = false;
            //    ViewBag.Image = NotFound;
            //}
            return View(employee);
        }

        public async Task<IActionResult> VaccinatedCreate(string tc, List<string> VaccinatedName, List<DateTime> VaccinatedDate, string VaccinatedTypeRequest, string VaccinatedDateRequest, bool IsWantVaccine, bool Allergy, bool Comfirmation, bool ExpressConsent)
        {
            if (IsWantVaccine == null || ExpressConsent == null || Allergy == null || Comfirmation == null || ExpressConsent == null)
            {
                ViewBag.Error = "Anket kaydedilirken bir hata oluştu. Lütfen daha sonra tekrar deneyiniz.";
                return View();
            }
            else if (IsWantVaccine == true && (VaccinatedDateRequest == null || VaccinatedTypeRequest == null))
            {
                ViewBag.Error = "Anket kaydedilirken bir hata oluştu. Lütfen daha sonra tekrar deneyiniz.";
                return View();
            }
            EmployeeVaccineInfo employeeVaccineInfo = new EmployeeVaccineInfo();
            employeeVaccineInfo.Tc = tc;
            employeeVaccineInfo.IsWantVaccine = IsWantVaccine;
            employeeVaccineInfo.VaccineName = VaccinatedTypeRequest;
            employeeVaccineInfo.VaccineDate = VaccinatedDateRequest;
            employeeVaccineInfo.Allergy = Allergy;
            employeeVaccineInfo.Confirmation = Comfirmation;
            employeeVaccineInfo.ExpressConsent = ExpressConsent;

            List<VaccineInfo> vaccineInfoList = new List<VaccineInfo>();
            for (int i = 0; i < VaccinatedName.Count; i++)
            {
                VaccineInfo vaccineInfo = new VaccineInfo();
                vaccineInfo.VaccineName = VaccinatedName[i];
                vaccineInfo.VaccineDate = VaccinatedDate[i];
                vaccineInfoList.Add(vaccineInfo);
            }

            employeeVaccineInfo.VaccineInformation = JsonConvert.SerializeObject(vaccineInfoList);


            IUyumsoftServiceManager mng = new UyumsoftServiceManager();

            var data= mng.GetEmployee(tc);

            employeeVaccineInfo.Name = data.Adı;
            employeeVaccineInfo.Surname = data.Soyadı;
            employeeVaccineInfo.Staff = data.Gorev;
            employeeVaccineInfo.Email = data.EMail;
            employeeVaccineInfo.Tc = data.TcKimlikNo;
            employeeVaccineInfo.Phone = data.Phone;

            _context.EmployeeVaccineInfo.Add(employeeVaccineInfo);
            _context.SaveChanges();
            return View();
        }

        public async Task<IActionResult> Close()
        {
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Employee");
        }

    }
}
