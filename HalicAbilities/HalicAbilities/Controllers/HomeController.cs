using ClosedXML.Excel;
using HalicAbilities.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NonFactors.Mvc.Grid;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HalicAbilities.Controllers
{
    public class HomeController : Controller
    {
        private readonly AbilitiesDbContext _context;
        private readonly AppDbContext _contextApp;

        public HomeController(AbilitiesDbContext context, AppDbContext contextApp)
        {
            _context = context;
            _contextApp = contextApp;
        }

        public IActionResult Index(Users user)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        
        public async Task<IActionResult> Login(string UserName, string Password)
        {
            var user = _contextApp.Users.FirstOrDefault(i => i.UserName == UserName && i.Password == Password);
            if (user != null)
            {
                var claims = new List<Claim>{
                    new Claim(ClaimTypes.Name, UserName)
                };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("StudentList", "Home");


            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Home");
        }

        [Authorize]
        public IActionResult StudentList()
        {
            var data = AbilitiesistGrid(_context.View_HalicinYetenekleri_FormBuilder.ToList());

            return View(data);
        }

        [Authorize]
        private IGrid<View_HalicinYetenekleri_FormBuilder> AbilitiesistGrid(List<View_HalicinYetenekleri_FormBuilder> models)
        {
            IGrid<View_HalicinYetenekleri_FormBuilder> grid = new Grid<View_HalicinYetenekleri_FormBuilder>(models.ToList());

            grid.Columns.Add(model => model.Ad_Soyad).Titled("Ad Soyad");
            grid.Columns.Add(model => model.Kimlik_No).Titled("Kimlik No");
            grid.Columns.Add(model => model.Telefon).Titled("Telefon");
            grid.Columns.Add(model => model.EMail).Titled("Email");
            grid.Columns.Add(model => model.Sehir).Titled("Şehir");
            grid.Columns.Add(model => model.ilce).Titled("İlçe");
            grid.Columns.Add(model => model.Egitim_Durum).Titled("Eğitim Durumu");
            grid.Columns.Add(model => model.Referans_Info).Titled("Referans");
            grid.Columns.Add(model => model.Spor_Lisans_VarMi).Titled("Spor Lisansı");
            grid.Columns.Add(model => "<a href='#' type='button' class='detay btn btn-primary' id='detayModal' data-toggle='modal' data-aday='" + model.GroupKey + "' data-target='#modalGrup'><i class='fa fa-book'></i></a>").Titled("Detay").Encoded(false);
            grid.Columns.Add(model => "<a href='https://halicinyetenekleri.halic.edu.tr/" + model.DosyaYukle + "' class='detay btn btn-primary' target='_blank'><i class='fa fa-book'></i></a> ").Titled("Dosyalar").Encoded(false);

            foreach (IGridColumn column in grid.Columns)
            {
                column.Filter.IsEnabled = true;
                column.Sort.IsEnabled = true;
            }

            return grid;
        }

        [Authorize]
        public IActionResult ExcelAbilities()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Basvurular");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Ad Soyad";
                worksheet.Cell(currentRow, 2).Value = "Kimlik No";
                worksheet.Cell(currentRow, 3).Value = "Telefon";
                worksheet.Cell(currentRow, 4).Value = "Email";
                worksheet.Cell(currentRow, 5).Value = "Şehir";
                worksheet.Cell(currentRow, 6).Value = "İlçe";
                worksheet.Cell(currentRow, 7).Value = "Eğitim Durumu";

                worksheet.Cell(currentRow, 8).Value = "Referans";
                worksheet.Cell(currentRow, 9).Value = "Spor Lisansı";
                worksheet.Cell(currentRow, 10).Value = "Bölüm 1";
                worksheet.Cell(currentRow, 11).Value = "Bölüm 2";
                worksheet.Cell(currentRow, 12).Value = "Bölüm 3";
                worksheet.Cell(currentRow, 13).Value = "Yabancı Dil";
                worksheet.Cell(currentRow, 14).Value = "Hakkında";
                worksheet.Cell(currentRow, 15).Value = "Yetenekler";
                worksheet.Cell(currentRow, 16).Value = "Başvuru Tipi";
                worksheet.Cell(currentRow, 17).Value = "Dosya";

                foreach (var apply in _context.View_HalicinYetenekleri_FormBuilder)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = apply.Ad_Soyad;
                    worksheet.Cell(currentRow, 2).Value = apply.Kimlik_No;
                    worksheet.Cell(currentRow, 3).Value = apply.Telefon;
                    worksheet.Cell(currentRow, 4).Value = apply.EMail;
                    worksheet.Cell(currentRow, 5).Value = apply.Sehir;
                    worksheet.Cell(currentRow, 6).Value = apply.ilce;
                    worksheet.Cell(currentRow, 7).Value = apply.Egitim_Durum;

                    worksheet.Cell(currentRow, 8).Value = apply.Referans_Info;
                    worksheet.Cell(currentRow, 9).Value = apply.Spor_Lisans_VarMi;
                    worksheet.Cell(currentRow, 10).Value = apply.Bolum1;
                    worksheet.Cell(currentRow, 11).Value = apply.Bolum2;
                    worksheet.Cell(currentRow, 12).Value = apply.Bolum3;
                    worksheet.Cell(currentRow, 13).Value = apply.YabanciDil;
                    worksheet.Cell(currentRow, 14).Value = apply.Hakkimda;
                    worksheet.Cell(currentRow, 15).Value = apply.Yeteneklerim;
                    worksheet.Cell(currentRow, 16).Value = apply.Basvuru_Tipi;
                    worksheet.Cell(currentRow, 17).Value = apply.DosyaYukle;



                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "Basvurular.xlsx");
                }
            }
        }

        public JsonResult GetData(string ID)
        {
            var result = _context.View_HalicinYetenekleri_FormBuilder.FirstOrDefault(i => i.GroupKey == ID);
            //var json = JsonConvert.SerializeObject(result);
            return Json(result);

        }

    }
}
