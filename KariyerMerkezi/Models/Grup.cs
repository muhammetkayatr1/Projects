using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KariyerMerkezi.Models
{
    public class Grup
    {
        public int ID { get; set; }
        public string Ad { get; set; }
        public int EtkinlikID { get; set; }
        public int Kapasite { get; set; }
        public bool IsActive { get; set; }
        public string Lokasyon { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
    }
}
