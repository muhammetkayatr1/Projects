using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HesProject.Models
{
    public class ActiveStudent
    {
        public int Id { get; set; }
        public string StudentNumber { get; set; }
        public string TcNumber { get; set; }
        public bool? IsCard { get; set; }
        public string CardStatus { get; set; }
    }
}
