using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HesProject.Models
{
    public class HesQuery
    {
        public string hes_code { get; set; }
    }

    public class SearchCollective
    {
        public IList<HesQuery> searches { get; set; }
    }

    public class SuccessMap
    {
    }

    public class UnsuccessMap
    {
        public string hes_code { get; set; }
    }

    public class Codes
    {
        public SuccessMap success_map { get; set; }
        public UnsuccessMap unsuccess_map { get; set; }
    }
}
