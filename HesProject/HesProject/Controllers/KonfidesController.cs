using HesProject.Models;
using HesProject.Models.konfides;
using HesProject.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HesProject.Controllers
{
    [Authorize]
    public class KonfidesController : Controller
    {
        string HesUrl = "https://hesservis.turkiye.gov.tr/services/g2g/saglik/hes";
        string Baseurl = "https://selfservis.halic.edu.tr/webapi/";

        private readonly AppDbContext _context;
        private readonly KonfidesDbContext _contextKonfides;

        public KonfidesController(AppDbContext context, KonfidesDbContext contextKonfides)
        {
            _context = context;
            _contextKonfides = contextKonfides;
        }
        public IActionResult Index()
        {
            var Ssn = "20070640038";
            var BlackList = false;
            var Safe = false;
              var sonuc = _contextKonfides.Database.ExecuteSqlRaw($"exec sp_External_CardBlacklisting_ForHesCodeIntegration_v2 {Ssn}, {BlackList}, {Safe}");
            //var sonuc = PullData(Ssn);
            return View();
        }
        /*[AllowAnonymous] */ //unutmaaaaa
        public IActionResult ActiveStudent()
        {
            foreach (var item in _context.ActiveStudent.Skip(2).Take(4000))
            {
                var sonuc = PullData(item.TcNumber);
                if (sonuc.Count == 0)
                {
                    var sonuc2 = PullData(item.StudentNumber);
                    if (sonuc2.Count == 0 )
                    {   
                        item.IsCard = false;
                        item.CardStatus = "Kart Bulunamadı";
                        _context.ActiveStudent.Update(item);
                    }
                    else
                    {
                        item.IsCard = true;
                        item.CardStatus = JsonConvert.SerializeObject(sonuc2);
                        _context.ActiveStudent.Update(item);
                    }
                   
                }
                else
                {
                    item.IsCard = true;
                    item.CardStatus = JsonConvert.SerializeObject(sonuc);
                    _context.ActiveStudent.Update(item);
                }

                

            }
            _context.SaveChanges();
            return View();
        }


        public IActionResult CardStatus()
        {
            foreach (var item in _context.ProlizData)
            {
                var sonuc = PullData(item.TCKIMLIKNO);
                if (sonuc.Count == 0)
                {
                    var sonuc2 = PullData(item.SNO);
                    if (sonuc2.Count == 0)
                    {
                        item.IsBlocked = false;
                        _context.ProlizData.Update(item);
                    }
                    else
                    {
                        item.IsBlocked = true;
                        _context.ProlizData.Update(item);
                    }

                }
                else
                {
                    item.IsBlocked = true;
                    _context.ProlizData.Update(item);
                }



            }
            _context.SaveChanges();
            return View();
        }


        public IActionResult Gate(string tc, int GateId, bool result, string action, string controller)
        {
            ProlizData prolizData = _context.ProlizData.FirstOrDefault(i => i.Id == GateId);
                if (result == true) //item.IsBlocked==true eklenecek
                {
                    var Ssn = tc;
                    var BlackList = false;
                    var Safe = false;
                    try
                    {
                        var sonuc = _contextKonfides.Database.ExecuteSqlRaw($"exec sp_External_CardBlacklisting_ForHesCodeIntegration_v2 {Ssn}, {BlackList}, {Safe}");
                        prolizData.IsBlocked = false;
                    prolizData.Description = "Kart kara listeden çıkarıldı.";
                }
                    catch (Exception ex)
                    {
                    prolizData.Description = ex.Message;
                    }

                    _context.ProlizData.Update(prolizData);
                }
            else if (result == false) //item.IsBlocked==true eklenecek
            {
                var Ssn = tc;
                var BlackList = true;
                var Safe = false;
                try
                {
                    var sonuc = _contextKonfides.Database.ExecuteSqlRaw($"exec sp_External_CardBlacklisting_ForHesCodeIntegration_v2 {Ssn}, {BlackList}, {Safe}");
                    prolizData.IsBlocked = true;
                    prolizData.Description = "Kart kara listeye eklendi.";
                }
                catch (Exception ex)
                {
                    prolizData.Description = ex.Message;
                }

                _context.ProlizData.Update(prolizData);
            }

            _context.SaveChanges();


            return RedirectToAction(action, controller);
        }


        public IActionResult GateOperation()
        {
            //foreach (var item in _context.ProlizData.Where(i => i.is_vaccinated != true && i.is_immune == false && i.TIP != "Öğrenci"))
            //{
            //    if (item.last_negative_test_date != null)
            //    {
            //        if (Convert.ToDateTime(item.last_negative_test_date).AddDays(+2) < DateTime.Now)
            //        {
            //            //var Ssn = item.TCKIMLIKNO;
            //            //var BlackList = true;
            //            //var Safe = false;
            //            //try
            //            //{
            //            //    var sonuc = _contextKonfides.Database.ExecuteSqlRaw($"exec sp_External_CardBlacklisting_ForHesCodeIntegration_v2 {Ssn}, {BlackList}, {Safe}");
            //            //    item.IsBlocked = true;
            //            //    item.Description = "Kara Listede";
            //            //}
            //            //catch (Exception ex)
            //            //{
            //            //    item.Description = ex.Message;
            //            //}

            //            //_context.ProlizData.Update(item);
            //        }
            //        else
            //        {
            //            //var Ssn = item.TCKIMLIKNO;
            //            //var BlackList = false;
            //            //var Safe = false;
            //            //try
            //            //{
            //            //    var sonuc = _contextKonfides.Database.ExecuteSqlRaw($"exec sp_External_CardBlacklisting_ForHesCodeIntegration_v2 {Ssn}, {BlackList}, {Safe}");
            //            //    item.IsBlocked = false;
            //            //    item.Description = "Kara Listede Değil";
            //            //}
            //            //catch (Exception ex)
            //            //{
            //            //    item.Description = ex.Message;
            //            //}

            //            //_context.ProlizData.Update(item);
            //        }

            //    }
            //    else
            //    {
            //        //var Ssn = item.TCKIMLIKNO;
            //        //var BlackList = true;
            //        //var Safe = false;
            //        //try
            //        //{
            //        //    var sonuc = _contextKonfides.Database.ExecuteSqlRaw($"exec sp_External_CardBlacklisting_ForHesCodeIntegration_v2 {Ssn}, {BlackList}, {Safe}");
            //        //    item.IsBlocked = true;
            //        //    item.Description = "Kara Listede";
            //        //}
            //        //catch (Exception ex)
            //        //{
            //        //    item.Description = ex.Message;
            //        //}

            //        //_context.ProlizData.Update(item);
            //    }
            //}

            foreach (var item in _context.ProlizData.Where(i => i.current_health_status == "RISKY" && i.TIP != "Öğrenci"))
            {
                if (item.IsBlocked != true)
                {
                    var Ssn = item.TCKIMLIKNO;
                    var BlackList = true;
                    var Safe = false;
                    try
                    {
                        var sonuc = _contextKonfides.Database.ExecuteSqlRaw($"exec sp_External_CardBlacklisting_ForHesCodeIntegration_v2 {Ssn}, {BlackList}, {Safe}");
                        item.IsBlocked = true;
                        item.Description = "Kara Listede";
                    }
                    catch (Exception ex)
                    {
                        item.Description = ex.Message;
                    }

                    _context.ProlizData.Update(item);
                }
            }

            foreach (var item in _context.ProlizData.Where(i => i.current_health_status != "RISKLESS" && i.TIP == "Öğrenci"))
            {
               
                    var Ssn = item.SNO;
                    var BlackList = true;
                    var Safe = false;
                    try
                    {
                        var sonuc = _contextKonfides.Database.ExecuteSqlRaw($"exec sp_External_CardBlacklisting_ForHesCodeIntegration_v2 {Ssn}, {BlackList}, {Safe}");
                        item.IsBlocked = true;
                        item.Description = "Kara Listede";
                    }
                    catch (Exception ex)
                    {
                    bool isTc = false;
                        Ssn = item.TCKIMLIKNO;
                        try
                        {
                            var sonuc = _contextKonfides.Database.ExecuteSqlRaw($"exec sp_External_CardBlacklisting_ForHesCodeIntegration_v2 {Ssn}, {BlackList}, {Safe}");
                            item.IsBlocked = true;
                            isTc = true;
                            item.Description = "Kara Listede";
                        }
                        catch (Exception e)
                        {
                            item.Description = e.Message;
                        }
                     
                    if (item.IsBlocked == true && isTc != true)
                    {
                        item.Description = ex.Message;
                    }
                    
                       }
                _context.ProlizData.Update(item);
            }

            foreach (var item in _context.ProlizData.Where(i => i.current_health_status == "RISKLESS" && i.TIP != "Öğrenci")) // && i.is_vaccinated == true  eklenecek
            {

                //if (item.current_health_status == "RISKLESS" && item.IsBlocked == true) //item.IsBlocked==true eklenecek
                //{
                var Ssn = item.TCKIMLIKNO;
                var BlackList = false;
                var Safe = false;
                try
                {
                    var sonuc = _contextKonfides.Database.ExecuteSqlRaw($"exec sp_External_CardBlacklisting_ForHesCodeIntegration_v2 {Ssn}, {BlackList}, {Safe}");
                    item.IsBlocked = false;
                    item.Description = "Kara Listede Değil";
                }
                catch (Exception ex)
                {
                    item.Description = ex.Message;
                }

                _context.ProlizData.Update(item);
                //}

            }

            foreach (var item in _context.ProlizData.Where(i => i.current_health_status == "RISKLESS" && i.TIP == "Öğrenci"))
            {

                var Ssn = item.SNO;
                var BlackList = false;
                var Safe = false;
                try
                {
                    var sonuc = _contextKonfides.Database.ExecuteSqlRaw($"exec sp_External_CardBlacklisting_ForHesCodeIntegration_v2 {Ssn}, {BlackList}, {Safe}");
                    item.IsBlocked = false;
                    item.Description = "Kara Listede Değil";
                }
                catch (Exception ex)
                {
                    Ssn = item.TCKIMLIKNO;
                    try
                    {
                        var sonuc = _contextKonfides.Database.ExecuteSqlRaw($"exec sp_External_CardBlacklisting_ForHesCodeIntegration_v2 {Ssn}, {BlackList}, {Safe}");
                        item.IsBlocked = false;
                        item.Description = "Kara Listede Değil";
                    }
                    catch (Exception e)
                    {
                        item.Description = e.Message;
                        if (item.IsBlocked == false)
                        {
                            item.Description = ex.Message;
                        }
                    }
                }

                _context.ProlizData.Update(item);


            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Admin");
        }

        private List<KimlikKarti> KimlikKartiSorgula(string parametre)
        {

            List<KimlikKarti> kartlar = new List<KimlikKarti>();



            //var query =
            //    (from bc in _contextKonfides.Bo_Card
            //     join cp in _contextKonfides.Card_Parameters on new { Id = bc.Id } equals new { Id = cp.Card_Id }
            //     join ccCOS in _contextKonfides.Campus_Core_CampusCardOwnership on new { OwnershipId = Convert.ToInt32(bc.OwnershipId) } equals new { OwnershipId = ccCOS.CardOwnershipId } into ccCOS_join
            //     from ccCOS in ccCOS_join.DefaultIfEmpty()
            //     join scCOS in _contextKonfides.SharedKernel_CardOwnershipBase on new { CardOwnershipId = ccCOS.CardOwnershipId } equals new { CardOwnershipId = scCOS.Id } into scCOS_join
            //     from scCOS in scCOS_join.DefaultIfEmpty()
            //     join BI in _contextKonfides.Bo_Individual on new { OwnerId = Convert.ToInt32(bc.OwnerId) } equals new { OwnerId = BI.Id } into BI_join
            //     from BI in BI_join.DefaultIfEmpty()
            //     join scCOS2 in _contextKonfides.SharedKernel_CardOwnershipBase on new { CardOwnershipId = Convert.ToInt32(BI.CardOwnershipId) } equals new { CardOwnershipId = scCOS2.Id } into scCOS2_join
            //     from scCOS2 in scCOS2_join.DefaultIfEmpty()
            //     join ccCOS2 in _contextKonfides.Campus_Core_CampusCardOwnership on new { Id = scCOS2.Id } equals new { Id = ccCOS2.CardOwnershipId } into ccCOS2_join
            //     from ccCOS2 in ccCOS2_join.DefaultIfEmpty()
            //     join skP in _contextKonfides.SharedKernel_PersonalityBase on new { PersonalityId = Convert.ToInt32(bc.PersonalityId) } equals new { PersonalityId = skP.Id } into skP_join
            //     from skP in skP_join.DefaultIfEmpty()
            //     join skPT in _contextKonfides.SharedKernel_PersonalityType on new { PersonalityTypeId = Convert.ToInt32(skP.PersonalityTypeId) } equals new { PersonalityTypeId = skPT.Id } into skPT_join
            //     from skPT in skPT_join.DefaultIfEmpty()
            //     join skp1 in _contextKonfides.SharedKernel_Position on new { PositionId = Convert.ToInt32(skP.PositionId) } equals new { PositionId = skp1.Id } into skp1_join
            //     from skp1 in skp1_join.DefaultIfEmpty()
            //     join skT in _contextKonfides.SharedKernel_Tier on new { TierOneId = skP.TierOneId } equals new { TierOneId = skT.Id } into skT_join
            //     from skT in skT_join.DefaultIfEmpty()
            //     join skT1 in _contextKonfides.SharedKernel_Tier on new { TierTwoId = skP.TierTwoId } equals new { TierTwoId = skT1.Id } into skT1_join
            //     from skT1 in skT1_join.DefaultIfEmpty()
            //     join skT2 in _contextKonfides.SharedKernel_Tier on new { TierThreeId = skP.TierThreeId } equals new { TierThreeId = skT2.Id } into skT2_join
            //     from skT2 in skT2_join.DefaultIfEmpty()
            //     join skT3 in _contextKonfides.SharedKernel_Tier on new { TierFourId = skP.TierFourId } equals new { TierFourId = skT3.Id } into skT3_join
            //     from skT3 in skT3_join.DefaultIfEmpty()
            //     join ccCBL in _contextKonfides.Campus_Core_CardBlacklistingUpdateOrder on new { LastBlacklistingOrderId = Convert.ToInt32(bc.LastBlacklistingOrderId) } equals new { LastBlacklistingOrderId = ccCBL.Id } into ccCBL_join
            //     from ccCBL in ccCBL_join.DefaultIfEmpty()
            //     join ccBLR in _contextKonfides.Campus_Core_BlacklistingReason on new { ReasonId = Convert.ToInt32(ccCBL.ReasonId) } equals new { ReasonId = ccBLR.Id } into ccBLR_join
            //     from ccBLR in ccBLR_join.DefaultIfEmpty()
            //     join tG in _contextKonfides.TerminalEODGroup on new { TerminalEodGroupId = bc.TerminalEodGroupId } equals new { TerminalEodGroupId = tG.ID } into tG_join
            //     from tG in tG_join.DefaultIfEmpty()
            //     select new KimlikKarti
            //     {
            //         KartNo = (decimal?)bc.Id,
            //         KartSeriNo = bc.SerialNumberHexString,
            //         KimlikNo = (decimal?)BI.Ssn,
            //         Ad = bc.OwnerFirstName,
            //         Soyad = bc.OwnerLastName,
            //         AdSoyad = BI.Name,
            //         GeciciKaraListe = bc.IsBlacklisted,
            //         KaraListe = bc.IsPermanentlyBlacklisted,
            //         Kirilim1 = skT.Name,
            //         Kirilim2 = skT1.Name,
            //         Kirilim3 = skT2.Name,
            //         Kirilim4 = skp1.Name,
            //         Kirilim5 = skT3.Name,
            //         KartTipi = skPT.Name,
            //         Durum = ccBLR.Name ?? "Geçiş Serbest",
            //         DurumAciklama = ccBLR.PosTextFormat ?? "Geçiş Serbest"
            //     }).ToList();


            
            
            var query = _contextKonfides.Database.ExecuteSqlCommand("select bc.Id as 'KartNo',bc.SerialNumberHexString as 'KartSeriNo',BI.Ssn as 'KimlikNo',bc.OwnerFirstName as 'Ad',bc.OwnerLastName as 'Soyad',BI.Name as 'AdSoyad',bc.IsBlackListed as 'GeciciKaraListe',bc.IsPermanentlyBlacklisted as 'KaraListe',skT.Name as 'Kirilim1',skT1.Name as 'Kirilim2',skt2.Name as 'Kirilim3',skp1.Name as 'Kirilim4',skt3.Name as 'Kirilim5',skpt.Name as 'KartTipi',ccBLR.Name as 'Durum',ccBLR.PosTextFormat as 'DurumAciklama'from bo_Card bc inner join Card_Parameters cp on bc.Id = cp.Card_Id left outer join Campus_Core_CampusCardOwnerShip ccCOS on bc.OwnershipId = ccCOS.CardOwnershipId left outer join SharedKernel_CardOwnershipBase scCOS on ccCos.CardOwnershipId = scCOS.Id left outer join bo_Individual BI on bc.OwnerId = BI.Id left outer join SharedKernel_CardOwnershipBase scCOS2 on BI.CardOwnershipId = scCOS2.Id left outer join Campus_Core_CampusCardOwnership ccCOS2 on scCOS2.Id = ccCOS2.CardOwnershipId left outer join SharedKernel_PersonalityBase skP on bc.PersonalityId = skP.Id left outer join SharedKernel_PersonalityType skPT on skP.PersonalityTypeId = skPT.Id left outer join SharedKernel_Position skp1 on skP.PositionId = skp1.Id left outer join SharedKernel_Tier skT on skP.TierOneId = skT.Id left outer join SharedKernel_Tier skT1 on skP.TierTwoId = skT1.Id left outer join SharedKernel_Tier skT2 on skP.TierThreeId = skT2.Id left outer join SharedKernel_Tier skT3 on skP.TierFourId = skT3.Id left outer join Campus_Core_CardBlacklistingUpdateOrder ccCBL on bc.LastBlacklistingOrderId = ccCBL.Id left outer join Campus_Core_BlacklistingReason ccBLR on ccCBL.ReasonId = ccBLR.Id left outer join TerminalEODGroup tG on bc.TerminalEodGroupId = tG.ID where BI.Ssn = '{0}'",parametre);


            //if(query.Count >0)
            //{
            //    foreach (var r in query)
            //    {
            //        KimlikKarti kart = r;
            //        kartlar.Add(kart);
            //    }

            //    return kartlar;
            //}
            //else
            //{
            //    return null;
            //}


            return null; 
           
        }
       

        public List<KimlikKarti> PullData(string parametre)
        {
            DataTable dataTable = new DataTable();
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



        private static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    var val = dr[column.ColumnName];

                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }


        public IActionResult CardData()
        {
            try
            {
                foreach (var item in _context.ProlizData.Where(i=>i.TIP != "Öğrenci"))
                {
                    var sonuc = PullData(item.TCKIMLIKNO);
                    if (sonuc.Count == 0)
                    {
                        var sonuc2 = PullData(item.SNO);
                        if (sonuc2.Count == 0)
                        {
                            item.IsCard = false;
                            item.CardStatus = "Kart Bulunamadı";
                            _context.ProlizData.Update(item);
                        }
                        else
                        {
                            item.IsCard = true;
                            item.CardStatus = JsonConvert.SerializeObject(sonuc2);
                            _context.ProlizData.Update(item);
                        }

                    }
                    else
                    {
                        item.IsCard = true;
                        item.CardStatus = JsonConvert.SerializeObject(sonuc);
                        _context.ProlizData.Update(item);
                    }



                }
            }
            catch (Exception ex)
            {

                var error = ex.Message;
            }

            try
            {
                foreach (var item in _context.ProlizData.Where(i => i.TIP == "Öğrenci"))
                {
                    var sonuc = PullData(item.TCKIMLIKNO);
                    if (sonuc.Count == 0)
                    {
                        if (item.SNO.IndexOf("A") < 0 && item.SNO.IndexOf("C") < 0 && item.SNO.IndexOf("Y") < 0)
                        {
                            var sonuc2 = PullData(item.SNO);
                            if (sonuc2.Count == 0)
                            {
                                item.IsCard = false;
                                item.CardStatus = "Kart Bulunamadı";
                                _context.ProlizData.Update(item);
                            }
                            else
                            {
                                item.IsCard = true;
                                item.CardStatus = JsonConvert.SerializeObject(sonuc2);
                                _context.ProlizData.Update(item);
                            }
                        }
                        else
                        {
                            item.IsCard = false;
                            item.CardStatus = "Kart Bulunamadı";
                            _context.ProlizData.Update(item);
                        }

                       

                    }
                    else
                    {
                        item.IsCard = true;
                        item.CardStatus = JsonConvert.SerializeObject(sonuc);
                        _context.ProlizData.Update(item);
                    }



                }
            }
            catch (Exception ex)
            {

                var error = ex.Message;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

    }
}
