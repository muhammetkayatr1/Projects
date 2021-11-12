using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfServisUI.Models
{
    public class SendSmsResult
    {
        public bool succes { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }
    public class Data
    {
        public string status { get; set; }
        public string data { get; set; }
        public string msg { get; set; }
    }
}
