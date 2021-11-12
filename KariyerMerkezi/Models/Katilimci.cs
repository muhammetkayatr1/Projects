using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KariyerMerkezi.Models
{
    public class Katilimci
    {
        public int ID { get; set; }
        public string TCKimlikNo { get; set; }
        public string Ad_Soyad { get; set; }
        public string FakulteAd { get; set; }
        public string BolumAd { get; set; }
        public string ProgramAd { get; set; }
        public string GSM { get; set; }
        public string Eposta { get; set; }
        public int Sinif { get; set; }
        public bool Cinsiyet { get; set; }
        public string Durum { get; set; }
        public string OgrenciNo { get; set; }

    }
}
