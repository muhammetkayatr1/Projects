using HesOperation.ProlizHesOperation;
using HesOperation.ProlizOperation;
using HesProject.Models;
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

namespace HesProject.Controllers
{
    [Authorize]
    public class ProlizController : Controller
    {

        private readonly AppDbContext _context;
        private readonly KonfidesDbContext _contextKonfides;

        public ProlizController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult GetAllHes() //Ogrenci no kullanılarak revize edilecek
        
        {

            IProlizHesServiceManager mng = new ProlizHesServiceManager();

            //var data = mng.GetStudentInfoOnProliz("23677801824", "");
            try
            {
                var allData = mng.GetAllHesOnProliz();

                for (int i = 0; i < allData.Count; i++)
                {
                    ProlizData prolizData = _context.ProlizData.FirstOrDefault(j => j.SNO == allData[i].S_NO);

                    if (prolizData != null)
                    {
                        if (prolizData.TIP == "Öğrenci")
                        {
                            prolizData.ASIDURUM = allData[i].ASI_DURUM;
                            prolizData.ASITARIH = allData[i].ASI_TARIH;
                            prolizData.HESKOD = allData[i].HES_KOD;
                            prolizData.HESTARIH = allData[i].HES_TARIH;
                            prolizData.RISKDURUM = allData[i].RISK_DURUM;
                            prolizData.SNO = allData[i].S_NO;
                            prolizData.TCKIMLIKNO = allData[i].TCKIMLIKNO;
                            prolizData.TIP = allData[i].TIP;
                            _context.ProlizData.Update(prolizData);
                        }
                        //else if (prolizData.TIP != "Öğrenci")
                        //{
                        //    //ProlizData proliz = new ProlizData();
                        //    //proliz.ASIDURUM = allData[i].ASI_DURUM;
                        //    //proliz.ASITARIH = allData[i].ASI_TARIH;
                        //    prolizData.HESKOD = allData[i].HES_KOD;
                        //    //proliz.HESTARIH = allData[i].HES_TARIH;
                        //    //proliz.RISKDURUM = allData[i].RISK_DURUM;
                        //    //proliz.SNO = allData[i].S_NO;
                        //    //proliz.TCKIMLIKNO = allData[i].TCKIMLIKNO;
                        //    //proliz.TIP = allData[i].TIP;
                        //    _context.ProlizData.Update(prolizData);
                        //}
                    }
                    else if (allData[i].TIP == "Öğrenci")
                    {
                        ProlizData proliz = new ProlizData();
                        proliz.ASIDURUM = allData[i].ASI_DURUM;
                        proliz.ASITARIH = allData[i].ASI_TARIH;
                        proliz.HESKOD = allData[i].HES_KOD;
                        proliz.HESTARIH = allData[i].HES_TARIH;
                        proliz.RISKDURUM = allData[i].RISK_DURUM;
                        proliz.SNO = allData[i].S_NO;
                        proliz.TCKIMLIKNO = allData[i].TCKIMLIKNO;
                        proliz.TIP = allData[i].TIP;
                        _context.ProlizData.Add(proliz);
                    }

                   
                    
                }
            //List<PersonData> personData = new List<PersonData>();
            
            }
            catch (Exception e)
            {

                var r = e.Message;
                throw;
            }
           

            _context.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }


