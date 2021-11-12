using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Entities
{
    public class Log
    {
        [Key]
        public int Id { get; set; }
        public string LogDetails { get; set; }
        //public string Tc { get; set; }
        //public string Giris { get; set; }
        //public string SifreDegistirme { get; set; }
        //public string MailDogrulama { get; set; }
        //public string TelefonDogrulama { get; set; }
        //public string SifreResetlemeSonucu { get; set; }
        //public string MailGonderme { get; set; }
        //public string SmsGonderme { get; set; }
        //public string Tarih { get; set; }
        //public string Token { get; set; }

    }
}
