using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HesProject.Models.konfides
{
    public class KimlikKarti
    {
        public decimal? KartNo { get; set; }
        public string KartSeriNo { get; set; }
        public decimal? KimlikNo { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string AdSoyad { get; set; }
        public bool GeciciKaraListe { get; set; }
        public bool KaraListe { get; set; }
        public string Kirilim1 { get; set; }
        public string Kirilim2 { get; set; }
        public string Kirilim3 { get; set; }
        public string Kirilim4 { get; set; }
        public string Kirilim5 { get; set; }
        public string KartTipi { get; set; }
        public string Durum { get; set; }
        public string DurumAciklama { get; set; }

    }
}
