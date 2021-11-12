using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class LogFromJson
    {
        public string Tc { get; set; }
        public bool? Giris { get; set; }
        public bool? SifreDegistirme { get; set; }
        public bool? MailDogrulama { get; set; }
        public bool? TelefonDogrulama { get; set; }
        public bool? SifreResetlemeSonucu { get; set; }
        public bool? MailGonderme { get; set; }
        public bool? SmsGonderme { get; set; }
        public DateTime Tarih { get; set; }
        public bool? Token { get; set; }

        public string SmsKodu { get; set; }
    }
}
