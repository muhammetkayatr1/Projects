using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfServisUI.Models
{
    public class PasswordResetLog
    {
        public int Id { get; set; }
        public string Tc { get; set; }
        public DateTime PasswordResetDate { get; set; }
    }
}
