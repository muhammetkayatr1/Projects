using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfServisUI.Models
{
    public class DataStudent
    { 
        public string tC_KIMLIK_NO { get; set; }
        public string ogR_NO { get; set; }
        public string ogR_ADI { get; set; }
        public string ogR_SOYAD { get; set; }
        public string fakultE_AD { get; set; }
        public string boluM_AD { get; set; }
        public string prograM_AD { get; set; }
        public string fakultE_KOD { get; set; }
        public string boluM_KOD { get; set; }
        public string prograM_KOD { get; set; }
        public string cinsiyet { get; set; }
        public string d_TARIH { get; set; }
        public string yoksiS_KOD { get; set; }
        public string ogrencI_GELIS_SEKLI { get; set; }
        public string ogrencI_STATU { get; set; }
        public string caP_YANDAL_DURUM { get; set; }
        public string sinif { get; set; }
        public string agno { get; set; }
        public string okudugU_YIL { get; set; }
        public string epostA1 { get; set; }
        public string gsM1 { get; set; }
        public string danismaN_1 { get; set; }
        public string danismaN_2 { get; set; }
        public string ogreniM_TIP { get; set; }
        public string ogrencI_SURE { get; set; }
        public string okudugU_DONEM { get; set; }
        public string picture { get; set; }
    }

    public class StudentNumberResult
    {
        public List<DataStudent> data { get; set; }
        public bool success { get; set; }
        public string message { get; set; }
    }


}
