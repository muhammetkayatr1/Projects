using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HesProject.Models
{
    public class Token
    {
        public string message { get; set; }
        public bool success { get; set; }
        public DataToken data { get; set; }
    }

    public class DataToken
    {
        public string token { get; set; }
        public string refreshToken { get; set; }
        public DateTime expiration { get; set; }
    }
}
