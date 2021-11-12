using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace KariyerMerkezi.Models
{
    public partial class Grup_Katilimci_Etkinlik
    {
        public int ID { get; set; }
        public string Ad_Soyad { get; set; }
        public string BolumAd { get; set; }
        public string FakulteAd { get; set; }
        public string Eposta { get; set; }
        public string GSM { get; set; }
        public int Sinif { get; set; }
        public string Durum { get; set; }
        public string Grup_Adi { get; set; }
        public DateTime Grup_BaslangicTarihi { get; set; }
        public DateTime Grup_BitisTarihi { get; set; }
        public int Kapasite { get; set; }
        public string Egitim_Adi { get; set; }
        public bool IsActive { get; set; }
        public string OgrenciNo { get; set; }
        public Nullable<bool> Yoklama { get; set; }
        public Nullable<bool> Sertifika { get; set; }
    }
}
