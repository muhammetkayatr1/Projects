using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaccinationCenter.Models
{
    public class ProlizData
    {
         public int Id { get; set; }
        public string TIP { get; set; }

		public string SNO { get; set; }

		public string TCKIMLIKNO { get; set; }

		public string HESKOD { get; set; }

		public string HESTARIH { get; set; }

		public string RISKDURUM { get; set; }

		public string ASIDURUM { get; set; }

		public string ASITARIH { get; set; }
        public Nullable<DateTime> expiration_date { get; set; }
        public string current_health_status { get; set; }
        public string masked_identity_number { get; set; }
        public string masked_firstname { get; set; }
        public string masked_lastname { get; set; }
        public bool? is_vaccinated { get; set; }
        public bool? is_immune { get; set; }
        public bool? is_test_data_shared { get; set; }
        public Nullable<DateTime> last_negative_test_date { get; set; }
        public string durum { get; set; }
        public string Description { get; set; }
        public bool? IsBlocked { get; set; }
        public string Fakulte { get; set; }
        public string Bolum { get; set; }
        public string Program { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Departman { get; set; }
        public bool? IsCard { get; set; }
        public string CardStatus { get; set; }
        public string Picture { get; set; }
        public int? RegisterId { get; set; }
    }
}
