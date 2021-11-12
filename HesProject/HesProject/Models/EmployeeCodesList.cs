using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HesProject.Models
{
    public class EmployeCodesList
    {
        public IList<HesQuery> hesCode { get; set; }
        public IList<HesResultPlus> employeeCodes { get; set; }
    }
}
