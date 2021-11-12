using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfServisUI.Models
{
    public class Login
    {
        [JsonProperty(PropertyName ="email")]
        public string userName { get; set; }
        public string password { get; set; }
    }
}
