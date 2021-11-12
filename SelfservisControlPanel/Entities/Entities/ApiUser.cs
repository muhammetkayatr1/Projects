using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class ApiUser
    {
        [JsonProperty(PropertyName = "email")]
        public string userName { get; set; }
        public string password { get; set; }
    }

    public class SmsResponse
    {
        public string referenceNumber { get; set; }
    }

    public class Rapor
    {
        public List<string> gonderilen { get; set; }
    }

    public class Data
    {
        public Rapor rapor { get; set; }
    }

    public class Data2
    {
        public object _0 { get; set; }
        public object _1 { get; set; }
        public string status { get; set; }
        public Data data { get; set; }
        public string msg { get; set; }
    }

    public class SmsResult
    {
        public Data2 data { get; set; }
        public bool success { get; set; }
        public string message { get; set; }
    }
}
