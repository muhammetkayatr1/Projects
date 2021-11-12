using ProlizWebService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HesOperation.ProlizOperation
{
    public interface IProlizServiceManager
    {

        List<Ogrenci> GetStudentInfoOnProliz(string IdentityNumber, string StudentNumber);
        List<AktifOgrenciler> GetAllStudentInfoOnProliz();
        List<AkademikPersonel> GetAcademicianInfoOnProliz();

    }
}
