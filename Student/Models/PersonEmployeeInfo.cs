using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfServisUI.Models
{
    public class PersonEmployeeInfo
    {
        public int registerId { get; set; }
        public int employeeId { get; set; }
        public string sicilNo { get; set; }
        public string adı { get; set; }
        public string soyadı { get; set; }
        public string tcKimlikNo { get; set; }
        public string sskNo { get; set; }
        public string cinsiyet { get; set; }
        public string dogumYeri { get; set; }
        public DateTime dogumTarihi { get; set; }
        public string kanGrubu { get; set; }
        public string isyeriAdi { get; set; }
        public string isyeriKodu { get; set; }
        public DateTime grubaGirisTarihi { get; set; }
        public DateTime girisTarihi { get; set; }
        public DateTime cikisTarihi { get; set; }
        public string gorev { get; set; }
        public string gorevKodu { get; set; }
        public string unvan { get; set; }
        public string unvanKodu { get; set; }
        public string personelTipiKodu { get; set; }
        public string istihdamTuru { get; set; }
        public string karMerkeziAdi { get; set; }
        public string karMerkeziKodu { get; set; }
        public string aktifDurumu { get; set; }
        public string eMail { get; set; }
        public string mobileTel { get; set; }
    }
}
