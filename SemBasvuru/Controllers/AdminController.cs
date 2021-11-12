using SemBasvuru.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NonFactors.Mvc.Grid;
using System.Data;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using Newtonsoft.Json;
using ClosedXML.Excel;

namespace SemBasvuru.Controllers
{
    [Authorize()]
    public class AdminController : Controller
    {

        private string Url = "https://www.halic.edu.tr/DataSource?key=5a365f0f-d3cb-4b02-83cc-40ac681bcbb8&key=5a365f0f-d3cb-4b02-83cc-40ac681bcbb8";
        private async Task<HttpClient> ClientOlustur()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");


            return client;
        }
        public IActionResult Student()
        {
            var data = VerileriGetir();

            var res = ListData(data.Result);
            
            return View(res);

        }
        public async Task<IEnumerable<SemBasvuru.Models.Student>> VerileriGetir()
        {
            HttpClient client = await ClientOlustur();
            var result = await client.GetStringAsync(Url);
            var res = JsonConvert.DeserializeObject<IEnumerable<Student>>(result);
            res = res.OrderByDescending(x => x.BasvuruTarihi).ToList();
            return res;
        }

        private IGrid<Student> ListData(IEnumerable<Student> student)
        {
            IGrid<Student> grid = new Grid<Student>(student.ToList());
            grid.Columns.Add(model => model.Id).Titled("Id");
            grid.Columns.Add(model => model.AdSoyad).Titled("Ad Soyad");
            grid.Columns.Add(model => model.Email).Titled("Email");
            grid.Columns.Add(model => model.Telefon).Titled("Telefon");
            grid.Columns.Add(model => model.Egitim).Titled("Eğitim");
            grid.Columns.Add(model => model.BasvuruTarihi.Date.ToString("dd/MM/yyyy")).Titled("Başvuru Tarihi");
            foreach (IGridColumn column in grid.Columns)
            {

                column.Filter.IsEnabled = true;
                column.Sort.IsEnabled = true;
            }

            return grid;
        }

        public IActionResult Excel()
        {
            var data = VerileriGetir();
            IEnumerable<Student> student = data.Result;
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Basvurular");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "Ad Soyad";
                worksheet.Cell(currentRow, 3).Value = "Email";
                worksheet.Cell(currentRow, 4).Value = "Telefon";
                worksheet.Cell(currentRow, 5).Value = "Eğitim";
                worksheet.Cell(currentRow, 6).Value = "Başvuru Tarihi";
                foreach (var item in student)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = item.Id;
                    worksheet.Cell(currentRow, 2).Value = item.AdSoyad;
                    worksheet.Cell(currentRow, 3).Value = item.Email;
                    worksheet.Cell(currentRow, 4).Value = item.Telefon;
                    worksheet.Cell(currentRow, 5).Value = item.Egitim;
                    worksheet.Cell(currentRow, 6).Value = item.BasvuruTarihi;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "basvurular.xlsx");
                }
            }
        }
    }
}
