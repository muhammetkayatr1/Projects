using ProlizWebService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HesOperation.ProlizOperation
{
    public class ProlizServiceManager : IProlizServiceManager
    {

        private string username;
        private string password;

        public ProlizServiceManager(string _username,string _password)
        {
            username = _username;
            password = _password;

        }


        public Task<List<Ogrenci>> GetStudentInfoOnProliz(string IdentityNumber, string StudentNumber)
        {
            List<Ogrenci> ogrenci = new List<Ogrenci>();
            using (var studentService = new proliz_data_minerSoapClient(proliz_data_minerSoapClient.EndpointConfiguration.proliz_data_minerSoap))
            {
                var query = await studentService.OgrenciBilgileriGetirAsync(_serviceUserName, _servicePassword, studentNumber, identityNumber);

                var ogrencidata = query.Body.OgrenciBilgileriGetirResult;

                if (ogrencidata != null && ogrencidata.Count > 0 && ogrencidata[0].Sucess)
                {
                    ogrenci = ogrencidata[0].ogr;
                }

                return ogrenci;
            }
        }
    }
}
