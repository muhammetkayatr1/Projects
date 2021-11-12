using ProlizHesService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HesOperation.ProlizHesOperation
{
    public interface IProlizHesServiceManager
    {
        List<HES> GetAllHesOnProliz();
    }
}
