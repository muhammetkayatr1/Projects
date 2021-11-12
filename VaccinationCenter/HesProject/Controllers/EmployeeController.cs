using HesOperation.ProlizOperation;
using HesOperation.Uyumsoft;
using VaccinationCenter.Models;
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

namespace VaccinationCenter.Controllers
{
    [AllowAnonymous]
    public class EmployeeController : Controller
    {
        string HesUrl = "https://hesservis.turkiye.gov.tr/services/g2g/saglik/hes";
        string Baseurl = "https://selfservis.halic.edu.tr/webapi/";

        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
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
      
        public IActionResult EmployeeInfo(string tc)
        {
            
            if (_context.EmployeeVaccineInfo.FirstOrDefault(i => i.Tc == tc) != null)
            {
                return RedirectToAction("Index", "Employee", new { Error = "Again" });
            }
            IUyumsoftServiceManager mng = new UyumsoftServiceManager();

            var dataProliz = mng.GetEmployee(tc);

            if (dataProliz.Adı == null)
            {
                return RedirectToAction("Index", "Employee", new { Error = "NotFound" });
            }

            EmployeeInfo employee = new EmployeeInfo();

            employee.TcKimlikNo = dataProliz.TcKimlikNo;
           
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

            ProlizData  prolizData = _context.ProlizData.FirstOrDefault(i => i.TCKIMLIKNO == tc);
            if (prolizData != null)
            {
                employeeVaccineInfo.is_vaccinated = prolizData.is_vaccinated;
                employeeVaccineInfo.HesCode = prolizData.HESKOD;
            }
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
