﻿using ClosedXML.Excel;
using HesOperation.ProlizOperation;
using HesOperation.Uyumsoft;
using HesProject.Helpers;
using HesProject.Models;
using HesProject.Models.konfides;
using HesProject.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NonFactors.Mvc.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HesProject.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        string Baseurl = "https://hesservis.turkiye.gov.tr/services/g2g/saglik/hes";

        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
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

                if (item.TIP == "Akademik" || item.TIP == "İdari")
                {
                    person++;
                }
                if (item.current_health_status == "RISKY" && (item.TIP == "Akademik" || item.TIP == "İdari"))
                {
                    personRisky++;
                }
                if (item.current_health_status == "RISKLESS" && (item.TIP == "Akademik" || item.TIP == "İdari"))
                {
                    personRiskless++;
                }
                if (item.current_health_status == null && (item.TIP == "Akademik" || item.TIP == "İdari"))
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

                    if (dataProliz.Count <= 0 )
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

        private IGrid<ProlizData> PeopleList(int param)
        {
            if (param == 1)
            {
                IGrid<ProlizData> grid = new Grid<ProlizData>(_context.ProlizData.ToList());
                grid.Columns.Add(model => model.TCKIMLIKNO as String).Filterable(GridFilterCase.Upper).Named("tcno").Titled("Tc Numarası");
                grid.Columns.Add(model => model.Ad + " " + model.Soyad as String).Filterable(GridFilterCase.Upper).Named("namesurnamme").Titled("Ad Soyad");
                grid.Columns.Add(model => model.TIP).Titled("Tip" as String).Filterable(GridFilterCase.Upper).Named("tip");
                grid.Columns.Add(model => model.HESKOD).Titled("Hes Kodu" as String).Filterable(GridFilterCase.Upper).Named("heskodu").RenderedAs(model => model.HESKOD == null ? "HES Kodu Yok" : model.HESKOD);
                grid.Columns.Add(model => model.current_health_status as String).Filterable(GridFilterCase.Upper).Named("hesdurumu").Titled("Hes Durumu").RenderedAs(model => model.current_health_status == "RISKY" ? "Riskli" : (model.current_health_status == "RISKLESS" ? "Riskli Değil" : model.durum));
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
                grid.Columns.Add(model => model.current_health_status as String).Filterable(GridFilterCase.Upper).Named("hesdurumu").Titled("Hes Durumu").RenderedAs(model => model.current_health_status == "RISKY" ? "Riskli" : (model.current_health_status == "RISKLESS" ? "Riskli Değil" : model.durum));
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
                grid.Columns.Add(model => model.current_health_status as String).Filterable(GridFilterCase.Upper).Named("hesdurumu").Titled("Hes Durumu").RenderedAs(model => model.current_health_status == "RISKY" ? "Riskli" : (model.current_health_status == "RISKLESS" ? "Riskli Değil" : model.durum));
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
                grid.Columns.Add(model => model.current_health_status as String).Filterable(GridFilterCase.Upper).Named("hesdurumu").Titled("Hes Durumu").RenderedAs(model => model.current_health_status == "RISKY" ? "Riskli" : (model.current_health_status == "RISKLESS" ? "Riskli Değil" : model.durum));
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
                grid.Columns.Add(model => model.current_health_status as String).Filterable(GridFilterCase.Upper).Named("hesdurumu").Titled("Hes Durumu").RenderedAs(model => model.current_health_status == "RISKY" ? "Riskli" : (model.current_health_status == "RISKLESS" ? "Riskli Değil" : model.durum));
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
                grid.Columns.Add(model => model.current_health_status as String).Filterable(GridFilterCase.Upper).Named("hesdurumu").Titled("Hes Durumu").RenderedAs(model => model.current_health_status == "RISKY" ? "Riskli" : (model.current_health_status == "RISKLESS" ? "Riskli Değil" : model.durum));
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
                grid.Columns.Add(model => model.current_health_status as String).Filterable(GridFilterCase.Upper).Named("hesdurumu").Titled("Hes Durumu").RenderedAs(model => model.current_health_status == "RISKY" ? "Riskli" : (model.current_health_status == "RISKLESS" ? "Riskli Değil" : model.durum));
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
                grid.Columns.Add(model => model.current_health_status as String).Filterable(GridFilterCase.Upper).Named("hesdurumu").Titled("Hes Durumu").RenderedAs(model => model.current_health_status == "RISKY" ? "Riskli" : (model.current_health_status == "RISKLESS" ? "Riskli Değil" : model.durum));
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
                grid.Columns.Add(model => model.current_health_status as String).Filterable(GridFilterCase.Upper).Named("hesdurumu").Titled("Hes Durumu").RenderedAs(model => model.current_health_status == "RISKY" ? "Riskli" : (model.current_health_status == "RISKLESS" ? "Riskli Değil" : model.durum));
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
                grid.Columns.Add(model => model.current_health_status as String).Filterable(GridFilterCase.Upper).Named("hesdurumu").Titled("Hes Durumu").RenderedAs(model => model.current_health_status == "RISKY" ? "Riskli" : (model.current_health_status == "RISKLESS" ? "Riskli Değil" : model.durum));
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
                grid.Columns.Add(model => model.current_health_status as String).Filterable(GridFilterCase.Upper).Named("hesdurumu").Titled("Hes Durumu").RenderedAs(model => model.current_health_status == "RISKY" ? "Riskli" : (model.current_health_status == "RISKLESS" ? "Riskli Değil" : model.durum));
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



        public IActionResult ExcelStudent(int param)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Kartı Olmayan Öğrenci Listesi");
                var currentRow = 5;
                worksheet.Range("B2:F3").Merge();

                worksheet.Cell(2, 2).Value = "Kartı Olmayan Öğrenci Listesi";
                worksheet.Cell(2, 2).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                worksheet.Cell(2, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(2, 2).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 1).Value = "Tc";
                worksheet.Cell(currentRow, 2).Value = "Öğrenci Numarası";
                worksheet.Cell(currentRow, 3).Value = "Ad";
                worksheet.Cell(currentRow, 4).Value = "Soyad";

                worksheet.Cell(currentRow, 5).Value = "Fakülte";
                worksheet.Cell(currentRow, 6).Value = "Bölüm";
                worksheet.Cell(currentRow, 7).Value = "Resim";

                worksheet.Cell(currentRow, 1).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 2).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 3).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 4).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 5).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 6).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 7).Style.Font.Bold = true;
                foreach (var apply in _context.ProlizData.Where(i => i.TIP == "Öğrenci" && i.IsCard == false))
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = apply.TCKIMLIKNO;
                    worksheet.Cell(currentRow, 2).Value = apply.SNO;
                    worksheet.Cell(currentRow, 3).Value = apply.Ad;
                    worksheet.Cell(currentRow, 4).Value = apply.Soyad;
                    worksheet.Cell(currentRow, 5).Value = apply.Fakulte;
                    worksheet.Cell(currentRow, 6).Value = apply.Bolum;
                    worksheet.Cell(currentRow, 7).Value = apply.TCKIMLIKNO + ".jpg";


                }
                worksheet.Columns("A:G").AdjustToContents();

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

            var people = await _context.ProlizData
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

        //    var people = await _context.ProlizData.FindAsync(id);
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

            ProlizData prolizData = _context.ProlizData.FirstOrDefault(i => i.Id == id);
            prolizData.HESKOD = hes;
            _context.ProlizData.Update(prolizData);
            _context.SaveChanges();
            return RedirectToAction(action, "Admin");

        }

        // GET: People/Delete/5


        // POST: People/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, string action)
        {
            var people = await _context.ProlizData.FindAsync(id);
            _context.ProlizData.Remove(people);
            await _context.SaveChangesAsync();
            return RedirectToAction(action, "Admin");
        }

        private bool PeopleExists(int id)
        {
            return _context.ProlizData.Any(e => e.Id == id);
        }

        public JsonResult getData(int ID)
        {
            ProlizData people = new ProlizData();
            people = _context.ProlizData.FirstOrDefault(i => i.Id == ID);
            //var json = JsonConvert.SerializeObject(result);
            return Json(people);

        }

        public async Task<IActionResult> ImageDowload()
        {
            foreach (var item in _context.ProlizData.Where(i=>i.IsCard == false && i.TIP=="Öğrenci"))
            {
                string imageUrl = item.Picture;
                string saveLocation = @"C:\imageCard\" + item.TCKIMLIKNO + ".jpg";

                byte[] imageBytes;
                HttpWebRequest imageRequest = (HttpWebRequest)WebRequest.Create(imageUrl);
                WebResponse imageResponse = imageRequest.GetResponse();

                Stream responseStream = imageResponse.GetResponseStream();

                using (BinaryReader br = new BinaryReader(responseStream))
                {
                    imageBytes = br.ReadBytes(500000);
                    br.Close();
                }
                responseStream.Close();
                imageResponse.Close();

                FileStream fs = new FileStream(saveLocation, FileMode.Create);
                BinaryWriter bw = new BinaryWriter(fs);
                try
                {
                    bw.Write(imageBytes);
                }
                finally
                {
                    fs.Close();
                    bw.Close();
                }
            }
           

            return View();
        }


        public async Task<IActionResult> EmployeeDelete()
        {
            foreach (var item in _context.ProlizData.Where(i => i.TIP != "Öğrenci"))
            {
                IUyumsoftServiceManager mng = new UyumsoftServiceManager();


                var dataProliz = mng.GetEmployee(item.TCKIMLIKNO);

                if (dataProliz.Adı == null)
                {
                    _context.ProlizData.Remove(item);
                }
            }

            _context.SaveChanges();
            return View();
        }

        public async Task<IActionResult> EmployeeUpdate()
        {
            foreach (var item in _context.ProlizData.Where(i => i.TIP != "Öğrenci" && i.RegisterId == null))
            {
                IUyumsoftServiceManager mng = new UyumsoftServiceManager();

                var dataProliz = mng.GetEmployee(item.TCKIMLIKNO);
                    item.RegisterId = dataProliz.RegisterId;
                    _context.ProlizData.Update(item);
            }

            _context.SaveChanges();
            return View();
        }
    }
}
