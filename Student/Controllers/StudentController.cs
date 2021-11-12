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
    public class StudentController : Controller
    {
        private readonly LogContext _context;

        public StudentController(LogContext context)
        {
            _context = context;
        }

        private readonly ILogger<StudentController> _logger;
        string Baseurl = "https://selfservis.halic.edu.tr/webapi/";
        public async Task<IActionResult> Token(string loginError)
        {
            Log log = new Log();
            LogJson logJson = new LogJson();
            Login user = new Login
            {
                userName = "selfservis@halic.edu.tr",
                password = "1q2W3e4R5*_"
            };
            var jsonUser = JsonConvert.SerializeObject(user);
            var content = new StringContent(jsonUser.ToString(), Encoding.UTF8, "application/json");
            Token tokenKey = new Token();

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl + "api/Auth/login");
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.PostAsync(Baseurl + "api/Auth/login", content);
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
            }
            catch (Exception)
            {
                return Redirect("https://selfservis.halic.edu.tr");
                throw;
            }

           
            if (loginError == "UserNotFound")
            {
                ViewBag.loginError = "Girdiğiniz TC Numarasına Ait Kullanıcı Bulunamadı!";
            }
            else if (loginError == "MailNotFound")
            {
                ViewBag.loginError = "Sistemimizde tanımlı iletişim bilginiz bulunmamaktadır. Lütfen https://obs.halic.edu.tr/ adresinden giriş yaparak Eposta ve Telefon bilgilerinizi doldurunuz. Bilgileriniz dolu olmasına rağmen giriş yapamıyorsanız Öğrenci İşleri birimi ile iletişime geçebilirsiniz.";
            }
            else if (loginError == "NotActive")
            {
                ViewBag.loginError = "Öğrencilik durumunuz aktif değildir veya geçeci kayıt statüsündedir. Öğrenci İşleri ile iletişime geçebilirsiniz.";
            }
            HttpContext.Session.SetString("token", tokenKey.data.token);
            return View(tokenKey);
        }

        public async Task<IActionResult> StudentInfo(string tc)
        {
            var logId = HttpContext.Session.GetInt32("log");
            Log log = _context.Log.FirstOrDefault(i => i.Id == logId);
            LogJson logJson = JsonConvert.DeserializeObject<LogJson>(log.LogDetails);

            var token = HttpContext.Session.GetString("token");
            StudentNumber identityNuber = new StudentNumber
            {
                identityNumber = tc,
                studentNumber = ""
            };
            var jsonIdentityNumber = JsonConvert.SerializeObject(identityNuber);
            var content = new StringContent(jsonIdentityNumber.ToString(), Encoding.UTF8, "application/json");
            StudentInfo studentInfo = new StudentInfo();


            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri(Baseurl + "api/SelfServisOperation/getemployeeInfo");
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    HttpResponseMessage Res = await client.PostAsync(Baseurl + "api/SelfServisOperation/getstudentinfo", content);
                    if (Res.IsSuccessStatusCode)
                    {
                        var studentInfoResponse = Res.Content.ReadAsStringAsync().Result;
                        studentInfo = (JsonConvert.DeserializeObject<StudentInfo>(studentInfoResponse));
                        if (studentInfo.success == false)
                        {
                            logJson.Giris = false;
                            logJson.Tc = tc;
                            log.LogDetails = JsonConvert.SerializeObject(logJson);
                            _context.SaveChanges();
                            return RedirectToAction("Token", "Student", new { loginError = "UserNotFound" });
                        }
                        HttpContext.Session.SetString("studentInfo", studentInfoResponse);
                        logJson.Giris = true;
                        logJson.Tc = tc;
                        log.LogDetails = JsonConvert.SerializeObject(logJson);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Token", "Student");
                throw;
            }

            int i = 0;

            foreach (var item in studentInfo.data)
            {
                if (item.gsM1 == "" && item.ogrencI_STATU.IndexOf("Aktif") >= 0)// studentInfo.eMail == null ile değiştirilecek
                {
                    return RedirectToAction("Token", "Student", new { loginError = "MailNotFound" });
                }
                else if(item.ogrencI_STATU.IndexOf("Aktif") >= 0)
                {
                    i++;
                }
            }

            if (i > 0)
            {
                return RedirectToAction("StudentInformation", "Student");
            }
            else
            {
                return RedirectToAction("Token", "Student", new { loginError = "NotActive" });
            }
            

        }



        public IActionResult StudentInformation(string Error)
        {
            if (Error == "ADError")
            {
                ViewBag.Error = "ADError";
            }
            StudentInfo studentInfo = new StudentInfo();
            studentInfo = JsonConvert.DeserializeObject<StudentInfo>(HttpContext.Session.GetString("studentInfo"));

            return View(studentInfo);


        }

        public IActionResult InfoNotFound()
        {
            StudentInfo studentInfo = new StudentInfo();
            studentInfo = JsonConvert.DeserializeObject<StudentInfo>(HttpContext.Session.GetString("studentInfo"));
            return View(studentInfo);


        }


        public IActionResult PhoneVerification(string Phone)
        {
            var logId = HttpContext.Session.GetInt32("log");
            Log log = _context.Log.FirstOrDefault(i => i.Id == logId);
            LogJson logJson = JsonConvert.DeserializeObject<LogJson>(log.LogDetails);
            StudentInfo studentInfo = new StudentInfo();
            studentInfo = JsonConvert.DeserializeObject<StudentInfo>(HttpContext.Session.GetString("studentInfo"));
            string phoneSplit = "";
            foreach (var item in studentInfo.data)
            {
                if (item.ogrencI_STATU.IndexOf("Aktif") >= 0)
                {
                   phoneSplit = item.gsM1.Replace(" ", "");
                }
            }
            
            phoneSplit = phoneSplit.Substring(phoneSplit.Length - 4, 4);

            if (Phone == phoneSplit) //telefon numarasıyla değşecek
            {
                logJson.TelefonDogrulama = true;
                log.LogDetails = JsonConvert.SerializeObject(logJson);
                _context.SaveChanges();
                return RedirectToAction("PasswordReset", "Student");
            }

            else
            {
                logJson.TelefonDogrulama = false;
                log.LogDetails = JsonConvert.SerializeObject(logJson);
                _context.SaveChanges();
                return RedirectToAction("ADStudentInfo", "Student", new { loginError = "PhoneError" });

            }
            
            return View(studentInfo);
        }


        public async Task<IActionResult> ADStudentInfo(string loginError)
        {
            var logId = HttpContext.Session.GetInt32("log");
            Log log = _context.Log.FirstOrDefault(i => i.Id == logId);
            LogJson logJson = JsonConvert.DeserializeObject<LogJson>(log.LogDetails);
            StudentInfo studentInfo = new StudentInfo();
            studentInfo = JsonConvert.DeserializeObject<StudentInfo>(HttpContext.Session.GetString("studentInfo"));


            PasswordResetLog passwordResetLog = new PasswordResetLog();

            if (_context.PasswordResetLog.FirstOrDefault(i=>i.Tc == studentInfo.data[0].tC_KIMLIK_NO) != null)
            {
                passwordResetLog = _context.PasswordResetLog.FirstOrDefault(i => i.Tc == studentInfo.data[0].tC_KIMLIK_NO);
                
                if (DateTime.Now.AddMinutes(-60) < passwordResetLog.PasswordResetDate)
                {
                    ViewBag.PasswordResetDate = passwordResetLog.PasswordResetDate.ToString("dd/MM/yyyy HH:mm");
                    return View(studentInfo);
                }
            }
           
            var token = HttpContext.Session.GetString("token");
            SearchADPersonInfo searchADStudentInfo = new SearchADPersonInfo()
            {
                searchKey = studentInfo.data[0].tC_KIMLIK_NO,  //studentInfo.data[0].tC_KIMLIK_NO,
                searchTypes = "UserName",
                isEmployee = false
            };

            var jsonSearchADStudentInfo = JsonConvert.SerializeObject(searchADStudentInfo);
            var content = new StringContent(jsonSearchADStudentInfo.ToString(), Encoding.UTF8, "application/json");
            ADStudentInfo ADStudentInfo = new ADStudentInfo();
            
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl + "api/SelfServisOperation/getaduserinfo");
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    HttpResponseMessage Res = await client.PostAsync(Baseurl + "api/SelfServisOperation/getaduserinfo", content);
                    if (Res.IsSuccessStatusCode)
                    {
                        var ADStudentInfoResponse = Res.Content.ReadAsStringAsync().Result;
                        ADStudentInfo = JsonConvert.DeserializeObject<ADStudentInfo>(ADStudentInfoResponse);
                        //if (ADStudentInfo.success == false)
                        //{
                        //    return RedirectToAction("StudentInformation", "Student", new { Error = "ADError" });
                        //}
                        HttpContext.Session.SetString("ADStudentInfo", ADStudentInfoResponse);
                        logJson.MailDogrulama = true;
                        logJson.SifreDegistirme = true;
                        log.LogDetails = JsonConvert.SerializeObject(logJson);
                        _context.SaveChanges();
                    }
                    else
                    {
                        logJson.MailDogrulama = false;
                        logJson.SifreDegistirme = true;
                        log.LogDetails = JsonConvert.SerializeObject(logJson);
                        _context.SaveChanges();
                        return RedirectToAction("StudentInformation", "Student", new { Error = "ADError" });
                    }
                }


                if (ADStudentInfo.success == false)
                {
                    SearchADPersonInfo searchADStudentInfoEmployeID = new SearchADPersonInfo()
                    {
                        searchKey = studentInfo.data[0].tC_KIMLIK_NO,  //studentInfo.data[0].tC_KIMLIK_NO,
                        searchTypes = "EmployeeID",
                        isEmployee = false
                    };

                    var jsonSearchADStudentInfoEmployeID = JsonConvert.SerializeObject(searchADStudentInfoEmployeID);
                    var contentEmployeID = new StringContent(jsonSearchADStudentInfoEmployeID.ToString(), Encoding.UTF8, "application/json");
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(Baseurl + "api/SelfServisOperation/getaduserinfo");
                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                        HttpResponseMessage Res = await client.PostAsync(Baseurl + "api/SelfServisOperation/getaduserinfo", contentEmployeID);
                        if (Res.IsSuccessStatusCode)
                        {
                            var ADStudentInfoResponse = Res.Content.ReadAsStringAsync().Result;
                            ADStudentInfo = JsonConvert.DeserializeObject<ADStudentInfo>(ADStudentInfoResponse);
                            logJson.MailDogrulama = true;
                            logJson.SifreDegistirme = true;
                            log.LogDetails = JsonConvert.SerializeObject(logJson);
                            _context.SaveChanges();
                            if (ADStudentInfo.success == false)
                            {
                                logJson.MailDogrulama = false;
                                logJson.SifreDegistirme = true;
                                log.LogDetails = JsonConvert.SerializeObject(logJson);
                                _context.SaveChanges();
                                return RedirectToAction("StudentInformation", "Student", new { Error = "ADError" });
                            }
                            HttpContext.Session.SetString("ADStudentInfo", ADStudentInfoResponse);

                        }
                        else
                        {
                            return RedirectToAction("StudentInformation", "Student", new { Error = "ADError" });
                        }
                    }
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Token", "Student");
                throw;
            }

            if (loginError != null)
            {
                ViewBag.loginError = "Girdiğiniz bilgiler ile doğrulama sağlanamadı!";
            }

            log.LogDetails = JsonConvert.SerializeObject(logJson);
            _context.SaveChanges();
            return View(studentInfo);

            //if (ADStudentInfo.data[0].sn == studentInfo.soyadı)
            //{
            //    logJson.MailDogrulama = true;
            //    log.LogDetails = JsonConvert.SerializeObject(logJson);
            //    _context.SaveChanges();
            //    return View(studentInfo);
            //}
            //else
            //{
            //    logJson.MailDogrulama = false;
            //    log.LogDetails = JsonConvert.SerializeObject(logJson);
            //    _context.SaveChanges();
            //    return RedirectToAction("PersonVerification", "Person", new { loginError = "MailError" });
            //}
        }

        public async Task<IActionResult> PasswordReset()
        {
            var logId = HttpContext.Session.GetInt32("log");
            Log log = _context.Log.FirstOrDefault(i => i.Id == logId);
            LogJson logJson = JsonConvert.DeserializeObject<LogJson>(log.LogDetails);

            ADStudentInfo ADStudentInfo = new ADStudentInfo();
            ADStudentInfo = JsonConvert.DeserializeObject<ADStudentInfo>(HttpContext.Session.GetString("ADStudentInfo"));
            var token = HttpContext.Session.GetString("token");
            PasswordReset passwordReset = new PasswordReset
            {
                userName = ADStudentInfo.data[0].samAccountName, //username ile değiştirilecek
                isEmployee = false
            };
            var jsonIdentityNumber = JsonConvert.SerializeObject(passwordReset);
            var content = new StringContent(jsonIdentityNumber.ToString(), Encoding.UTF8, "application/json");
            PasswordResult passwordResult = new PasswordResult();
            StudentInfo studentInfo = new StudentInfo();
            studentInfo = JsonConvert.DeserializeObject<StudentInfo>(HttpContext.Session.GetString("studentInfo"));

            PasswordResetLog passwordResetLog = new PasswordResetLog();
            try
            {

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
            }
            catch (Exception)
            {
                return RedirectToAction("Token", "Student");
                throw;
            }

            if (passwordResult.success == true) 
            {
                logJson.SifreResetlemeSonucu = true;
                log.LogDetails = JsonConvert.SerializeObject(logJson);
                _context.SaveChanges();
                HttpContext.Session.SetString("newPassword", passwordResult.message);

                if (_context.PasswordResetLog.FirstOrDefault(i => i.Tc == studentInfo.data[0].tC_KIMLIK_NO) != null)
                {
                    passwordResetLog = _context.PasswordResetLog.FirstOrDefault(i => i.Tc == studentInfo.data[0].tC_KIMLIK_NO);
                    passwordResetLog.PasswordResetDate = DateTime.Now;
                    _context.PasswordResetLog.Update(passwordResetLog);
                    _context.SaveChanges();
                }
                else
                {
                    passwordResetLog.Tc = studentInfo.data[0].tC_KIMLIK_NO;
                    passwordResetLog.PasswordResetDate = DateTime.Now;
                    _context.PasswordResetLog.Add(passwordResetLog);
                    _context.SaveChanges();
                }
                return RedirectToAction("SendSms", "Student");

            }
            else
            {
                logJson.SifreResetlemeSonucu = false;
                log.LogDetails = JsonConvert.SerializeObject(logJson);
                _context.SaveChanges();
            }
            
            return View(studentInfo);

        }

        public async Task<IActionResult> SendSms()
        {
            var logId = HttpContext.Session.GetInt32("log");
            Log log = _context.Log.FirstOrDefault(i => i.Id == logId);
            LogJson logJson = JsonConvert.DeserializeObject<LogJson>(log.LogDetails);
            StudentInfo studentInfo = new StudentInfo();
            studentInfo = JsonConvert.DeserializeObject<StudentInfo>(HttpContext.Session.GetString("studentInfo"));
            var newPassword = HttpContext.Session.GetString("newPassword");
            ADStudentInfo ADStudentInfo = new ADStudentInfo();
            ADStudentInfo = JsonConvert.DeserializeObject<ADStudentInfo>(HttpContext.Session.GetString("ADStudentInfo"));
            var token = HttpContext.Session.GetString("token");
            var phone = "";

            foreach (var item in studentInfo.data)
            {
                if (item.ogrencI_STATU.IndexOf("Aktif") >= 0)
                {
                    if (item.gsM1.Substring(0, 1) == "0")
                    {
                        phone = item.gsM1.Replace(" ", "");
                    }
                    else
                    {
                        phone = "0" + item.gsM1.Replace(" ", "");
                    }
                }
               
            }

            
            SendSms sendSms = new SendSms
            {
                cellPhoneNumber = phone,  //ADStudentInfo.data[0].telephoneNumber ile değiştirilecek
                message = $"SelfServis ile sifreniz yeniden olusturulmustur. Mail hesabiniza 30 dk sonra girebilirsiniz. Yeni sifreniz {newPassword} seklindedir."

            };

            var jsonIdentityNumber = JsonConvert.SerializeObject(sendSms);
            var content = new StringContent(jsonIdentityNumber.ToString(), Encoding.UTF8, "application/json");
            SendSmsResult sendSmsResult = new SendSmsResult();

            try
            {
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
                        return View(studentInfo);

                    }
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Token", "Student");
                throw;
            }


           

            SendMail();
            return View(studentInfo);

        }

        public async Task<IActionResult> Close()
        {
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }
            //HttpContext.Session.Clear();
            return Redirect("https://selfservis.halic.edu.tr/");
        }

        private async void SendMail()
        {
            var logId = HttpContext.Session.GetInt32("log");
            Log log = _context.Log.FirstOrDefault(i => i.Id == logId);
            LogJson logJson = JsonConvert.DeserializeObject<LogJson>(log.LogDetails);
            StudentInfo studentInfo = new StudentInfo();
            studentInfo = JsonConvert.DeserializeObject<StudentInfo>(HttpContext.Session.GetString("studentInfo"));
            MailMessage ePosta = new MailMessage();
            ePosta.From = new MailAddress("selfservis@halic.edu.tr");
            ePosta.IsBodyHtml = true;
            ePosta.To.Add(studentInfo.data[0].epostA2); //student.Eposta
            ePosta.Subject = "Şifre Yenileme";
            ePosta.Body = "Sayın, " + studentInfo.data[0].ogR_ADI + " " + studentInfo.data[0].ogR_SOYAD + " </br > Haliç Üniversitesi SelfServis Platformu kullanılarak şifreniz değiştirilmiştir. Yeni şifreniz sistemde kayıtlı telefon numaranıza SMS ile gönderilmiştir. Şifre değişikliği sizin tarafınızdan yapılmadıysa Bilgi İşlem Daire Başkanlığı ile iletişime geçebilirsiniz. </br > İyi günler dileriz. </br > Haliç Üniversitesi Bilgi İşlem Daire Başkanlığı";
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

            }
            catch (SmtpException ex)
            {
                logJson.MailGonderme = false;
                log.LogDetails = JsonConvert.SerializeObject(logJson);
                _context.SaveChanges();
                kontrol = false;
                var hata = ex.Message;
                // System.Windows.Forms.MessageBox.Show(ex.Message, "Mail Gönderme Hatasi");
            }

        }


        public async void SendMailPassword()
        {
            var newPassword = HttpContext.Session.GetString("newPassword");
            var logId = HttpContext.Session.GetInt32("log");
            Log log = _context.Log.FirstOrDefault(i => i.Id == logId);
            LogJson logJson = JsonConvert.DeserializeObject<LogJson>(log.LogDetails);
            StudentInfo studentInfo = new StudentInfo();
            studentInfo = JsonConvert.DeserializeObject<StudentInfo>(HttpContext.Session.GetString("studentInfo"));
            MailMessage ePosta = new MailMessage();
            ePosta.From = new MailAddress("selfservis@halic.edu.tr");
            ePosta.IsBodyHtml = true;
            ePosta.To.Add(studentInfo.data[0].epostA2); //student.Eposta
            ePosta.Subject = "Şifre Yenileme";
            ePosta.Body = "Sayın, " + studentInfo.data[0].ogR_ADI + " " + studentInfo.data[0].ogR_SOYAD + " </br > Haliç Üniversitesi SelfServis Platformu kullanılarak şifreniz değiştirilmiştir. Yeni şifreniz " + newPassword + " şeklindedir. Şifre değişikliği sizin tarafınızdan yapılmadıysa Bilgi İşlem Daire Başkanlığı ile iletişime geçebilirsiniz. </br > İyi günler dileriz. </br > Haliç Üniversitesi Bilgi İşlem Daire Başkanlığı";
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

            }
            catch (SmtpException ex)
            {
                logJson.MailGonderme = false;
                log.LogDetails = JsonConvert.SerializeObject(logJson);
                _context.SaveChanges();
                kontrol = false;
                var hata = ex.Message;
                // System.Windows.Forms.MessageBox.Show(ex.Message, "Mail Gönderme Hatasi");
            }

        }



        //public async Task<IActionResult> SendSmsNewStudent()
        //{
        //    int i = 0;
        //    foreach (var item in _context.NewStudent)
        //    {
        //        var token = HttpContext.Session.GetString("token");
        //        var phone = "";
        //        if (item.Phone.Substring(0, 1) == "0")
        //        {
        //            phone = item.Phone.Replace(" ", "");
        //        }
        //        else
        //        {
        //            phone = "0" + item.Phone.Replace(" ", "");
        //        }
        //        SendSms sendSms = new SendSms
        //        {
        //            cellPhoneNumber = phone,  //ADStudentInfo.data[0].telephoneNumber ile değiştirilecek bu yıl 
        //            message = $"Sevgili Ogrencilerimiz;\n\nMail sifrenizi olusturmadıysanız Selfservis Platformu uzerinden yeni sifrenizi olusturup kullanmaya baslayabilirsiniz.\n\nSelfservis Platformu\nhttps://bit.ly/3EYKNrI"

        //        };

        //        var jsonIdentityNumber = JsonConvert.SerializeObject(sendSms);
        //        var content = new StringContent(jsonIdentityNumber.ToString(), Encoding.UTF8, "application/json");
        //        SendSmsResult sendSmsResult = new SendSmsResult();

        //        try
        //        {
        //            using (var client = new HttpClient())
        //            {
        //                client.BaseAddress = new Uri(Baseurl + "api/SelfServisOperation/sendSms");
        //                client.DefaultRequestHeaders.Clear();
        //                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        //                HttpResponseMessage Res = await client.PostAsync(Baseurl + "api/SelfServisOperation/sendSms", content);
        //                if (Res.IsSuccessStatusCode)
        //                {

        //                    item.Result = true;
        //                    _context.NewStudent.Update(item);
        //                    var SendSmsResultResponse = Res.Content.ReadAsStringAsync().Result;
        //                    sendSmsResult = JsonConvert.DeserializeObject<SendSmsResult>(SendSmsResultResponse);

        //                }
        //                else
        //                {
        //                    item.Result = false;
        //                    _context.NewStudent.Update(item);
                            

        //                }
        //            }
        //            i++;
        //        }
        //        catch (Exception)
        //        {
        //            throw;
        //        }
        //    }


        //    _context.SaveChanges();
        //    return View();

        //}

    }

}

