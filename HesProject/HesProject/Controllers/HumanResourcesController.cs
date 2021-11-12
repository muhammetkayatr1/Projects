using ClosedXML.Excel;
using HesOperation.ProlizOperation;
using HesOperation.Uyumsoft;
using HesProject.Helpers;
using HesProject.Models;
using HesProject.Models.konfides;
using HesProject.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NonFactors.Mvc.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HesProject.Controllers
{
    [Authorize]
    public class HumanResourcesController : Controller
    {
        string Baseurl = "https://hesservis.turkiye.gov.tr/services/g2g/saglik/hes";

        private readonly AppDbContext _context;

        public HumanResourcesController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            int student = 0, studentRisky = 0, studentRiskless = 0, studentError = 0,
               person = 0, personRisky = 0, personRiskless = 0, personError = 0;
            foreach (var item in _context.ProlizData)
            {
                if (item.TIP == "Öğrenci")
                {
                    student++;
                }
                if (item.current_health_status == "RISKY" && item.TIP == "Öğrenci")
                {
                    studentRisky++;
                }
                if (item.current_health_status == "RISKLESS" && item.TIP == "Öğrenci")
                {
                    studentRiskless++;
                }
                if (item.current_health_status == null && item.TIP == "Öğrenci")
                {
                    studentError++;
                }


                if (item.TIP != "Öğrenci")
                {
                    person++;
                }
                if (item.current_health_status == "RISKY" && item.TIP != "Öğrenci")
                {
                    personRisky++;
                }
                if (item.current_health_status == "RISKLESS" && item.TIP != "Öğrenci")
                {
                    personRiskless++;
                }
                if (item.current_health_status == null && item.TIP != "Öğrenci")
                {
                    personError++;
                }
            }

            ViewBag.Person = person;
            ViewBag.PersonRisky = personRisky;
            ViewBag.PersonRiskless = personRiskless;
            ViewBag.PersonError = personError;


            return View();
        }


        public async Task<IActionResult> PersonList()
        {
            int person = 0, personRisky = 0, personRiskless = 0, personError = 0;
            foreach (var item in _context.ProlizData)
            {


                if (item.TIP != "Öğrenci")
                {
                    person++;
                }
                if (item.current_health_status == "RISKY" && item.TIP != "Öğrenci")
                {
                    personRisky++;
                }
                if (item.current_health_status == "RISKLESS" && item.TIP != "Öğrenci")
                {
                    personRiskless++;
                }
                if (item.current_health_status == null && item.TIP != "Öğrenci")
                {
                    personError++;
                }
            }


            ViewBag.Person = person;
            ViewBag.PersonRisky = personRisky;
            ViewBag.PersonRiskless = personRiskless;
            ViewBag.PersonError = personError;
            var data = PeopleList(1);
            return View(data);
        }

        public ActionResult Risky()
        {
            int person = 0, personRisky = 0, personRiskless = 0, personError = 0;
            foreach (var item in _context.ProlizData)
            {


                if (item.TIP != "Öğrenci")
                {
                    person++;
                }
                if (item.current_health_status == "RISKY" && item.TIP != "Öğrenci")
                {
                    personRisky++;
                }
                if (item.current_health_status == "RISKLESS" && item.TIP != "Öğrenci")
                {
                    personRiskless++;
                }
                if (item.current_health_status == null && item.TIP != "Öğrenci")
                {
                    personError++;
                }
            }

            ViewBag.Person = person;
            ViewBag.PersonRisky = personRisky;
            ViewBag.PersonRiskless = personRiskless;
            ViewBag.PersonError = personError;
            var data = PeopleList(2);
            return View(data);

        }
        public ActionResult Riskless()
        {
            int person = 0, personRisky = 0, personRiskless = 0, personError = 0;
            foreach (var item in _context.ProlizData)
            {


                if (item.TIP != "Öğrenci")
                {
                    person++;
                }
                if (item.current_health_status == "RISKY" && item.TIP != "Öğrenci")
                {
                    personRisky++;
                }
                if (item.current_health_status == "RISKLESS" && item.TIP != "Öğrenci")
                {
                    personRiskless++;
                }
                if (item.current_health_status == null && item.TIP != "Öğrenci")
                {
                    personError++;
                }
            }

            ViewBag.Person = person;
            ViewBag.PersonRisky = personRisky;
            ViewBag.PersonRiskless = personRiskless;
            ViewBag.PersonError = personError;
            var data = PeopleList(3);
            return View(data);

        }

        public ActionResult Student()
        {
            int student = 0, studentRisky = 0, studentRiskless = 0, studentError = 0,
                person = 0, personRisky = 0, personRiskless = 0, personError = 0;
            foreach (var item in _context.ProlizData)
            {
                if (item.TIP == "Öğrenci")
                {
                    student++;
                }
                if (item.current_health_status == "RISKY" && item.TIP == "Öğrenci")
                {
                    studentRisky++;
                }
                if (item.current_health_status == "RISKLESS" && item.TIP == "Öğrenci")
                {
                    studentRiskless++;
                }
                if (item.current_health_status == null && item.TIP == "Öğrenci")
                {
                    studentError++;
                }

                if (item.TIP != "Öğrenci")
                {
                    person++;
                }
                if (item.current_health_status == "RISKY" && item.TIP != "Öğrenci")
                {
                    personRisky++;
                }
                if (item.current_health_status == "RISKLESS" && item.TIP != "Öğrenci")
                {
                    personRiskless++;
                }
                if (item.current_health_status == null && item.TIP != "Öğrenci")
                {
                    personError++;
                }
            }

            ViewBag.Student = student;
            ViewBag.StudentRisky = studentRisky;
            ViewBag.StudentRiskless = studentRiskless;
            ViewBag.StudentError = studentError;

            ViewBag.Person = person;
            ViewBag.PersonRisky = personRisky;
            ViewBag.PersonRiskless = personRiskless;
            ViewBag.PersonError = personError;
            var data = PeopleList(4);
            return View(data);

        }
        public ActionResult Employee()
        {
            int person = 0, personRisky = 0, personRiskless = 0, personError = 0;
            foreach (var item in _context.ProlizData)
            {


                if (item.TIP != "Öğrenci")
                {
                    person++;
                }
                if (item.current_health_status == "RISKY" && item.TIP != "Öğrenci")
                {
                    personRisky++;
                }
                if (item.current_health_status == "RISKLESS" && item.TIP != "Öğrenci")
                {
                    personRiskless++;
                }
                if (item.current_health_status == null && item.TIP != "Öğrenci")
                {
                    personError++;
                }
            }

            ViewBag.Person = person;
            ViewBag.PersonRisky = personRisky;
            ViewBag.PersonRiskless = personRiskless;
            ViewBag.PersonError = personError;
             var data = PeopleList(5);
           
            return View(data);

        }



        public ActionResult StudentRisky()
        {
            int student = 0, studentRisky = 0, studentRiskless = 0, studentError = 0,
                person = 0, personRisky = 0, personRiskless = 0, personError = 0;
            foreach (var item in _context.ProlizData)
            {
                if (item.TIP == "Öğrenci")
                {
                    student++;
                }
                if (item.current_health_status == "RISKY" && item.TIP == "Öğrenci")
                {
                    studentRisky++;
                }
                if (item.current_health_status == "RISKLESS" && item.TIP == "Öğrenci")
                {
                    studentRiskless++;
                }
                if (item.current_health_status == null && item.TIP == "Öğrenci")
                {
                    studentError++;
                }

                if (item.TIP != "Öğrenci")
                {
                    person++;
                }
                if (item.current_health_status == "RISKY" && item.TIP != "Öğrenci")
                {
                    personRisky++;
                }
                if (item.current_health_status == "RISKLESS" && item.TIP != "Öğrenci")
                {
                    personRiskless++;
                }
                if (item.current_health_status == null && item.TIP != "Öğrenci")
                {
                    personError++;
                }
            }

            ViewBag.Student = student;
            ViewBag.StudentRisky = studentRisky;
            ViewBag.StudentRiskless = studentRiskless;
            ViewBag.StudentError = studentError;

            ViewBag.Person = person;
            ViewBag.PersonRisky = personRisky;
            ViewBag.PersonRiskless = personRiskless;
            ViewBag.PersonError = personError;
            var data = PeopleList(6);
            return View(data);

        }
        public ActionResult StudentRiskless()
        {
            int student = 0, studentRisky = 0, studentRiskless = 0, studentError = 0,
                person = 0, personRisky = 0, personRiskless = 0, personError = 0;
            foreach (var item in _context.ProlizData)
            {
                if (item.TIP == "Öğrenci")
                {
                    student++;
                }
                if (item.current_health_status == "RISKY" && item.TIP == "Öğrenci")
                {
                    studentRisky++;
                }
                if (item.current_health_status == "RISKLESS" && item.TIP == "Öğrenci")
                {
                    studentRiskless++;
                }
                if (item.current_health_status == null && item.TIP == "Öğrenci")
                {
                    studentError++;
                }

                if (item.TIP != "Öğrenci")
                {
                    person++;
                }
                if (item.current_health_status == "RISKY" && item.TIP != "Öğrenci")
                {
                    personRisky++;
                }
                if (item.current_health_status == "RISKLESS" && item.TIP != "Öğrenci")
                {
                    personRiskless++;
                }
                if (item.current_health_status == null && item.TIP != "Öğrenci")
                {
                    personError++;
                }
            }

            ViewBag.Student = student;
            ViewBag.StudentRisky = studentRisky;
            ViewBag.StudentRiskless = studentRiskless;
            ViewBag.StudentError = studentError;

            ViewBag.Person = person;
            ViewBag.PersonRisky = personRisky;
            ViewBag.PersonRiskless = personRiskless;
            ViewBag.PersonError = personError;
            var data = PeopleList(7);
            return View(data);

        }

        public ActionResult EmployeeRisky()
        {
            int person = 0, personRisky = 0, personRiskless = 0, personError = 0;
            foreach (var item in _context.ProlizData)
            {


                if (item.TIP != "Öğrenci")
                {
                    person++;
                }
                if (item.current_health_status == "RISKY" && item.TIP != "Öğrenci")
                {
                    personRisky++;
                }
                if (item.current_health_status == "RISKLESS" && item.TIP != "Öğrenci")
                {
                    personRiskless++;
                }
                if (item.current_health_status == null && item.TIP != "Öğrenci")
                {
                    personError++;
                }
            }


            ViewBag.Person = person;
            ViewBag.PersonRisky = personRisky;
            ViewBag.PersonRiskless = personRiskless;
            ViewBag.PersonError = personError;
            var data = PeopleList(8);
            return View(data);

        }
        public ActionResult EmployeeRiskless()
        {
            int person = 0, personRisky = 0, personRiskless = 0, personError = 0;
            foreach (var item in _context.ProlizData)
            {


                if (item.TIP != "Öğrenci")
                {
                    person++;
                }
                if (item.current_health_status == "RISKY" && item.TIP != "Öğrenci")
                {
                    personRisky++;
                }
                if (item.current_health_status == "RISKLESS" && item.TIP != "Öğrenci")
                {
                    personRiskless++;
                }
                if (item.current_health_status == null && item.TIP != "Öğrenci")
                {
                    personError++;
                }
            }


            ViewBag.Person = person;
            ViewBag.PersonRisky = personRisky;
            ViewBag.PersonRiskless = personRiskless;
            ViewBag.PersonError = personError;
            var data = PeopleList(9);
            return View(data);

        }

        public ActionResult StudentError()
        {
            int student = 0, studentRisky = 0, studentRiskless = 0, studentError = 0,
                person = 0, personRisky = 0, personRiskless = 0, personError = 0;
            foreach (var item in _context.ProlizData)
            {
                if (item.TIP == "Öğrenci")
                {
                    student++;
                }
                if (item.current_health_status == "RISKY" && item.TIP == "Öğrenci")
                {
                    studentRisky++;
                }
                if (item.current_health_status == "RISKLESS" && item.TIP == "Öğrenci")
                {
                    studentRiskless++;
                }
                if (item.current_health_status == null && item.TIP == "Öğrenci")
                {
                    studentError++;
                }

                if (item.TIP != "Öğrenci")
                {
                    person++;
                }
                if (item.current_health_status == "RISKY" && item.TIP != "Öğrenci")
                {
                    personRisky++;
                }
                if (item.current_health_status == "RISKLESS" && item.TIP != "Öğrenci")
                {
                    personRiskless++;
                }
                if (item.current_health_status == null && item.TIP != "Öğrenci")
                {
                    personError++;
                }
            }

            ViewBag.Student = student;
            ViewBag.StudentRisky = studentRisky;
            ViewBag.StudentRiskless = studentRiskless;
            ViewBag.StudentError = studentError;

            ViewBag.Person = person;
            ViewBag.PersonRisky = personRisky;
            ViewBag.PersonRiskless = personRiskless;
            ViewBag.PersonError = personError;
            var data = PeopleList(11);
            return View(data);

        }
        public ActionResult EmployeeError()
        {
            int person = 0, personRisky = 0, personRiskless = 0, personError = 0;
            foreach (var item in _context.ProlizData)
            {
              

                if (item.TIP != "Öğrenci")
                {
                    person++;
                }
                if (item.current_health_status == "RISKY" && item.TIP != "Öğrenci")
                {
                    personRisky++;
                }
                if (item.current_health_status == "RISKLESS" && item.TIP != "Öğrenci")
                {
                    personRiskless++;
                }
                if (item.current_health_status == null && item.TIP != "Öğrenci")
                {
                    personError++;
                }
            }

           
            ViewBag.Person = person;
            ViewBag.PersonRisky = personRisky;
            ViewBag.PersonRiskless = personRiskless;
            ViewBag.PersonError = personError;
            var data = PeopleList(10);
            return View(data);

        }


        public ActionResult UnVaccinated()
        {
            int person = 0, personRisky = 0, personRiskless = 0, personError = 0,
               vaccinated = 0, unVaccinated = 0, pcrTested = 0, unPcrTested = 0;
            foreach (var item in _context.ProlizData)
            {
                if (item.TIP != "Öğrenci")
                {
                    person++;
                }
                if (item.current_health_status == "RISKY" && item.TIP != "Öğrenci")
                {
                    personRisky++;
                }
                if (item.current_health_status == "RISKLESS" && item.TIP != "Öğrenci")
                {
                    personRiskless++;
                }
                if (item.current_health_status == null && item.TIP != "Öğrenci")
                {
                    personError++;
                }


                if (item.TIP != "Öğrenci" && item.is_vaccinated == true && item.current_health_status != null)
                {
                    vaccinated++;
                }
                if (item.TIP != "Öğrenci" && item.is_vaccinated != true && item.current_health_status != null)
                {
                    unVaccinated++;
                }
                if (item.TIP != "Öğrenci" && item.last_negative_test_date != null && item.current_health_status != null && item.is_vaccinated != true)
                {
                    pcrTested++;
                }
                if (item.TIP != "Öğrenci" && item.last_negative_test_date == null && item.current_health_status != null && item.is_vaccinated != true)
                {
                    unPcrTested++;
                }
            }


            ViewBag.Person = person;
            ViewBag.PersonRisky = personRisky;
            ViewBag.PersonRiskless = personRiskless;
            ViewBag.PersonError = personError;
            ViewBag.Vaccinated = vaccinated;
            ViewBag.UnVaccinated = unVaccinated;
            ViewBag.PcrTested = pcrTested;
            ViewBag.UnPcrTested = unPcrTested;
            var data = PeopleList(12);
            return View(data);

        }


        public ActionResult Vaccinated()
        {
            int person = 0, personRisky = 0, personRiskless = 0, personError = 0,
               vaccinated = 0, unVaccinated = 0, pcrTested = 0, unPcrTested = 0;
            foreach (var item in _context.ProlizData)
            {
                if (item.TIP != "Öğrenci")
                {
                    person++;
                }
                if (item.current_health_status == "RISKY" && item.TIP != "Öğrenci")
                {
                    personRisky++;
                }
                if (item.current_health_status == "RISKLESS" && item.TIP != "Öğrenci")
                {
                    personRiskless++;
                }
                if (item.current_health_status == null && item.TIP != "Öğrenci")
                {
                    personError++;
                }


                if (item.TIP != "Öğrenci" && item.is_vaccinated == true && item.current_health_status != null)
                {
                    vaccinated++;
                }
                if (item.TIP != "Öğrenci" && item.is_vaccinated != true && item.current_health_status != null)
                {
                    unVaccinated++;
                }
                if (item.TIP != "Öğrenci" && item.last_negative_test_date != null && item.current_health_status != null && item.is_vaccinated != true)
                {
                    pcrTested++;
                }
                if (item.TIP != "Öğrenci" && item.last_negative_test_date == null && item.current_health_status != null && item.is_vaccinated != true)
                {
                    unPcrTested++;
                }
            }


            ViewBag.Person = person;
            ViewBag.PersonRisky = personRisky;
            ViewBag.PersonRiskless = personRiskless;
            ViewBag.PersonError = personError;
            ViewBag.Vaccinated = vaccinated;
            ViewBag.UnVaccinated = unVaccinated;
            ViewBag.PcrTested = pcrTested;
            ViewBag.UnPcrTested = unPcrTested;
            var data = PeopleList(13);
            return View(data);

        }

        public ActionResult PcrTested()
        {
            int person = 0, personRisky = 0, personRiskless = 0, personError = 0,
                vaccinated = 0, unVaccinated = 0, pcrTested = 0, unPcrTested = 0;
            foreach (var item in _context.ProlizData)
            {
                if (item.TIP != "Öğrenci")
                {
                    person++;
                }
                if (item.current_health_status == "RISKY" && item.TIP != "Öğrenci")
                {
                    personRisky++;
                }
                if (item.current_health_status == "RISKLESS" && item.TIP != "Öğrenci")
                {
                    personRiskless++;
                }
                if (item.current_health_status == null && item.TIP != "Öğrenci")
                {
                    personError++;
                }


                if (item.TIP != "Öğrenci" && item.is_vaccinated == true && item.current_health_status != null)
                {
                    vaccinated++;
                }
                if (item.TIP != "Öğrenci" && item.is_vaccinated != true && item.current_health_status != null)
                {
                    unVaccinated++;
                }
                if (item.TIP != "Öğrenci" && item.last_negative_test_date != null && item.current_health_status != null && item.is_vaccinated != true)
                {
                    pcrTested++;
                }
                if (item.TIP != "Öğrenci" && item.last_negative_test_date == null && item.current_health_status != null && item.is_vaccinated != true)
                {
                    unPcrTested++;
                }
            }


            ViewBag.Person = person;
            ViewBag.PersonRisky = personRisky;
            ViewBag.PersonRiskless = personRiskless;
            ViewBag.PersonError = personError;
            ViewBag.Vaccinated = vaccinated;
            ViewBag.UnVaccinated = unVaccinated;
            ViewBag.PcrTested = pcrTested;
            ViewBag.UnPcrTested = unPcrTested;
            var data = PeopleList(14);
            return View(data);

        }


        public ActionResult UnPcrTested()
        {
            int person = 0, personRisky = 0, personRiskless = 0, personError = 0,
                vaccinated = 0, unVaccinated = 0, pcrTested = 0, unPcrTested = 0;
            foreach (var item in _context.ProlizData)
            {
                if (item.TIP != "Öğrenci")
                {
                    person++;
                }
                if (item.current_health_status == "RISKY" && item.TIP != "Öğrenci")
                {
                    personRisky++;
                }
                if (item.current_health_status == "RISKLESS" && item.TIP != "Öğrenci")
                {
                    personRiskless++;
                }
                if (item.current_health_status == null && item.TIP != "Öğrenci")
                {
                    personError++;
                }


                if (item.TIP != "Öğrenci" && item.is_vaccinated == true && item.current_health_status != null)
                {
                    vaccinated++;
                }
                if (item.TIP != "Öğrenci" && item.is_vaccinated != true && item.current_health_status != null)
                {
                    unVaccinated++;
                }
                if (item.TIP != "Öğrenci" && item.last_negative_test_date != null && item.current_health_status != null && item.is_vaccinated != true)
                {
                    pcrTested++;
                }
                if (item.TIP != "Öğrenci" && item.last_negative_test_date == null && item.current_health_status != null && item.is_vaccinated != true)
                {
                    unPcrTested++;
                }
            }


            ViewBag.Person = person;
            ViewBag.PersonRisky = personRisky;
            ViewBag.PersonRiskless = personRiskless;
            ViewBag.PersonError = personError;
            ViewBag.Vaccinated = vaccinated;
            ViewBag.UnVaccinated = unVaccinated;
            ViewBag.PcrTested = pcrTested;
            ViewBag.UnPcrTested = unPcrTested;
            var data = PeopleList(15);
            return View(data);

        }

        private IGrid<ProlizData> PeopleList(int param)
        {
            if (param == 1)
            {
                IGrid<ProlizData> grid = new Grid<ProlizData>(_context.ProlizData.ToList());
                grid.Columns.Add(model => model.TCKIMLIKNO as String).Filterable(GridFilterCase.Upper).Named("tcno").Titled("Tc Numarası");
                grid.Columns.Add(model => model.Ad + " " + model.Soyad as String).Filterable(GridFilterCase.Upper).Named("namesurnamme").Titled("Ad Soyad");
                grid.Columns.Add(model => model.TIP).Titled("Tip" as String).Filterable(GridFilterCase.Upper).Named("tip");
                grid.Columns.Add(model => model.HESKOD).Titled("Hes Kodu" as String).Filterable(GridFilterCase.Upper).Named("heskodu").RenderedAs(model => model.HESKOD == null ? "HES Kodu Yok" : model.HESKOD);
                grid.Columns.Add(model => model.current_health_status as String).Filterable(GridFilterCase.Upper).Named("hesdurumu").Titled("Hes Durumu").RenderedAs(model => model.current_health_status == "RISKY" ? "Riskli" : (model.current_health_status == "RISKLESS" ? "Riskli Değil" :  model.durum));
                grid.Columns.Add(model => model.IsCard).Titled("Kartı Var Mı?" as String).Filterable(GridFilterCase.Upper).Named("kartvarmı").RenderedAs(model => model.IsCard == true ? "Var" : (model.IsCard == false ? "Yok" : "Kart Bilgisi Bulunamadı"));
                // grid.Columns.Add(model => model.IsBlocked).Titled("Kart Durumu" as String).Filterable(GridFilterCase.Upper).Named("kartdurumu").RenderedAs(model => model.IsBlocked == true ? "Kara Listede" : (model.IsBlocked == false ? "Giriş Yapabilir" : "Kart Bilgisi Bulunamadı"));
                grid.Columns.Add(model => "<a href='#' type='button' class='detay btn btn-primary ' style='margin-right:10px' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalDetail'><i class='fas fa-book'></i></a><a href='#' type='button' class='detay btn btn-primary ' style='margin-right:10px' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalGrup'><i class='fas fa-heartbeat'></i></a><a href='#' type='button' class='detay btn btn-primary' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalGate' onclick='MyFunction();'><i class='fas fa-lock'></i></a>").Titled("Detay").Encoded(false).Css("transaction");

                foreach (IGridColumn column in grid.Columns)
                {

                    column.Filter.IsEnabled = true;
                    column.Sort.IsEnabled = true;
                }

                return grid;
            }

            if (param == 2)
            {
                IGrid<ProlizData> grid = new Grid<ProlizData>(_context.ProlizData.Where(i => i.current_health_status == "RISKY").ToList());
                grid.Columns.Add(model => model.TCKIMLIKNO as String).Filterable(GridFilterCase.Upper).Named("tcno").Titled("Tc Numarası");
                grid.Columns.Add(model => model.Ad + " " + model.Soyad as String).Filterable(GridFilterCase.Upper).Named("namesurnamme").Titled("Ad Soyad");
                grid.Columns.Add(model => model.TIP).Titled("Tip" as String).Filterable(GridFilterCase.Upper).Named("tip");
                grid.Columns.Add(model => model.HESKOD).Titled("Hes Kodu" as String).Filterable(GridFilterCase.Upper).Named("heskodu").RenderedAs(model => model.HESKOD == null ? "HES Kodu Yok" : model.HESKOD);
                grid.Columns.Add(model => model.current_health_status as String).Filterable(GridFilterCase.Upper).Named("hesdurumu").Titled("Hes Durumu").RenderedAs(model => model.current_health_status == "RISKY" ? "Riskli" : (model.current_health_status == "RISKLESS" ? "Riskli Değil" :  model.durum));
                grid.Columns.Add(model => model.IsCard).Titled("Kartı Var Mı?" as String).Filterable(GridFilterCase.Upper).Named("kartvarmı").RenderedAs(model => model.IsCard == true ? "Var" : (model.IsCard == false ? "Yok" : "Kart Bilgisi Bulunamadı"));
                // grid.Columns.Add(model => model.IsBlocked).Titled("Kart Durumu" as String).Filterable(GridFilterCase.Upper).Named("kartdurumu").RenderedAs(model => model.IsBlocked == true ? "Kara Listede" : (model.IsBlocked == false ? "Giriş Yapabilir" : "Kart Bilgisi Bulunamadı"));
                grid.Columns.Add(model => "<a href='#' type='button' class='detay btn btn-primary ' style='margin-right:10px' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalDetail'><i class='fas fa-book'></i></a><a href='#' type='button' class='detay btn btn-primary ' style='margin-right:10px' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalGrup'><i class='fas fa-heartbeat'></i></a><a href='#' type='button' class='detay btn btn-primary' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalGate' onclick='MyFunction();'><i class='fas fa-lock'></i></a>").Titled("Detay").Encoded(false).Css("transaction");

                foreach (IGridColumn column in grid.Columns)
                {

                    column.Filter.IsEnabled = true;
                    column.Sort.IsEnabled = true;
                }

                return grid;
            }

            if (param == 3)
            {
                IGrid<ProlizData> grid = new Grid<ProlizData>(_context.ProlizData.Where(i => i.current_health_status == "RISKLESS").ToList());
                grid.Columns.Add(model => model.TCKIMLIKNO as String).Filterable(GridFilterCase.Upper).Named("tcno").Titled("Tc Numarası");
                grid.Columns.Add(model => model.Ad + " " + model.Soyad as String).Filterable(GridFilterCase.Upper).Named("namesurnamme").Titled("Ad Soyad");
                grid.Columns.Add(model => model.TIP).Titled("Tip" as String).Filterable(GridFilterCase.Upper).Named("tip");
                grid.Columns.Add(model => model.HESKOD).Titled("Hes Kodu" as String).Filterable(GridFilterCase.Upper).Named("heskodu").RenderedAs(model => model.HESKOD == null ? "HES Kodu Yok" : model.HESKOD);
                grid.Columns.Add(model => model.current_health_status as String).Filterable(GridFilterCase.Upper).Named("hesdurumu").Titled("Hes Durumu").RenderedAs(model => model.current_health_status == "RISKY" ? "Riskli" : (model.current_health_status == "RISKLESS" ? "Riskli Değil" :  model.durum));
                grid.Columns.Add(model => model.IsCard).Titled("Kartı Var Mı?" as String).Filterable(GridFilterCase.Upper).Named("kartvarmı").RenderedAs(model => model.IsCard == true ? "Var" : (model.IsCard == false ? "Yok" : "Kart Bilgisi Bulunamadı"));
                // grid.Columns.Add(model => model.IsBlocked).Titled("Kart Durumu" as String).Filterable(GridFilterCase.Upper).Named("kartdurumu").RenderedAs(model => model.IsBlocked == true ? "Kara Listede" : (model.IsBlocked == false ? "Giriş Yapabilir" : "Kart Bilgisi Bulunamadı"));
                grid.Columns.Add(model => "<a href='#' type='button' class='detay btn btn-primary ' style='margin-right:10px' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalDetail'><i class='fas fa-book'></i></a><a href='#' type='button' class='detay btn btn-primary ' style='margin-right:10px' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalGrup'><i class='fas fa-heartbeat'></i></a><a href='#' type='button' class='detay btn btn-primary' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalGate' onclick='MyFunction();'><i class='fas fa-lock'></i></a>").Titled("Detay").Encoded(false).Css("transaction");

                foreach (IGridColumn column in grid.Columns)
                {

                    column.Filter.IsEnabled = true;
                    column.Sort.IsEnabled = true;
                }

                return grid;
            }
            if (param == 4)
            {
                IGrid<ProlizData> grid = new Grid<ProlizData>(_context.ProlizData.Where(i => i.TIP == "Öğrenci").ToList());
                grid.Columns.Add(model => model.TCKIMLIKNO as String).Filterable(GridFilterCase.Upper).Named("tcno").Titled("Tc Numarası");
                grid.Columns.Add(model => model.Ad + " " + model.Soyad as String).Filterable(GridFilterCase.Upper).Named("namesurnamme").Titled("Ad Soyad");
                grid.Columns.Add(model => model.TIP).Titled("Tip" as String).Filterable(GridFilterCase.Upper).Named("tip");
                grid.Columns.Add(model => model.HESKOD).Titled("Hes Kodu" as String).Filterable(GridFilterCase.Upper).Named("heskodu").RenderedAs(model => model.HESKOD == null ? "HES Kodu Yok" : model.HESKOD);
                grid.Columns.Add(model => model.current_health_status as String).Filterable(GridFilterCase.Upper).Named("hesdurumu").Titled("Hes Durumu").RenderedAs(model => model.current_health_status == "RISKY" ? "Riskli" : (model.current_health_status == "RISKLESS" ? "Riskli Değil" :  model.durum));
                grid.Columns.Add(model => model.IsCard).Titled("Kartı Var Mı?" as String).Filterable(GridFilterCase.Upper).Named("kartvarmı").RenderedAs(model => model.IsCard == true ? "Var" : (model.IsCard == false ? "Yok" : "Kart Bilgisi Bulunamadı"));
                // grid.Columns.Add(model => model.IsBlocked).Titled("Kart Durumu" as String).Filterable(GridFilterCase.Upper).Named("kartdurumu").RenderedAs(model => model.IsBlocked == true ? "Kara Listede" : (model.IsBlocked == false ? "Giriş Yapabilir" : "Kart Bilgisi Bulunamadı"));
                grid.Columns.Add(model => "<a href='#' type='button' class='detay btn btn-primary ' style='margin-right:10px' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalDetail'><i class='fas fa-book'></i></a><a href='#' type='button' class='detay btn btn-primary ' style='margin-right:10px' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalGrup'><i class='fas fa-heartbeat'></i></a><a href='#' type='button' class='detay btn btn-primary' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalGate' onclick='MyFunction();'><i class='fas fa-lock'></i></a>").Titled("Detay").Encoded(false).Css("transaction");

                foreach (IGridColumn column in grid.Columns)
                {

                    column.Filter.IsEnabled = true;
                    column.Sort.IsEnabled = true;
                }

                return grid;
            }

            if (param == 5)
            {
                IGrid<ProlizData> grid = new Grid<ProlizData>(_context.ProlizData.Where(i => i.TIP != "Öğrenci").ToList());
                grid.Columns.Add(model => model.TCKIMLIKNO as String).Filterable(GridFilterCase.Upper).Named("tcno").Titled("Tc Numarası");
                grid.Columns.Add(model => model.Ad + " " + model.Soyad as String).Filterable(GridFilterCase.Upper).Named("namesurnamme").Titled("Ad Soyad");
                grid.Columns.Add(model => model.TIP).Titled("Tip" as String).Filterable(GridFilterCase.Upper).Named("tip");
                grid.Columns.Add(model => model.HESKOD).Titled("Hes Kodu" as String).Named("heskodu").RenderedAs(model => model.HESKOD == null ? "HES Kodu Yok" : model.HESKOD).Filterable(GridFilterCase.Upper);
                grid.Columns.Add(model => model.current_health_status as String).Filterable(GridFilterCase.Upper).Named("hesdurumu").Titled("Hes Durumu").RenderedAs(model => model.current_health_status == "RISKY" ? "Riskli" : (model.current_health_status == "RISKLESS" ? "Riskli Değil" :  model.durum));
                grid.Columns.Add(model => model.IsCard).Titled("Kartı Var Mı?" as String).Filterable(GridFilterCase.Upper).Named("kartvarmı").RenderedAs(model => model.IsCard == true ? "Var" : (model.IsCard == false ? "Yok" : "Kart Bilgisi Bulunamadı"));
               // grid.Columns.Add(model => model.IsBlocked).Titled("Kart Durumu" as String).Filterable(GridFilterCase.Upper).Named("kartdurumu").RenderedAs(model => model.IsBlocked == true ? "Kara Listede" : (model.IsBlocked == false ? "Giriş Yapabilir" : "Kart Bilgisi Bulunamadı"));
                grid.Columns.Add(model => "<a href='#' type='button' class='detay btn btn-primary ' style='margin-right:10px' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalDetail'><i class='fas fa-book'></i></a><a href='#' type='button' class='detay btn btn-primary ' style='margin-right:10px' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalGrup'><i class='fas fa-heartbeat'></i></a><a href='#' type='button' class='detay btn btn-primary' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalGate' onclick='MyFunction();'><i class='fas fa-lock'></i></a>").Titled("Detay").Encoded(false).Css("transaction");

                foreach (IGridColumn column in grid.Columns)
                {

                    column.Filter.IsEnabled = true;
                    column.Sort.IsEnabled = true;
                }

                return grid;
            }

            if (param == 6)
            {
                IGrid<ProlizData> grid = new Grid<ProlizData>(_context.ProlizData.Where(i => i.TIP == "Öğrenci" && i.current_health_status == "RISKY").ToList());
                grid.Columns.Add(model => model.TCKIMLIKNO as String).Filterable(GridFilterCase.Upper).Named("tcno").Titled("Tc Numarası");
                grid.Columns.Add(model => model.Ad + " " + model.Soyad as String).Filterable(GridFilterCase.Upper).Named("namesurnamme").Titled("Ad Soyad");
                grid.Columns.Add(model => model.TIP).Titled("Tip" as String).Filterable(GridFilterCase.Upper).Named("tip");
                grid.Columns.Add(model => model.HESKOD).Titled("Hes Kodu" as String).Filterable(GridFilterCase.Upper).Named("heskodu").RenderedAs(model => model.HESKOD == null ? "HES Kodu Yok" : model.HESKOD);
                grid.Columns.Add(model => model.current_health_status as String).Filterable(GridFilterCase.Upper).Named("hesdurumu").Titled("Hes Durumu").RenderedAs(model => model.current_health_status == "RISKY" ? "Riskli" : (model.current_health_status == "RISKLESS" ? "Riskli Değil" :  model.durum));
                grid.Columns.Add(model => model.IsCard).Titled("Kartı Var Mı?" as String).Filterable(GridFilterCase.Upper).Named("kartvarmı").RenderedAs(model => model.IsCard == true ? "Var" : (model.IsCard == false ? "Yok" : "Kart Bilgisi Bulunamadı"));
                // grid.Columns.Add(model => model.IsBlocked).Titled("Kart Durumu" as String).Filterable(GridFilterCase.Upper).Named("kartdurumu").RenderedAs(model => model.IsBlocked == true ? "Kara Listede" : (model.IsBlocked == false ? "Giriş Yapabilir" : "Kart Bilgisi Bulunamadı"));
                grid.Columns.Add(model => "<a href='#' type='button' class='detay btn btn-primary ' style='margin-right:10px' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalDetail'><i class='fas fa-book'></i></a><a href='#' type='button' class='detay btn btn-primary ' style='margin-right:10px' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalGrup'><i class='fas fa-heartbeat'></i></a><a href='#' type='button' class='detay btn btn-primary' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalGate' onclick='MyFunction();'><i class='fas fa-lock'></i></a>").Titled("Detay").Encoded(false).Css("transaction");

                foreach (IGridColumn column in grid.Columns)
                {

                    column.Filter.IsEnabled = true;
                    column.Sort.IsEnabled = true;
                }

                return grid;
            }

            if (param == 7)
            {
                IGrid<ProlizData> grid = new Grid<ProlizData>(_context.ProlizData.Where(i => i.TIP == "Öğrenci" && i.current_health_status == "RISKLESS").ToList());
                grid.Columns.Add(model => model.TCKIMLIKNO as String).Filterable(GridFilterCase.Upper).Named("tcno").Titled("Tc Numarası");
                grid.Columns.Add(model => model.Ad + " " + model.Soyad as String).Filterable(GridFilterCase.Upper).Named("namesurnamme").Titled("Ad Soyad");
                grid.Columns.Add(model => model.TIP).Titled("Tip" as String).Filterable(GridFilterCase.Upper).Named("tip");
                grid.Columns.Add(model => model.HESKOD).Titled("Hes Kodu" as String).Filterable(GridFilterCase.Upper).Named("heskodu").RenderedAs(model => model.HESKOD == null ? "HES Kodu Yok" : model.HESKOD);
                grid.Columns.Add(model => model.current_health_status as String).Filterable(GridFilterCase.Upper).Named("hesdurumu").Titled("Hes Durumu").RenderedAs(model => model.current_health_status == "RISKY" ? "Riskli" : (model.current_health_status == "RISKLESS" ? "Riskli Değil" :  model.durum));
                grid.Columns.Add(model => model.IsCard).Titled("Kartı Var Mı?" as String).Filterable(GridFilterCase.Upper).Named("kartvarmı").RenderedAs(model => model.IsCard == true ? "Var" : (model.IsCard == false ? "Yok" : "Kart Bilgisi Bulunamadı"));
                // grid.Columns.Add(model => model.IsBlocked).Titled("Kart Durumu" as String).Filterable(GridFilterCase.Upper).Named("kartdurumu").RenderedAs(model => model.IsBlocked == true ? "Kara Listede" : (model.IsBlocked == false ? "Giriş Yapabilir" : "Kart Bilgisi Bulunamadı"));
                grid.Columns.Add(model => "<a href='#' type='button' class='detay btn btn-primary ' style='margin-right:10px' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalDetail'><i class='fas fa-book'></i></a><a href='#' type='button' class='detay btn btn-primary ' style='margin-right:10px' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalGrup'><i class='fas fa-heartbeat'></i></a><a href='#' type='button' class='detay btn btn-primary' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalGate' onclick='MyFunction();'><i class='fas fa-lock'></i></a>").Titled("Detay").Encoded(false).Css("transaction");

                foreach (IGridColumn column in grid.Columns)
                {

                    column.Filter.IsEnabled = true;
                    column.Sort.IsEnabled = true;
                }

                return grid;
            }

            if (param == 8)
            {
                IGrid<ProlizData> grid = new Grid<ProlizData>(_context.ProlizData.Where(i => i.TIP != "Öğrenci" && i.current_health_status == "RISKY").ToList());
                grid.Columns.Add(model => model.TCKIMLIKNO as String).Filterable(GridFilterCase.Upper).Named("tcno").Titled("Tc Numarası");
                grid.Columns.Add(model => model.Ad + " " + model.Soyad as String).Filterable(GridFilterCase.Upper).Named("namesurnamme").Titled("Ad Soyad");
                grid.Columns.Add(model => model.TIP).Titled("Tip" as String).Filterable(GridFilterCase.Upper).Named("tip");
                grid.Columns.Add(model => model.HESKOD).Titled("Hes Kodu" as String).Named("heskodu").RenderedAs(model => model.HESKOD == null ? "HES Kodu Yok" : model.HESKOD).Filterable(GridFilterCase.Upper);
                grid.Columns.Add(model => model.current_health_status as String).Filterable(GridFilterCase.Upper).Named("hesdurumu").Titled("Hes Durumu").RenderedAs(model => model.current_health_status == "RISKY" ? "Riskli" : (model.current_health_status == "RISKLESS" ? "Riskli Değil" :  model.durum));
                grid.Columns.Add(model => model.IsCard).Titled("Kartı Var Mı?" as String).Filterable(GridFilterCase.Upper).Named("kartvarmı").RenderedAs(model => model.IsCard == true ? "Var" : (model.IsCard == false ? "Yok" : "Kart Bilgisi Bulunamadı"));
                // grid.Columns.Add(model => model.IsBlocked).Titled("Kart Durumu" as String).Filterable(GridFilterCase.Upper).Named("kartdurumu").RenderedAs(model => model.IsBlocked == true ? "Kara Listede" : (model.IsBlocked == false ? "Giriş Yapabilir" : "Kart Bilgisi Bulunamadı"));
                grid.Columns.Add(model => "<a href='#' type='button' class='detay btn btn-primary ' style='margin-right:10px' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalDetail'><i class='fas fa-book'></i></a><a href='#' type='button' class='detay btn btn-primary ' style='margin-right:10px' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalGrup'><i class='fas fa-heartbeat'></i></a><a href='#' type='button' class='detay btn btn-primary' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalGate' onclick='MyFunction();'><i class='fas fa-lock'></i></a>").Titled("Detay").Encoded(false).Css("transaction");

                foreach (IGridColumn column in grid.Columns)
                {

                    column.Filter.IsEnabled = true;
                    column.Sort.IsEnabled = true;
                }

                return grid;
            }

            if (param == 9)
            {
                IGrid<ProlizData> grid = new Grid<ProlizData>(_context.ProlizData.Where(i => i.TIP != "Öğrenci" && i.current_health_status == "RISKLESS").ToList());
                grid.Columns.Add(model => model.TCKIMLIKNO as String).Filterable(GridFilterCase.Upper).Named("tcno").Titled("Tc Numarası");
                grid.Columns.Add(model => model.Ad + " " + model.Soyad as String).Filterable(GridFilterCase.Upper).Named("namesurnamme").Titled("Ad Soyad");
                grid.Columns.Add(model => model.TIP).Titled("Tip" as String).Filterable(GridFilterCase.Upper).Named("tip");
                grid.Columns.Add(model => model.HESKOD).Titled("Hes Kodu" as String).Filterable(GridFilterCase.Upper).Named("heskodu").RenderedAs(model => model.HESKOD == null ? "HES Kodu Yok" : model.HESKOD);
                grid.Columns.Add(model => model.current_health_status as String).Filterable(GridFilterCase.Upper).Named("hesdurumu").Titled("Hes Durumu").RenderedAs(model => model.current_health_status == "RISKY" ? "Riskli" : (model.current_health_status == "RISKLESS" ? "Riskli Değil" :  model.durum));
                grid.Columns.Add(model => model.IsCard).Titled("Kartı Var Mı?" as String).Filterable(GridFilterCase.Upper).Named("kartvarmı").RenderedAs(model => model.IsCard == true ? "Var" : (model.IsCard == false ? "Yok" : "Kart Bilgisi Bulunamadı"));
                // grid.Columns.Add(model => model.IsBlocked).Titled("Kart Durumu" as String).Filterable(GridFilterCase.Upper).Named("kartdurumu").RenderedAs(model => model.IsBlocked == true ? "Kara Listede" : (model.IsBlocked == false ? "Giriş Yapabilir" : "Kart Bilgisi Bulunamadı"));
                grid.Columns.Add(model => "<a href='#' type='button' class='detay btn btn-primary ' style='margin-right:10px' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalDetail'><i class='fas fa-book'></i></a><a href='#' type='button' class='detay btn btn-primary ' style='margin-right:10px' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalGrup'><i class='fas fa-heartbeat'></i></a><a href='#' type='button' class='detay btn btn-primary' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalGate' onclick='MyFunction();'><i class='fas fa-lock'></i></a>").Titled("Detay").Encoded(false).Css("transaction");

                foreach (IGridColumn column in grid.Columns)
                {

                    column.Filter.IsEnabled = true;
                    column.Sort.IsEnabled = true;
                }

                return grid;
            }

            if (param == 10)
            {
                IGrid<ProlizData> grid = new Grid<ProlizData>(_context.ProlizData.Where(i => i.TIP != "Öğrenci" && i.current_health_status == null).ToList());
                grid.Columns.Add(model => model.TCKIMLIKNO as String).Filterable(GridFilterCase.Upper).Named("tcno").Titled("Tc Numarası");
                grid.Columns.Add(model => model.Ad + " " + model.Soyad as String).Filterable(GridFilterCase.Upper).Named("namesurnamme").Titled("Ad Soyad");
                grid.Columns.Add(model => model.TIP).Titled("Tip" as String).Filterable(GridFilterCase.Upper).Named("tip");
                grid.Columns.Add(model => model.HESKOD).Titled("Hes Kodu" as String).Filterable(GridFilterCase.Upper).Named("heskodu").RenderedAs(model => model.HESKOD == null ? "HES Kodu Yok" : model.HESKOD);
                grid.Columns.Add(model => model.durum as String).Filterable(GridFilterCase.Upper).Named("hesdurumu").Titled("Hes Durumu").RenderedAs(model => model.current_health_status == "RISKY" ? "Riskli" : (model.current_health_status == "RISKLESS" ? "Riskli Değil" :  model.durum));
                grid.Columns.Add(model => model.IsCard).Titled("Kartı Var Mı?" as String).Filterable(GridFilterCase.Upper).Named("kartvarmı").RenderedAs(model => model.IsCard == true ? "Var" : (model.IsCard == false ? "Yok" : "Kart Bilgisi Bulunamadı"));
                // grid.Columns.Add(model => model.IsBlocked).Titled("Kart Durumu" as String).Filterable(GridFilterCase.Upper).Named("kartdurumu").RenderedAs(model => model.IsBlocked == true ? "Kara Listede" : (model.IsBlocked == false ? "Giriş Yapabilir" : "Kart Bilgisi Bulunamadı"));
                grid.Columns.Add(model => "<a href='#' type='button' class='detay btn btn-primary ' style='margin-right:10px' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalDetail'><i class='fas fa-book'></i></a><a href='#' type='button' class='detay btn btn-primary ' style='margin-right:10px' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalGrup'><i class='fas fa-heartbeat'></i></a><a href='#' type='button' class='detay btn btn-primary' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalGate' onclick='MyFunction();'><i class='fas fa-lock'></i></a>").Titled("Detay").Encoded(false).Css("transaction");

                foreach (IGridColumn column in grid.Columns)
                {

                    column.Filter.IsEnabled = true;
                    column.Sort.IsEnabled = true;
                }

                return grid;
            }

            if (param == 11)
            {
                IGrid<ProlizData> grid = new Grid<ProlizData>(_context.ProlizData.Where(i => (i.TIP == "Öğrenci") && i.current_health_status == null).ToList());
                grid.Columns.Add(model => model.TCKIMLIKNO as String).Filterable(GridFilterCase.Upper).Named("tcno").Titled("Tc Numarası");
                grid.Columns.Add(model => model.Ad + " " + model.Soyad as String).Filterable(GridFilterCase.Upper).Named("namesurnamme").Titled("Ad Soyad");
                grid.Columns.Add(model => model.TIP).Titled("Tip" as String).Filterable(GridFilterCase.Upper).Named("tip");
                grid.Columns.Add(model => model.HESKOD).Titled("Hes Kodu" as String).Filterable(GridFilterCase.Upper).Named("heskodu").RenderedAs(model => model.HESKOD == null ? "HES Kodu Yok" : model.HESKOD);
                grid.Columns.Add(model => model.current_health_status as String).Filterable(GridFilterCase.Upper).Named("hesdurumu").Titled("Hes Durumu").RenderedAs(model => model.current_health_status == "RISKY" ? "Riskli" : (model.current_health_status == "RISKLESS" ? "Riskli Değil" :  model.durum));
                grid.Columns.Add(model => model.IsCard).Titled("Kartı Var Mı?" as String).Filterable(GridFilterCase.Upper).Named("kartvarmı").RenderedAs(model => model.IsCard == true ? "Var" : (model.IsCard == false ? "Yok" : "Kart Bilgisi Bulunamadı"));
                // grid.Columns.Add(model => model.IsBlocked).Titled("Kart Durumu" as String).Filterable(GridFilterCase.Upper).Named("kartdurumu").RenderedAs(model => model.IsBlocked == true ? "Kara Listede" : (model.IsBlocked == false ? "Giriş Yapabilir" : "Kart Bilgisi Bulunamadı"));
                grid.Columns.Add(model => "<a href='#' type='button' class='detay btn btn-primary ' style='margin-right:10px' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalDetail'><i class='fas fa-book'></i></a><a href='#' type='button' class='detay btn btn-primary ' style='margin-right:10px' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalGrup'><i class='fas fa-heartbeat'></i></a><a href='#' type='button' class='detay btn btn-primary' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalGate' onclick='MyFunction();'><i class='fas fa-lock'></i></a>").Titled("Detay").Encoded(false).Css("transaction");

                foreach (IGridColumn column in grid.Columns)
                {

                    column.Filter.IsEnabled = true;
                    column.Sort.IsEnabled = true;
                }

                return grid;
            }

            if (param == 12) // Aşılarını tamamlamayanlar
            {
                IGrid<ProlizData> grid = new Grid<ProlizData>(_context.ProlizData.Where(i => i.TIP != "Öğrenci" && i.is_vaccinated != true && i.current_health_status != null).ToList());
                grid.Columns.Add(model => model.TCKIMLIKNO as String).Filterable(GridFilterCase.Upper).Named("tcno").Titled("Tc Numarası");
                grid.Columns.Add(model => model.Ad + " " + model.Soyad as String).Filterable(GridFilterCase.Upper).Named("namesurnamme").Titled("Ad Soyad");
                grid.Columns.Add(model => model.TIP).Titled("Tip" as String).Filterable(GridFilterCase.Upper).Named("tip");
                grid.Columns.Add(model => model.HESKOD).Titled("Hes Kodu" as String).Filterable(GridFilterCase.Upper).Named("heskodu").RenderedAs(model => model.HESKOD == null ? "HES Kodu Yok" : model.HESKOD);
                grid.Columns.Add(model => model.current_health_status as String).Filterable(GridFilterCase.Upper).Named("hesdurumu").Titled("Hes Durumu").RenderedAs(model => model.current_health_status == "RISKY" ? "Riskli" : (model.current_health_status == "RISKLESS" ? "Riskli Değil" :  model.durum));
                grid.Columns.Add(model => model.IsCard).Titled("Kartı Var Mı?" as String).Filterable(GridFilterCase.Upper).Named("kartvarmı").RenderedAs(model => model.IsCard == true ? "Var" : (model.IsCard == false ? "Yok" : "Kart Bilgisi Bulunamadı"));
                // grid.Columns.Add(model => model.IsBlocked).Titled("Kart Durumu" as String).Filterable(GridFilterCase.Upper).Named("kartdurumu").RenderedAs(model => model.IsBlocked == true ? "Kara Listede" : (model.IsBlocked == false ? "Giriş Yapabilir" : "Kart Bilgisi Bulunamadı"));
                grid.Columns.Add(model => "<a href='#' type='button' class='detay btn btn-primary ' style='margin-right:10px' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalDetail'><i class='fas fa-book'></i></a><a href='#' type='button' class='detay btn btn-primary ' style='margin-right:10px' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalGrup'><i class='fas fa-heartbeat'></i></a><a href='#' type='button' class='detay btn btn-primary' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalGate' onclick='MyFunction();'><i class='fas fa-lock'></i></a>").Titled("Detay").Encoded(false).Css("transaction");

                foreach (IGridColumn column in grid.Columns)
                {

                    column.Filter.IsEnabled = true;
                    column.Sort.IsEnabled = true;
                }

                return grid;
            }


            if (param == 13) // Aşılarını tamamlayanlar
            {
                IGrid<ProlizData> grid = new Grid<ProlizData>(_context.ProlizData.Where(i => i.TIP != "Öğrenci" && i.is_vaccinated == true && i.current_health_status != null).ToList());
                grid.Columns.Add(model => model.TCKIMLIKNO as String).Filterable(GridFilterCase.Upper).Named("tcno").Titled("Tc Numarası");
                grid.Columns.Add(model => model.Ad + " " + model.Soyad as String).Filterable(GridFilterCase.Upper).Named("namesurnamme").Titled("Ad Soyad");
                grid.Columns.Add(model => model.TIP).Titled("Tip" as String).Filterable(GridFilterCase.Upper).Named("tip");
                grid.Columns.Add(model => model.HESKOD).Titled("Hes Kodu" as String).Filterable(GridFilterCase.Upper).Named("heskodu").RenderedAs(model => model.HESKOD == null ? "HES Kodu Yok" : model.HESKOD);
                grid.Columns.Add(model => model.current_health_status as String).Filterable(GridFilterCase.Upper).Named("hesdurumu").Titled("Hes Durumu").RenderedAs(model => model.current_health_status == "RISKY" ? "Riskli" : (model.current_health_status == "RISKLESS" ? "Riskli Değil" :  model.durum));
                grid.Columns.Add(model => model.IsCard).Titled("Kartı Var Mı?" as String).Filterable(GridFilterCase.Upper).Named("kartvarmı").RenderedAs(model => model.IsCard == true ? "Var" : (model.IsCard == false ? "Yok" : "Kart Bilgisi Bulunamadı"));
                // grid.Columns.Add(model => model.IsBlocked).Titled("Kart Durumu" as String).Filterable(GridFilterCase.Upper).Named("kartdurumu").RenderedAs(model => model.IsBlocked == true ? "Kara Listede" : (model.IsBlocked == false ? "Giriş Yapabilir" : "Kart Bilgisi Bulunamadı"));
                grid.Columns.Add(model => "<a href='#' type='button' class='detay btn btn-primary ' style='margin-right:10px' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalDetail'><i class='fas fa-book'></i></a><a href='#' type='button' class='detay btn btn-primary ' style='margin-right:10px' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalGrup'><i class='fas fa-heartbeat'></i></a><a href='#' type='button' class='detay btn btn-primary' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalGate' onclick='MyFunction();'><i class='fas fa-lock'></i></a>").Titled("Detay").Encoded(false).Css("transaction");

                foreach (IGridColumn column in grid.Columns)
                {

                    column.Filter.IsEnabled = true;
                    column.Sort.IsEnabled = true;
                }

                return grid;
            }

            if (param == 14) //Aşılarını tamamlamamayıp 3 gün içerisinde test yaptıranlar
            {
                IGrid<ProlizData> grid = new Grid<ProlizData>(_context.ProlizData.Where(i => i.TIP != "Öğrenci" && i.last_negative_test_date != null && i.current_health_status != null && i.is_vaccinated == true).ToList());
                grid.Columns.Add(model => model.TCKIMLIKNO as String).Filterable(GridFilterCase.Upper).Named("tcno").Titled("Tc Numarası");
                grid.Columns.Add(model => model.Ad + " " + model.Soyad as String).Filterable(GridFilterCase.Upper).Named("namesurnamme").Titled("Ad Soyad");
                grid.Columns.Add(model => model.TIP).Titled("Tip" as String).Filterable(GridFilterCase.Upper).Named("tip");
                grid.Columns.Add(model => model.HESKOD).Titled("Hes Kodu" as String).Filterable(GridFilterCase.Upper).Named("heskodu").RenderedAs(model => model.HESKOD == null ? "HES Kodu Yok" : model.HESKOD);
                grid.Columns.Add(model => model.current_health_status as String).Filterable(GridFilterCase.Upper).Named("hesdurumu").Titled("Hes Durumu").RenderedAs(model => model.current_health_status == "RISKY" ? "Riskli" : (model.current_health_status == "RISKLESS" ? "Riskli Değil" :  model.durum));
                grid.Columns.Add(model => model.IsCard).Titled("Kartı Var Mı?" as String).Filterable(GridFilterCase.Upper).Named("kartvarmı").RenderedAs(model => model.IsCard == true ? "Var" : (model.IsCard == false ? "Yok" : "Kart Bilgisi Bulunamadı"));
                // grid.Columns.Add(model => model.IsBlocked).Titled("Kart Durumu" as String).Filterable(GridFilterCase.Upper).Named("kartdurumu").RenderedAs(model => model.IsBlocked == true ? "Kara Listede" : (model.IsBlocked == false ? "Giriş Yapabilir" : "Kart Bilgisi Bulunamadı"));
                grid.Columns.Add(model => "<a href='#' type='button' class='detay btn btn-primary ' style='margin-right:10px' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalDetail'><i class='fas fa-book'></i></a><a href='#' type='button' class='detay btn btn-primary ' style='margin-right:10px' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalGrup'><i class='fas fa-heartbeat'></i></a><a href='#' type='button' class='detay btn btn-primary' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalGate' onclick='MyFunction();'><i class='fas fa-lock'></i></a>").Titled("Detay").Encoded(false).Css("transaction");

                foreach (IGridColumn column in grid.Columns)
                {

                    column.Filter.IsEnabled = true;
                    column.Sort.IsEnabled = true;
                }

                return grid;
            }

            if (param == 15) //Aşılarını tamamlamamayıp 3 gün içinde test yaptırmayanlar
            {
                IGrid<ProlizData> grid = new Grid<ProlizData>(_context.ProlizData.Where(i => i.TIP != "Öğrenci" && i.last_negative_test_date == null && i.current_health_status != null && i.is_vaccinated != true).ToList());
                grid.Columns.Add(model => model.TCKIMLIKNO as String).Filterable(GridFilterCase.Upper).Named("tcno").Titled("Tc Numarası");
                grid.Columns.Add(model => model.Ad + " " + model.Soyad as String).Filterable(GridFilterCase.Upper).Named("namesurnamme").Titled("Ad Soyad");
                grid.Columns.Add(model => model.TIP).Titled("Tip" as String).Filterable(GridFilterCase.Upper).Named("tip");
                grid.Columns.Add(model => model.HESKOD).Titled("Hes Kodu" as String).Filterable(GridFilterCase.Upper).Named("heskodu").RenderedAs(model => model.HESKOD == null ? "HES Kodu Yok" : model.HESKOD);
                grid.Columns.Add(model => model.current_health_status as String).Filterable(GridFilterCase.Upper).Named("hesdurumu").Titled("Hes Durumu").RenderedAs(model => model.current_health_status == "RISKY" ? "Riskli" : (model.current_health_status == "RISKLESS" ? "Riskli Değil" :  model.durum));
                grid.Columns.Add(model => model.IsCard).Titled("Kartı Var Mı?" as String).Filterable(GridFilterCase.Upper).Named("kartvarmı").RenderedAs(model => model.IsCard == true ? "Var" : (model.IsCard == false ? "Yok" : "Kart Bilgisi Bulunamadı"));
                // grid.Columns.Add(model => model.IsBlocked).Titled("Kart Durumu" as String).Filterable(GridFilterCase.Upper).Named("kartdurumu").RenderedAs(model => model.IsBlocked == true ? "Kara Listede" : (model.IsBlocked == false ? "Giriş Yapabilir" : "Kart Bilgisi Bulunamadı"));
                grid.Columns.Add(model => "<a href='#' type='button' class='detay btn btn-primary ' style='margin-right:10px' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalDetail'><i class='fas fa-book'></i></a><a href='#' type='button' class='detay btn btn-primary ' style='margin-right:10px' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalGrup'><i class='fas fa-heartbeat'></i></a><a href='#' type='button' class='detay btn btn-primary' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalGate' onclick='MyFunction();'><i class='fas fa-lock'></i></a>").Titled("Detay").Encoded(false).Css("transaction");

                foreach (IGridColumn column in grid.Columns)
                {

                    column.Filter.IsEnabled = true;
                    column.Sort.IsEnabled = true;
                }

                return grid;
            }

            return null;
        }




        // GET: People/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var people = await _context.Person
                .FirstOrDefaultAsync(m => m.Id == id);
            if (people == null)
            {
                return NotFound();
            }

            return View(people);
        }

        // GET: People/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: People/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,tc,hes,durum")] Person people)
        {
            if (ModelState.IsValid)
            {
                _context.Add(people);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(people);
        }


        public async Task<IActionResult> UserCreate(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("User", "Admin");
            }
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> UserDelete(int id)
        {
            var user = await _context.User.FindAsync(id);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("User", "Admin");
        }

        public async Task<IActionResult> UserEdit(User user)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeopleExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("User", "Admin");
            }
            return View(user);
        }

        // GET: People/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var people = await _context.Person.FindAsync(id);
        //    if (people == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(people);
        //}

        //// POST: People/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string action, int id, string hes)
        {

            ProlizData prolizData = _context.ProlizData.FirstOrDefault(i => i.Id ==id);
            prolizData.HESKOD = hes;
            _context.ProlizData.Update(prolizData);
            _context.SaveChanges();
            return RedirectToAction(action, "HumanResources");
            
        }

        // GET: People/Delete/5


        // POST: People/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, string action)
        {
            var people = await _context.Person.FindAsync(id);
            _context.Person.Remove(people);
            await _context.SaveChangesAsync();
            return RedirectToAction(action, "Admin");
        }

        private bool PeopleExists(int id)
        {
            return _context.Person.Any(e => e.Id == id);
        }

        public JsonResult getData(int ID)
        {
            ProlizData people = new ProlizData();
            people = _context.ProlizData.FirstOrDefault(i => i.Id == ID);
            //var json = JsonConvert.SerializeObject(result);
            return Json(people);

        }


        public IActionResult GetStudentInfo(string tc)
        {

            IProlizServiceManager mng = new ProlizServiceManager();


            var data = mng.GetStudentInfoOnProliz(tc, "");
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



            HttpContext.Session.SetString("studentInfo", tc);


            return View(studentInfo);
        }


        [HttpGet]
        public ActionResult GetEmployee()
        {
            return View();
        }
        public async Task<IActionResult> GetEmployee(string tc)
        {

            ProlizData prolizData = new ProlizData();
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            if (tc == null)
            {
                ViewBag.Error = "Kişi Bulunamadı!";
                return View(employeeViewModel);
            }


            prolizData = _context.ProlizData.FirstOrDefault(i => i.TCKIMLIKNO == tc && i.TIP != "Öğrenci");


            if (prolizData == null)
            {
                IUyumsoftServiceManager mng = new UyumsoftServiceManager();

                var dataProliz = mng.GetEmployee(tc);
                if (dataProliz.Adı != null)
                {
                    ProlizData proliz = new ProlizData();
                    proliz.Ad = dataProliz.Adı;
                    proliz.Soyad = dataProliz.Soyadı;
                    proliz.Departman = dataProliz.Gorev;
                    proliz.TIP = dataProliz.IstihdamTuru;
                    proliz.TCKIMLIKNO = dataProliz.TcKimlikNo;
                    employeeViewModel.ProlizData = proliz;

                }
                else
                {
                    ViewBag.Error = "Kişi Bulunamadı!";
                    return View(employeeViewModel);
                }

            }
            else
            {
                employeeViewModel.ProlizData = prolizData;
                var kartData = PullData(tc);
                employeeViewModel.KimlikKarti = kartData;
            }




            if (employeeViewModel.ProlizData == null && employeeViewModel.KimlikKarti.Count == 0)
            {
                ViewBag.Error = "Kişi Bulunamadı!";
            }
            return View(employeeViewModel);

        }

        private DataTable dataTable = new DataTable();
        public List<KimlikKarti> PullData(string parametre)
        {
            string connString = @"Server=10.20.1.124; Database=Halic_Agora; user id=service-konfides;password=Pqnajen34!+391284;";
            string query = $"select bc.Id as 'KartNo',bc.SerialNumberHexString as 'KartSeriNo',BI.Ssn as 'KimlikNo',bc.OwnerFirstName as 'Ad',bc.OwnerLastName as 'Soyad',BI.Name as 'AdSoyad',bc.IsBlackListed as 'GeciciKaraListe',bc.IsPermanentlyBlacklisted as 'KaraListe',skT.Name as 'Kirilim1',skT1.Name as 'Kirilim2',skt2.Name as 'Kirilim3',skp1.Name as 'Kirilim4',skt3.Name as 'Kirilim5',skpt.Name as 'KartTipi',ccBLR.Name as 'Durum',ccBLR.PosTextFormat as 'DurumAciklama'from bo_Card bc inner join Card_Parameters cp on bc.Id = cp.Card_Id left outer join Campus_Core_CampusCardOwnerShip ccCOS on bc.OwnershipId = ccCOS.CardOwnershipId left outer join SharedKernel_CardOwnershipBase scCOS on ccCos.CardOwnershipId = scCOS.Id left outer join bo_Individual BI on bc.OwnerId = BI.Id left outer join SharedKernel_CardOwnershipBase scCOS2 on BI.CardOwnershipId = scCOS2.Id left outer join Campus_Core_CampusCardOwnership ccCOS2 on scCOS2.Id = ccCOS2.CardOwnershipId left outer join SharedKernel_PersonalityBase skP on bc.PersonalityId = skP.Id left outer join SharedKernel_PersonalityType skPT on skP.PersonalityTypeId = skPT.Id left outer join SharedKernel_Position skp1 on skP.PositionId = skp1.Id left outer join SharedKernel_Tier skT on skP.TierOneId = skT.Id left outer join SharedKernel_Tier skT1 on skP.TierTwoId = skT1.Id left outer join SharedKernel_Tier skT2 on skP.TierThreeId = skT2.Id left outer join SharedKernel_Tier skT3 on skP.TierFourId = skT3.Id left outer join Campus_Core_CardBlacklistingUpdateOrder ccCBL on bc.LastBlacklistingOrderId = ccCBL.Id left outer join Campus_Core_BlacklistingReason ccBLR on ccCBL.ReasonId = ccBLR.Id left outer join TerminalEODGroup tG on bc.TerminalEodGroupId = tG.ID where BI.Ssn = '{parametre}'";

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(query, conn);

            conn.Open();

            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // this will query your database and return the result to your datatable
            da.Fill(dataTable);
            conn.Close();
            da.Dispose();

            // var data =  ConvertDataTable<KimlikKarti>(dataTable);

            var data = Helper.DataTableToList<KimlikKarti>(dataTable).ToList();

            return data;
        }

        public IActionResult HesUpdate()
        {
            List<EmployeeHesInfo> employeeHesInfos = new List<EmployeeHesInfo>();
            foreach (var item in _context.EmployeeHesInfo)
            {
                employeeHesInfos.Add(item);
            }
            for (int i = 0; i < employeeHesInfos.Count; i++)
            {
                ProlizData prolizData = _context.ProlizData.FirstOrDefault(j => j.TCKIMLIKNO == employeeHesInfos[i].Tc);
                if (prolizData != null)
                {
                    prolizData.HESKOD = employeeHesInfos[i].HesKodu;
                    _context.Update(prolizData);
                }
                
            }
            _context.SaveChanges();

            return View();
        }


        public IActionResult Excel(int param)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Tüm Liste");
                var currentRow = 5;
                worksheet.Range("B2:J3").Merge();
                
                worksheet.Cell(2,2).Value = "Tüm Personel Listesi";
                worksheet.Cell(2, 2).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                worksheet.Cell(2, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(2, 2).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 1).Value = "Tc";
                worksheet.Cell(currentRow, 2).Value = "Ad";
                worksheet.Cell(currentRow, 3).Value = "Soyad";
                worksheet.Cell(currentRow, 4).Value = "Unvanı";
                worksheet.Cell(currentRow, 5).Value = "Çalışan Tipi";
                worksheet.Cell(currentRow, 6).Value = "Hes Kodu";
                worksheet.Cell(currentRow, 7).Value = "Sağlık Durumu";
                worksheet.Cell(currentRow, 8).Value = "Aşı Durumu";
                worksheet.Cell(currentRow, 9).Value = "Bağışıklık Durumu";
                worksheet.Cell(currentRow, 10).Value = "Telefon";
                worksheet.Cell(currentRow, 11).Value = "Email";
                worksheet.Cell(currentRow, 1).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 2).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 3).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 4).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 5).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 6).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 7).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 8).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 9).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 10).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 11).Style.Font.Bold = true;
                foreach (var apply in _context.ProlizData.Where(i => i.TIP != "Öğrenci"))
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = apply.TCKIMLIKNO;
                    worksheet.Cell(currentRow, 2).Value = apply.Ad;
                    worksheet.Cell(currentRow, 3).Value = apply.Soyad;
                    worksheet.Cell(currentRow, 4).Value = apply.Departman;
                    worksheet.Cell(currentRow, 5).Value = apply.TIP;
                    worksheet.Cell(currentRow, 6).Value = apply.HESKOD;
                    if (apply.current_health_status == "RISKY")
                    {
                        worksheet.Cell(currentRow, 7).Value = "Riskli";
                    }
                    else if (apply.current_health_status == "RISKLESS")
                    {
                        worksheet.Cell(currentRow, 7).Value = "Riskli Değil";
                    }
                    else
                    {
                        worksheet.Cell(currentRow, 7).Value = "";
                    }


                    if (apply.is_vaccinated == true)
                    {
                        worksheet.Cell(currentRow, 8).Value = "Covid-19 Aşıları Tamamlanmıştır";
                    }
                    else if (apply.is_vaccinated == false)
                    {
                        worksheet.Cell(currentRow, 8).Value = "Covid-19 Aşıları Tamamlanmamıştır";
                    }
                    else
                    {
                        worksheet.Cell(currentRow, 8).Value = "";
                    }


                    if (apply.is_immune == true)
                    {
                        worksheet.Cell(currentRow, 9).Value = "Evet";
                    }
                    else if (apply.is_immune == false)
                    {
                        worksheet.Cell(currentRow, 9).Value = "Hayır";
                    }
                    else
                    {
                        worksheet.Cell(currentRow, 9).Value = "";
                    }
                    worksheet.Cell(currentRow, 10).Value = apply.Phone;
                    worksheet.Cell(currentRow, 11).Value = apply.Email;

                }
                worksheet.Columns("A:K").AdjustToContents();

                var hesSheet = workbook.Worksheets.Add("Hes Kodu Aktif Personel Listesi");
                var hesRow = 5;
                hesSheet.Range("B2:J3").Merge();

                hesSheet.Cell(2, 2).Value = "Hes Kodu Aktif Olan Personeller";
                hesSheet.Cell(2, 2).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                hesSheet.Cell(2, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                hesSheet.Cell(2, 2).Style.Font.Bold = true;
                hesSheet.Cell(hesRow, 1).Value = "Tc";
                hesSheet.Cell(hesRow, 2).Value = "Ad";
                hesSheet.Cell(hesRow, 3).Value = "Soyad";
                hesSheet.Cell(hesRow, 4).Value = "Unvanı";
                hesSheet.Cell(hesRow, 5).Value = "Çalışan Tipi";
                hesSheet.Cell(hesRow, 6).Value = "Hes Kodu";
                hesSheet.Cell(hesRow, 7).Value = "Sağlık Durumu";
                hesSheet.Cell(hesRow, 8).Value = "Aşı Durumu";
                hesSheet.Cell(hesRow, 9).Value = "Bağışıklık Durumu";
                hesSheet.Cell(hesRow, 10).Value = "Telefon";
                hesSheet.Cell(hesRow, 11).Value = "Email";
                hesSheet.Cell(hesRow, 1).Style.Font.Bold = true;
                hesSheet.Cell(hesRow, 2).Style.Font.Bold = true;
                hesSheet.Cell(hesRow, 3).Style.Font.Bold = true;
                hesSheet.Cell(hesRow, 4).Style.Font.Bold = true;
                hesSheet.Cell(hesRow, 5).Style.Font.Bold = true;
                hesSheet.Cell(hesRow, 6).Style.Font.Bold = true;
                hesSheet.Cell(hesRow, 7).Style.Font.Bold = true;
                hesSheet.Cell(hesRow, 8).Style.Font.Bold = true;
                hesSheet.Cell(hesRow, 9).Style.Font.Bold = true;
                hesSheet.Cell(hesRow, 10).Style.Font.Bold = true;
                hesSheet.Cell(hesRow, 11).Style.Font.Bold = true;
                foreach (var apply in _context.ProlizData.Where(i => i.TIP != "Öğrenci" && i.current_health_status != null))
                {
                    hesRow++;
                    hesSheet.Cell(hesRow, 1).Value = apply.TCKIMLIKNO;
                    hesSheet.Cell(hesRow, 2).Value = apply.Ad;
                    hesSheet.Cell(hesRow, 3).Value = apply.Soyad;
                    hesSheet.Cell(hesRow, 4).Value = apply.Departman;
                    hesSheet.Cell(hesRow, 5).Value = apply.TIP;
                    hesSheet.Cell(hesRow, 6).Value = apply.HESKOD;
                    if (apply.current_health_status == "RISKY")
                    {
                        hesSheet.Cell(hesRow, 7).Value = "Riskli";
                    }
                    else if (apply.current_health_status == "RISKLESS")
                    {
                        hesSheet.Cell(hesRow, 7).Value = "Riskli Değil";
                    }
                    else
                    {
                        hesSheet.Cell(hesRow, 7).Value = "";
                    }

                    if (apply.is_vaccinated == true)
                    {
                        hesSheet.Cell(hesRow, 8).Value = "Covid-19 Aşıları Tamamlanmıştır";
                    }
                    else if (apply.is_vaccinated == false)
                    {
                        hesSheet.Cell(hesRow, 8).Value = "Covid-19 Aşıları Tamamlanmamıştır";
                    }
                    else
                    {
                        hesSheet.Cell(hesRow, 8).Value = "";
                    }

                    if (apply.is_immune == true)
                    {
                        hesSheet.Cell(hesRow, 9).Value = "Evet";
                    }
                    else if (apply.is_immune == false)
                    {
                        hesSheet.Cell(hesRow, 9).Value = "Hayır";
                    }
                    else
                    {
                        hesSheet.Cell(hesRow, 9).Value = "";
                    }
                    hesSheet.Cell(hesRow, 10).Value = apply.Phone;
                    hesSheet.Cell(hesRow, 11).Value = apply.Email;
                }
                hesSheet.Columns("A:K").AdjustToContents();

                var risklessSheet = workbook.Worksheets.Add("Sağlıklı Personel Listesi");
                var risklessRow = 5;
                risklessSheet.Range("B2:J3").Merge();

                risklessSheet.Cell(2, 2).Value = "Hes Kodu Durumu Riskli Olmayan Personeller";
                risklessSheet.Cell(2, 2).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                risklessSheet.Cell(2, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                risklessSheet.Cell(2, 2).Style.Font.Bold = true;
                risklessSheet.Cell(risklessRow, 1).Value = "Tc";
                risklessSheet.Cell(risklessRow, 2).Value = "Ad";
                risklessSheet.Cell(risklessRow, 3).Value = "Soyad";
                risklessSheet.Cell(risklessRow, 4).Value = "Unvanı";
                risklessSheet.Cell(risklessRow, 5).Value = "Çalışan Tipi";
                risklessSheet.Cell(risklessRow, 6).Value = "Hes Kodu";
                risklessSheet.Cell(risklessRow, 7).Value = "Sağlık Durumu";
                risklessSheet.Cell(risklessRow, 8).Value = "Aşı Durumu";
                risklessSheet.Cell(risklessRow, 9).Value = "Bağışıklık Durumu";
                risklessSheet.Cell(risklessRow, 10).Value = "Telefon";
                risklessSheet.Cell(risklessRow, 11).Value = "Email";
                risklessSheet.Cell(risklessRow, 1).Style.Font.Bold = true;
                risklessSheet.Cell(risklessRow, 2).Style.Font.Bold = true;
                risklessSheet.Cell(risklessRow, 3).Style.Font.Bold = true;
                risklessSheet.Cell(risklessRow, 4).Style.Font.Bold = true;
                risklessSheet.Cell(risklessRow, 5).Style.Font.Bold = true;
                risklessSheet.Cell(risklessRow, 6).Style.Font.Bold = true;
                risklessSheet.Cell(risklessRow, 7).Style.Font.Bold = true;
                risklessSheet.Cell(risklessRow, 8).Style.Font.Bold = true;
                risklessSheet.Cell(risklessRow, 9).Style.Font.Bold = true;
                risklessSheet.Cell(risklessRow, 10).Style.Font.Bold = true;
                risklessSheet.Cell(risklessRow, 11).Style.Font.Bold = true;
                foreach (var apply in _context.ProlizData.Where(i => i.TIP != "Öğrenci" && i.current_health_status == "RISKLESS"))
                {
                    risklessRow++;
                    risklessSheet.Cell(risklessRow, 1).Value = apply.TCKIMLIKNO;
                    risklessSheet.Cell(risklessRow, 2).Value = apply.Ad;
                    risklessSheet.Cell(risklessRow, 3).Value = apply.Soyad;
                    risklessSheet.Cell(risklessRow, 4).Value = apply.Departman;
                    risklessSheet.Cell(risklessRow, 5).Value = apply.TIP;
                    risklessSheet.Cell(risklessRow, 6).Value = apply.HESKOD;
                    if (apply.current_health_status == "RISKY")
                    {
                        risklessSheet.Cell(risklessRow, 7).Value = "Riskli";
                    }
                    else if (apply.current_health_status == "RISKLESS")
                    {
                        risklessSheet.Cell(risklessRow, 7).Value = "Riskli Değil";
                    }
                    else
                    {
                        risklessSheet.Cell(risklessRow, 7).Value = "";
                    }


                    if (apply.is_vaccinated == true)
                    {
                        risklessSheet.Cell(risklessRow, 8).Value = "Covid-19 Aşıları Tamamlanmıştır";
                    }
                    else if (apply.is_vaccinated == false)
                    {
                        risklessSheet.Cell(risklessRow, 8).Value = "Covid-19 Aşıları Tamamlanmamıştır";
                    }
                    else
                    {
                        risklessSheet.Cell(risklessRow, 8).Value = "";
                    }

                    if (apply.is_immune == true)
                    {
                        risklessSheet.Cell(risklessRow, 9).Value = "Evet";
                    }
                    else if (apply.is_immune == false)
                    {
                        risklessSheet.Cell(risklessRow, 9).Value = "Hayır";
                    }
                    else
                    {
                        risklessSheet.Cell(risklessRow, 9).Value = "";
                    }
                    risklessSheet.Cell(risklessRow, 10).Value = apply.Phone;
                    risklessSheet.Cell(risklessRow, 11).Value = apply.Email;
                }
                risklessSheet.Columns("A:K").AdjustToContents();

                var riskySheet = workbook.Worksheets.Add("Riskli Personel Listesi");
                var riskyRow = 5;
                riskySheet.Range("B2:J3").Merge();

                riskySheet.Cell(2, 2).Value = "Hes Kodu Durumu Riskli Olan Personeller";
                riskySheet.Cell(2, 2).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                riskySheet.Cell(2, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                riskySheet.Cell(2, 2).Style.Font.Bold = true;
                riskySheet.Cell(riskyRow, 1).Value = "Tc";
                riskySheet.Cell(riskyRow, 2).Value = "Ad";
                riskySheet.Cell(riskyRow, 3).Value = "Soyad";
                riskySheet.Cell(riskyRow, 4).Value = "Unvanı";
                riskySheet.Cell(riskyRow, 5).Value = "Çalışan Tipi";
                riskySheet.Cell(riskyRow, 6).Value = "Hes Kodu";
                riskySheet.Cell(riskyRow, 7).Value = "Sağlık Durumu";
                riskySheet.Cell(riskyRow, 8).Value = "Aşı Durumu";
                riskySheet.Cell(riskyRow, 9).Value = "Bağışıklık Durumu";
                riskySheet.Cell(riskyRow, 10).Value = "Telefon";
                riskySheet.Cell(riskyRow, 11).Value = "Email";
                riskySheet.Cell(riskyRow, 1).Style.Font.Bold = true;
                riskySheet.Cell(riskyRow, 2).Style.Font.Bold = true;
                riskySheet.Cell(riskyRow, 3).Style.Font.Bold = true;
                riskySheet.Cell(riskyRow, 4).Style.Font.Bold = true;
                riskySheet.Cell(riskyRow, 5).Style.Font.Bold = true;
                riskySheet.Cell(riskyRow, 6).Style.Font.Bold = true;
                riskySheet.Cell(riskyRow, 7).Style.Font.Bold = true;
                riskySheet.Cell(riskyRow, 8).Style.Font.Bold = true;
                riskySheet.Cell(riskyRow, 9).Style.Font.Bold = true;
                riskySheet.Cell(riskyRow, 10).Style.Font.Bold = true;
                riskySheet.Cell(riskyRow, 11).Style.Font.Bold = true;
                foreach (var apply in _context.ProlizData.Where(i => i.TIP != "Öğrenci" && i.current_health_status == "RISKY"))
                {
                    riskyRow++;
                    riskySheet.Cell(riskyRow, 1).Value = apply.TCKIMLIKNO;
                    riskySheet.Cell(riskyRow, 2).Value = apply.Ad;
                    riskySheet.Cell(riskyRow, 3).Value = apply.Soyad;
                    riskySheet.Cell(riskyRow, 4).Value = apply.Departman;
                    riskySheet.Cell(riskyRow, 5).Value = apply.TIP;
                    riskySheet.Cell(riskyRow, 6).Value = apply.HESKOD;
                    if (apply.current_health_status == "RISKY")
                    {
                        riskySheet.Cell(riskyRow, 7).Value = "Riskli";
                    }
                    else if (apply.current_health_status == "RISKLESS")
                    {
                        riskySheet.Cell(riskyRow, 7).Value = "Riskli Değil";
                    }
                    else
                    {
                        riskySheet.Cell(riskyRow, 7).Value = "";
                    }


                    if (apply.is_vaccinated == true)
                    {
                        riskySheet.Cell(riskyRow, 8).Value = "Covid-19 Aşıları Tamamlanmıştır";
                    }
                    else if (apply.is_vaccinated == false)
                    {
                        riskySheet.Cell(riskyRow, 8).Value = "Covid-19 Aşıları Tamamlanmamıştır";
                    }
                    else
                    {
                        riskySheet.Cell(riskyRow, 8).Value = "";
                    }

                    if (apply.is_immune == true)
                    {
                        riskySheet.Cell(riskyRow, 9).Value = "Evet";
                    }
                    else if (apply.is_immune == false)
                    {
                        riskySheet.Cell(riskyRow, 9).Value = "Hayır";
                    }
                    else
                    {
                        riskySheet.Cell(riskyRow, 9).Value = "";
                    }
                    riskySheet.Cell(riskyRow, 10).Value = apply.Phone;
                    riskySheet.Cell(riskyRow, 11).Value = apply.Email;
                }
                riskySheet.Columns("A:K").AdjustToContents();

                var errorSheet = workbook.Worksheets.Add("Hes Kodu Hatalı Listesi");
                var errorRow = 5;
                errorSheet.Range("B2:J3").Merge();

                errorSheet.Cell(2, 2).Value = "Hes Kodu Bildirmeyen, Hatalı veya Süresi Dolmuş Personeller ";
                errorSheet.Cell(2, 2).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                errorSheet.Cell(2, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                errorSheet.Cell(2, 2).Style.Font.Bold = true;
                errorSheet.Cell(errorRow, 1).Value = "Tc";
                errorSheet.Cell(errorRow, 2).Value = "Ad";
                errorSheet.Cell(errorRow, 3).Value = "Soyad";
                errorSheet.Cell(errorRow, 4).Value = "Unvanı";
                errorSheet.Cell(errorRow, 5).Value = "Çalışan Tipi";
                errorSheet.Cell(errorRow, 6).Value = "Hes Kodu";
                errorSheet.Cell(errorRow, 7).Value = "Sağlık Durumu";
                errorSheet.Cell(errorRow, 8).Value = "Aşı Durumu";
                errorSheet.Cell(errorRow, 9).Value = "Bağışıklık Durumu";
                errorSheet.Cell(errorRow, 10).Value = "Telefon";
                errorSheet.Cell(errorRow, 11).Value = "Email";
                errorSheet.Cell(errorRow, 1).Style.Font.Bold = true;
                errorSheet.Cell(errorRow, 2).Style.Font.Bold = true;
                errorSheet.Cell(errorRow, 3).Style.Font.Bold = true;
                errorSheet.Cell(errorRow, 4).Style.Font.Bold = true;
                errorSheet.Cell(errorRow, 5).Style.Font.Bold = true;
                errorSheet.Cell(errorRow, 6).Style.Font.Bold = true;
                errorSheet.Cell(errorRow, 7).Style.Font.Bold = true;
                errorSheet.Cell(errorRow, 8).Style.Font.Bold = true;
                errorSheet.Cell(errorRow, 9).Style.Font.Bold = true;
                errorSheet.Cell(errorRow, 10).Style.Font.Bold = true;
                errorSheet.Cell(errorRow, 11).Style.Font.Bold = true;
                foreach (var apply in _context.ProlizData.Where(i => i.TIP != "Öğrenci" && i.current_health_status == null))
                {
                    errorRow++;
                    errorSheet.Cell(errorRow, 1).Value = apply.TCKIMLIKNO;
                    errorSheet.Cell(errorRow, 2).Value = apply.Ad;
                    errorSheet.Cell(errorRow, 3).Value = apply.Soyad;
                    errorSheet.Cell(errorRow, 4).Value = apply.Departman;
                    errorSheet.Cell(errorRow, 5).Value = apply.TIP;
                    errorSheet.Cell(errorRow, 6).Value = apply.HESKOD;
                    if (apply.current_health_status == "RISKY")
                    {
                        errorSheet.Cell(errorRow, 7).Value = "Riskli";
                    }
                    else if (apply.current_health_status == "RISKLESS")
                    {
                        errorSheet.Cell(errorRow, 7).Value = "Riskli Değil";
                    }
                    else
                    {
                        errorSheet.Cell(errorRow, 7).Value = "";
                    }


                    if (apply.is_vaccinated == true)
                    {
                        errorSheet.Cell(errorRow, 8).Value = "Covid-19 Aşıları Tamamlanmıştır";
                    }
                    else if (apply.is_vaccinated == false)
                    {
                        errorSheet.Cell(errorRow, 8).Value = "Covid-19 Aşıları Tamamlanmamıştır";
                    }
                    else
                    {
                        errorSheet.Cell(errorRow, 8).Value = "";
                    }

                    if (apply.is_immune == true)
                    {
                        errorSheet.Cell(errorRow, 9).Value = "Evet";
                    }
                    else if (apply.is_immune == false)
                    {
                        errorSheet.Cell(errorRow, 9).Value = "Hayır";
                    }
                    else
                    {
                        errorSheet.Cell(errorRow, 9).Value = "";
                    }
                    errorSheet.Cell(errorRow, 10).Value = apply.Phone;
                    errorSheet.Cell(errorRow, 11).Value = apply.Email;
                }
                errorSheet.Columns("A:K").AdjustToContents();

                var vaccinatedSheet = workbook.Worksheets.Add("Aşı Olan Personel Listesi");
                var vaccinatedRow = 5;
                vaccinatedSheet.Range("B2:J3").Merge();

                vaccinatedSheet.Cell(2, 2).Value = "Tüm Aşılarını Tamamlayan Personeller";
                vaccinatedSheet.Cell(2, 2).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                vaccinatedSheet.Cell(2, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                vaccinatedSheet.Cell(2, 2).Style.Font.Bold = true;
                vaccinatedSheet.Cell(vaccinatedRow, 1).Value = "Tc";
                vaccinatedSheet.Cell(vaccinatedRow, 2).Value = "Ad";
                vaccinatedSheet.Cell(vaccinatedRow, 3).Value = "Soyad";
                vaccinatedSheet.Cell(vaccinatedRow, 4).Value = "Unvanı";
                vaccinatedSheet.Cell(vaccinatedRow, 5).Value = "Çalışan Tipi";
                vaccinatedSheet.Cell(vaccinatedRow, 6).Value = "Hes Kodu";
                vaccinatedSheet.Cell(vaccinatedRow, 7).Value = "Sağlık Durumu";
                vaccinatedSheet.Cell(vaccinatedRow, 8).Value = "Aşı Durumu";
                vaccinatedSheet.Cell(vaccinatedRow, 9).Value = "Bağışıklık Durumu";
                vaccinatedSheet.Cell(vaccinatedRow, 10).Value = "Telefon";
                vaccinatedSheet.Cell(vaccinatedRow, 11).Value = "Email";
                vaccinatedSheet.Cell(vaccinatedRow, 1).Style.Font.Bold = true;
                vaccinatedSheet.Cell(vaccinatedRow, 2).Style.Font.Bold = true;
                vaccinatedSheet.Cell(vaccinatedRow, 3).Style.Font.Bold = true;
                vaccinatedSheet.Cell(vaccinatedRow, 4).Style.Font.Bold = true;
                vaccinatedSheet.Cell(vaccinatedRow, 5).Style.Font.Bold = true;
                vaccinatedSheet.Cell(vaccinatedRow, 6).Style.Font.Bold = true;
                vaccinatedSheet.Cell(vaccinatedRow, 7).Style.Font.Bold = true;
                vaccinatedSheet.Cell(vaccinatedRow, 8).Style.Font.Bold = true;
                vaccinatedSheet.Cell(vaccinatedRow, 9).Style.Font.Bold = true;
                vaccinatedSheet.Cell(vaccinatedRow, 10).Style.Font.Bold = true;
                vaccinatedSheet.Cell(vaccinatedRow, 11).Style.Font.Bold = true;
                foreach (var apply in _context.ProlizData.Where(i => i.TIP != "Öğrenci" && i.is_vaccinated == true))
                {
                    vaccinatedRow++;
                    vaccinatedSheet.Cell(vaccinatedRow, 1).Value = apply.TCKIMLIKNO;
                    vaccinatedSheet.Cell(vaccinatedRow, 2).Value = apply.Ad;
                    vaccinatedSheet.Cell(vaccinatedRow, 3).Value = apply.Soyad;
                    vaccinatedSheet.Cell(vaccinatedRow, 4).Value = apply.Departman;
                    vaccinatedSheet.Cell(vaccinatedRow, 5).Value = apply.TIP;
                    vaccinatedSheet.Cell(vaccinatedRow, 6).Value = apply.HESKOD;
                    if (apply.current_health_status == "RISKY")
                    {
                        vaccinatedSheet.Cell(vaccinatedRow, 7).Value = "Riskli";
                    }
                    else if (apply.current_health_status == "RISKLESS")
                    {
                        vaccinatedSheet.Cell(vaccinatedRow, 7).Value = "Riskli Değil";
                    }
                    else
                    {
                        vaccinatedSheet.Cell(vaccinatedRow, 7).Value = "";
                    }


                    if (apply.is_vaccinated == true)
                    {
                        vaccinatedSheet.Cell(vaccinatedRow, 8).Value = "Covid-19 Aşıları Tamamlanmıştır";
                    }
                    else if (apply.is_vaccinated == false)
                    {
                        vaccinatedSheet.Cell(vaccinatedRow, 8).Value = "Covid-19 Aşıları Tamamlanmamıştır";
                    }
                    else
                    {
                        vaccinatedSheet.Cell(vaccinatedRow, 8).Value = "";
                    }

                    if (apply.is_immune == true)
                    {
                        vaccinatedSheet.Cell(vaccinatedRow, 9).Value = "Evet";
                    }
                    else if (apply.is_immune == false)
                    {
                        vaccinatedSheet.Cell(vaccinatedRow, 9).Value = "Hayır";
                    }
                    else
                    {
                        vaccinatedSheet.Cell(vaccinatedRow, 9).Value = "";
                    }
                    vaccinatedSheet.Cell(vaccinatedRow, 10).Value = apply.Phone;
                    vaccinatedSheet.Cell(vaccinatedRow, 11).Value = apply.Email;
                }
                vaccinatedSheet.Columns("A:K").AdjustToContents();


                var unVaccinatedSheet = workbook.Worksheets.Add("Aşı Olmayan Personel Listesi");
                var unVaccinatedRow = 5;
                unVaccinatedSheet.Range("B2:J3").Merge();

                unVaccinatedSheet.Cell(2, 2).Value = "Tüm Aşılarını Tamamlamayan veya Son Aşısının Üstünden 14 Gün Geçmeyen Personeller";
                unVaccinatedSheet.Cell(2, 2).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                unVaccinatedSheet.Cell(2, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                unVaccinatedSheet.Cell(2, 2).Style.Font.Bold = true;
                unVaccinatedSheet.Cell(unVaccinatedRow, 1).Value = "Tc";
                unVaccinatedSheet.Cell(unVaccinatedRow, 2).Value = "Ad";
                unVaccinatedSheet.Cell(unVaccinatedRow, 3).Value = "Soyad";
                unVaccinatedSheet.Cell(unVaccinatedRow, 4).Value = "Unvanı";
                unVaccinatedSheet.Cell(unVaccinatedRow, 5).Value = "Çalışan Tipi";
                unVaccinatedSheet.Cell(unVaccinatedRow, 6).Value = "Hes Kodu";
                unVaccinatedSheet.Cell(unVaccinatedRow, 7).Value = "Sağlık Durumu";
                unVaccinatedSheet.Cell(unVaccinatedRow, 8).Value = "Aşı Durumu";
                unVaccinatedSheet.Cell(unVaccinatedRow, 9).Value = "Bağışıklık Durumu";
                unVaccinatedSheet.Cell(unVaccinatedRow, 10).Value = "Telefon";
                unVaccinatedSheet.Cell(unVaccinatedRow, 11).Value = "Email";
                unVaccinatedSheet.Cell(unVaccinatedRow, 1).Style.Font.Bold = true;
                unVaccinatedSheet.Cell(unVaccinatedRow, 2).Style.Font.Bold = true;
                unVaccinatedSheet.Cell(unVaccinatedRow, 3).Style.Font.Bold = true;
                unVaccinatedSheet.Cell(unVaccinatedRow, 4).Style.Font.Bold = true;
                unVaccinatedSheet.Cell(unVaccinatedRow, 5).Style.Font.Bold = true;
                unVaccinatedSheet.Cell(unVaccinatedRow, 6).Style.Font.Bold = true;
                unVaccinatedSheet.Cell(unVaccinatedRow, 7).Style.Font.Bold = true;
                unVaccinatedSheet.Cell(unVaccinatedRow, 8).Style.Font.Bold = true;
                unVaccinatedSheet.Cell(unVaccinatedRow, 9).Style.Font.Bold = true;
                unVaccinatedSheet.Cell(unVaccinatedRow, 10).Style.Font.Bold = true;
                unVaccinatedSheet.Cell(unVaccinatedRow, 11).Style.Font.Bold = true;
                foreach (var apply in _context.ProlizData.Where(i => i.TIP != "Öğrenci" && i.is_vaccinated == false))
                {
                    unVaccinatedRow++;
                    unVaccinatedSheet.Cell(unVaccinatedRow, 1).Value = apply.TCKIMLIKNO;
                    unVaccinatedSheet.Cell(unVaccinatedRow, 2).Value = apply.Ad;
                    unVaccinatedSheet.Cell(unVaccinatedRow, 3).Value = apply.Soyad;
                    unVaccinatedSheet.Cell(unVaccinatedRow, 4).Value = apply.Departman;
                    unVaccinatedSheet.Cell(unVaccinatedRow, 5).Value = apply.TIP;
                    unVaccinatedSheet.Cell(unVaccinatedRow, 6).Value = apply.HESKOD;
                    if (apply.current_health_status == "RISKY")
                    {
                        unVaccinatedSheet.Cell(unVaccinatedRow, 7).Value = "Riskli";
                    }
                    else if (apply.current_health_status == "RISKLESS")
                    {
                        unVaccinatedSheet.Cell(unVaccinatedRow, 7).Value = "Riskli Değil";
                    }
                    else
                    {
                        unVaccinatedSheet.Cell(unVaccinatedRow, 7).Value = "";
                    }


                    if (apply.is_vaccinated == true)
                    {
                        unVaccinatedSheet.Cell(unVaccinatedRow, 8).Value = "Covid-19 Aşıları Tamamlanmıştır";
                    }
                    else if (apply.is_vaccinated == false)
                    {
                        unVaccinatedSheet.Cell(unVaccinatedRow, 8).Value = "Covid-19 Aşıları Tamamlanmamıştır";
                    }
                    else
                    {
                        unVaccinatedSheet.Cell(unVaccinatedRow, 8).Value = "";
                    }


                    if (apply.is_immune == true)
                    {
                        unVaccinatedSheet.Cell(unVaccinatedRow, 9).Value = "Evet";
                    }
                    else if (apply.is_immune == false)
                    {
                        unVaccinatedSheet.Cell(unVaccinatedRow, 9).Value = "Hayır";
                    }
                    else
                    {
                        unVaccinatedSheet.Cell(unVaccinatedRow, 9).Value = "";
                    }
                    unVaccinatedSheet.Cell(unVaccinatedRow, 10).Value = apply.Phone;
                    unVaccinatedSheet.Cell(unVaccinatedRow, 11).Value = apply.Email;
                }
                unVaccinatedSheet.Columns("A:K").AdjustToContents();

                var notShareSheet = workbook.Worksheets.Add("Paylaşım İzni Vermeyenler");
                var notShareRow = 5;
                notShareSheet.Range("B2:J3").Merge();

                notShareSheet.Cell(2, 2).Value = "Hes Uygulamasından Bilgi Paylaşımına İzin Vermeyen Personeller";
                notShareSheet.Cell(2, 2).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                notShareSheet.Cell(2, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                notShareSheet.Cell(2, 2).Style.Font.Bold = true;
                notShareSheet.Cell(notShareRow, 1).Value = "Tc";
                notShareSheet.Cell(notShareRow, 2).Value = "Ad";
                notShareSheet.Cell(notShareRow, 3).Value = "Soyad";
                notShareSheet.Cell(notShareRow, 4).Value = "Unvanı";
                notShareSheet.Cell(notShareRow, 5).Value = "Çalışan Tipi";
                notShareSheet.Cell(notShareRow, 6).Value = "Hes Kodu";
                notShareSheet.Cell(notShareRow, 7).Value = "Sağlık Durumu";
                notShareSheet.Cell(notShareRow, 8).Value = "Aşı Durumu";
                notShareSheet.Cell(notShareRow, 9).Value = "Bağışıklık Durumu";
                notShareSheet.Cell(notShareRow, 10).Value = "Telefon";
                notShareSheet.Cell(notShareRow, 11).Value = "Email";
                notShareSheet.Cell(notShareRow, 1).Style.Font.Bold = true;
                notShareSheet.Cell(notShareRow, 2).Style.Font.Bold = true;
                notShareSheet.Cell(notShareRow, 3).Style.Font.Bold = true;
                notShareSheet.Cell(notShareRow, 4).Style.Font.Bold = true;
                notShareSheet.Cell(notShareRow, 5).Style.Font.Bold = true;
                notShareSheet.Cell(notShareRow, 6).Style.Font.Bold = true;
                notShareSheet.Cell(notShareRow, 7).Style.Font.Bold = true;
                notShareSheet.Cell(notShareRow, 8).Style.Font.Bold = true;
                notShareSheet.Cell(notShareRow, 9).Style.Font.Bold = true;
                notShareSheet.Cell(notShareRow, 10).Style.Font.Bold = true;
                notShareSheet.Cell(notShareRow, 11).Style.Font.Bold = true;
                foreach (var apply in _context.ProlizData.Where(i => i.TIP != "Öğrenci" && (i.is_vaccinated == null || i.is_immune == null || i.is_test_data_shared == null) && i.current_health_status != null))
                {
                    notShareRow++;
                    notShareSheet.Cell(notShareRow, 1).Value = apply.TCKIMLIKNO;
                    notShareSheet.Cell(notShareRow, 2).Value = apply.Ad;
                    notShareSheet.Cell(notShareRow, 3).Value = apply.Soyad;
                    notShareSheet.Cell(notShareRow, 4).Value = apply.Departman;
                    notShareSheet.Cell(notShareRow, 5).Value = apply.TIP;
                    notShareSheet.Cell(notShareRow, 6).Value = apply.HESKOD;
                    if (apply.current_health_status == "RISKY")
                    {
                        notShareSheet.Cell(notShareRow, 7).Value = "Riskli";
                    }
                    else if (apply.current_health_status == "RISKLESS")
                    {
                        notShareSheet.Cell(notShareRow, 7).Value = "Riskli Değil";
                    }
                    else
                    {
                        notShareSheet.Cell(notShareRow, 7).Value = "";
                    }


                    if (apply.is_vaccinated == true)
                    {
                        notShareSheet.Cell(notShareRow, 8).Value = "Covid-19 Aşıları Tamamlanmıştır";
                    }
                    else if (apply.is_vaccinated == false)
                    {
                        notShareSheet.Cell(notShareRow, 8).Value = "Covid-19 Aşıları Tamamlanmamıştır";
                    }
                    else
                    {
                        notShareSheet.Cell(notShareRow, 8).Value = "";
                    }

                    if (apply.is_immune == true)
                    {
                        notShareSheet.Cell(notShareRow, 9).Value = "Evet";
                    }
                    else if (apply.is_immune == false)
                    {
                        notShareSheet.Cell(notShareRow, 9).Value = "Hayır";
                    }
                    else
                    {
                        notShareSheet.Cell(notShareRow, 9).Value = "";
                    }
                    notShareSheet.Cell(notShareRow, 10).Value = apply.Phone;
                    notShareSheet.Cell(notShareRow, 11).Value = apply.Email;
                }

                notShareSheet.Columns("A:K").AdjustToContents();



                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "liste.xlsx");
                }
            }
        }


        public IActionResult ExcelStudent(int param)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Tüm Liste");
                var currentRow = 5;
                worksheet.Range("B2:F3").Merge();

                worksheet.Cell(2, 2).Value = "Tüm Öğrenci Listesi";
                worksheet.Cell(2, 2).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                worksheet.Cell(2, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(2, 2).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 1).Value = "Tc";
                worksheet.Cell(currentRow, 2).Value = "Ad";
                worksheet.Cell(currentRow, 3).Value = "Soyad";
                worksheet.Cell(currentRow, 4).Value = "Unvanı";

                worksheet.Cell(currentRow, 5).Value = "Hes Kodu";
                worksheet.Cell(currentRow, 6).Value = "Sağlık Durumu";
                worksheet.Cell(currentRow, 7).Value = "Aşı Durumu";

                worksheet.Cell(currentRow, 1).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 2).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 3).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 4).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 5).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 6).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 7).Style.Font.Bold = true;
                foreach (var apply in _context.ProlizData.Where(i => i.TIP == "Öğrenci"))
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = apply.TCKIMLIKNO;
                    worksheet.Cell(currentRow, 2).Value = apply.Ad;
                    worksheet.Cell(currentRow, 3).Value = apply.Soyad;
                    worksheet.Cell(currentRow, 4).Value = apply.Departman;
                    worksheet.Cell(currentRow, 5).Value = apply.HESKOD;
                    if (apply.current_health_status == "RISKY")
                    {
                        worksheet.Cell(currentRow, 6).Value = "Riskli";
                    }
                    else if (apply.current_health_status == "RISKLESS")
                    {
                        worksheet.Cell(currentRow, 6).Value = "Riskli Değil";
                    }
                    else
                    {
                        worksheet.Cell(currentRow, 6).Value = "";
                    }


                    if (apply.is_vaccinated == true)
                    {
                        worksheet.Cell(currentRow, 7).Value = "Covid-19 Aşıları Tamamlanmıştır";
                    }
                    else if (apply.is_vaccinated == false)
                    {
                        worksheet.Cell(currentRow, 7).Value = "Covid-19 Aşıları Tamamlanmamıştır";
                    }
                    else
                    {
                        worksheet.Cell(currentRow, 7).Value = "";
                    }


                }
                worksheet.Columns("A:G").AdjustToContents();

                var hesSheet = workbook.Worksheets.Add("Hes Kodu Aktif Öğrenci Listesi");
                var hesRow = 5;
                hesSheet.Range("B2:F3").Merge();

                hesSheet.Cell(2, 2).Value = "Hes Kodu Aktif Olan Öğrenciler";
                hesSheet.Cell(2, 2).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                hesSheet.Cell(2, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                hesSheet.Cell(2, 2).Style.Font.Bold = true;
                hesSheet.Cell(hesRow, 1).Value = "Tc";
                hesSheet.Cell(hesRow, 2).Value = "Ad";
                hesSheet.Cell(hesRow, 3).Value = "Soyad";
                hesSheet.Cell(hesRow, 4).Value = "Unvanı";

                hesSheet.Cell(hesRow, 5).Value = "Hes Kodu";
                hesSheet.Cell(hesRow, 6).Value = "Sağlık Durumu";
                hesSheet.Cell(hesRow, 7).Value = "Aşı Durumu";
                hesSheet.Cell(hesRow, 1).Style.Font.Bold = true;
                hesSheet.Cell(hesRow, 2).Style.Font.Bold = true;
                hesSheet.Cell(hesRow, 3).Style.Font.Bold = true;
                hesSheet.Cell(hesRow, 4).Style.Font.Bold = true;
                hesSheet.Cell(hesRow, 5).Style.Font.Bold = true;
                hesSheet.Cell(hesRow, 6).Style.Font.Bold = true;
                hesSheet.Cell(hesRow, 7).Style.Font.Bold = true;
                foreach (var apply in _context.ProlizData.Where(i => i.TIP == "Öğrenci" && i.current_health_status != null))
                {
                    hesRow++;
                    hesSheet.Cell(hesRow, 1).Value = apply.TCKIMLIKNO;
                    hesSheet.Cell(hesRow, 2).Value = apply.Ad;
                    hesSheet.Cell(hesRow, 3).Value = apply.Soyad;
                    hesSheet.Cell(hesRow, 4).Value = apply.Departman;
                    hesSheet.Cell(hesRow, 5).Value = apply.HESKOD;
                    if (apply.current_health_status == "RISKY")
                    {
                        hesSheet.Cell(hesRow, 6).Value = "Riskli";
                    }
                    else if (apply.current_health_status == "RISKLESS")
                    {
                        hesSheet.Cell(hesRow, 6).Value = "Riskli Değil";
                    }
                    else
                    {
                        hesSheet.Cell(hesRow, 6).Value = "";
                    }

                    if (apply.is_vaccinated == true)
                    {
                        hesSheet.Cell(hesRow, 7).Value = "Covid-19 Aşıları Tamamlanmıştır";
                    }
                    else if (apply.is_vaccinated == false)
                    {
                        hesSheet.Cell(hesRow, 7).Value = "Covid-19 Aşıları Tamamlanmamıştır";
                    }
                    else
                    {
                        hesSheet.Cell(currentRow, 7).Value = "";
                    }


                }
                hesSheet.Columns("A:G").AdjustToContents();

                var risklessSheet = workbook.Worksheets.Add("Sağlıklı Öğrenci Listesi");
                var risklessRow = 5;
                risklessSheet.Range("B2:F3").Merge();

                risklessSheet.Cell(2, 2).Value = "Hes Kodu Durumu Riskli Olmayan Öğrenciler";
                risklessSheet.Cell(2, 2).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                risklessSheet.Cell(2, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                risklessSheet.Cell(2, 2).Style.Font.Bold = true;
                risklessSheet.Cell(risklessRow, 1).Value = "Tc";
                risklessSheet.Cell(risklessRow, 2).Value = "Ad";
                risklessSheet.Cell(risklessRow, 3).Value = "Soyad";
                risklessSheet.Cell(risklessRow, 4).Value = "Unvanı";

                risklessSheet.Cell(risklessRow, 5).Value = "Hes Kodu";
                risklessSheet.Cell(risklessRow, 6).Value = "Sağlık Durumu";
                risklessSheet.Cell(risklessRow, 7).Value = "Aşı Durumu";
                risklessSheet.Cell(risklessRow, 1).Style.Font.Bold = true;
                risklessSheet.Cell(risklessRow, 2).Style.Font.Bold = true;
                risklessSheet.Cell(risklessRow, 3).Style.Font.Bold = true;
                risklessSheet.Cell(risklessRow, 4).Style.Font.Bold = true;
                risklessSheet.Cell(risklessRow, 5).Style.Font.Bold = true;
                risklessSheet.Cell(risklessRow, 6).Style.Font.Bold = true;
                risklessSheet.Cell(risklessRow, 7).Style.Font.Bold = true;
                foreach (var apply in _context.ProlizData.Where(i => i.TIP == "Öğrenci" && i.current_health_status == "RISKLESS"))
                {
                    risklessRow++;
                    risklessSheet.Cell(risklessRow, 1).Value = apply.TCKIMLIKNO;
                    risklessSheet.Cell(risklessRow, 2).Value = apply.Ad;
                    risklessSheet.Cell(risklessRow, 3).Value = apply.Soyad;
                    risklessSheet.Cell(risklessRow, 4).Value = apply.Departman;
                    risklessSheet.Cell(risklessRow, 5).Value = apply.HESKOD;
                    if (apply.current_health_status == "RISKY")
                    {
                        risklessSheet.Cell(risklessRow, 6).Value = "Riskli";
                    }
                    else if (apply.current_health_status == "RISKLESS")
                    {
                        risklessSheet.Cell(risklessRow, 6).Value = "Riskli Değil";
                    }
                    else
                    {
                        risklessSheet.Cell(risklessRow, 6).Value = "";
                    }


                    if (apply.is_vaccinated == true)
                    {
                        risklessSheet.Cell(risklessRow, 7).Value = "Covid-19 Aşıları Tamamlanmıştır";
                    }
                    else if (apply.is_vaccinated == false)
                    {
                        risklessSheet.Cell(risklessRow, 7).Value = "Covid-19 Aşıları Tamamlanmamıştır";
                    }
                    else
                    {
                        risklessSheet.Cell(risklessRow, 7).Value = "";
                    }
                }
                risklessSheet.Columns("A:G").AdjustToContents();

                var riskySheet = workbook.Worksheets.Add("Riskli Öğrenci Listesi");
                var riskyRow = 5;
                riskySheet.Range("B2:F3").Merge();

                riskySheet.Cell(2, 2).Value = "Hes Kodu Durumu Riskli Olan Öğrenciler";
                riskySheet.Cell(2, 2).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                riskySheet.Cell(2, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                riskySheet.Cell(2, 2).Style.Font.Bold = true;
                riskySheet.Cell(riskyRow, 1).Value = "Tc";
                riskySheet.Cell(riskyRow, 2).Value = "Ad";
                riskySheet.Cell(riskyRow, 3).Value = "Soyad";
                riskySheet.Cell(riskyRow, 4).Value = "Unvanı";

                riskySheet.Cell(riskyRow, 5).Value = "Hes Kodu";
                riskySheet.Cell(riskyRow, 6).Value = "Sağlık Durumu";
                riskySheet.Cell(riskyRow, 7).Value = "Aşı Durumu";
                riskySheet.Cell(riskyRow, 1).Style.Font.Bold = true;
                riskySheet.Cell(riskyRow, 2).Style.Font.Bold = true;
                riskySheet.Cell(riskyRow, 3).Style.Font.Bold = true;
                riskySheet.Cell(riskyRow, 4).Style.Font.Bold = true;
                riskySheet.Cell(riskyRow, 5).Style.Font.Bold = true;
                riskySheet.Cell(riskyRow, 6).Style.Font.Bold = true;
                riskySheet.Cell(riskyRow, 7).Style.Font.Bold = true;
                foreach (var apply in _context.ProlizData.Where(i => i.TIP == "Öğrenci" && i.current_health_status == "RISKY"))
                {
                    riskyRow++;
                    riskySheet.Cell(riskyRow, 1).Value = apply.TCKIMLIKNO;
                    riskySheet.Cell(riskyRow, 2).Value = apply.Ad;
                    riskySheet.Cell(riskyRow, 3).Value = apply.Soyad;
                    riskySheet.Cell(riskyRow, 4).Value = apply.Departman;
                    riskySheet.Cell(riskyRow, 5).Value = apply.HESKOD;
                    if (apply.current_health_status == "RISKY")
                    {
                        riskySheet.Cell(riskyRow, 6).Value = "Riskli";
                    }
                    else if (apply.current_health_status == "RISKLESS")
                    {
                        riskySheet.Cell(riskyRow, 6).Value = "Riskli Değil";
                    }
                    else
                    {
                        riskySheet.Cell(riskyRow, 6).Value = "";
                    }


                    if (apply.is_vaccinated == true)
                    {
                        riskySheet.Cell(riskyRow, 7).Value = "Covid-19 Aşıları Tamamlanmıştır";
                    }
                    else if (apply.is_vaccinated == false)
                    {
                        riskySheet.Cell(riskyRow, 7).Value = "Covid-19 Aşıları Tamamlanmamıştır";
                    }
                    else
                    {
                        riskySheet.Cell(riskyRow, 7).Value = "";
                    }
                }
                riskySheet.Columns("A:G").AdjustToContents();

                var errorSheet = workbook.Worksheets.Add("Hes Kodu Hatalı Listesi");
                var errorRow = 5;
                errorSheet.Range("B2:F3").Merge();

                errorSheet.Cell(2, 2).Value = "Hes Kodu Bildirmeyen, Hatalı veya Süresi Dolmuş Öğrenciler ";
                errorSheet.Cell(2, 2).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                errorSheet.Cell(2, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                errorSheet.Cell(2, 2).Style.Font.Bold = true;
                errorSheet.Cell(errorRow, 1).Value = "Tc";
                errorSheet.Cell(errorRow, 2).Value = "Ad";
                errorSheet.Cell(errorRow, 3).Value = "Soyad";
                errorSheet.Cell(errorRow, 4).Value = "Unvanı";

                errorSheet.Cell(errorRow, 5).Value = "Hes Kodu";
                errorSheet.Cell(errorRow, 6).Value = "Sağlık Durumu";
                errorSheet.Cell(errorRow, 7).Value = "Aşı Durumu";
                errorSheet.Cell(errorRow, 1).Style.Font.Bold = true;
                errorSheet.Cell(errorRow, 2).Style.Font.Bold = true;
                errorSheet.Cell(errorRow, 3).Style.Font.Bold = true;
                errorSheet.Cell(errorRow, 4).Style.Font.Bold = true;
                errorSheet.Cell(errorRow, 5).Style.Font.Bold = true;
                errorSheet.Cell(errorRow, 6).Style.Font.Bold = true;
                errorSheet.Cell(errorRow, 7).Style.Font.Bold = true;
                foreach (var apply in _context.ProlizData.Where(i => i.TIP == "Öğrenci" && i.current_health_status == null))
                {
                    errorRow++;
                    errorSheet.Cell(errorRow, 1).Value = apply.TCKIMLIKNO;
                    errorSheet.Cell(errorRow, 2).Value = apply.Ad;
                    errorSheet.Cell(errorRow, 3).Value = apply.Soyad;
                    errorSheet.Cell(errorRow, 4).Value = apply.Departman;
                    errorSheet.Cell(errorRow, 5).Value = apply.HESKOD;
                    if (apply.current_health_status == "RISKY")
                    {
                        errorSheet.Cell(errorRow, 6).Value = "Riskli";
                    }
                    else if (apply.current_health_status == "RISKLESS")
                    {
                        errorSheet.Cell(errorRow, 6).Value = "Riskli Değil";
                    }
                    else
                    {
                        errorSheet.Cell(errorRow, 6).Value = "";
                    }


                    if (apply.is_vaccinated == true)
                    {
                        errorSheet.Cell(errorRow, 7).Value = "Covid-19 Aşıları Tamamlanmıştır";
                    }
                    else if (apply.is_vaccinated == false)
                    {
                        errorSheet.Cell(errorRow, 7).Value = "Covid-19 Aşıları Tamamlanmamıştır";
                    }
                    else
                    {
                        errorSheet.Cell(errorRow, 7).Value = "";
                    }
                }
                errorSheet.Columns("A:G").AdjustToContents();

                var vaccinatedSheet = workbook.Worksheets.Add("Aşı Olan Öğrenci Listesi");
                var vaccinatedRow = 5;
                vaccinatedSheet.Range("B2:F3").Merge();

                vaccinatedSheet.Cell(2, 2).Value = "Tüm Aşılarını Tamamlayan Öğrenciler";
                vaccinatedSheet.Cell(2, 2).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                vaccinatedSheet.Cell(2, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                vaccinatedSheet.Cell(2, 2).Style.Font.Bold = true;
                vaccinatedSheet.Cell(vaccinatedRow, 1).Value = "Tc";
                vaccinatedSheet.Cell(vaccinatedRow, 2).Value = "Ad";
                vaccinatedSheet.Cell(vaccinatedRow, 3).Value = "Soyad";
                vaccinatedSheet.Cell(vaccinatedRow, 4).Value = "Unvanı";

                vaccinatedSheet.Cell(vaccinatedRow, 5).Value = "Hes Kodu";
                vaccinatedSheet.Cell(vaccinatedRow, 6).Value = "Sağlık Durumu";
                vaccinatedSheet.Cell(vaccinatedRow, 7).Value = "Aşı Durumu";
                vaccinatedSheet.Cell(vaccinatedRow, 1).Style.Font.Bold = true;
                vaccinatedSheet.Cell(vaccinatedRow, 2).Style.Font.Bold = true;
                vaccinatedSheet.Cell(vaccinatedRow, 3).Style.Font.Bold = true;
                vaccinatedSheet.Cell(vaccinatedRow, 4).Style.Font.Bold = true;
                vaccinatedSheet.Cell(vaccinatedRow, 5).Style.Font.Bold = true;
                vaccinatedSheet.Cell(vaccinatedRow, 6).Style.Font.Bold = true;
                vaccinatedSheet.Cell(vaccinatedRow, 7).Style.Font.Bold = true;
                foreach (var apply in _context.ProlizData.Where(i => i.TIP == "Öğrenci" && i.is_vaccinated == true))
                {
                    vaccinatedRow++;
                    vaccinatedSheet.Cell(vaccinatedRow, 1).Value = apply.TCKIMLIKNO;
                    vaccinatedSheet.Cell(vaccinatedRow, 2).Value = apply.Ad;
                    vaccinatedSheet.Cell(vaccinatedRow, 3).Value = apply.Soyad;
                    vaccinatedSheet.Cell(vaccinatedRow, 4).Value = apply.Departman;
                    vaccinatedSheet.Cell(vaccinatedRow, 5).Value = apply.HESKOD;
                    if (apply.current_health_status == "RISKY")
                    {
                        vaccinatedSheet.Cell(vaccinatedRow, 6).Value = "Riskli";
                    }
                    else if (apply.current_health_status == "RISKLESS")
                    {
                        vaccinatedSheet.Cell(vaccinatedRow, 6).Value = "Riskli Değil";
                    }
                    else
                    {
                        vaccinatedSheet.Cell(vaccinatedRow, 6).Value = "";
                    }


                    if (apply.is_vaccinated == true)
                    {
                        vaccinatedSheet.Cell(vaccinatedRow, 7).Value = "Covid-19 Aşıları Tamamlanmıştır";
                    }
                    else if (apply.is_vaccinated == false)
                    {
                        vaccinatedSheet.Cell(vaccinatedRow, 7).Value = "Covid-19 Aşıları Tamamlanmamıştır";
                    }
                    else
                    {
                        vaccinatedSheet.Cell(vaccinatedRow, 7).Value = "";
                    }
                }
                vaccinatedSheet.Columns("A:G").AdjustToContents();


                var unVaccinatedSheet = workbook.Worksheets.Add("Aşı Olmayan Öğrenci Listesi");
                var unVaccinatedRow = 5;
                unVaccinatedSheet.Range("B2:F3").Merge();

                unVaccinatedSheet.Cell(2, 2).Value = "Tüm Aşılarını Tamamlamayan veya Son Aşısının Üstünden 14 Gün Geçmeyen Öğrenciler";
                unVaccinatedSheet.Cell(2, 2).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                unVaccinatedSheet.Cell(2, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                unVaccinatedSheet.Cell(2, 2).Style.Font.Bold = true;
                unVaccinatedSheet.Cell(unVaccinatedRow, 1).Value = "Tc";
                unVaccinatedSheet.Cell(unVaccinatedRow, 2).Value = "Ad";
                unVaccinatedSheet.Cell(unVaccinatedRow, 3).Value = "Soyad";
                unVaccinatedSheet.Cell(unVaccinatedRow, 4).Value = "Unvanı";

                unVaccinatedSheet.Cell(unVaccinatedRow, 5).Value = "Hes Kodu";
                unVaccinatedSheet.Cell(unVaccinatedRow, 6).Value = "Sağlık Durumu";
                unVaccinatedSheet.Cell(unVaccinatedRow, 7).Value = "Aşı Durumu";
                unVaccinatedSheet.Cell(unVaccinatedRow, 1).Style.Font.Bold = true;
                unVaccinatedSheet.Cell(unVaccinatedRow, 2).Style.Font.Bold = true;
                unVaccinatedSheet.Cell(unVaccinatedRow, 3).Style.Font.Bold = true;
                unVaccinatedSheet.Cell(unVaccinatedRow, 4).Style.Font.Bold = true;
                unVaccinatedSheet.Cell(unVaccinatedRow, 5).Style.Font.Bold = true;
                unVaccinatedSheet.Cell(unVaccinatedRow, 6).Style.Font.Bold = true;
                unVaccinatedSheet.Cell(unVaccinatedRow, 7).Style.Font.Bold = true;
                foreach (var apply in _context.ProlizData.Where(i => i.TIP == "Öğrenci" && i.is_vaccinated == false))
                {
                    unVaccinatedRow++;
                    unVaccinatedSheet.Cell(unVaccinatedRow, 1).Value = apply.TCKIMLIKNO;
                    unVaccinatedSheet.Cell(unVaccinatedRow, 2).Value = apply.Ad;
                    unVaccinatedSheet.Cell(unVaccinatedRow, 3).Value = apply.Soyad;
                    unVaccinatedSheet.Cell(unVaccinatedRow, 4).Value = apply.Departman;
                    unVaccinatedSheet.Cell(unVaccinatedRow, 5).Value = apply.HESKOD;
                    if (apply.current_health_status == "RISKY")
                    {
                        unVaccinatedSheet.Cell(unVaccinatedRow, 6).Value = "Riskli";
                    }
                    else if (apply.current_health_status == "RISKLESS")
                    {
                        unVaccinatedSheet.Cell(unVaccinatedRow, 6).Value = "Riskli Değil";
                    }
                    else
                    {
                        unVaccinatedSheet.Cell(unVaccinatedRow, 6).Value = "";
                    }


                    if (apply.is_vaccinated == true)
                    {
                        unVaccinatedSheet.Cell(unVaccinatedRow, 7).Value = "Covid-19 Aşıları Tamamlanmıştır";
                    }
                    else if (apply.is_vaccinated == false)
                    {
                        unVaccinatedSheet.Cell(unVaccinatedRow, 7).Value = "Covid-19 Aşıları Tamamlanmamıştır";
                    }
                    else
                    {
                        unVaccinatedSheet.Cell(unVaccinatedRow, 7).Value = "";
                    }
                }
                unVaccinatedSheet.Columns("A:G").AdjustToContents();

                var notShareSheet = workbook.Worksheets.Add("Paylaşım İzni Vermeyenler");
                var notShareRow = 5;
                notShareSheet.Range("B2:F3").Merge();

                notShareSheet.Cell(2, 2).Value = "Hes Uygulamasından Bilgi Paylaşımına İzin Vermeyen Öğrenciler";
                notShareSheet.Cell(2, 2).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                notShareSheet.Cell(2, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                notShareSheet.Cell(2, 2).Style.Font.Bold = true;
                notShareSheet.Cell(notShareRow, 1).Value = "Tc";
                notShareSheet.Cell(notShareRow, 2).Value = "Ad";
                notShareSheet.Cell(notShareRow, 3).Value = "Soyad";
                notShareSheet.Cell(notShareRow, 4).Value = "Unvanı";

                notShareSheet.Cell(notShareRow, 5).Value = "Hes Kodu";
                notShareSheet.Cell(notShareRow, 6).Value = "Sağlık Durumu";
                notShareSheet.Cell(notShareRow, 7).Value = "Aşı Durumu";
                notShareSheet.Cell(notShareRow, 1).Style.Font.Bold = true;
                notShareSheet.Cell(notShareRow, 2).Style.Font.Bold = true;
                notShareSheet.Cell(notShareRow, 3).Style.Font.Bold = true;
                notShareSheet.Cell(notShareRow, 4).Style.Font.Bold = true;
                notShareSheet.Cell(notShareRow, 5).Style.Font.Bold = true;
                notShareSheet.Cell(notShareRow, 6).Style.Font.Bold = true;
                notShareSheet.Cell(notShareRow, 7).Style.Font.Bold = true;
                foreach (var apply in _context.ProlizData.Where(i => i.TIP == "Öğrenci" && (i.is_vaccinated == null || i.is_immune == null || i.is_test_data_shared == null) && i.current_health_status != null))
                {
                    notShareRow++;
                    notShareSheet.Cell(notShareRow, 1).Value = apply.TCKIMLIKNO;
                    notShareSheet.Cell(notShareRow, 2).Value = apply.Ad;
                    notShareSheet.Cell(notShareRow, 3).Value = apply.Soyad;
                    notShareSheet.Cell(notShareRow, 4).Value = apply.Departman;
                    notShareSheet.Cell(notShareRow, 5).Value = apply.HESKOD;
                    if (apply.current_health_status == "RISKY")
                    {
                        notShareSheet.Cell(notShareRow, 6).Value = "Riskli";
                    }
                    else if (apply.current_health_status == "RISKLESS")
                    {
                        notShareSheet.Cell(notShareRow, 6).Value = "Riskli Değil";
                    }
                    else
                    {
                        notShareSheet.Cell(notShareRow, 6).Value = "";
                    }


                    if (apply.is_vaccinated == true)
                    {
                        notShareSheet.Cell(notShareRow, 7).Value = "Covid-19 Aşıları Tamamlanmıştır";
                    }
                    else if (apply.is_vaccinated == false)
                    {
                        notShareSheet.Cell(notShareRow, 7).Value = "Covid-19 Aşıları Tamamlanmamıştır";
                    }
                    else
                    {
                        notShareSheet.Cell(notShareRow, 7).Value = "";
                    }
                }

                notShareSheet.Columns("A:G").AdjustToContents();



                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "liste.xlsx");
                }
            }
        }
    }
}



