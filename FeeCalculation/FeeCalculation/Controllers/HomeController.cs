using FeeCalculation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FeeCalculation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;
        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index(string Error)
        {
            if (Error == "Error")
            {
                var tc = TempData["PassiveStudentTc"];
                PassiveStudent passiveStudent = new PassiveStudent();
                passiveStudent = _context.PassiveStudent.FirstOrDefault(i => i.TcNumber == tc);
                ViewBag.Description = passiveStudent.Description;
                ViewBag.Error = "Error";
            }
            else if (Error == "Overdue")
            {
                ViewBag.Overdue = "Overdue";
            }
            else if (Error == "NotFound")
            {
                ViewBag.NotFound = "Bu Tc numarasına ait öğrenci bulunamadı. ogrencimuhasebesi@halic.edu.tr mail adresi ile iletişime geçebilirsiniz.";
            }
            return View();
        }



        public IActionResult FeeCalculation(string tc)
        {
            ActiveStudent activeStudent = new ActiveStudent();
            activeStudent = _context.ActiveStudent.FirstOrDefault(i => i.TcNumber == tc);
            PassiveStudent passiveStudent = new PassiveStudent();
            passiveStudent = _context.PassiveStudent.FirstOrDefault(i => i.TcNumber == tc);
            OverdueStudent overdueStudent = new OverdueStudent();
            overdueStudent = _context.OverdueStudent.FirstOrDefault(i => i.TcNumber == tc);
            if (passiveStudent != null)
            {
                TempData["PassiveStudentTc"] = tc;
                return RedirectToAction("Index", "Home", new { Error = "Error" });
            }

            else if (overdueStudent != null && overdueStudent.Date < DateTime.Now.AddDays(-3))
            {
                return RedirectToAction("Index", "Home", new { Error = "Overdue" });
            }
            else if (overdueStudent != null && overdueStudent.Date > DateTime.Now.AddDays(-3))
            {
                return View(activeStudent);
            }

            else if (activeStudent != null)
            {
                return View(activeStudent);
            }

            else if (activeStudent == null && overdueStudent ==null && passiveStudent == null)
            {
                return RedirectToAction("Index", "Home", new { Error = "NotFound" });
            }

            return View();
            
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
