using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlumniAssociation.Models
{
    public class View_MezunlarDernegi_FormBuilder
    {
        public string FormName { get; set; }
        [Key]
        public string GroupKey { get; set; }
        public string Ad_Soyad { get; set; }
        public string DogumYeri { get; set; }
        public string DogumTarihi { get; set; }
        public string MezunFakulte { get; set; }
        public string MezunBolum { get; set; }
        public string MezunYili { get; set; }
        public string CalistigiKurum { get; set; }
        public string Gorev { get; set; }
        public string Isyeri { get; set; }
        public string Telefon { get; set; }
        public string Il { get; set; }
        public string Expr1 { get; set; }
    }
}
