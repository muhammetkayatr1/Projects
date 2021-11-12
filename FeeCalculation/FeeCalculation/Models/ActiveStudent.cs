using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeeCalculation.Models
{
    public class ActiveStudent
    {
        public int Id { get; set; }
        public string TcNumber { get; set; }
        public string NameSurname { get; set; }
        public string Program { get; set; }
        public string Fee { get; set; }
        public string DiscountFee { get; set; }
        public string AdvanceFee { get; set; }
        public string FirstDiscount { get; set; }
        public string SecondDiscount { get; set; }
        public string ThirdDiscount { get; set; }

    }
}
