using HesOperation.ProlizHesOperation;
using HesOperation.ProlizOperation;
using HesOperation.Uyumsoft;
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
    public class UyumsoftController : Controller
    {

        private readonly AppDbContext _context;
        private readonly KonfidesDbContext _contextKonfides;

        public UyumsoftController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> GetAllEmployee()
        {
            IUyumsoftServiceManager mng = new UyumsoftServiceManager();

            var dataProliz = mng.GetAllEmployee();


            for (int i = 0; i < dataProliz.Count; i++)
            {
                
                ProlizData prolizData = _context.ProlizData.FirstOrDefault(j => j.TCKIMLIKNO == dataProliz[i].TcKimlikNo && j.TIP != "Öğrenci");
                if (prolizData == null)
                {
                    if (dataProliz[i].Gorev != "Stajyer (Öğrenci)" && dataProliz[i].Gorev != "DESTEK ÖĞRENCİ" && dataProliz[i].GorevKodu != "20.20.13" && dataProliz[i].GorevKodu != "20.40.15") 
                    {
                        ProlizData proliz = new ProlizData();
                    proliz.Ad = dataProliz[i].Adı;
                    proliz.Soyad = dataProliz[i].Soyadı;
                    proliz.TCKIMLIKNO = dataProliz[i].TcKimlikNo;
                    proliz.Departman = dataProliz[i].Gorev;
                    proliz.TIP = dataProliz[i].IstihdamTuru;
                    proliz.SNO = dataProliz[i].TcKimlikNo;
                    proliz.RegisterId = dataProliz[i].RegisterId;

                    proliz.HESKOD = (dataProliz[i].HesCode.Replace(" ","").Replace("-",""));

                    proliz.Phone = dataProliz[i].MobileTel;
                    proliz.Email = dataProliz[i].EMail;
                    proliz.Picture = "https://erprapor.halic.edu.tr/ShowImages.aspx?RegisterId=" + Convert.ToString(dataProliz[i].RegisterId);
                    _context.ProlizData.Add(proliz);
                    }
                }
                else if (prolizData!= null)
                {
                        prolizData.Ad = dataProliz[i].Adı;
                        prolizData.Soyad = dataProliz[i].Soyadı;
                        prolizData.TCKIMLIKNO = dataProliz[i].TcKimlikNo;
                        prolizData.Departman = dataProliz[i].Gorev;
                        prolizData.TIP = dataProliz[i].IstihdamTuru;
                        prolizData.SNO = dataProliz[i].TcKimlikNo;
                        prolizData.RegisterId = dataProliz[i].RegisterId;
                        prolizData.HESKOD = dataProliz[i].HesCode;
                        prolizData.Phone = dataProliz[i].MobileTel;
                        prolizData.Email = dataProliz[i].EMail;
                        prolizData.Picture = "https://erprapor.halic.edu.tr/ShowImages.aspx?RegisterId=" + Convert.ToString(dataProliz[i].RegisterId);
                        _context.ProlizData.Update(prolizData);
                    
                }
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Admin");
        }
    }
}
