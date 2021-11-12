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
    public class InfirmaryController : Controller
    {
        string Baseurl = "https://hesservis.turkiye.gov.tr/services/g2g/saglik/hes";

        private readonly AppDbContext _context;

        public InfirmaryController(AppDbContext context)
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

            ViewBag.Student = student;
            ViewBag.StudentRisky = studentRisky;
            ViewBag.StudentRiskless = studentRiskless;
            ViewBag.StudentError = studentError;

            ViewBag.Person = person;
            ViewBag.PersonRisky = personRisky;
            ViewBag.PersonRiskless = personRiskless;
            ViewBag.PersonError = personError;


            return View();
        }


        public async Task<IActionResult> PersonList()
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
            var data = PeopleList(1);
            return View(data);
        }

        public ActionResult Risky()
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
            var data = PeopleList(2);
            return View(data);

        }
        public ActionResult Riskless()
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
            var data = PeopleList(8);
            return View(data);

        }
        public ActionResult EmployeeRiskless()
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
            var data = PeopleList(10);
            return View(data);

        }

        [HttpGet]
        public ActionResult GetStudent()
        {
            return View();
        }

        public async Task<IActionResult> GetStudent(string tc)
        {


            List<ProlizData> prolizData = new List<ProlizData>();
            StudentViewModel studentViewModel = new StudentViewModel();


            if (tc == null)
            {
                ViewBag.Error = "Kişi Bulunamadı!";
                return View(studentViewModel);
            }
            var kartData = PullData(tc);
            foreach (var item in _context.ProlizData.Where(i => i.TCKIMLIKNO == tc && i.TIP == "Öğrenci"))
            {
                if (item != null)
                {
                    prolizData.Add(item);
                    studentViewModel.KimlikKarti = kartData;
                }
                else
                {
                    ViewBag.Error = "Kişi Bulunamadı!";
                    return View(studentViewModel);
                }
            }

            if (prolizData.Count == 0)
            {
                foreach (var item in _context.ProlizData.Where(i => i.SNO == tc && i.TIP == "Öğrenci"))
                {
                    if (item != null)
                    {
                        prolizData.Add(item);
                        studentViewModel.KimlikKarti = kartData;
                    }
                    else
                    {
                        ViewBag.Error = "Kişi Bulunamadı!";
                        return View(studentViewModel);
                    }
                }
            }

            if (prolizData.Count == 0)
            {
                IProlizServiceManager mng = new ProlizServiceManager();


                var dataProliz = mng.GetStudentInfoOnProliz(tc, "");

                if (dataProliz.Count <= 0)
                {
                    dataProliz = mng.GetStudentInfoOnProliz("", tc);

                    if (dataProliz.Count <= 0)
                    {
                        ViewBag.Error = "Kişi Bulunamadı!";
                        return View(studentViewModel);
                    }
                }



                foreach (var item in dataProliz)
                {
                    if (dataProliz.Count > 0)
                    {
                        ProlizData proliz = new ProlizData();
                        proliz.Ad = item.OGR_ADI;
                        proliz.Soyad = item.OGR_SOYAD;
                        proliz.Fakulte = item.FAKULTE_AD;
                        proliz.Bolum = item.BOLUM_AD;
                        proliz.Program = item.PROGRAM_AD;
                        proliz.Picture = item.PICTURE;
                        prolizData.Add(proliz);
                        studentViewModel.KimlikKarti = kartData;
                    }
                    else
                    {
                        ViewBag.Error = "Kişi Bulunamadı!";
                        return View(studentViewModel);
                    }

                }

                if (kartData.Count == 0)
                {
                    kartData = PullData(studentViewModel.ProlizData[0].TCKIMLIKNO);
                    studentViewModel.KimlikKarti = kartData;
                }



                studentViewModel.ProlizData = prolizData;

                if (studentViewModel.ProlizData.Count == 0 && studentViewModel.KimlikKarti == null)
                {
                    ViewBag.Error = "Kişi Bulunamadı!";
                }
                return View(studentViewModel);
            }


            studentViewModel.ProlizData = prolizData;
            if (studentViewModel.ProlizData.Count == 0 && studentViewModel.KimlikKarti == null)
            {
                ViewBag.Error = "Kişi Bulunamadı!";
            }
            if (kartData.Count == 0)
            {
                kartData = PullData(studentViewModel.ProlizData[0].TCKIMLIKNO);
                studentViewModel.KimlikKarti = kartData;
            }
            return View(studentViewModel);

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


        private IGrid<ProlizData> PeopleList(int param)
        {
            if (param == 1)
            {
                IGrid<ProlizData> grid = new Grid<ProlizData>(_context.ProlizData.ToList());
                grid.Columns.Add(model => model.TCKIMLIKNO.Substring(0,2) + "*******" + model.TCKIMLIKNO.Substring(9, 2) as String).Filterable(GridFilterCase.Upper).Named("tcno").Titled("Tc Numarası");
                grid.Columns.Add(model => model.Ad + " " + model.Soyad as String).Filterable(GridFilterCase.Upper).Named("namesurnamme").Titled("Ad Soyad");
                grid.Columns.Add(model => model.TIP).Titled("Tip" as String).Filterable(GridFilterCase.Upper).Named("tip");
                grid.Columns.Add(model => model.HESKOD).Titled("Hes Kodu" as String).Named("heskodu").RenderedAs(model => model.HESKOD == null ? "HES Kodu Yok" : model.HESKOD).Filterable(GridFilterCase.Upper);
                grid.Columns.Add(model => model.current_health_status as String).Filterable(GridFilterCase.Upper).Named("hesdurumu").Titled("Hes Durumu").RenderedAs(model => model.current_health_status == "RISKY" ? "Riskli" : (model.current_health_status == "RISKLESS" ? "Riskli Değil" :  model.durum));
               // grid.Columns.Add(model => model.IsCard).Titled("Kartı Var Mı?" as String).Filterable(GridFilterCase.Upper).Named("kartvarmı").RenderedAs(model => model.IsCard == true ? "Var" : (model.IsCard == false ? "Yok" : "Kart Bilgisi Bulunamadı"));
                // grid.Columns.Add(model => model.IsBlocked).Titled("Kart Durumu" as String).Filterable(GridFilterCase.Upper).Named("kartdurumu").RenderedAs(model => model.IsBlocked == true ? "Kara Listede" : (model.IsBlocked == false ? "Giriş Yapabilir" : "Kart Bilgisi Bulunamadı"));
                grid.Columns.Add(model => "<a href='#' type='button' class='detay btn btn-primary ' style='margin-right:10px' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalDetail'><i class='fas fa-book'></i></a>").Titled("Detay").Encoded(false).Css("transaction");

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
                grid.Columns.Add(model => model.TCKIMLIKNO.Substring(0,2) + "*******" + model.TCKIMLIKNO.Substring(9, 2) as String).Filterable(GridFilterCase.Upper).Named("tcno").Titled("Tc Numarası");
                grid.Columns.Add(model => model.Ad + " " + model.Soyad as String).Filterable(GridFilterCase.Upper).Named("namesurnamme").Titled("Ad Soyad");
                grid.Columns.Add(model => model.TIP).Titled("Tip" as String).Filterable(GridFilterCase.Upper).Named("tip");
                grid.Columns.Add(model => model.HESKOD).Titled("Hes Kodu" as String).Named("heskodu").RenderedAs(model => model.HESKOD == null ? "HES Kodu Yok" : model.HESKOD).Filterable(GridFilterCase.Upper);
                grid.Columns.Add(model => model.current_health_status as String).Filterable(GridFilterCase.Upper).Named("hesdurumu").Titled("Hes Durumu").RenderedAs(model => model.current_health_status == "RISKY" ? "Riskli" : (model.current_health_status == "RISKLESS" ? "Riskli Değil" :  model.durum));
               // grid.Columns.Add(model => model.IsCard).Titled("Kartı Var Mı?" as String).Filterable(GridFilterCase.Upper).Named("kartvarmı").RenderedAs(model => model.IsCard == true ? "Var" : (model.IsCard == false ? "Yok" : "Kart Bilgisi Bulunamadı"));
                // grid.Columns.Add(model => model.IsBlocked).Titled("Kart Durumu" as String).Filterable(GridFilterCase.Upper).Named("kartdurumu").RenderedAs(model => model.IsBlocked == true ? "Kara Listede" : (model.IsBlocked == false ? "Giriş Yapabilir" : "Kart Bilgisi Bulunamadı"));
                grid.Columns.Add(model => "<a href='#' type='button' class='detay btn btn-primary ' style='margin-right:10px' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalDetail'><i class='fas fa-book'></i></a>").Titled("Detay").Encoded(false).Css("transaction");

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
                grid.Columns.Add(model => model.TCKIMLIKNO.Substring(0,2) + "*******" + model.TCKIMLIKNO.Substring(9, 2) as String).Filterable(GridFilterCase.Upper).Named("tcno").Titled("Tc Numarası");
                grid.Columns.Add(model => model.Ad + " " + model.Soyad as String).Filterable(GridFilterCase.Upper).Named("namesurnamme").Titled("Ad Soyad");
                grid.Columns.Add(model => model.TIP).Titled("Tip" as String).Filterable(GridFilterCase.Upper).Named("tip");
                grid.Columns.Add(model => model.HESKOD).Titled("Hes Kodu" as String).Named("heskodu").RenderedAs(model => model.HESKOD == null ? "HES Kodu Yok" : model.HESKOD).Filterable(GridFilterCase.Upper);
                grid.Columns.Add(model => model.current_health_status as String).Filterable(GridFilterCase.Upper).Named("hesdurumu").Titled("Hes Durumu").RenderedAs(model => model.current_health_status == "RISKY" ? "Riskli" : (model.current_health_status == "RISKLESS" ? "Riskli Değil" :  model.durum));
               // grid.Columns.Add(model => model.IsCard).Titled("Kartı Var Mı?" as String).Filterable(GridFilterCase.Upper).Named("kartvarmı").RenderedAs(model => model.IsCard == true ? "Var" : (model.IsCard == false ? "Yok" : "Kart Bilgisi Bulunamadı"));
                // grid.Columns.Add(model => model.IsBlocked).Titled("Kart Durumu" as String).Filterable(GridFilterCase.Upper).Named("kartdurumu").RenderedAs(model => model.IsBlocked == true ? "Kara Listede" : (model.IsBlocked == false ? "Giriş Yapabilir" : "Kart Bilgisi Bulunamadı"));
                grid.Columns.Add(model => "<a href='#' type='button' class='detay btn btn-primary ' style='margin-right:10px' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalDetail'><i class='fas fa-book'></i></a>").Titled("Detay").Encoded(false).Css("transaction");

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
                grid.Columns.Add(model => model.TCKIMLIKNO.Substring(0,2) + "*******" + model.TCKIMLIKNO.Substring(9, 2) as String).Filterable(GridFilterCase.Upper).Named("tcno").Titled("Tc Numarası");
                grid.Columns.Add(model => model.Ad + " " + model.Soyad as String).Filterable(GridFilterCase.Upper).Named("namesurnamme").Titled("Ad Soyad");
                grid.Columns.Add(model => model.TIP).Titled("Tip" as String).Filterable(GridFilterCase.Upper).Named("tip");
                grid.Columns.Add(model => model.HESKOD).Titled("Hes Kodu" as String).Named("heskodu").RenderedAs(model => model.HESKOD == null ? "HES Kodu Yok" : model.HESKOD).Filterable(GridFilterCase.Upper);
                grid.Columns.Add(model => model.current_health_status as String).Filterable(GridFilterCase.Upper).Named("hesdurumu").Titled("Hes Durumu").RenderedAs(model => model.current_health_status == "RISKY" ? "Riskli" : (model.current_health_status == "RISKLESS" ? "Riskli Değil" :  model.durum));
               // grid.Columns.Add(model => model.IsCard).Titled("Kartı Var Mı?" as String).Filterable(GridFilterCase.Upper).Named("kartvarmı").RenderedAs(model => model.IsCard == true ? "Var" : (model.IsCard == false ? "Yok" : "Kart Bilgisi Bulunamadı"));
                // grid.Columns.Add(model => model.IsBlocked).Titled("Kart Durumu" as String).Filterable(GridFilterCase.Upper).Named("kartdurumu").RenderedAs(model => model.IsBlocked == true ? "Kara Listede" : (model.IsBlocked == false ? "Giriş Yapabilir" : "Kart Bilgisi Bulunamadı"));
                grid.Columns.Add(model => "<a href='#' type='button' class='detay btn btn-primary ' style='margin-right:10px' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalDetail'><i class='fas fa-book'></i></a>").Titled("Detay").Encoded(false).Css("transaction");

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
                grid.Columns.Add(model => model.TCKIMLIKNO.Substring(0,2) + "*******" + model.TCKIMLIKNO.Substring(9, 2) as String).Filterable(GridFilterCase.Upper).Named("tcno").Titled("Tc Numarası");
                grid.Columns.Add(model => model.Ad + " " + model.Soyad as String).Filterable(GridFilterCase.Upper).Named("namesurnamme").Titled("Ad Soyad");
                grid.Columns.Add(model => model.TIP).Titled("Tip" as String).Filterable(GridFilterCase.Upper).Named("tip");
                grid.Columns.Add(model => model.HESKOD).Titled("Hes Kodu" as String).Named("heskodu").RenderedAs(model => model.HESKOD == null ? "HES Kodu Yok" : model.HESKOD).Filterable(GridFilterCase.Upper);
                grid.Columns.Add(model => model.current_health_status as String).Filterable(GridFilterCase.Upper).Named("hesdurumu").Titled("Hes Durumu").RenderedAs(model => model.current_health_status == "RISKY" ? "Riskli" : (model.current_health_status == "RISKLESS" ? "Riskli Değil" :  model.durum));
               // grid.Columns.Add(model => model.IsCard).Titled("Kartı Var Mı?" as String).Filterable(GridFilterCase.Upper).Named("kartvarmı").RenderedAs(model => model.IsCard == true ? "Var" : (model.IsCard == false ? "Yok" : "Kart Bilgisi Bulunamadı"));
                // grid.Columns.Add(model => model.IsBlocked).Titled("Kart Durumu" as String).Filterable(GridFilterCase.Upper).Named("kartdurumu").RenderedAs(model => model.IsBlocked == true ? "Kara Listede" : (model.IsBlocked == false ? "Giriş Yapabilir" : "Kart Bilgisi Bulunamadı"));
                grid.Columns.Add(model => "<a href='#' type='button' class='detay btn btn-primary ' style='margin-right:10px' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalDetail'><i class='fas fa-book'></i></a>").Titled("Detay").Encoded(false).Css("transaction");

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
                grid.Columns.Add(model => model.TCKIMLIKNO.Substring(0,2) + "*******" + model.TCKIMLIKNO.Substring(9, 2) as String).Filterable(GridFilterCase.Upper).Named("tcno").Titled("Tc Numarası");
                grid.Columns.Add(model => model.Ad + " " + model.Soyad as String).Filterable(GridFilterCase.Upper).Named("namesurnamme").Titled("Ad Soyad");
                grid.Columns.Add(model => model.TIP).Titled("Tip" as String).Filterable(GridFilterCase.Upper).Named("tip");
                grid.Columns.Add(model => model.HESKOD).Titled("Hes Kodu" as String).Named("heskodu").RenderedAs(model => model.HESKOD == null ? "HES Kodu Yok" : model.HESKOD).Filterable(GridFilterCase.Upper);
                grid.Columns.Add(model => model.current_health_status as String).Filterable(GridFilterCase.Upper).Named("hesdurumu").Titled("Hes Durumu").RenderedAs(model => model.current_health_status == "RISKY" ? "Riskli" : (model.current_health_status == "RISKLESS" ? "Riskli Değil" :  model.durum));
               // grid.Columns.Add(model => model.IsCard).Titled("Kartı Var Mı?" as String).Filterable(GridFilterCase.Upper).Named("kartvarmı").RenderedAs(model => model.IsCard == true ? "Var" : (model.IsCard == false ? "Yok" : "Kart Bilgisi Bulunamadı"));
                // grid.Columns.Add(model => model.IsBlocked).Titled("Kart Durumu" as String).Filterable(GridFilterCase.Upper).Named("kartdurumu").RenderedAs(model => model.IsBlocked == true ? "Kara Listede" : (model.IsBlocked == false ? "Giriş Yapabilir" : "Kart Bilgisi Bulunamadı"));
                grid.Columns.Add(model => "<a href='#' type='button' class='detay btn btn-primary ' style='margin-right:10px' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalDetail'><i class='fas fa-book'></i></a>").Titled("Detay").Encoded(false).Css("transaction");

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
                grid.Columns.Add(model => model.TCKIMLIKNO.Substring(0,2) + "*******" + model.TCKIMLIKNO.Substring(9, 2) as String).Filterable(GridFilterCase.Upper).Named("tcno").Titled("Tc Numarası");
                grid.Columns.Add(model => model.Ad + " " + model.Soyad as String).Filterable(GridFilterCase.Upper).Named("namesurnamme").Titled("Ad Soyad");
                grid.Columns.Add(model => model.TIP).Titled("Tip" as String).Filterable(GridFilterCase.Upper).Named("tip");
                grid.Columns.Add(model => model.HESKOD).Titled("Hes Kodu" as String).Named("heskodu").RenderedAs(model => model.HESKOD == null ? "HES Kodu Yok" : model.HESKOD).Filterable(GridFilterCase.Upper);
                grid.Columns.Add(model => model.current_health_status as String).Filterable(GridFilterCase.Upper).Named("hesdurumu").Titled("Hes Durumu").RenderedAs(model => model.current_health_status == "RISKY" ? "Riskli" : (model.current_health_status == "RISKLESS" ? "Riskli Değil" :  model.durum));
               // grid.Columns.Add(model => model.IsCard).Titled("Kartı Var Mı?" as String).Filterable(GridFilterCase.Upper).Named("kartvarmı").RenderedAs(model => model.IsCard == true ? "Var" : (model.IsCard == false ? "Yok" : "Kart Bilgisi Bulunamadı"));
                // grid.Columns.Add(model => model.IsBlocked).Titled("Kart Durumu" as String).Filterable(GridFilterCase.Upper).Named("kartdurumu").RenderedAs(model => model.IsBlocked == true ? "Kara Listede" : (model.IsBlocked == false ? "Giriş Yapabilir" : "Kart Bilgisi Bulunamadı"));
                grid.Columns.Add(model => "<a href='#' type='button' class='detay btn btn-primary ' style='margin-right:10px' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalDetail'><i class='fas fa-book'></i></a>").Titled("Detay").Encoded(false).Css("transaction");

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
                grid.Columns.Add(model => model.TCKIMLIKNO.Substring(0,2) + "*******" + model.TCKIMLIKNO.Substring(9, 2) as String).Filterable(GridFilterCase.Upper).Named("tcno").Titled("Tc Numarası");
                grid.Columns.Add(model => model.Ad + " " + model.Soyad as String).Filterable(GridFilterCase.Upper).Named("namesurnamme").Titled("Ad Soyad");
                grid.Columns.Add(model => model.TIP).Titled("Tip" as String).Filterable(GridFilterCase.Upper).Named("tip");
                grid.Columns.Add(model => model.HESKOD).Titled("Hes Kodu" as String).Named("heskodu").RenderedAs(model => model.HESKOD == null ? "HES Kodu Yok" : model.HESKOD).Filterable(GridFilterCase.Upper);
                grid.Columns.Add(model => model.current_health_status as String).Filterable(GridFilterCase.Upper).Named("hesdurumu").Titled("Hes Durumu").RenderedAs(model => model.current_health_status == "RISKY" ? "Riskli" : (model.current_health_status == "RISKLESS" ? "Riskli Değil" :  model.durum));
                //grid.Columns.Add(model => model.IsCard).Titled("Kartı Var Mı?" as String).Filterable(GridFilterCase.Upper).Named("kartvarmı").RenderedAs(model => model.IsCard == true ? "Var" : (model.IsCard == false ? "Yok" : "Kart Bilgisi Bulunamadı"));
                // grid.Columns.Add(model => model.IsBlocked).Titled("Kart Durumu" as String).Filterable(GridFilterCase.Upper).Named("kartdurumu").RenderedAs(model => model.IsBlocked == true ? "Kara Listede" : (model.IsBlocked == false ? "Giriş Yapabilir" : "Kart Bilgisi Bulunamadı"));
                grid.Columns.Add(model => "<a href='#' type='button' class='detay btn btn-primary ' style='margin-right:10px' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalDetail'><i class='fas fa-book'></i></a>").Titled("Detay").Encoded(false).Css("transaction");

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
                grid.Columns.Add(model => model.TCKIMLIKNO.Substring(0,2) + "*******" + model.TCKIMLIKNO.Substring(9, 2) as String).Filterable(GridFilterCase.Upper).Named("tcno").Titled("Tc Numarası");
                grid.Columns.Add(model => model.Ad + " " + model.Soyad as String).Filterable(GridFilterCase.Upper).Named("namesurnamme").Titled("Ad Soyad");
                grid.Columns.Add(model => model.TIP).Titled("Tip" as String).Filterable(GridFilterCase.Upper).Named("tip");
                grid.Columns.Add(model => model.HESKOD).Titled("Hes Kodu" as String).Named("heskodu").RenderedAs(model => model.HESKOD == null ? "HES Kodu Yok" : model.HESKOD).Filterable(GridFilterCase.Upper);
                grid.Columns.Add(model => model.current_health_status as String).Filterable(GridFilterCase.Upper).Named("hesdurumu").Titled("Hes Durumu").RenderedAs(model => model.current_health_status == "RISKY" ? "Riskli" : (model.current_health_status == "RISKLESS" ? "Riskli Değil" :  model.durum));
               // grid.Columns.Add(model => model.IsCard).Titled("Kartı Var Mı?" as String).Filterable(GridFilterCase.Upper).Named("kartvarmı").RenderedAs(model => model.IsCard == true ? "Var" : (model.IsCard == false ? "Yok" : "Kart Bilgisi Bulunamadı"));
                // grid.Columns.Add(model => model.IsBlocked).Titled("Kart Durumu" as String).Filterable(GridFilterCase.Upper).Named("kartdurumu").RenderedAs(model => model.IsBlocked == true ? "Kara Listede" : (model.IsBlocked == false ? "Giriş Yapabilir" : "Kart Bilgisi Bulunamadı"));
                grid.Columns.Add(model => "<a href='#' type='button' class='detay btn btn-primary ' style='margin-right:10px' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalDetail'><i class='fas fa-book'></i></a>").Titled("Detay").Encoded(false).Css("transaction");

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
                grid.Columns.Add(model => model.TCKIMLIKNO.Substring(0,2) + "*******" + model.TCKIMLIKNO.Substring(9, 2) as String).Filterable(GridFilterCase.Upper).Named("tcno").Titled("Tc Numarası");
                grid.Columns.Add(model => model.Ad + " " + model.Soyad as String).Filterable(GridFilterCase.Upper).Named("namesurnamme").Titled("Ad Soyad");
                grid.Columns.Add(model => model.TIP).Titled("Tip" as String).Filterable(GridFilterCase.Upper).Named("tip");
                grid.Columns.Add(model => model.HESKOD).Titled("Hes Kodu" as String).Named("heskodu").RenderedAs(model => model.HESKOD == null ? "HES Kodu Yok" : model.HESKOD).Filterable(GridFilterCase.Upper);
                grid.Columns.Add(model => model.current_health_status as String).Filterable(GridFilterCase.Upper).Named("hesdurumu").Titled("Hes Durumu").RenderedAs(model => model.current_health_status == "RISKY" ? "Riskli" : (model.current_health_status == "RISKLESS" ? "Riskli Değil" :  model.durum));
              //  grid.Columns.Add(model => model.IsCard).Titled("Kartı Var Mı?" as String).Filterable(GridFilterCase.Upper).Named("kartvarmı").RenderedAs(model => model.IsCard == true ? "Var" : (model.IsCard == false ? "Yok" : "Kart Bilgisi Bulunamadı"));
                // grid.Columns.Add(model => model.IsBlocked).Titled("Kart Durumu" as String).Filterable(GridFilterCase.Upper).Named("kartdurumu").RenderedAs(model => model.IsBlocked == true ? "Kara Listede" : (model.IsBlocked == false ? "Giriş Yapabilir" : "Kart Bilgisi Bulunamadı"));
                grid.Columns.Add(model => "<a href='#' type='button' class='detay btn btn-primary ' style='margin-right:10px' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalDetail'><i class='fas fa-book'></i></a>").Titled("Detay").Encoded(false).Css("transaction");

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
                grid.Columns.Add(model => model.TCKIMLIKNO.Substring(0,2) + "*******" + model.TCKIMLIKNO.Substring(9, 2) as String).Filterable(GridFilterCase.Upper).Named("tcno").Titled("Tc Numarası");
                grid.Columns.Add(model => model.Ad + " " + model.Soyad as String).Filterable(GridFilterCase.Upper).Named("namesurnamme").Titled("Ad Soyad");
                grid.Columns.Add(model => model.TIP).Titled("Tip" as String).Filterable(GridFilterCase.Upper).Named("tip");
                grid.Columns.Add(model => model.HESKOD).Titled("Hes Kodu" as String).Named("heskodu").RenderedAs(model => model.HESKOD == null ? "HES Kodu Yok" : model.HESKOD).Filterable(GridFilterCase.Upper);
                grid.Columns.Add(model => model.current_health_status as String).Filterable(GridFilterCase.Upper).Named("hesdurumu").Titled("Hes Durumu").RenderedAs(model => model.current_health_status == "RISKY" ? "Riskli" : (model.current_health_status == "RISKLESS" ? "Riskli Değil" :  model.durum));
                //grid.Columns.Add(model => model.IsCard).Titled("Kartı Var Mı?" as String).Filterable(GridFilterCase.Upper).Named("kartvarmı").RenderedAs(model => model.IsCard == true ? "Var" : (model.IsCard == false ? "Yok" : "Kart Bilgisi Bulunamadı"));
                // grid.Columns.Add(model => model.IsBlocked).Titled("Kart Durumu" as String).Filterable(GridFilterCase.Upper).Named("kartdurumu").RenderedAs(model => model.IsBlocked == true ? "Kara Listede" : (model.IsBlocked == false ? "Giriş Yapabilir" : "Kart Bilgisi Bulunamadı"));
                grid.Columns.Add(model => "<a href='#' type='button' class='detay btn btn-primary ' style='margin-right:10px' id='detayModal' data-toggle='modal' data-aday='" + model.Id + "' data-target='#modalDetail'><i class='fas fa-book'></i></a>").Titled("Detay").Encoded(false).Css("transaction");

                foreach (IGridColumn column in grid.Columns)
                {

                    column.Filter.IsEnabled = true;
                    column.Sort.IsEnabled = true;
                }

                return grid;
            }

            return null;
        }


        public IActionResult ExcelNotOrder(int param)
        {
            string type = "";
            if (param == 1)
            {
                type = "Ogrenci";
            }
            else if (param == 1)
            {
                type = "Perosnel";
            }

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Liste");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Tc";
                worksheet.Cell(currentRow, 2).Value = "Tip";
                worksheet.Cell(currentRow, 3).Value = "Hes Kodu";
                worksheet.Cell(currentRow, 4).Value = "Durum";

                foreach (var apply in _context.ProlizData.Where(i => i.current_health_status == ""))
                {
                    currentRow++;
                    //worksheet.Cell(currentRow, 1).Value = apply.tc;
                    //worksheet.Cell(currentRow, 2).Value = apply.status;
                    //worksheet.Cell(currentRow, 3).Value = apply.hes;
                    //worksheet.Cell(currentRow, 4).Value = apply.durum;
                }

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
        public async Task<IActionResult> Edit(string action, Person people)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(people);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeopleExists(people.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(action, "Admin");
            }
            return View(people);
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


        public IActionResult Excel(int param)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Tüm Liste");
                var currentRow = 5;
                worksheet.Range("B2:F3").Merge();

                worksheet.Cell(2, 2).Value = "Tüm Personel Listesi";
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
                foreach (var apply in _context.ProlizData.Where(i => i.TIP != "Öğrenci"))
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = apply.TCKIMLIKNO.Substring(0, 2) + "*******" + apply.TCKIMLIKNO.Substring(9, 2);
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

                var hesSheet = workbook.Worksheets.Add("Hes Kodu Aktif Personel Listesi");
                var hesRow = 5;
                hesSheet.Range("B2:F3").Merge();

                hesSheet.Cell(2, 2).Value = "Hes Kodu Aktif Olan Personeller";
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
                foreach (var apply in _context.ProlizData.Where(i => i.TIP != "Öğrenci" && i.current_health_status != null))
                {
                    hesRow++;
                    hesSheet.Cell(hesRow, 1).Value = apply.TCKIMLIKNO.Substring(0,2) + "*******" + apply.TCKIMLIKNO.Substring(9, 2);
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

                var risklessSheet = workbook.Worksheets.Add("Sağlıklı Personel Listesi");
                var risklessRow = 5;
                risklessSheet.Range("B2:F3").Merge();

                risklessSheet.Cell(2, 2).Value = "Hes Kodu Durumu Riskli Olmayan Personeller";
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
                foreach (var apply in _context.ProlizData.Where(i => i.TIP != "Öğrenci" && i.current_health_status == "RISKLESS"))
                {
                    risklessRow++;
                    risklessSheet.Cell(risklessRow, 1).Value = apply.TCKIMLIKNO.Substring(0,2) + "*******" + apply.TCKIMLIKNO.Substring(9, 2);
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

                var riskySheet = workbook.Worksheets.Add("Riskli Personel Listesi");
                var riskyRow = 5;
                riskySheet.Range("B2:F3").Merge();

                riskySheet.Cell(2, 2).Value = "Hes Kodu Durumu Riskli Olan Personeller";
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
                foreach (var apply in _context.ProlizData.Where(i => i.TIP != "Öğrenci" && i.current_health_status == "RISKY"))
                {
                    riskyRow++;
                    riskySheet.Cell(riskyRow, 1).Value = apply.TCKIMLIKNO.Substring(0,2) + "*******" + apply.TCKIMLIKNO.Substring(9, 2);
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

                errorSheet.Cell(2, 2).Value = "Hes Kodu Bildirmeyen, Hatalı veya Süresi Dolmuş Personeller ";
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
                foreach (var apply in _context.ProlizData.Where(i => i.TIP != "Öğrenci" && i.current_health_status == null))
                {
                    errorRow++;
                    errorSheet.Cell(errorRow, 1).Value = apply.TCKIMLIKNO.Substring(0,2) + "*******" + apply.TCKIMLIKNO.Substring(9, 2);
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

                var vaccinatedSheet = workbook.Worksheets.Add("Aşı Olan Personel Listesi");
                var vaccinatedRow = 5;
                vaccinatedSheet.Range("B2:F3").Merge();

                vaccinatedSheet.Cell(2, 2).Value = "Tüm Aşılarını Tamamlayan Personeller";
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
                foreach (var apply in _context.ProlizData.Where(i => i.TIP != "Öğrenci" && i.is_vaccinated == true))
                {
                    vaccinatedRow++;
                    vaccinatedSheet.Cell(vaccinatedRow, 1).Value = apply.TCKIMLIKNO.Substring(0,2) + "*******" + apply.TCKIMLIKNO.Substring(9, 2);
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


                var unVaccinatedSheet = workbook.Worksheets.Add("Aşı Olmayan Personel Listesi");
                var unVaccinatedRow = 5;
                unVaccinatedSheet.Range("B2:F3").Merge();

                unVaccinatedSheet.Cell(2, 2).Value = "Tüm Aşılarını Tamamlamayan veya Son Aşısının Üstünden 14 Gün Geçmeyen Personeller";
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
                foreach (var apply in _context.ProlizData.Where(i => i.TIP != "Öğrenci" && i.is_vaccinated == false))
                {
                    unVaccinatedRow++;
                    unVaccinatedSheet.Cell(unVaccinatedRow, 1).Value = apply.TCKIMLIKNO.Substring(0,2) + "*******" + apply.TCKIMLIKNO.Substring(9, 2);
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

                notShareSheet.Cell(2, 2).Value = "Hes Uygulamasından Bilgi Paylaşımına İzin Vermeyen Personeller";
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
                foreach (var apply in _context.ProlizData.Where(i => i.TIP != "Öğrenci" && (i.is_vaccinated == null || i.is_immune == null || i.is_test_data_shared == null) && i.current_health_status != null))
                {
                    notShareRow++;
                    notShareSheet.Cell(notShareRow, 1).Value = apply.TCKIMLIKNO.Substring(0,2) + "*******" + apply.TCKIMLIKNO.Substring(9, 2);
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
                    worksheet.Cell(currentRow, 1).Value = apply.TCKIMLIKNO.Substring(0,2) + "*******" + apply.TCKIMLIKNO.Substring(9, 2);
                    worksheet.Cell(currentRow, 2).Value = apply.Ad;
                    worksheet.Cell(currentRow, 3).Value = apply.Soyad;
                    worksheet.Cell(currentRow, 4).Value = "Öğrenci";
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
                    hesSheet.Cell(hesRow, 1).Value = apply.TCKIMLIKNO.Substring(0,2) + "*******" + apply.TCKIMLIKNO.Substring(9, 2);
                    hesSheet.Cell(hesRow, 2).Value = apply.Ad;
                    hesSheet.Cell(hesRow, 3).Value = apply.Soyad;
                    hesSheet.Cell(hesRow, 4).Value = "Öğrenci";
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
                    risklessSheet.Cell(risklessRow, 1).Value = apply.TCKIMLIKNO.Substring(0,2) + "*******" + apply.TCKIMLIKNO.Substring(9, 2);
                    risklessSheet.Cell(risklessRow, 2).Value = apply.Ad;
                    risklessSheet.Cell(risklessRow, 3).Value = apply.Soyad;
                    risklessSheet.Cell(risklessRow, 4).Value = "Öğrenci";
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
                    riskySheet.Cell(riskyRow, 1).Value = apply.TCKIMLIKNO.Substring(0,2) + "*******" + apply.TCKIMLIKNO.Substring(9, 2);
                    riskySheet.Cell(riskyRow, 2).Value = apply.Ad;
                    riskySheet.Cell(riskyRow, 3).Value = apply.Soyad;
                    riskySheet.Cell(riskyRow, 4).Value = "Öğrenci";
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
                    errorSheet.Cell(errorRow, 1).Value = apply.TCKIMLIKNO.Substring(0,2) + "*******" + apply.TCKIMLIKNO.Substring(9, 2);
                    errorSheet.Cell(errorRow, 2).Value = apply.Ad;
                    errorSheet.Cell(errorRow, 3).Value = apply.Soyad;
                    errorSheet.Cell(errorRow, 4).Value = "Öğrenci";
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
                    vaccinatedSheet.Cell(vaccinatedRow, 1).Value = apply.TCKIMLIKNO.Substring(0,2) + "*******" + apply.TCKIMLIKNO.Substring(9, 2);
                    vaccinatedSheet.Cell(vaccinatedRow, 2).Value = apply.Ad;
                    vaccinatedSheet.Cell(vaccinatedRow, 3).Value = apply.Soyad;
                    vaccinatedSheet.Cell(vaccinatedRow, 4).Value = "Öğrenci";
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
                    unVaccinatedSheet.Cell(unVaccinatedRow, 1).Value = apply.TCKIMLIKNO.Substring(0,2) + "*******" + apply.TCKIMLIKNO.Substring(9, 2);
                    unVaccinatedSheet.Cell(unVaccinatedRow, 2).Value = apply.Ad;
                    unVaccinatedSheet.Cell(unVaccinatedRow, 3).Value = apply.Soyad;
                    unVaccinatedSheet.Cell(unVaccinatedRow, 4).Value = "Öğrenci";
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
                    notShareSheet.Cell(notShareRow, 1).Value = apply.TCKIMLIKNO.Substring(0,2) + "*******" + apply.TCKIMLIKNO.Substring(9, 2);
                    notShareSheet.Cell(notShareRow, 2).Value = apply.Ad;
                    notShareSheet.Cell(notShareRow, 3).Value = apply.Soyad;
                    notShareSheet.Cell(notShareRow, 4).Value = "Öğrenci";
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
