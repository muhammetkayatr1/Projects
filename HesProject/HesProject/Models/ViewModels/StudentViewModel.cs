using HesProject.Models.konfides;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HesProject.Models.ViewModels
{
    public class StudentViewModel
    {
        public List<ProlizData> ProlizData { get; set; }
        public List<KimlikKarti> KimlikKarti { get; set; }
    }
}
