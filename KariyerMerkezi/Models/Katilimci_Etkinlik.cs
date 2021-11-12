using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KariyerMerkezi.Models
{
    public class Katilimci_Etkinlik
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public int GrupID { get; set; }
        public Nullable<bool> Yoklama { get; set; }
        public Nullable<bool> Sertifika { get; set; }

    }
}
