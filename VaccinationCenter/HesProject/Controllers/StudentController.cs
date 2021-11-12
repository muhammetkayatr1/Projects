using HesOperation.ProlizOperation;
using VaccinationCenter.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Proliz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace VaccinationCenter.Controllers
{
    [AllowAnonymous]
    public class StudentController : Controller
    {
        string HesUrl = "https://hesservis.turkiye.gov.tr/services/g2g/saglik/hes";
        string Baseurl = "https://selfservis.halic.edu.tr/webapi/";

        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Test()
        {
            return View();
        }

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
        public IActionResult StudentInfo(string tc)
        {
            if (_context.StudentVaccineInfo.FirstOrDefault(i => i.Tc == tc) != null)
            {
                return RedirectToAction("Index", "Student", new { Error = "Again" });
            }
            IProlizServiceManager mng = new ProlizServiceManager();

            
            var data = mng.GetStudentInfoOnProliz(tc, "");
            if (data.Count == 0)
            {
                return RedirectToAction("Index", "Student", new { Error = "NotFound" });
            }
            List<Student> studentInfo = new List<Student>();
            foreach (var item in data)
            {
                Student student = new Student();
                student.OGR_ADI = item.OGR_ADI;
                student.OGR_SOYAD = item.OGR_SOYAD;
                student.BOLUM_AD = item.BOLUM_AD;
                student.EPOSTA1 = item.EPOSTA1;
                student.FAKULTE_AD = item.FAKULTE_AD;
                student.OGR_NO = item.OGR_NO;
                student.TC_KIMLIK_NO = item.TC_KIMLIK_NO;
                student.PICTURE = item.PICTURE;
                studentInfo.Add(student);
            }
            

            return View(studentInfo);
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
            StudentVaccineInfo studentVaccineInfo = new StudentVaccineInfo();
            studentVaccineInfo.Tc = tc;
            studentVaccineInfo.IsWantVaccine = IsWantVaccine;
            studentVaccineInfo.VaccineName = VaccinatedTypeRequest;
            studentVaccineInfo.VaccineDate = VaccinatedDateRequest;
            studentVaccineInfo.Allergy = Allergy;
            studentVaccineInfo.Confirmation = Comfirmation;
            studentVaccineInfo.ExpressConsent = ExpressConsent;

            List<VaccineInfo> vaccineInfoList = new List<VaccineInfo>();
            for (int i = 0; i < VaccinatedName.Count; i++)
            {
                VaccineInfo vaccineInfo = new VaccineInfo();
                vaccineInfo.VaccineName = VaccinatedName[i];
                vaccineInfo.VaccineDate = VaccinatedDate[i];
                vaccineInfoList.Add(vaccineInfo);
            }

            studentVaccineInfo.VaccineInformation = JsonConvert.SerializeObject(vaccineInfoList);


            IProlizServiceManager mng = new ProlizServiceManager();


            var data = mng.GetStudentInfoOnProliz(tc, "");
            foreach (var item in data)
            {
                studentVaccineInfo.Name = item.OGR_ADI;
                studentVaccineInfo.Surname = item.OGR_SOYAD;
                studentVaccineInfo.Program = item.BOLUM_AD;
                studentVaccineInfo.Email = item.EPOSTA1;
                studentVaccineInfo.Faculty = item.FAKULTE_AD;
                studentVaccineInfo.StudentNumber = item.OGR_NO;
                studentVaccineInfo.Tc = item.TC_KIMLIK_NO;
                studentVaccineInfo.Phone = item.GSM1;
            }

            ProlizData prolizData = _context.ProlizData.FirstOrDefault(i => i.TCKIMLIKNO == tc);
            if (prolizData != null)
            {
                studentVaccineInfo.is_vaccinated = prolizData.is_vaccinated;
                studentVaccineInfo.HesCode = prolizData.HESKOD;
            }

            _context.StudentVaccineInfo.Add(studentVaccineInfo);
            _context.SaveChanges();
            return View();
        }
    }
}
