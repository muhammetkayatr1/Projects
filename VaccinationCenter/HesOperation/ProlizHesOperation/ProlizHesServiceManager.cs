using ProlizHesService;
using System;
using System.Collections.Generic;
using System.Text;

namespace HesOperation.ProlizHesOperation
{
    public class ProlizHesServiceManager: IProlizHesServiceManager
    {
        private string _serviceUserName = "ProHesHalic";
        private string _servicePassword = "Halic!+Hes-2021#";


        public List<HES> GetAllHesOnProliz()
        {
            List<HES> ogrenci = new List<HES>();


            using (var hesService = new proliz_obs_hes_minerSoapClient(proliz_obs_hes_minerSoapClient.EndpointConfiguration.proliz_obs_hes_minerSoap))
            {
                HESListesiSBERequestBody requestBody = new HESListesiSBERequestBody(_serviceUserName, _servicePassword, "");
                HESListesiSBERequest request = new HESListesiSBERequest(requestBody);
                var query = hesService.HESListesiSBE(_serviceUserName, _servicePassword, "");
                var state = hesService.State;
                var inner = hesService.InnerChannel;

                return query[0].hesListesi;
            }
              













            //    AktifOgrenciListesiGetirRequestBody requestBody = new AktifOgrenciListesiGetirRequestBody(_serviceUserName, _servicePassword, "", "");
            //    AktifOgrenciListesiGetirRequest request = new AktifOgrenciListesiGetirRequest(requestBody);

            //    var query = studentService.AktifOgrenciListesiGetir(request);

            //    var state = studentService.State;
            //    var inner = studentService.InnerChannel;

            //    var ogrencidata = query.Body.AktifOgrenciListesiGetirResult;

            //    if (ogrencidata != null && ogrencidata.Count > 0 && ogrencidata[0].Sucess)
            //    {
            //        ogrenci = ogrencidata[0].ogrenciList;
            //    }

            //    return ogrenci;
            //}
        }
    }
}
