using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SelfServisUI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;


namespace SelfServisUI.Controllers
{
    public class PersonController : Controller
    {
        private readonly LogContext _context;

        public PersonController(LogContext context)
        {
            _context = context;
        }

        private readonly ILogger<PersonController> _logger;
        string Baseurl = "https://selfservis.halic.edu.tr/webapi/";
        public async Task<IActionResult> Token(string loginError)
        {
            Log log = new Log();
            LogJson logJson = new LogJson();
            Login user = new Login {
             userName = "selfservis@halic.edu.tr", 
             password = "1q2W3e4R5*_"
            };
            var jsonUser = JsonConvert.SerializeObject(user);
          var content =  new StringContent(jsonUser.ToString(), Encoding.UTF8, "application/json");
            Token tokenKey = new Token();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl + "api/Auth/login");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.PostAsync(Baseurl + "api/Auth/login" , content );
                if (Res.IsSuccessStatusCode)
                {
                    var TokenResponse = Res.Content.ReadAsStringAsync().Result;
                    tokenKey = JsonConvert.DeserializeObject<Token>(TokenResponse);
                    logJson.Token = true;
                    logJson.Tarih = DateTime.Now;
                    log.LogDetails = JsonConvert.SerializeObject(logJson);
                    _context.Add(log);
                    await _context.SaveChangesAsync();
                    HttpContext.Session.SetInt32("log", log.Id);
                }
                
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenKey.data.token);
            }
            if (loginError == "UserNotFound")
            {
                ViewBag.loginError = "Girdiğiniz TC Numarasına Ait Kullanıcı Bulunamadı!";
            }
            else if (loginError == "MailNotFound")
            {
                ViewBag.loginError = "Sistemimizde tanımlı iletişim bilginiz bulunmamaktadır. Lütfen İnsan Kaynakları Birimi ile iletişime geçiniz.";
            }
            HttpContext.Session.SetString("token", tokenKey.data.token);
            return View(tokenKey);
        }



        public async Task<IActionResult> PersonEmployeeInfo(string tc)
        {
            var logId = HttpContext.Session.GetInt32("log");
            Log log = _context.Log.FirstOrDefault(i => i.Id == logId);
            LogJson logJson = JsonConvert.DeserializeObject<LogJson>(log.LogDetails);

            var token = HttpContext.Session.GetString("token");
            SearchIdentityNumber identityNuber = new SearchIdentityNumber
            {
                identityNumber = tc
            };
            var jsonIdentityNumber = JsonConvert.SerializeObject(identityNuber);
            var content = new StringContent(jsonIdentityNumber.ToString(), Encoding.UTF8, "application/json");
            PersonEmployeeInfo personEmployeeInfo = new PersonEmployeeInfo();
            using (var client = new HttpClient())
            {
                
                client.BaseAddress = new Uri(Baseurl + "api/SelfServisOperation/getemployeeInfo");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage Res = await client.PostAsync(Baseurl + "api/SelfServisOperation/getemployeeInfo", content);
                if (Res.IsSuccessStatusCode)
                {
                    var PersonEmployeeInfoResponse = Res.Content.ReadAsStringAsync().Result;
                   personEmployeeInfo = (JsonConvert.DeserializeObject<List<PersonEmployeeInfo>>(PersonEmployeeInfoResponse))[0];
                    HttpContext.Session.SetString("personEmployeeInfo", PersonEmployeeInfoResponse);
                    logJson.Giris = true;
                    logJson.Tc = tc;
                    log.LogDetails = JsonConvert.SerializeObject(logJson);
                    _context.SaveChanges();
                }
                else 
                {
                    logJson.Giris = false;
                    logJson.Tc = tc;
                    log.LogDetails = JsonConvert.SerializeObject(logJson);
                    _context.SaveChanges();
                    return RedirectToAction("Token", "Person" , new { loginError = "UserNotFound" });
                }
            }

            if (string.IsNullOrEmpty(personEmployeeInfo.eMail) || personEmployeeInfo.mobileTel == null) // personEmployeeInfo.eMail == null ile değiştirilecek
            {
                return RedirectToAction("Token", "Person", new { loginError = "MailNotFound" });
            }

            return RedirectToAction("EmployeeInfo", "Person");


        }

        public IActionResult EmployeeInfo()
        {
            PersonEmployeeInfo personEmployeeInfo = new PersonEmployeeInfo();
            personEmployeeInfo = (JsonConvert.DeserializeObject<List<PersonEmployeeInfo>>(HttpContext.Session.GetString("personEmployeeInfo")))[0];
            WebClient x = new WebClient();
            byte[] s = x.DownloadData("https://erprapor.halic.edu.tr/ShowImages.aspx?RegisterId=" + personEmployeeInfo.registerId);
            bool NotFound;//
            if (s.Length > 529)
            {
                NotFound = true;
                ViewBag.Image = NotFound;

            }
            else
            {
                NotFound = false;
                ViewBag.Image = NotFound;
            }
            var data = ADInfo(personEmployeeInfo.tcKimlikNo);
           // ViewBag.LastUpdate = data.Result;
            return View(personEmployeeInfo);

            
        }

        public IActionResult InfoNotFound()
        {
            PersonEmployeeInfo personEmployeeInfo = new PersonEmployeeInfo();
            personEmployeeInfo = (JsonConvert.DeserializeObject<List<PersonEmployeeInfo>>(HttpContext.Session.GetString("personEmployeeInfo")))[0];
            WebClient x = new WebClient();
            byte[] s = x.DownloadData("https://erprapor.halic.edu.tr/ShowImages.aspx?RegisterId=" + personEmployeeInfo.registerId);
            bool NotFound;
            if (s.Length > 529)
            {
                NotFound = true;
                ViewBag.Image = NotFound;

            }
            else
            {
                NotFound = false;
                ViewBag.Image = NotFound;
            }
            return View(personEmployeeInfo);


        }

        public IActionResult PhoneVerification(string Phone)
        {
            var logId = HttpContext.Session.GetInt32("log");
            Log log = _context.Log.FirstOrDefault(i => i.Id == logId);
            LogJson logJson = JsonConvert.DeserializeObject<LogJson>(log.LogDetails);
            PersonEmployeeInfo personEmployeeInfo = new PersonEmployeeInfo();
            personEmployeeInfo = (JsonConvert.DeserializeObject<List<PersonEmployeeInfo>>(HttpContext.Session.GetString("personEmployeeInfo")))[0];
            var phoneSplit = personEmployeeInfo.mobileTel.Replace(" ", "");
            phoneSplit = phoneSplit.Substring(phoneSplit.Length - 4, 4);

            if (Phone == phoneSplit) //telefon numarasıyla değşecek
            {
                logJson.TelefonDogrulama = true;
                log.LogDetails = JsonConvert.SerializeObject(logJson);
                _context.SaveChanges();
                return RedirectToAction("PasswordReset", "Person");
            }

            else
            {
                logJson.TelefonDogrulama = false;
                log.LogDetails = JsonConvert.SerializeObject(logJson);
                _context.SaveChanges();
                return RedirectToAction("ADPersonInfo", "Person", new { loginError = "PhoneError" });

            }
            WebClient x = new WebClient();
            byte[] s = x.DownloadData("https://erprapor.halic.edu.tr/ShowImages.aspx?RegisterId=" + personEmployeeInfo.registerId);
            bool NotFound;
            if (s.Length > 529)
            {
                NotFound = true;
                ViewBag.Image = NotFound;

            }
            else
            {
                NotFound = false;
                ViewBag.Image = NotFound;
            }
            return View(personEmployeeInfo);
        }

        public IActionResult PersonVerification(string loginError)
        {
            var logId = HttpContext.Session.GetInt32("log");
            Log log = _context.Log.FirstOrDefault(i => i.Id == logId);
            LogJson logJson = JsonConvert.DeserializeObject<LogJson>(log.LogDetails);
            if (loginError != null)
            {
                ViewBag.loginError = "Girdiğiniz bilgiler ile doğrulama sağlanamadı!";
            }
            PersonEmployeeInfo personEmployeeInfo = new PersonEmployeeInfo();
            personEmployeeInfo = (JsonConvert.DeserializeObject<List<PersonEmployeeInfo>>(HttpContext.Session.GetString("personEmployeeInfo")))[0];
            WebClient x = new WebClient();
            byte[] s = x.DownloadData("https://erprapor.halic.edu.tr/ShowImages.aspx?RegisterId=" + personEmployeeInfo.registerId);
            bool NotFound;
            if (s.Length > 529)
            {
                NotFound = true;
                ViewBag.Image = NotFound;

            }
            else
            {
                NotFound = false;
                ViewBag.Image = NotFound;
            }
            if (string.IsNullOrEmpty(personEmployeeInfo.eMail) && personEmployeeInfo.mobileTel == null) // model.employeeId ile değişecek
            {
                logJson.SifreDegistirme = false;
                log.LogDetails = JsonConvert.SerializeObject(logJson);
                _context.SaveChanges();
                return RedirectToAction("InfoNotFound", "Person");
            }
            else
            {
                logJson.SifreDegistirme = true;
                log.LogDetails = JsonConvert.SerializeObject(logJson);
                _context.SaveChanges();
                return View(personEmployeeInfo);
            }
            
        }

        public async Task<IActionResult> ADPersonInfo(string Email, string loginError)
        {
            var logId = HttpContext.Session.GetInt32("log");
            Log log = _context.Log.FirstOrDefault(i => i.Id == logId);
            LogJson logJson = JsonConvert.DeserializeObject<LogJson>(log.LogDetails);
            PersonEmployeeInfo personEmployeeInfo = new PersonEmployeeInfo();
            personEmployeeInfo = (JsonConvert.DeserializeObject<List<PersonEmployeeInfo>>(HttpContext.Session.GetString("personEmployeeInfo")))[0];
            WebClient x = new WebClient();
            byte[] s = x.DownloadData("https://erprapor.halic.edu.tr/ShowImages.aspx?RegisterId=" + personEmployeeInfo.registerId);
            bool NotFound;
            if (s.Length > 529)
            {
                NotFound = true;
                ViewBag.Image = NotFound;

            }
            else
            {
                NotFound = false;
                ViewBag.Image = NotFound;
            }
            var token = HttpContext.Session.GetString("token");
            SearchADPersonInfo searchADPersonInfo = new SearchADPersonInfo();
           
            if (Email != null)
            {
                searchADPersonInfo.searchKey = Email;
                searchADPersonInfo.searchTypes = "Email";
                searchADPersonInfo.isEmployee = true;
            }
            var jsonSearchADPersonInfo = JsonConvert.SerializeObject(searchADPersonInfo);
            var content = new StringContent(jsonSearchADPersonInfo.ToString(), Encoding.UTF8, "application/json");
            ADPersonInfo ADPersonInfo = new ADPersonInfo();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl + "api/SelfServisOperation/getaduserinfo");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage Res = await client.PostAsync(Baseurl + "api/SelfServisOperation/getaduserinfo", content);
                if (Res.IsSuccessStatusCode)
                {
                    var ADPersonInfoResponse = Res.Content.ReadAsStringAsync().Result;
                    ADPersonInfo = JsonConvert.DeserializeObject<ADPersonInfo>(ADPersonInfoResponse);
                    HttpContext.Session.SetString("ADPersonInfo", ADPersonInfoResponse);
                    
                }
                if (loginError != null)
                {
                    logJson.MailDogrulama = true;
                    log.LogDetails = JsonConvert.SerializeObject(logJson);
                    _context.SaveChanges();
                    ViewBag.loginError = "Girdiğiniz bilgiler ile doğrulama sağlanamadı!";
                    return View(personEmployeeInfo);
                }
                if (ADPersonInfo.success == false )
                {
                    logJson.MailDogrulama = false;
                    log.LogDetails = JsonConvert.SerializeObject(logJson);
                    _context.SaveChanges();
                    return RedirectToAction("PersonVerification", "Person", new { loginError = "MailError" });
                }
            }

            logJson.MailDogrulama = true;
            log.LogDetails = JsonConvert.SerializeObject(logJson);
            _context.SaveChanges();
            return View(personEmployeeInfo);

            //if (ADPersonInfo.data[0].sn == personEmployeeInfo.soyadı)
            //{
            //    logJson.MailDogrulama = true;
            //    log.LogDetails = JsonConvert.SerializeObject(logJson);
            //    _context.SaveChanges();
            //    return View(personEmployeeInfo);
            //}
            //else
            //{
            //    logJson.MailDogrulama = false;
            //    log.LogDetails = JsonConvert.SerializeObject(logJson);
            //    _context.SaveChanges();
            //    return RedirectToAction("PersonVerification", "Person", new { loginError = "MailError" });
            //}
        }

        public async Task<IActionResult> ADPersonSimpleInfo(string tc)
        {
            var token = HttpContext.Session.GetString("token");
            SearchADPersonInfo searchADPersonInfo = new SearchADPersonInfo
            {
                searchKey = tc,
                searchTypes = "IdentityNumber "

            };
            var jsonSearchADPersonInfo = JsonConvert.SerializeObject(searchADPersonInfo);
            var content = new StringContent(jsonSearchADPersonInfo.ToString(), Encoding.UTF8, "application/json");
            ADPersonInfoSimple ADPersonInfoSimple = new ADPersonInfoSimple();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl + "api/SelfServisOperation/getadusersimpleinfo");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage Res = await client.PostAsync(Baseurl + "api/SelfServisOperation/getadusersimpleinfo", content);
                if (Res.IsSuccessStatusCode)
                {
                    var ADPersonInfoSimpleResponse = Res.Content.ReadAsStringAsync().Result;
                    ADPersonInfoSimple = JsonConvert.DeserializeObject<ADPersonInfoSimple>(ADPersonInfoSimpleResponse);
                    

                }
            }
            return View(ADPersonInfoSimple);

        }


        public async Task<IActionResult> PasswordReset()
        {
            var logId = HttpContext.Session.GetInt32("log");
            Log log = _context.Log.FirstOrDefault(i => i.Id == logId);
            LogJson logJson = JsonConvert.DeserializeObject<LogJson>(log.LogDetails);

            ADPersonInfo ADPersonInfo = new ADPersonInfo();
            ADPersonInfo = JsonConvert.DeserializeObject<ADPersonInfo>(HttpContext.Session.GetString("ADPersonInfo"));
            var token = HttpContext.Session.GetString("token");
            PasswordReset passwordReset = new PasswordReset
            {
                userName = ADPersonInfo.data[0].samAccountName, //username ile değiştirilecek
                isEmployee = true
            };
            var jsonIdentityNumber = JsonConvert.SerializeObject(passwordReset);
            var content = new StringContent(jsonIdentityNumber.ToString(), Encoding.UTF8, "application/json");
            PasswordResult passwordResult = new PasswordResult();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl + "api/SelfServisOperation/setaduserpasswordreset");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage Res = await client.PostAsync(Baseurl + "api/SelfServisOperation/setaduserpasswordreset", content);
                if (Res.IsSuccessStatusCode)
                {
                    var PasswordResultResponse = Res.Content.ReadAsStringAsync().Result;
                    passwordResult = JsonConvert.DeserializeObject<PasswordResult>(PasswordResultResponse);

                }
            }
            if (passwordResult.success == true) //reset çalışmadığı içib false yazdım. True olarak değiştirilecek
            {
                logJson.SifreResetlemeSonucu = true;
                log.LogDetails = JsonConvert.SerializeObject(logJson);
                _context.SaveChanges();
                HttpContext.Session.SetString("newPassword", passwordResult.message);
                return RedirectToAction("SendSms", "Person");
                
            }
            else
            {
                logJson.SifreResetlemeSonucu = false;
                log.LogDetails = JsonConvert.SerializeObject(logJson);
                _context.SaveChanges();
            }
            PersonEmployeeInfo personEmployeeInfo = new PersonEmployeeInfo();
            personEmployeeInfo = (JsonConvert.DeserializeObject<List<PersonEmployeeInfo>>(HttpContext.Session.GetString("personEmployeeInfo")))[0];
            WebClient x = new WebClient();
            byte[] s = x.DownloadData("https://erprapor.halic.edu.tr/ShowImages.aspx?RegisterId=" + personEmployeeInfo.registerId);
            bool NotFound;
            if (s.Length > 529)
            {
                NotFound = true;
                ViewBag.Image = NotFound;

            }
            else
            {
                NotFound = false;
                ViewBag.Image = NotFound;
            }
            return View(personEmployeeInfo);
           

        }

        public async Task<IActionResult> SendSms()
        {
            var logId = HttpContext.Session.GetInt32("log");
            Log log = _context.Log.FirstOrDefault(i => i.Id == logId);
            LogJson logJson = JsonConvert.DeserializeObject<LogJson>(log.LogDetails);
            PersonEmployeeInfo personEmployeeInfo = new PersonEmployeeInfo();
            personEmployeeInfo = (JsonConvert.DeserializeObject<List<PersonEmployeeInfo>>(HttpContext.Session.GetString("personEmployeeInfo")))[0];
            var newPassword = HttpContext.Session.GetString("newPassword");
            ADPersonInfo ADPersonInfo = new ADPersonInfo();
            ADPersonInfo = JsonConvert.DeserializeObject<ADPersonInfo>(HttpContext.Session.GetString("ADPersonInfo"));
            var token = HttpContext.Session.GetString("token");
            var phone = "";
            if (personEmployeeInfo.mobileTel.Substring(0,1)=="0")
            {
                phone = personEmployeeInfo.mobileTel.Replace(" ", "");
            }
            else
            {
                phone = "0" + personEmployeeInfo.mobileTel.Replace(" ", "");
            }
            SendSms sendSms = new SendSms
            {
                cellPhoneNumber = phone,  //ADPersonInfo.data[0].telephoneNumber ile değiştirilecek
                message = $"SelfServis ile şifreniz yeniden oluşturulmuştur. Yeni şifreniz: {newPassword} şeklindedir."

            };

            WebClient x = new WebClient();
            byte[] s = x.DownloadData("https://erprapor.halic.edu.tr/ShowImages.aspx?RegisterId=" + personEmployeeInfo.registerId);
            bool NotFound;
            if (s.Length > 529)
            {
                NotFound = true;
                ViewBag.Image = NotFound;

            }
            else
            {
                NotFound = false;
                ViewBag.Image = NotFound;
            }


            var jsonIdentityNumber = JsonConvert.SerializeObject(sendSms);
            var content = new StringContent(jsonIdentityNumber.ToString(), Encoding.UTF8, "application/json");
            SendSmsResult sendSmsResult = new SendSmsResult();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl + "api/SelfServisOperation/sendSms");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage Res = await client.PostAsync(Baseurl + "api/SelfServisOperation/sendSms", content);
                if (Res.IsSuccessStatusCode)
                {
                    var SendSmsResultResponse = Res.Content.ReadAsStringAsync().Result;
                    sendSmsResult = JsonConvert.DeserializeObject<SendSmsResult>(SendSmsResultResponse);
                    logJson.SmsGonderme = true;
                    logJson.SmsKodu = sendSmsResult.data.data;
                    log.LogDetails = JsonConvert.SerializeObject(logJson);
                    _context.SaveChanges();
                    

                }
                else
                {
                    logJson.SmsGonderme = false;
                    log.LogDetails = JsonConvert.SerializeObject(logJson);
                    SendMailPassword();
                    ViewBag.SmsError = "SmsError";
                    _context.SaveChanges();
                    return View(personEmployeeInfo);

                }
            }
           
            SendMail();
            return View(personEmployeeInfo);

        }

        public async Task<IActionResult> Close()
        {
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }
            //HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        private bool SendMail()
        {
            var logId = HttpContext.Session.GetInt32("log");
            Log log = _context.Log.FirstOrDefault(i => i.Id == logId);
            LogJson logJson = JsonConvert.DeserializeObject<LogJson>(log.LogDetails);
            PersonEmployeeInfo personEmployeeInfo = new PersonEmployeeInfo();
            personEmployeeInfo = (JsonConvert.DeserializeObject<List<PersonEmployeeInfo>>(HttpContext.Session.GetString("personEmployeeInfo")))[0];
            MailMessage ePosta = new MailMessage();
            ePosta.From = new MailAddress("selfservis@halic.edu.tr");
            ePosta.IsBodyHtml = true;
            ePosta.To.Add(personEmployeeInfo.eMail); //student.Eposta
            ePosta.Subject = "Şifre Yenileme";
            ePosta.Body = "Sayın, " + personEmployeeInfo.adı + " " + personEmployeeInfo.soyadı + " </br > Haliç Üniversitesi SelfServis Platformu kullanılarak şifreniz değiştirilmiştir. Yeni şifreniz sistemde kayıtlı telefon numaranıza SMS ile gönderilmiştir. Şifre değişikliği sizin tarafınızdan yapılmadıysa Bilgi İşlem Daire Başkanlığı ile iletişime geçebilirsiniz. </br > İyi günler dileriz. </br > Haliç Üniversitesi Bilgi İşlem Daire Başkanlığı";
            SmtpClient smtp = new SmtpClient();


            smtp.Credentials = new System.Net.NetworkCredential("selfservis@halic.edu.tr", "Halic1719");
            smtp.Port = 587;
            smtp.Host = "smtp.outlook.com";
            smtp.EnableSsl = true;
            object userState = ePosta;
            bool kontrol = true;
            bool result;
            try
            {
                logJson.MailGonderme = true;
                log.LogDetails = JsonConvert.SerializeObject(logJson);
                _context.SaveChanges();
                // smtp.SendAsync(ePosta, (object)ePosta);
                smtp.Send(ePosta);
                //smtp.Dispose();
                ePosta.Attachments.Dispose();
                return true;

            }
            catch (SmtpException ex)
            {
                logJson.MailGonderme = false;
                log.LogDetails = JsonConvert.SerializeObject(logJson);
                _context.SaveChanges();
                kontrol = false;
                var hata = ex.Message;
                return false;
                // System.Windows.Forms.MessageBox.Show(ex.Message, "Mail Gönderme Hatasi");
            }
            
        }


        private bool SendMailPassword()
        {
            var newPassword = HttpContext.Session.GetString("newPassword");
            var logId = HttpContext.Session.GetInt32("log");
            Log log = _context.Log.FirstOrDefault(i => i.Id == logId);
            LogJson logJson = JsonConvert.DeserializeObject<LogJson>(log.LogDetails);
            PersonEmployeeInfo personEmployeeInfo = new PersonEmployeeInfo();
            personEmployeeInfo = (JsonConvert.DeserializeObject<List<PersonEmployeeInfo>>(HttpContext.Session.GetString("personEmployeeInfo")))[0];
            MailMessage ePosta = new MailMessage();
            ePosta.From = new MailAddress("selfservis@halic.edu.tr");
            ePosta.IsBodyHtml = true;
            ePosta.To.Add(personEmployeeInfo.eMail); //student.Eposta
            ePosta.Subject = "Şifre Yenileme";
            ePosta.Body = "Sayın, " + personEmployeeInfo.adı + " " + personEmployeeInfo.soyadı + " </br > Haliç Üniversitesi SelfServis Platformu kullanılarak şifreniz değiştirilmiştir. Yeni şifreniz " + newPassword + " şeklindedir. Şifre değişikliği sizin tarafınızdan yapılmadıysa Bilgi İşlem Daire Başkanlığı ile iletişime geçebilirsiniz. </br > İyi günler dileriz. </br > Haliç Üniversitesi Bilgi İşlem Daire Başkanlığı";
            SmtpClient smtp = new SmtpClient();


            smtp.Credentials = new System.Net.NetworkCredential("selfservis@halic.edu.tr", "Halic1719");
            smtp.Port = 587;
            smtp.Host = "smtp.outlook.com";
            smtp.EnableSsl = true;
            object userState = ePosta;
            bool kontrol = true;
            bool result;
            try
            {
                logJson.MailGonderme = true;
                log.LogDetails = JsonConvert.SerializeObject(logJson);
                _context.SaveChanges();
                // smtp.SendAsync(ePosta, (object)ePosta);
                smtp.Send(ePosta);
                //smtp.Dispose();
                ePosta.Attachments.Dispose();
                return true;

            }
            catch (SmtpException ex)
            {
                logJson.MailGonderme = false;
                log.LogDetails = JsonConvert.SerializeObject(logJson);
                _context.SaveChanges();
                kontrol = false;
                var hata = ex.Message;
                return false;
                // System.Windows.Forms.MessageBox.Show(ex.Message, "Mail Gönderme Hatasi");
            }

        }

        private async Task<List<string>> ADInfo(string tcKimlikNo)
        {
            var token = HttpContext.Session.GetString("token");
            SearchADPersonInfo searchADPersonInfo = new SearchADPersonInfo();

            if (tcKimlikNo != null)
            {
                searchADPersonInfo.searchKey = tcKimlikNo;
                searchADPersonInfo.searchTypes = "IdentityNumber";
                searchADPersonInfo.isEmployee = true;
            }
            var jsonSearchADPersonInfo = JsonConvert.SerializeObject(searchADPersonInfo);
            var content = new StringContent(jsonSearchADPersonInfo.ToString(), Encoding.UTF8, "application/json");
            ADPersonInfo ADPersonInfo = new ADPersonInfo();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl + "api/SelfServisOperation/getaduserinfo");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage Res = await client.PostAsync(Baseurl + "api/SelfServisOperation/getaduserinfo", content);
                if (Res.IsSuccessStatusCode)
                {
                    var ADPersonInfoResponse = Res.Content.ReadAsStringAsync().Result;
                    ADPersonInfo = JsonConvert.DeserializeObject<ADPersonInfo>(ADPersonInfoResponse);

                }
            }
            List<string> data = new List<string>();
            data.Add(ADPersonInfo.data[0].userPasswordStatus);
            data.Add(ADPersonInfo.data[0].pwdLastSet.ToString("MM//dd(yyyy"));
            return data;

        }

    }

    }

