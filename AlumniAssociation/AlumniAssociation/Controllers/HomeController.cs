using AlumniAssociation.Models;
using ClosedXML.Excel;
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

namespace AlumniAssociation.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly LoginDbContext _contextApp;

        public HomeController(AppDbContext context, LoginDbContext contextApp)
        {
            _context = context;
            _contextApp = contextApp;
        }

        public IActionResult Index()
        {
            return View(_context.View_MezunlarDernegi_FormBuilder.ToList());
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
            var data = ListGrid(_context.View_MezunlarDernegi_FormBuilder.ToList());

            return View(data);
        }

        [Authorize]
        private IGrid<View_MezunlarDernegi_FormBuilder> ListGrid(List<View_MezunlarDernegi_FormBuilder> models)
        {
            IGrid<View_MezunlarDernegi_FormBuilder> grid = new Grid<View_MezunlarDernegi_FormBuilder>(models.ToList());

            grid.Columns.Add(model => model.Ad_Soyad).Titled("Ad Soyad").Filterable(GridFilterCase.Lower);
            grid.Columns.Add(model => model.DogumYeri).Titled("Doğum Yeri").Filterable(GridFilterCase.Lower);
            grid.Columns.Add(model => model.DogumTarihi).Titled("Doğum Tarihi").Filterable(GridFilterCase.Lower);
            grid.Columns.Add(model => model.MezunFakulte).Titled("Fakülte").Filterable(GridFilterCase.Lower);
            grid.Columns.Add(model => model.MezunBolum).Titled("Bölüm").Filterable(GridFilterCase.Lower);
            grid.Columns.Add(model => model.MezunYili).Titled("Mezuniyet Yılı").Filterable(GridFilterCase.Lower);
            grid.Columns.Add(model => model.CalistigiKurum).Titled("Çalıştığı Kurum").Filterable(GridFilterCase.Lower);
            grid.Columns.Add(model => model.Gorev).Titled("Görev").Filterable(GridFilterCase.Lower);
            grid.Columns.Add(model => model.Isyeri).Titled("İş Yeri").Filterable(GridFilterCase.Lower);
            grid.Columns.Add(model => model.Il).Titled("İl").Filterable(GridFilterCase.Lower);
            grid.Columns.Add(model => model.Expr1).Titled("İlçe").Filterable(GridFilterCase.Lower);
            foreach (IGridColumn column in grid.Columns)
            {
                column.Filter.IsEnabled = true;
                column.Sort.IsEnabled = true;
            }

            return grid;
        }

        [Authorize]
        public IActionResult Excel()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Basvurular");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Ad Soyad";
                worksheet.Cell(currentRow, 2).Value = "Doğum Yeri";
                worksheet.Cell(currentRow, 3).Value = "Doğum Tarihi";
                worksheet.Cell(currentRow, 4).Value = "Fakülte";
                worksheet.Cell(currentRow, 5).Value = "Bölüm";
                worksheet.Cell(currentRow, 6).Value = "Mezuniyet Yılı";
                worksheet.Cell(currentRow, 7).Value = "Çalıştığı Kurum";
                worksheet.Cell(currentRow, 8).Value = "Görev";
                worksheet.Cell(currentRow, 9).Value = "İş Yeri";
                worksheet.Cell(currentRow, 10).Value = "İl";
                worksheet.Cell(currentRow, 11).Value = "İlçe";

                foreach (var apply in _context.View_MezunlarDernegi_FormBuilder)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = apply.Ad_Soyad;
                    worksheet.Cell(currentRow, 2).Value = apply.DogumYeri;
                    worksheet.Cell(currentRow, 3).Value = apply.DogumTarihi;
                    worksheet.Cell(currentRow, 4).Value = apply.MezunFakulte;
                    worksheet.Cell(currentRow, 5).Value = apply.MezunBolum;
                    worksheet.Cell(currentRow, 6).Value = apply.MezunYili;
                    worksheet.Cell(currentRow, 7).Value = apply.CalistigiKurum;
                    worksheet.Cell(currentRow, 8).Value = apply.Gorev;
                    worksheet.Cell(currentRow, 9).Value = apply.Isyeri;
                    worksheet.Cell(currentRow, 10).Value = apply.Il;
                    worksheet.Cell(currentRow, 11).Value = apply.Expr1;

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

    }
}
