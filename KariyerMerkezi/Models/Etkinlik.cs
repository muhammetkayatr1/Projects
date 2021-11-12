using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KariyerMerkezi.Models
{
    public class Etkinlik
    {
        public int ID { get; set; }
        public string Ad { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public string Aciklama { get; set; }
        public string EtkinlikResim { get; set; }
        public bool IsGroup { get; set; }
        public bool IsActive { get; set; }
        public string EgitimIcerigiHTML { get; set; }
        public string GrupAciklama { get; set; }
        public int Sira { get; set; }
        public int Tur { get; set; }
        public Nullable<int> Konferans_Kontenjan { get; set; }
        public bool Basvuru_Acikmi { get; set; }

    }
}
