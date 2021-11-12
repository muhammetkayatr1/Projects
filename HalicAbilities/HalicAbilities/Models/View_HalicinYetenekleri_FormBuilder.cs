using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HalicAbilities.Models
{
    
    public class View_HalicinYetenekleri_FormBuilder
    {
        public string FormName { get; set; }
        [Key]
        public string GroupKey { get; set; }
        public string Kimlik_No { get; set; }
        public string Ad_Soyad { get; set; }
        public string Telefon { get; set; }
        public string EMail { get; set; }
        public string Sehir { get; set; }
        public string ilce { get; set; }
        public string Egitim_Durum { get; set; }
        public string Referans_Info { get; set; }
        public string Spor_Lisans_VarMi { get; set; }
        public string Bolum1 { get; set; }
        public string Bolum2 { get; set; }
        public string Bolum3 { get; set; }
        public string YabanciDil { get; set; }
        public string Hakkimda { get; set; }
        public string Basvuru_Tipi { get; set; }
        public string Yeteneklerim { get; set; }
        public string DosyaYukle { get; set; }
    }
}
