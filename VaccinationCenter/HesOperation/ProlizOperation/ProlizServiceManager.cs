using ProlizWebService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HesOperation.ProlizOperation
{
    public class ProlizServiceManager : IProlizServiceManager
    {

        private string _serviceUserName = "prlz_hlc_min";
        private string _servicePassword = "+Pro_Hal_2016!";

       


        public List<Ogrenci> GetStudentInfoOnProliz(string IdentityNumber, string StudentNumber)
        {
            List<Ogrenci> ogrenci = new List<Ogrenci>();



            using (var studentService = new proliz_data_minerSoapClient(proliz_data_minerSoapClient.EndpointConfiguration.proliz_data_minerSoap))
            {
                
                OgrenciBilgileriGetirRequestBody requestBody = new OgrenciBilgileriGetirRequestBody(_serviceUserName, _servicePassword, StudentNumber, IdentityNumber);
                OgrenciBilgileriGetirRequest request = new OgrenciBilgileriGetirRequest(requestBody);

                var query =  studentService.OgrenciBilgileriGetir(request);

               var state= studentService.State;
                var inner =studentService.InnerChannel;
              
                var ogrencidata = query.Body.OgrenciBilgileriGetirResult;

                if (ogrencidata != null && ogrencidata.Count > 0 && ogrencidata[0].Sucess)
                {
                    ogrenci = ogrencidata[0].ogr;
                }

                return ogrenci;
            }
        }

        public List<AktifOgrenciler> GetAllStudentInfoOnProliz()
        {
            List<AktifOgrenciler> ogrenci = new List<AktifOgrenciler>();



            using (var studentService = new proliz_data_minerSoapClient(proliz_data_minerSoapClient.EndpointConfiguration.proliz_data_minerSoap))
            {

               AktifOgrenciListesiGetirRequestBody requestBody = new AktifOgrenciListesiGetirRequestBody(_serviceUserName, _servicePassword, "", "");
                AktifOgrenciListesiGetirRequest request = new AktifOgrenciListesiGetirRequest(requestBody);

                var query = studentService.AktifOgrenciListesiGetir(request);

                var state = studentService.State;
                var inner = studentService.InnerChannel;

                var ogrencidata = query.Body.AktifOgrenciListesiGetirResult;

                if (ogrencidata != null && ogrencidata.Count > 0 && ogrencidata[0].Sucess)
                {
                    ogrenci = ogrencidata[0].ogrenciList;
                }

                return ogrenci;
            }
        }

        public List<AkademikPersonel> GetAcademicianInfoOnProliz()
        {
            List<AkademikPersonel> academician = new List<AkademikPersonel>();



            using (var academicianService = new proliz_data_minerSoapClient(proliz_data_minerSoapClient.EndpointConfiguration.proliz_data_minerSoap))
            {

                AkademikPersonelBilgileriGetirRequestBody requestBody = new AkademikPersonelBilgileriGetirRequestBody(_serviceUserName, _servicePassword, "", "");
                AkademikPersonelBilgileriGetirRequest request = new AkademikPersonelBilgileriGetirRequest(requestBody);

                var query = academicianService.AkademikPersonelBilgileriGetir(request);

                var state = academicianService.State;
                var inner = academicianService.InnerChannel;

                var academiciandata = query.Body.AkademikPersonelBilgileriGetirResult;

                if (academiciandata != null && academiciandata.Count > 0 && academiciandata[0].Sucess)
                {
                    academician = academiciandata[0].akademikPersonel;
                }

                return academician;
            }
        }
    }
}
