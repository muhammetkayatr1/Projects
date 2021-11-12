using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfServisUI.Models
{
    public class ADPersonInfoSimple
    {
        public List<DataAdSimple> data { get; set; }
        public bool success { get; set; }
        public string message { get; set; }
    }

    public class DataAdSimple
    {
        public string userName { get; set; }
        public string email { get; set; }
        public string telephoneNumber { get; set; }
        public DateTime passwordExpiryDate { get; set; }
        public string managerName { get; set; }
        public string memberOf { get; set; }
        public DateTime passwordLastSet { get; set; }
        public string userPhoto { get; set; }
        public string title { get; set; }
        public string department { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string accountStatus { get; set; }
        public string userPasswordStatus { get; set; }
    }



}
