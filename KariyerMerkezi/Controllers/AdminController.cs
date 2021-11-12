using KariyerMerkezi.Models;
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
using System.Drawing;
using System.Net.Mail;
using Microsoft.AspNetCore.SignalR;
using KariyerMerkezi.Hubs;
using Microsoft.Extensions.DependencyInjection;

namespace KariyerMerkezi.Controllers
{
    [Authorize()]
    public class AdminController : Controller
    {
       
        private readonly StudentContext _context;

        
        public AdminController(StudentContext context)
        {
            _context = context;
        }

        public ActionResult MailManager()
        {
            var userAdmin = _context.Kullanici.FirstOrDefault(i => i.KullaniciAdi == "kariyermerkezi");
            return View(userAdmin);
        }

        public async Task<IActionResult> MailCrud(string mail, string password)
        {
            var userAdmin = _context.Kullanici.FirstOrDefault(i => i.KullaniciAdi == "kariyermerkezi");
            userAdmin.EPosta = mail;
            userAdmin.Sifre = password;
            _context.SaveChanges();
            return RedirectToAction(nameof(MailManager));
        }

        public ActionResult Home()
        {
            var etkinlikSayisi = _context.Etkinlik.Count();
            var basvuruSayisi = _context.Katilimci.Count();
            var aktifEtkinlik = 0;
            var pasifEtkinlik = 0;
            foreach (var item in _context.Etkinlik)
            {
                if (item.IsActive == true)
                {
                    aktifEtkinlik++;
                }
                else
                {
                    pasifEtkinlik++;
                }
            }
            ViewBag.etkinlikSayisi = etkinlikSayisi;
            ViewBag.basvuruSayisi = basvuruSayisi;
            ViewBag.aktifEtkinlik = aktifEtkinlik;
            ViewBag.pasifEtkinlik = pasifEtkinlik;
            return View();
        }

