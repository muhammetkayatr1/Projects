using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NonFactors.Mvc.Grid;
using VaccinationCenter.Models;

namespace VaccinationCenter.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            int student = 0, studentVaccine = 0, studentUnVaccine = 0,
               employee = 0, employeeVaccine = 0, employeeUnVaccine = 0;
            foreach (var item in _context.StudentVaccineInfo)
            {
                if (item.IsWantVaccine == true)
                {
                    studentVaccine++;
                }
                else if (item.IsWantVaccine == false)
                {
                    studentUnVaccine++;
                }
                student++;
            }

            foreach (var item in _context.EmployeeVaccineInfo)
            {
                if (item.IsWantVaccine == true)
                {
                    employeeVaccine++;
                }
                else if (item.IsWantVaccine == false)
                {
                    employeeUnVaccine++;
                }
                employee++;
            }
            ViewBag.Student = student;
            ViewBag.StudentVaccine = studentVaccine;
            ViewBag.StudentUnVaccine = studentUnVaccine;
            ViewBag.Employee = employee;
            ViewBag.EmployeeVaccine = employeeVaccine;
            ViewBag.EmployeeUnVaccine = employeeUnVaccine;

            return View();
        }

        public IActionResult Student()
        {
            int student = 0, studentVaccine = 0, studentUnVaccine = 0;
            foreach (var item in _context.StudentVaccineInfo)
            {
                if (item.IsWantVaccine == true)
                {
                    studentVaccine++;
                }
                else if (item.IsWantVaccine == false)
                {
                    studentUnVaccine++;
                }
                student++;
            }

            ViewBag.Student = student;
            ViewBag.StudentVaccine = studentVaccine;
            ViewBag.StudentUnVaccine = studentUnVaccine;

            var data = StudentList(1);
            return View(data);
        }

        public IActionResult StudentVaccine()
        {
            int student = 0, studentVaccine = 0, studentUnVaccine = 0;
            foreach (var item in _context.StudentVaccineInfo)
            {
                if (item.IsWantVaccine == true)
                {
                    studentVaccine++;
                }
                else if (item.IsWantVaccine == false)
                {
                    studentUnVaccine++;
                }
                student++;
            }

            ViewBag.Student = student;
            ViewBag.StudentVaccine = studentVaccine;
            ViewBag.StudentUnVaccine = studentUnVaccine;

            var data = StudentList(2);
            return View(data);
        }

        public IActionResult StudentUnVaccine()
        {
            int student = 0, studentVaccine = 0, studentUnVaccine = 0;
            foreach (var item in _context.StudentVaccineInfo)
            {
                if (item.IsWantVaccine == true)
                {
                    studentVaccine++;
                }
                else if (item.IsWantVaccine == false)
                {
                    studentUnVaccine++;
                }
                student++;
            }

            ViewBag.Student = student;
            ViewBag.StudentVaccine = studentVaccine;
            ViewBag.StudentUnVaccine = studentUnVaccine;

            var data = StudentList(3);
            return View(data);
        }

        public IActionResult Employee()
        {
            int employee = 0, employeeVaccine = 0, employeeUnVaccine = 0;
            foreach (var item in _context.EmployeeVaccineInfo)
            {
                if (item.IsWantVaccine == true)
                {
                    employeeVaccine++;
                }
                else if (item.IsWantVaccine == false)
                {
                    employeeUnVaccine++;
                }
                employee++;
            }

            ViewBag.Employee = employee;
            ViewBag.EmployeeVaccine = employeeVaccine;
            ViewBag.EmployeeUnVaccine = employeeUnVaccine;

            var data = EmployeeList(1);
            return View(data);
        }

        public IActionResult EmployeeVaccine()
        {
            int  employee = 0, employeeVaccine = 0, employeeUnVaccine = 0;
            foreach (var item in _context.EmployeeVaccineInfo)
            {
                if (item.IsWantVaccine == true)
                {
                    employeeVaccine++;
                }
                else if (item.IsWantVaccine == false)
                {
                    employeeUnVaccine++;
                }
                employee++;
            }

            ViewBag.Employee = employee;
            ViewBag.EmployeeVaccine = employeeVaccine;
            ViewBag.EmployeeUnVaccine = employeeUnVaccine;

            var data = EmployeeList(2);
            return View(data);
        }

        public IActionResult EmployeeUnVaccine()
        {
            int employee = 0, employeeVaccine = 0, employeeUnVaccine = 0;
            foreach (var item in _context.EmployeeVaccineInfo)
            {
                if (item.IsWantVaccine == true)
                {
                    employeeVaccine++;
                }
                else if (item.IsWantVaccine == false)
                {
                    employeeUnVaccine++;
                }
                employee++;
            }

            ViewBag.Employee = employee;
            ViewBag.EmployeeVaccine = employeeVaccine;
            ViewBag.EmployeeUnVaccine = employeeUnVaccine;

            var data = EmployeeList(3);
            return View(data);
        }

        public IActionResult GetHes()
        {
            List<EmployeeVaccineInfo> employeeVaccineInfos = new List<EmployeeVaccineInfo>();
            List<StudentVaccineInfo> studentVaccineInfos = new List<StudentVaccineInfo>();
            foreach (var item in _context.EmployeeVaccineInfo)
            {
                employeeVaccineInfos.Add(item);
            }

            foreach (var item in _context.StudentVaccineInfo)
            {
                studentVaccineInfos.Add(item);
            }

            for (int i = 0; i < employeeVaccineInfos.Count; i++)
            {
                ProlizData prolizData = _context.ProlizData.FirstOrDefault(j => j.TCKIMLIKNO == employeeVaccineInfos[i].Tc);
                employeeVaccineInfos[i].HesCode = prolizData.HESKOD;
                employeeVaccineInfos[i].is_vaccinated = prolizData.is_vaccinated;
                _context.EmployeeVaccineInfo.Update(employeeVaccineInfos[i]);
            }
            for (int i = 0; i < studentVaccineInfos.Count; i++)
            {
                ProlizData prolizData = _context.ProlizData.FirstOrDefault(j => j.TCKIMLIKNO == studentVaccineInfos[i].Tc);
                studentVaccineInfos[i].HesCode = prolizData.HESKOD;
                studentVaccineInfos[i].is_vaccinated = prolizData.is_vaccinated;
                _context.StudentVaccineInfo.Update(studentVaccineInfos[i]);
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

            private IGrid<StudentVaccineInfo> StudentList(int param)
        {
            if (param == 1)
            {
                IGrid<StudentVaccineInfo> grid = new Grid<StudentVaccineInfo>(_context.StudentVaccineInfo.ToList());
                grid.Columns.Add(model => model.Tc as String).Filterable(GridFilterCase.Upper).Named("tcno").Titled("Tc Numarası");
                grid.Columns.Add(model => model.Name + " " + model.Surname as String).Filterable(GridFilterCase.Upper).Named("namesurnamme").Titled("Ad Soyad");
                grid.Columns.Add(model => model.HesCode as String).Filterable(GridFilterCase.Upper).Named("hescode").Titled("Hes Kodu");
                grid.Columns.Add(model => model.is_vaccinated).Titled("Hes Kodu Aşı Durmu" as String).Filterable(GridFilterCase.Upper).Named("isvaccinated").RenderedAs(model => model.is_vaccinated == true ? "Evet" : (model.is_vaccinated == false ? "Hayır" : "Bilgi Bulunamadı"));
                grid.Columns.Add(model => model.IsWantVaccine).Titled("Aşı Olmak İstiyor Mu?" as String).Filterable(GridFilterCase.Upper).Named("asiolmakistiyormu").RenderedAs(model => model.IsWantVaccine == true ? "Evet" : (model.IsWantVaccine == false ? "Hayır" : "Bilgi Bulunamadı"));
                grid.Columns.Add(model => model.VaccineName as String).Filterable(GridFilterCase.Upper).Named("vaccinename").Titled("Aşı Adı");
                grid.Columns.Add(model => model.VaccineDate as String).Filterable(GridFilterCase.Upper).Named("vaccinedate").Titled("Aşı Tarihi");
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
                IGrid<StudentVaccineInfo> grid = new Grid<StudentVaccineInfo>(_context.StudentVaccineInfo.Where(i => i.IsWantVaccine == true).ToList());
                grid.Columns.Add(model => model.Tc as String).Filterable(GridFilterCase.Upper).Named("tcno").Titled("Tc Numarası");
                grid.Columns.Add(model => model.Name + " " + model.Surname as String).Filterable(GridFilterCase.Upper).Named("namesurnamme").Titled("Ad Soyad");
                grid.Columns.Add(model => model.HesCode as String).Filterable(GridFilterCase.Upper).Named("hescode").Titled("Hes Kodu");
                grid.Columns.Add(model => model.is_vaccinated).Titled("Hes Kodu Aşı Durmu" as String).Filterable(GridFilterCase.Upper).Named("isvaccinated").RenderedAs(model => model.is_vaccinated == true ? "Evet" : (model.is_vaccinated == false ? "Hayır" : "Bilgi Bulunamadı"));
                grid.Columns.Add(model => model.IsWantVaccine).Titled("Aşı Olmak İstiyor Mu?" as String).Filterable(GridFilterCase.Upper).Named("asiolmakistiyormu").RenderedAs(model => model.IsWantVaccine == true ? "Evet" : (model.IsWantVaccine == false ? "Hayır" : "Bilgi Bulunamadı"));
                grid.Columns.Add(model => model.VaccineName as String).Filterable(GridFilterCase.Upper).Named("vaccinename").Titled("Aşı Adı");
                grid.Columns.Add(model => model.VaccineDate as String).Filterable(GridFilterCase.Upper).Named("vaccinedate").Titled("Aşı Tarihi");
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
                IGrid<StudentVaccineInfo> grid = new Grid<StudentVaccineInfo>(_context.StudentVaccineInfo.Where(i => i.IsWantVaccine == false).ToList());
                grid.Columns.Add(model => model.Tc as String).Filterable(GridFilterCase.Upper).Named("tcno").Titled("Tc Numarası");
                grid.Columns.Add(model => model.Name + " " + model.Surname as String).Filterable(GridFilterCase.Upper).Named("namesurnamme").Titled("Ad Soyad");
                grid.Columns.Add(model => model.HesCode as String).Filterable(GridFilterCase.Upper).Named("hescode").Titled("Hes Kodu");
                grid.Columns.Add(model => model.is_vaccinated).Titled("Hes Kodu Aşı Durmu" as String).Filterable(GridFilterCase.Upper).Named("isvaccinated").RenderedAs(model => model.is_vaccinated == true ? "Evet" : (model.is_vaccinated == false ? "Hayır" : "Bilgi Bulunamadı"));
                grid.Columns.Add(model => model.IsWantVaccine).Titled("Aşı Olmak İstiyor Mu?" as String).Filterable(GridFilterCase.Upper).Named("asiolmakistiyormu").RenderedAs(model => model.IsWantVaccine == true ? "Evet" : (model.IsWantVaccine == false ? "Hayır" : "Bilgi Bulunamadı"));
                grid.Columns.Add(model => model.VaccineName as String).Filterable(GridFilterCase.Upper).Named("vaccinename").Titled("Aşı Adı");
                grid.Columns.Add(model => model.VaccineDate as String).Filterable(GridFilterCase.Upper).Named("vaccinedate").Titled("Aşı Tarihi");
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


        private IGrid<EmployeeVaccineInfo> EmployeeList(int param)
        {
            if (param == 1)
            {
                IGrid<EmployeeVaccineInfo> grid = new Grid<EmployeeVaccineInfo>(_context.EmployeeVaccineInfo.ToList());
                grid.Columns.Add(model => model.Tc as String).Filterable(GridFilterCase.Upper).Named("tcno").Titled("Tc Numarası");
                grid.Columns.Add(model => model.Name + " " + model.Surname as String).Filterable(GridFilterCase.Upper).Named("namesurnamme").Titled("Ad Soyad");
                grid.Columns.Add(model => model.HesCode as String).Filterable(GridFilterCase.Upper).Named("hescode").Titled("Hes Kodu");
                grid.Columns.Add(model => model.is_vaccinated).Titled("Hes Kodu Aşı Durmu" as String).Filterable(GridFilterCase.Upper).Named("isvaccinated").RenderedAs(model => model.is_vaccinated == true ? "Evet" : (model.is_vaccinated == false ? "Hayır" : "Bilgi Bulunamadı"));
                grid.Columns.Add(model => model.IsWantVaccine).Titled("Aşı Olmak İstiyor Mu?" as String).Filterable(GridFilterCase.Upper).Named("asiolmakistiyormu").RenderedAs(model => model.IsWantVaccine == true ? "Evet" : (model.IsWantVaccine == false ? "Hayır" : "Bilgi Bulunamadı"));
                grid.Columns.Add(model => model.VaccineName as String).Filterable(GridFilterCase.Upper).Named("vaccinename").Titled("Aşı Adı");
                grid.Columns.Add(model => model.VaccineDate as String).Filterable(GridFilterCase.Upper).Named("vaccinedate").Titled("Aşı Tarihi");
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
                IGrid<EmployeeVaccineInfo> grid = new Grid<EmployeeVaccineInfo>(_context.EmployeeVaccineInfo.Where(i => i.IsWantVaccine == true).ToList());
                grid.Columns.Add(model => model.Tc as String).Filterable(GridFilterCase.Upper).Named("tcno").Titled("Tc Numarası");
                grid.Columns.Add(model => model.Name + " " + model.Surname as String).Filterable(GridFilterCase.Upper).Named("namesurnamme").Titled("Ad Soyad");
                grid.Columns.Add(model => model.HesCode as String).Filterable(GridFilterCase.Upper).Named("hescode").Titled("Hes Kodu");
                grid.Columns.Add(model => model.is_vaccinated).Titled("Hes Kodu Aşı Durmu" as String).Filterable(GridFilterCase.Upper).Named("isvaccinated").RenderedAs(model => model.is_vaccinated == true ? "Evet" : (model.is_vaccinated == false ? "Hayır" : "Bilgi Bulunamadı"));
                grid.Columns.Add(model => model.IsWantVaccine).Titled("Aşı Olmak İstiyor Mu?" as String).Filterable(GridFilterCase.Upper).Named("asiolmakistiyormu").RenderedAs(model => model.IsWantVaccine == true ? "Evet" : (model.IsWantVaccine == false ? "Hayır" : "Bilgi Bulunamadı"));
                grid.Columns.Add(model => model.VaccineName as String).Filterable(GridFilterCase.Upper).Named("vaccinename").Titled("Aşı Adı");
                grid.Columns.Add(model => model.VaccineDate as String).Filterable(GridFilterCase.Upper).Named("vaccinedate").Titled("Aşı Tarihi");
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
                IGrid<EmployeeVaccineInfo> grid = new Grid<EmployeeVaccineInfo>(_context.EmployeeVaccineInfo.Where(i => i.IsWantVaccine == false).ToList());
                grid.Columns.Add(model => model.Tc as String).Filterable(GridFilterCase.Upper).Named("tcno").Titled("Tc Numarası");
                grid.Columns.Add(model => model.Name + " " + model.Surname as String).Filterable(GridFilterCase.Upper).Named("namesurnamme").Titled("Ad Soyad");
                grid.Columns.Add(model => model.HesCode as String).Filterable(GridFilterCase.Upper).Named("hescode").Titled("Hes Kodu");
                grid.Columns.Add(model => model.is_vaccinated).Titled("Hes Kodu Aşı Durmu" as String).Filterable(GridFilterCase.Upper).Named("isvaccinated").RenderedAs(model => model.is_vaccinated == true ? "Evet" : (model.is_vaccinated == false ? "Hayır" : "Bilgi Bulunamadı"));
                grid.Columns.Add(model => model.IsWantVaccine).Titled("Aşı Olmak İstiyor Mu?" as String).Filterable(GridFilterCase.Upper).Named("asiolmakistiyormu").RenderedAs(model => model.IsWantVaccine == true ? "Evet" : (model.IsWantVaccine == false ? "Hayır" : "Bilgi Bulunamadı"));
                grid.Columns.Add(model => model.VaccineName as String).Filterable(GridFilterCase.Upper).Named("vaccinename").Titled("Aşı Adı");
                grid.Columns.Add(model => model.VaccineDate as String).Filterable(GridFilterCase.Upper).Named("vaccinedate").Titled("Aşı Tarihi");
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

        public JsonResult getEmployee(int ID)
        {
            EmployeeVaccineInfo employeeVaccineInfo = new EmployeeVaccineInfo();
            employeeVaccineInfo = _context.EmployeeVaccineInfo.FirstOrDefault(i => i.Id == ID);
            var json = JsonConvert.DeserializeObject<List<VaccineInfo>>(employeeVaccineInfo.VaccineInformation);
            foreach (var item in json)
            {
                item.VaccineDate.ToString("dd/MM/yyyy");
            }
            return Json(json);

        }

        public JsonResult getStudent(int ID)
        {
            StudentVaccineInfo studentVaccineInfo = new StudentVaccineInfo();
            studentVaccineInfo = _context.StudentVaccineInfo.FirstOrDefault(i => i.Id == ID);
            List<VaccineInfo> json = JsonConvert.DeserializeObject<List<VaccineInfo>>(studentVaccineInfo.VaccineInformation);
            foreach (var item in json)
            {
                item.VaccineDate.ToString("dd/MM/yyyy");
            }
            return Json(json);

        }

        public IActionResult Excel()
        {
            using (var workbook = new XLWorkbook())
            {
               
                var employeeSheet = workbook.Worksheets.Add("Personeller");
                var employeeRow = 5;
                employeeSheet.Range("B2:L3").Merge();

                employeeSheet.Cell(2, 2).Value = "Personel Aşı Merkezi Anketi";
                employeeSheet.Cell(2, 2).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                employeeSheet.Cell(2, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                employeeSheet.Cell(2, 2).Style.Font.Bold = true;
                employeeSheet.Cell(employeeRow, 1).Value = "Tc Kimlik Numarası";
                employeeSheet.Cell(employeeRow, 2).Value = "Görev/Unvan";
                employeeSheet.Cell(employeeRow, 3).Value = "Ad";
                employeeSheet.Cell(employeeRow, 4).Value = "Soyad";
                employeeSheet.Cell(employeeRow, 5).Value = "Hes Kodu";
                employeeSheet.Cell(employeeRow, 6).Value = "Hes Kodu Aşı Durumu";
                employeeSheet.Cell(employeeRow, 7).Value = "Aşı Olmak İstiyor Mu?";
                employeeSheet.Cell(employeeRow, 8).Value = "Aşı Adı";
                employeeSheet.Cell(employeeRow, 9).Value = "Aşı Tarihi";
                employeeSheet.Cell(employeeRow, 10).Value = "1. Aşı";
                employeeSheet.Cell(employeeRow, 11).Value = "2. Aşı";
                employeeSheet.Cell(employeeRow, 12).Value = "3. Aşı";
                employeeSheet.Cell(employeeRow, 13).Value = "4. Aşı";
                employeeSheet.Cell(employeeRow, 1).Style.Font.Bold = true;
                employeeSheet.Cell(employeeRow, 2).Style.Font.Bold = true;
                employeeSheet.Cell(employeeRow, 3).Style.Font.Bold = true;
                employeeSheet.Cell(employeeRow, 4).Style.Font.Bold = true;
                employeeSheet.Cell(employeeRow, 5).Style.Font.Bold = true;
                employeeSheet.Cell(employeeRow, 6).Style.Font.Bold = true;
                employeeSheet.Cell(employeeRow, 7).Style.Font.Bold = true;
                employeeSheet.Cell(employeeRow, 8).Style.Font.Bold = true;
                employeeSheet.Cell(employeeRow, 9).Style.Font.Bold = true;
                employeeSheet.Cell(employeeRow, 10).Style.Font.Bold = true;
                employeeSheet.Cell(employeeRow, 11).Style.Font.Bold = true;
                employeeSheet.Cell(employeeRow, 12).Style.Font.Bold = true;
                employeeSheet.Cell(employeeRow, 13).Style.Font.Bold = true;
                foreach (var apply in _context.EmployeeVaccineInfo)
                {
                    employeeRow++;
                    employeeSheet.Cell(employeeRow, 1).Value = apply.Tc;
                    employeeSheet.Cell(employeeRow, 2).Value = apply.Staff;
                    employeeSheet.Cell(employeeRow, 3).Value = apply.Name;
                    employeeSheet.Cell(employeeRow, 4).Value = apply.Surname;
                    employeeSheet.Cell(employeeRow, 5).Value = apply.HesCode;
                    employeeSheet.Cell(employeeRow, 6).Value = apply.is_vaccinated;
                    if (apply.is_vaccinated == true)
                    {
                        employeeSheet.Cell(employeeRow, 6).Value = "Evet";
                    }
                    else if(apply.is_vaccinated == false)
                    {
                        employeeSheet.Cell(employeeRow, 6).Value = "Hayır";
                    }
                    else
                    {
                        employeeSheet.Cell(employeeRow, 6).Value = "Bilinmiyor";
                    }


                    if (apply.IsWantVaccine == true)
                    {
                        employeeSheet.Cell(employeeRow, 7).Value = "Evet";
                    }
                    else
                    {
                        employeeSheet.Cell(employeeRow, 7).Value = "Hayır";
                    }
                    employeeSheet.Cell(employeeRow, 8).Value = apply.VaccineName;
                    employeeSheet.Cell(employeeRow, 9).Value = apply.VaccineDate;

                    for (int i = 0; i < JsonConvert.DeserializeObject<List<VaccineInfo>>(apply.VaccineInformation).Count; i++)
                    {
                        employeeSheet.Cell(employeeRow, i+10).Value = JsonConvert.DeserializeObject<List<VaccineInfo>>(apply.VaccineInformation)[i].VaccineDate.ToString("dd/MM/yyyy") + " / " + JsonConvert.DeserializeObject<List<VaccineInfo>>(apply.VaccineInformation)[i].VaccineName;

                    }

                }

                employeeSheet.Columns("A:K").AdjustToContents();


                var studentSheet = workbook.Worksheets.Add("Öğrenciler");
                var studentRow = 5;
                studentSheet.Range("B2:L3").Merge();

                studentSheet.Cell(2, 2).Value = "Öğrenci Aşı Merkezi Anketi";
                studentSheet.Cell(2, 2).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                studentSheet.Cell(2, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                studentSheet.Cell(2, 2).Style.Font.Bold = true;
                studentSheet.Cell(studentRow, 1).Value = "Tc Kimlik Numarası";
                studentSheet.Cell(studentRow, 2).Value = "Öğrenci Numarası";
                studentSheet.Cell(studentRow, 3).Value = "Ad";
                studentSheet.Cell(studentRow, 4).Value = "Soyad";
                studentSheet.Cell(studentRow, 5).Value = "Hes Kodu";
                studentSheet.Cell(studentRow, 6).Value = "Hes Kodu Aşı Durumu";
                studentSheet.Cell(studentRow, 7).Value = "Aşı Olmak İstiyor Mu?";
                studentSheet.Cell(studentRow, 8).Value = "Aşı Adı";
                studentSheet.Cell(studentRow, 9).Value = "Aşı Tarihi";
                studentSheet.Cell(studentRow, 10).Value = "1. Aşı";
                studentSheet.Cell(studentRow, 11).Value = "2. Aşı";
                studentSheet.Cell(studentRow, 12).Value = "3. Aşı";
                studentSheet.Cell(studentRow, 13).Value = "4. Aşı";
                studentSheet.Cell(studentRow, 1).Style.Font.Bold = true;
                studentSheet.Cell(studentRow, 2).Style.Font.Bold = true;
                studentSheet.Cell(studentRow, 3).Style.Font.Bold = true;
                studentSheet.Cell(studentRow, 4).Style.Font.Bold = true;
                studentSheet.Cell(studentRow, 5).Style.Font.Bold = true;
                studentSheet.Cell(studentRow, 6).Style.Font.Bold = true;
                studentSheet.Cell(studentRow, 7).Style.Font.Bold = true;
                studentSheet.Cell(studentRow, 8).Style.Font.Bold = true;
                studentSheet.Cell(studentRow, 9).Style.Font.Bold = true;
                studentSheet.Cell(studentRow, 10).Style.Font.Bold = true;
                studentSheet.Cell(studentRow, 11).Style.Font.Bold = true;
                studentSheet.Cell(studentRow, 12).Style.Font.Bold = true;
                studentSheet.Cell(studentRow, 13).Style.Font.Bold = true;
                foreach (var apply in _context.StudentVaccineInfo)
                {
                    studentRow++;
                    studentSheet.Cell(studentRow, 1).Value = apply.Tc;
                    studentSheet.Cell(studentRow, 2).Value = apply.StudentNumber;
                    studentSheet.Cell(studentRow, 3).Value = apply.Name;
                    studentSheet.Cell(studentRow, 4).Value = apply.Surname;
                    studentSheet.Cell(studentRow, 5).Value = apply.HesCode;
                    if (apply.is_vaccinated == true)
                    {
                        studentSheet.Cell(studentRow, 6).Value = "Evet";
                    }
                    else if (apply.is_vaccinated == false)
                    {
                        studentSheet.Cell(studentRow, 6).Value = "Hayır";
                    }
                    else
                    {
                        studentSheet.Cell(studentRow, 6).Value = "Bilinmiyor";
                    }



                    if (apply.IsWantVaccine == true)
                    {
                        studentSheet.Cell(studentRow, 7).Value = "Evet";
                    }
                    else
                    {
                        studentSheet.Cell(studentRow, 7).Value = "Hayır";
                    }
                    studentSheet.Cell(studentRow, 8).Value = apply.VaccineName;
                    studentSheet.Cell(studentRow, 9).Value = apply.VaccineDate;
                    for (int i = 0; i < JsonConvert.DeserializeObject<List<VaccineInfo>>(apply.VaccineInformation).Count; i++)
                    {
                        studentSheet.Cell(studentRow, i + 10).Value = JsonConvert.DeserializeObject<List<VaccineInfo>>(apply.VaccineInformation)[i].VaccineDate + " / " + JsonConvert.DeserializeObject<List<VaccineInfo>>(apply.VaccineInformation)[i].VaccineName;

                    }
                }

                studentSheet.Columns("A:K").AdjustToContents();



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