        public IActionResult GetAllStudent() //Ogrenci no kullanılarak revize edilecek
        {

            IProlizServiceManager mng = new ProlizServiceManager();

            //var data = mng.GetStudentInfoOnProliz("23677801824", "");

            var allStudent = mng.GetAllStudentInfoOnProliz();

            var dataDb = allStudent.Where(p => !_context.ProlizData.Select(i => i.SNO).Contains(p.OGRENCI_NO));

            foreach (var item in dataDb)
            {
                ProlizData prolizData = new ProlizData();
                prolizData.Ad = item.AD;
                prolizData.Soyad = item.SOYAD;
                prolizData.Fakulte = item.FAKULTE_AD;
                prolizData.Bolum = item.BOLUM_AD;
                prolizData.Program = item.PROGRAM_AD;

                _context.ProlizData.Add(prolizData);
            }

            var data = _context.Person.Where(p => allStudent.Select(i => i.OGRENCI_NO).Contains(p.tc));

            for (int i = 0; i < allStudent.Count; i++)
            {
                ProlizData prolizData = _context.ProlizData.FirstOrDefault(j => j.TCKIMLIKNO == allStudent[i].TC_KIMLIK_NO);
                prolizData.Ad = allStudent[i].AD;
                prolizData.Soyad = allStudent[i].SOYAD;
                prolizData.Fakulte = allStudent[i].FAKULTE_AD;
                prolizData.Bolum = allStudent[i].BOLUM_AD;
                prolizData.Program = allStudent[i].PROGRAM_AD;

                _context.ProlizData.Add(prolizData);
            }

            //foreach (var item in data)
            //{
            //    _context.Person.Update(item);
            //}

            _context.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        public IActionResult GetAllAcademician()
        {

            IProlizServiceManager mng = new ProlizServiceManager();

            //var data = mng.GetStudentInfoOnProliz("23677801824", "");

            var allAcademician = mng.GetAcademicianInfoOnProliz();

            //var dataDb = allAcademician.Where(p => !_context.Person.Select(i => i.tc).Contains(p.tc_kimlik_no));
       
            //foreach (var item in dataDb)
            //{
            //    Person person = new Person();
            //    person.tc = item.tc_kimlik_no;
            //    // person.hes = item.Hes
            //    _context.Person.Add(person);
            //}

            for (int i = 0; i < allAcademician.Count(); i++)
            {
                ProlizData prolizData = _context.ProlizData.FirstOrDefault(j => j.TCKIMLIKNO == allAcademician[i].tc_kimlik_no);
                if (prolizData != null)
                {
                    prolizData.Ad = allAcademician[i].adi;
                    prolizData.Soyad = allAcademician[i].soyadi;
                    prolizData.Fakulte = allAcademician[i].fak_ad;
                    prolizData.Bolum = allAcademician[i].bol_ad;
                    prolizData.Program = allAcademician[i].prog_ad;
                    _context.Update(prolizData);
                }
                 

            }
            //var data = _context.Person.Where(p => allAcademician.Select(i => i.tc_kimlik_no).Contains(p.tc));

            //foreach (var item in data)
            //{
            //    _context.Person.Update(item);
            //}

            _context.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }





        public IActionResult GetStudent()
        {

            IProlizServiceManager mng = new ProlizServiceManager();

            try
            {
                foreach (var item in _context.ProlizData.Where(i=>i.TIP=="Öğrenci" && i.Ad == null))
                {
                    var data = mng.GetStudentInfoOnProliz("", item.SNO);
                    if (data != null)
                    {
                        item.Ad = data[0].OGR_ADI;
                        item.Soyad = data[0].OGR_SOYAD;
                        item.Fakulte = data[0].FAKULTE_AD;
                        item.Bolum = data[0].BOLUM_AD;
                        item.Program = data[0].PROGRAM_AD;
                        item.Picture = data[0].PICTURE;
                        _context.ProlizData.Update(item);
                    }
                    else
                    {
                        item.Ad = "Bulunamadı";
                        item.Soyad = "Bulunamadı";
                        item.Fakulte = "Bulunamadı";
                        item.Bolum = "Bulunamadı";
                        item.Program = "Bulunamadı";
                        item.Picture = "Bulunamadı";
                        _context.ProlizData.Update(item);
                    }
                   
                }
            }
            catch (Exception e)
            {

                var r = e.Message;
            }
            


            _context.SaveChanges();


            //     var data = mng.GetStudentInfoOnProliz(tc, "");
            //if (data.Count == 0)
            //{
            //    return RedirectToAction("Index", "Student", new { loginError = "UserNotFound" });
            //}
            //List<Student> studentInfo = new List<Student>();
            //foreach (var item in data)
            //{
            //    Student student = new Student();
            //    student.OGR_ADI = item.OGR_ADI;
            //    student.OGR_SOYAD = item.OGR_SOYAD;
            //    student.BOLUM_AD = item.BOLUM_AD;
            //    student.EPOSTA1 = item.EPOSTA1;
            //    student.FAKULTE_AD = item.FAKULTE_AD;
            //    student.OGR_NO = item.OGR_NO;
            //    student.TC_KIMLIK_NO = item.TC_KIMLIK_NO;
            //    student.PICTURE = item.PICTURE;
            //    studentInfo.Add(student);
            //}



            //HttpContext.Session.SetString("studentInfo", tc);

            //Person person = new Person();
            //person = _context.Person.FirstOrDefault(i => i.tc == tc);
            //if (person != null)
            //{
            //    ViewBag.Tc = person.tc;
            //    ViewBag.Hes = person.hes;
            //    if (person.durum == "RISKLESS")
            //    {
            //        ViewBag.Durum = "Riskli Değil";
            //    }
            //    else if (person.durum == "RISKY")
            //    {
            //        ViewBag.Durum = "Riskli";
            //    }
            //    ViewBag.Status = person.status;

            //}

            return RedirectToAction("Index", "Admin");
        }

    }
}
