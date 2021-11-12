using ProlizWebService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HesOperation.ProlizOperation
{
    public interface IProlizServiceManager
    {

        Task<List<Ogrenci>> GetStudentInfoOnProliz(string IdentityNumber, string StudentNumber);

    }
}
