using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfServisUI.Models
{

    public class DataAdStudent
    {
        public string accountExpires { get; set; }
        public DateTime msDSUserPasswordExpiryTimeComputed { get; set; }
        public string extensionAttribute1 { get; set; }
        public string extensionAttribute2 { get; set; }
        public string extensionAttribute3 { get; set; }
        public string extensionAttribute4 { get; set; }
        public string extensionAttribute5 { get; set; }
        public string extensionAttribute6 { get; set; }
        public string extensionAttribute7 { get; set; }
        public string extensionAttribute8 { get; set; }
        public string extensionAttribute9 { get; set; }
        public string extensionAttribute10 { get; set; }
        public string extensionAttribute11 { get; set; }
        public string extensionAttribute12 { get; set; }
        public string extensionAttribute13 { get; set; }
        public string extensionAttribute14 { get; set; }
        public string extensionAttribute15 { get; set; }
        public string employeeType { get; set; }
        public string employeeId { get; set; }
        public string employeeNumber { get; set; }
        public string isAccountLocked { get; set; }
        public string lastLogonTimeStamp { get; set; }
        public string userAccountControl { get; set; }
        public string samAccountName { get; set; }
        public string badPwdCount { get; set; }
        public DateTime pwdLastSet { get; set; }
        public string mobile { get; set; }
        public string description { get; set; }
        public string mail { get; set; }
        public string division { get; set; }
        public string manager { get; set; }
        public string sn { get; set; }
        public string givenname { get; set; }
        public string department { get; set; }
        public string physicalDeliveryOfficeName { get; set; }
        public string title { get; set; }
        public string telephoneNumber { get; set; }
        public string company { get; set; }
        public string canonicalName { get; set; }
        public string displayName { get; set; }
        public string memberOf { get; set; }
        public string ipPhone { get; set; }
        public string userPasswordStatus { get; set; }
    }

    public class ADStudentInfo
    {
        public List<DataAdStudent> data { get; set; }
        public bool success { get; set; }
        public string message { get; set; }
    }
}
