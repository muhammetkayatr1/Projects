using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeeCalculation.Models
{
    public class OverdueStudent
    {
        public int Id { get; set; }
        public string TcNumber { get; set; }
        public DateTime? Date { get; set; }
    }
}
