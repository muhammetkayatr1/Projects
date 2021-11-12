using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HesProject.Models
{
    public class EmployeeVaccineInfo
    {
        public int Id { get; set; }
        public string Tc { get; set; }
        public string Staff { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool ExpressConsent { get; set; }
        public bool Allergy { get; set; }
        public bool Confirmation { get; set; }
        public bool IsWantVaccine { get; set; }
        public string VaccineInformation { get; set; }
        public string VaccineDate { get; set; }
        public string VaccineName { get; set; }
    }

  
}

