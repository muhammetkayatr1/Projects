using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaccinationCenter.Models
{
    public class EmployeeInfo
    {
        public int RegisterId { get; set; }

        public int EmployeeId { get; set; }

        public string SicilNo { get; set; }

        public string Adı { get; set; }

        public string Soyadı { get; set; }

        public string TcKimlikNo { get; set; }

        public string SskNo { get; set; }

        public string Cinsiyet { get; set; }

        public string DogumYeri { get; set; }

        public System.DateTime DogumTarihi { get; set; }

        public string KanGrubu { get; set; }

        public string IsyeriAdi { get; set; }

        public string IsyeriKodu { get; set; }

        public string Amir1SicilNo { get; set; }

        public string Amir1Ad { get; set; }

        public string Amir1Soyad { get; set; }

        public string Amir1OrgKodu { get; set; }

        public string Amir1Organizasyon { get; set; }

        public System.DateTime GrubaGirisTarihi { get; set; }

        public System.DateTime GirisTarihi { get; set; }

        public System.DateTime CikisTarihi { get; set; }

        public string Gorev { get; set; }

        public string GorevKodu { get; set; }

        public string Unvan { get; set; }

        public string UnvanKodu { get; set; }

        public string OrgKodu { get; set; }

        public string Organizasyon { get; set; }

        public string PersonelTipiKodu { get; set; }

        public string IstihdamTuru { get; set; }

        public string KarMerkeziAdi { get; set; }

        public string KarMerkeziKodu { get; set; }

        public string AktifDurumu { get; set; }

        public string MobileTel { get; set; }

        public string Phone { get; set; }

        public string EMail { get; set; }
    }
}
