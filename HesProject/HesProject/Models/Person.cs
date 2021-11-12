using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HesProject.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string tc { get; set; }
        public string hes { get; set; }
        public DateTime expiration_date { get; set; }
        public string current_health_status { get; set; }
        public string masked_identity_number { get; set; }
        public string masked_firstname { get; set; }
        public string masked_lastname { get; set; }
        public bool? is_vaccinated { get; set; }
        public bool? is_immune { get; set; }
        public bool? is_test_data_shared { get; set; }
        public DateTime? last_negative_test_date { get; set; }
        public string durum { get; set; }
        public string status { get; set; }
        public string Description { get; set; }
        public bool IsBlocked { get; set; }

    }
}