        public async Task<IActionResult> EtkinlikDelete(int? id)
        {
            var etkinlik = await _context.Etkinlik.FindAsync(id);
            _context.Etkinlik.Remove(etkinlik);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Etkinlik));
        }

        public async Task<IActionResult> GrupDelete(int? id)
        {
            var grup = await _context.Grup.FindAsync(id);
            _context.Grup.Remove(grup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Grup));
        }

        [HttpGet]
        public ActionResult StudentList()
        {
            var data = List();
            return View(data);

        }

        public ActionResult Etkinlik()
        {
            var data = EtkinlikList();
            return View(data);

        }

        public ActionResult YoklamaGeldi(List<int> Secim)
        {
            int grupID = 0;
            foreach (var item in Secim)
            {
                Katilimci_Etkinlik katilimci = new Katilimci_Etkinlik();
                katilimci = _context.Katilimci_Etkinlik.FirstOrDefault(i => i.ID == item);
                katilimci.Yoklama = null;
                grupID = katilimci.GrupID;
            }
            var grup = _context.Grup.FirstOrDefault(i => i.ID == grupID);
            _context.SaveChanges();
            return RedirectToAction("EtkinlikDetay", new { id = grup.EtkinlikID });

        }

        public ActionResult YoklamaGelmedi(List<int> Secim)
        {
            int grupID = 0;
            foreach (var item in Secim)
            {
                Katilimci_Etkinlik katilimci = new Katilimci_Etkinlik();
                katilimci = _context.Katilimci_Etkinlik.FirstOrDefault(i => i.ID == item);
                katilimci.Yoklama = null;
                grupID = katilimci.GrupID;

            }
            var grup = _context.Grup.FirstOrDefault(i => i.ID == grupID);
            _context.SaveChanges();
            return RedirectToAction("EtkinlikDetay", new { id = grup.EtkinlikID });

        }

        static string UppercaseWords(string value)
        {
            char[] array = value.ToCharArray();
            // Handle the first letter in the string.
            if (array.Length >= 1)
            {
                if (char.IsLower(array[0]))
                {
                    array[0] = char.ToUpper(array[0]);
                }
            }
            // Scan through the letters, checking for spaces.
            // ... Uppercase the lowercase letters following spaces.
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] != ' ')
                {
                    array[i] = char.ToLower(array[i]);
                }
                else
                {
                    array[i] = char.ToUpper(array[i]);
                }
            }
            return new string(array);
        }

        public ActionResult Sertifika(List<int> Secim)
        {
            int grupID = 0;
            foreach (var item in Secim)
            {
                Katilimci_Etkinlik katilimci = new Katilimci_Etkinlik();
                katilimci = _context.Katilimci_Etkinlik.FirstOrDefault(i => i.ID == item);
                katilimci.Sertifika = false;
                grupID = katilimci.GrupID;
            }
            var grup = _context.Grup.FirstOrDefault(i => i.ID == grupID);
            _context.SaveChanges();
            foreach (var item in Secim)
            {
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;

                var student = _context.Grup_Katilimci_Etkinlik.FirstOrDefault(i => i.ID == item);
                string nameSurname = UppercaseWords(student.Ad_Soyad);
                string cource = student.Egitim_Adi;
                DateTime date = student.Grup_BaslangicTarihi;
                PointF nameLocation = new PointF(1000f, 1650f);
                PointF courceLocation = new PointF(1245f, 2360f);
                PointF dateLocation = new PointF(1245f, 2440f);
                string imageFilePath = @"wwwroot/images/sertifika.png";
                Bitmap bitmap = (Bitmap)Image.FromFile(imageFilePath);//load the image file
                Font nameFont = new Font("Calibri", 17, FontStyle.Bold);
                Font courceFont = new Font("Calibri", 17, FontStyle.Bold);
                Brush brush = new SolidBrush(Color.FromArgb(0, 25, 108));
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    using (nameFont)
                    {
                        graphics.DrawString(nameSurname, nameFont, brush , nameLocation);
                        graphics.DrawString(cource, courceFont, brush, courceLocation, sf);
                        graphics.DrawString(date.ToString("dd/MM/yyyy"), courceFont, brush, dateLocation, sf);
                        bitmap.Save(item + ".png", System.Drawing.Imaging.ImageFormat.Png);
                        //bitmap.Clone();
                    }
                }
                var userAdmin = _context.Kullanici.FirstOrDefault(i => i.KullaniciAdi == "kariyermerkezi");

                MailMessage ePosta = new MailMessage();
                ePosta.From = new MailAddress(userAdmin.EPosta, "Kariyer Merkezi");
                ePosta.IsBodyHtml = true;
                ePosta.To.Add(student.Eposta); //student.Eposta
                ePosta.Attachments.Add(new Attachment(item + ".png"));
                ePosta.Subject = "Sertifika";
                ePosta.Body = "Değerli Öğrencimiz, </br > Kariyer Merkezinin düzenlediği etkinliğe katılımınız onaylandığı için ekteki 'Katılım Sertifikası' tarafınıza gönderilmiştir. </br > İyi günler dileriz </br > Kariyer Merkezi";
                SmtpClient smtp = new SmtpClient();

                
                smtp.Credentials = new System.Net.NetworkCredential(userAdmin.EPosta,userAdmin.Sifre);
                smtp.Port = 587;
                smtp.Host = "smtp.outlook.com";
                smtp.EnableSsl = true;
                object userState = ePosta;
                bool kontrol = true;
                try
                {
                    // smtp.SendAsync(ePosta, (object)ePosta);
                    smtp.Send(ePosta);
                    //smtp.Dispose();
                    ePosta.Attachments.Dispose();
                    if (System.IO.File.Exists(item + ".png"))
                    {
                        System.IO.File.Delete(item + ".png");
                    }

                }
                catch (SmtpException ex)
                {
                    kontrol = false;
                    var hata = ex.Message;
                    // System.Windows.Forms.MessageBox.Show(ex.Message, "Mail Gönderme Hatasi");
                }
            }


            return RedirectToAction("EtkinlikDetay", new { id = grup.EtkinlikID });

        }

        public ActionResult Grup()
        {
            var data = GrupList();
            return View(data);

        }

        private IGrid<Grup_Katilimci_Etkinlik> List()
        {
                IGrid<Grup_Katilimci_Etkinlik> grid = new Grid<Grup_Katilimci_Etkinlik>(_context.Grup_Katilimci_Etkinlik.ToList());
                grid.Columns.Add(model => model.ID).Titled("ID");
                grid.Columns.Add(model => model.Ad_Soyad).Titled("Ad Soyad");
                grid.Columns.Add(model => model.OgrenciNo).Titled("Öğrenci No");
                grid.Columns.Add(model => model.GSM).Titled("Telefon");
                grid.Columns.Add(model => model.Eposta).Titled("E-Posta");
                grid.Columns.Add(model => model.FakulteAd).Titled("Fakülte");
                grid.Columns.Add(model => model.BolumAd).Titled("Bölüm");
                grid.Columns.Add(model => model.Egitim_Adi).Titled("Eğitim");
                grid.Columns.Add(model => model.Grup_Adi).Titled("Grup");
            foreach (IGridColumn column in grid.Columns)
                {

                    column.Filter.IsEnabled = true;
                    column.Sort.IsEnabled = true;
                }

                return grid;
        }

        private IGrid<Etkinlik> EtkinlikList()
        {

            IGrid <Etkinlik> grid = new Grid<Etkinlik>(_context.Etkinlik.OrderByDescending(i => i.ID).ToList());
            grid.Columns.Add(model => model.ID).Titled("ID");
            grid.Columns.Add(model => model.Ad).Titled("Ad");
            grid.Columns.Add(model => model.BaslangicTarihi).Titled("Başlangıç Tarihi");
            grid.Columns.Add(model => model.BaslangicTarihi).Titled("Başlangıç Tarihi");
            grid.Columns.Add(model => model.IsActive == true ? "Aktif" : "Pasif").Titled("Durum");
            grid.Columns.Add(model => model.Tur == 0 ? "Eğitim" : model.Tur==1 ? "Konferans" : model.Tur==2 ? "Etkinlik" : "Seminer").Titled("Tür");
            grid.Columns.Add(model => "<a href='#' type='button' class='detay btn btn-primary' id='detayModal' data-toggle='modal' data-aday='" + model.ID + "' data-target='#modalGrup'><i class='fa fa-book'></i></a>").Titled("Grup").Encoded(false);
            grid.Columns.Add(model => "<a href='#' type='button' class='detay btn btn-primary' id='detayModal' data-toggle='modal' data-aday='" + model.ID + "' data-target='#modalDetay'><i class='fa fa-book'></i></a> <a href='#' type='button' class='detay btn btn-primary' id='detayModal' data-toggle='modal' data-aday='" + model.ID + "' data-target='#modalDelete'><i class='fa fa-trash'></i></a> <a id='DetailBtn' href='EtkinlikDetay?id=" + model.ID + "'  type='button' class='detay btn btn-primary'><i class='fa fa-user'></i></a>").Titled("Detay").Encoded(false).Css("col-width");
            foreach (IGridColumn column in grid.Columns)
            {
                column.Filter.IsEnabled = true;
                column.Sort.IsEnabled = true;
            }

            return grid;
        }

        private IGrid<Grup> GrupList()
        {
            IGrid<Grup> grid = new Grid<Grup>(_context.Grup.OrderByDescending(i => i.ID).ToList());
            grid.Columns.Add(model => model.ID).Titled("ID");
            grid.Columns.Add(model => model.Ad).Titled("Ad");
            grid.Columns.Add(model => _context.Etkinlik.FirstOrDefault(i => i.ID == model.EtkinlikID).Ad ).Titled("EtkinlikID");
            grid.Columns.Add(model => model.IsActive == true ? "Aktif" : "Pasif").Titled("Durum");
            grid.Columns.Add(model => model.Kapasite).Titled("Kapasite");
            grid.Columns.Add(model => model.Lokasyon).Titled("Lokasyon");
            grid.Columns.Add(model => model.BaslangicTarihi).Titled("Başlangıç Tarihi");
            grid.Columns.Add(model => model.BitisTarihi).Titled("Bitiş Tarihi");
            grid.Columns.Add(model => "<a href='#' type='button' class='detay btn btn-primary' id='detayModal' data-toggle='modal' data-aday='" + model.ID + "' data-target='#modalGrup'><i class='fa fa-book'></i></a> <a href='#' type='button' class='detay btn btn-primary' id='detayModal' data-toggle='modal' data-aday='" + model.ID + "' data-target='#modalDelete'><i class='fa fa-trash'></i></a>").Titled("Detay").Encoded(false);
            foreach (IGridColumn column in grid.Columns)
            {

                column.Filter.IsEnabled = true;
                column.Sort.IsEnabled = true;
            }

            return grid;
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Ad,BaslangicTarihi,BitisTarihi,Aciklama,EtkinlikResim,IsGroup,IsActive,EgitimIcerigiHTML,GrupAciklama,Sira,Tur,Konferans_Kontenjan,Basvuru_Acikmi")] Etkinlik etkinlik, IFormFile EtkinlikResim)
        {
            if (EtkinlikResim != null)
            {
                //var extent = Path.GetExtension(EtkinlikResim.FileName);
                //var randomName = ($"{Guid.NewGuid()}{extent}");
                var path = Path.Combine(Directory.GetCurrentDirectory(), "..\\Content\\images", EtkinlikResim.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await EtkinlikResim.CopyToAsync(stream);
                }
            }
            if (ModelState.IsValid)
            {
                etkinlik.Sira = 1;
                etkinlik.IsGroup = true;
                etkinlik.EtkinlikResim = "panel/images/" + EtkinlikResim.FileName;
                _context.Add(etkinlik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Etkinlik));
            }
            return View(etkinlik);
        }

        public IActionResult GrupCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GrupCreate([Bind("ID,Ad,EtkinlikID,Kapasite,IsActive,Lokasyon,BaslangicTarihi,BitisTarihi")] Grup grup)
        {
            if (ModelState.IsValid)
            {
                var EtkinlikGrup = _context.Etkinlik.FirstOrDefault(i => i.ID == grup.EtkinlikID);
                EtkinlikGrup.IsGroup = true;
                grup.IsActive = true;
                _context.Add(grup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Grup));
            }
            return View(grup);
        }

        [HttpGet]
        public JsonResult getData(int ID)
        {
            List<Etkinlik> result = new List<Etkinlik>();
            result.Add(_context.Etkinlik.FirstOrDefault(i => i.ID == ID));
            //var json = JsonConvert.SerializeObject(result);
            return Json(result);

        }

        public JsonResult getDataGrup(int ID)
        {
            List<Grup> result = new List<Grup>();
            result.Add(_context.Grup.FirstOrDefault(i => i.ID == ID));
            //var json = JsonConvert.SerializeObject(result);
            return Json(result);

        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etkinlik = await _context.Etkinlik.FindAsync(id);
            if (etkinlik == null)
            {
                return NotFound();
            }
            return View(etkinlik);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Ad,BaslangicTarihi,BitisTarihi,Aciklama,EtkinlikResim,IsGroup,IsActive,EgitimIcerigiHTML,GrupAciklama,Sira,Tur,Konferans_Kontenjan,Basvuru_Acikmi")] Etkinlik etkinlik, IFormFile EtkinlikResim)
        {
            if (id != etkinlik.ID)
            {
                return NotFound();
            }

            if (EtkinlikResim != null)
            {
                //var extent = Path.GetExtension(EtkinlikResim.FileName);
                //var randomName = ($"{Guid.NewGuid()}{extent}");
                var path = Path.Combine(Directory.GetCurrentDirectory(), "..\\Content\\images", EtkinlikResim.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await EtkinlikResim.CopyToAsync(stream);
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    etkinlik.Sira = 1;
                    etkinlik.IsGroup = true;
                    etkinlik.EtkinlikResim = "/Content/images/" + EtkinlikResim.FileName;
                    _context.Update(etkinlik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EtkinlikExists(etkinlik.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Etkinlik));
            }
            return View(etkinlik);
        }

        private bool EtkinlikExists(int id)
        {
            return _context.Etkinlik.Any(e => e.ID == id);
        }


        public IActionResult ExcelEtkinlik()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Etkinlikler");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Ad";
                worksheet.Cell(currentRow, 2).Value = "Başlangıç Tarihi";
                worksheet.Cell(currentRow, 3).Value = "Bitiş Tarihi";
                worksheet.Cell(currentRow, 4).Value = "Durum";
                worksheet.Cell(currentRow, 5).Value = "Tür";
                
                foreach (var etkinlik in _context.Etkinlik)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = etkinlik.Ad;
                    worksheet.Cell(currentRow, 2).Value = etkinlik.BaslangicTarihi;
                    worksheet.Cell(currentRow, 3).Value = etkinlik.BitisTarihi;
                    if (etkinlik.IsActive == true)
                    {
                        worksheet.Cell(currentRow, 4).Value = "Aktif";
                    }
                    else
                    {
                        worksheet.Cell(currentRow, 4).Value = "Pasif";
                    }
                    if (etkinlik.Tur == 0)
                    {
                        worksheet.Cell(currentRow, 5).Value = "Eğitim";
                    }
                    else if (etkinlik.Tur == 1)
                    {
                        worksheet.Cell(currentRow, 5).Value = "Konferans";
                    }
                    else if (etkinlik.Tur == 2)
                    {
                        worksheet.Cell(currentRow, 5).Value = "Etkinlik";
                    }
                    else
                    {
                        worksheet.Cell(currentRow, 5).Value = "Seminer";
                    }
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "etkinlikler.xlsx");
                }
            }
        }

        public IActionResult ExcelGrup()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Grup");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Ad";
                worksheet.Cell(currentRow, 2).Value = "Başlangıç Tarihi";
                worksheet.Cell(currentRow, 3).Value = "Bitiş Tarihi";
                worksheet.Cell(currentRow, 4).Value = "Durum";
                worksheet.Cell(currentRow, 5).Value = "Kapasite";
                worksheet.Cell(currentRow, 6).Value = "Lokasyon";
                worksheet.Cell(currentRow, 7).Value = "Etkinlik Adı";

                foreach (var grup in _context.Grup)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = grup.Ad;
                    worksheet.Cell(currentRow, 2).Value = grup.BaslangicTarihi;
                    worksheet.Cell(currentRow, 3).Value = grup.BitisTarihi;
                    if (grup.IsActive == true)
                    {
                        worksheet.Cell(currentRow, 4).Value = "Aktif";
                    }
                    else
                    {
                        worksheet.Cell(currentRow, 4).Value = "Pasif";
                    }
                    worksheet.Cell(currentRow, 5).Value = grup.Kapasite;
                    worksheet.Cell(currentRow, 6).Value = grup.Lokasyon;
                    var kisi = _context.Etkinlik.FirstOrDefault(i => i.ID == grup.EtkinlikID);
                    if (kisi != null)
                    {
                        worksheet.Cell(currentRow, 7).Value = kisi.Ad;
                    }
                    else
                    {
                        worksheet.Cell(currentRow, 7).Value = "Etkinlik Bulunamadı";
                    }
                    
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "gruplar.xlsx");
                }
            }
        }

        public IActionResult ExcelBasvurular()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Başvurular");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Ad";
                worksheet.Cell(currentRow, 2).Value = "Bölüm";
                worksheet.Cell(currentRow, 3).Value = "Fakülte";
                worksheet.Cell(currentRow, 4).Value = "E-posta";
                worksheet.Cell(currentRow, 5).Value = "GSM";
                worksheet.Cell(currentRow, 6).Value = "Sınıf";
                worksheet.Cell(currentRow, 7).Value = "Durum";
                worksheet.Cell(currentRow, 8).Value = "Grup Adı";
                worksheet.Cell(currentRow, 9).Value = "Grup Başlangıç Tarihi";
                worksheet.Cell(currentRow, 10).Value = "Grup Bitiş Tarihi";
                worksheet.Cell(currentRow, 11).Value = "Kapasite";
                worksheet.Cell(currentRow, 12).Value = "Eğitim Adı";
                worksheet.Cell(currentRow, 13).Value = "Öğrenci No";

                foreach (var basvuru in _context.Grup_Katilimci_Etkinlik)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = basvuru.Ad_Soyad;
                    worksheet.Cell(currentRow, 2).Value = basvuru.BolumAd;
                    worksheet.Cell(currentRow, 3).Value = basvuru.FakulteAd;
                    worksheet.Cell(currentRow, 4).Value = basvuru.Eposta;
                    worksheet.Cell(currentRow, 5).Value = basvuru.GSM;
                    worksheet.Cell(currentRow, 6).Value = basvuru.Sinif;
                    worksheet.Cell(currentRow, 7).Value = basvuru.Durum;
                    worksheet.Cell(currentRow, 8).Value = basvuru.Grup_Adi;
                    worksheet.Cell(currentRow, 9).Value = basvuru.Grup_BaslangicTarihi;
                    worksheet.Cell(currentRow, 10).Value = basvuru.Grup_BitisTarihi;
                    worksheet.Cell(currentRow, 11).Value = basvuru.Kapasite;
                    worksheet.Cell(currentRow, 12).Value = basvuru.Egitim_Adi;
                    worksheet.Cell(currentRow, 13).Value = basvuru.OgrenciNo;
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

        public async Task<IActionResult> EtkinlikDetay(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
           var etkinlik = _context.Etkinlik.FirstOrDefault(i => i.ID == id);
            List<Grup_Katilimci_Etkinlik> grup_Katilimci_Etkinlik = new List<Grup_Katilimci_Etkinlik>();
            foreach (var item in _context.Grup_Katilimci_Etkinlik)
            {
                if (item.Egitim_Adi == etkinlik.Ad)
                {
                    grup_Katilimci_Etkinlik.Add(item);
                }
            }
            //return View(grup_Katilimci_Etkinlik);

            var data = EtkinlikKatilimci(grup_Katilimci_Etkinlik);
            return View(data);
        }



        private IGrid<Grup_Katilimci_Etkinlik> EtkinlikKatilimci(List<Grup_Katilimci_Etkinlik> katilimci)
        {
            IGrid<Grup_Katilimci_Etkinlik> grid = new Grid<Grup_Katilimci_Etkinlik>(katilimci.ToList());
            grid.Columns.Add(model => "<input type='checkbox' name='Secim' value='" + model.ID + "'>").Titled("Seçim").Encoded(false);
            grid.Columns.Add(model => model.Ad_Soyad).Titled("Ad Soyad");
            grid.Columns.Add(model => model.OgrenciNo).Titled("Öğrenci No");
            grid.Columns.Add(model => model.GSM).Titled("Telefon");
            grid.Columns.Add(model => model.Eposta).Titled("E-Posta");
            grid.Columns.Add(model => model.FakulteAd).Titled("Fakülte");
            grid.Columns.Add(model => model.BolumAd).Titled("Bölüm");
            grid.Columns.Add(model => model.Egitim_Adi).Titled("Eğitim");
            grid.Columns.Add(model => model.Grup_Adi).Titled("Grup");
            grid.Columns.Add(model => model.Yoklama == true ? "Geldi" : model.Yoklama == false ? "Gelmedi" : "Belirtilmedi").Titled("Yoklama"); 
            grid.Columns.Add(model => model.Sertifika == true ? "Gönderildi" : "Gönderilmedi").Titled("Sertifika");
            foreach (IGridColumn column in grid.Columns)
            {
                column.Filter.IsEnabled = true;
                column.Sort.IsEnabled = true;
            }

            return grid;
        }

        public async Task<IActionResult> SertifikaGonder(int? id)
        {
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;

            var student = _context.Grup_Katilimci_Etkinlik.FirstOrDefault(i => i.ID == id);
            string nameSurname = student.Ad_Soyad;
            string cource = student.Egitim_Adi;
            PointF nameLocation = new PointF(252f, 417f);
            PointF courceLocation = new PointF(308f, 590f);
            string imageFilePath = @"wwwroot/images/sertifika.png";
            Bitmap bitmap = (Bitmap)Image.FromFile(imageFilePath);//load the image file
            Font nameFont = new Font("Arial", 10);
            Font courceFont = new Font("Arial", 12);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                using (nameFont)
                {
                    graphics.DrawString(nameSurname, nameFont, Brushes.Black, nameLocation);
                    graphics.DrawString(cource, courceFont, Brushes.Black, courceLocation, sf);
                    bitmap.Save("sertifika.png", System.Drawing.Imaging.ImageFormat.Png);
                }
            }

            MailMessage ePosta = new MailMessage();
            ePosta.From = new MailAddress("muhammetkayatr@outlook.com");
            //
            ePosta.To.Add("kaya19051997@gmail.com");
             ePosta.Attachments.Add(new Attachment(@"sertifika.png"));
            ePosta.Subject = "Test Konu";
            //
            ePosta.Body = "Test içerik";
            SmtpClient smtp = new SmtpClient();
            //
            smtp.Credentials = new System.Net.NetworkCredential("muhammetkayatr@outlook.com", "kaya2534");
            smtp.Port = 587;
            smtp.Host = "smtp.outlook.com";
            smtp.EnableSsl = true;
            object userState = ePosta;
            bool kontrol = true;
            try
            {
                smtp.SendAsync(ePosta, (object)ePosta);
            }
            catch (SmtpException ex)
            {
                kontrol = false;
                var hata = ex.Message;
               // System.Windows.Forms.MessageBox.Show(ex.Message, "Mail Gönderme Hatasi");
            }
         //   return kontrol;
            return View();
        }
    }
}
