using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace SCPDashboard.Helpers
{
    public static class ExtensionMethods
    {
        public static string ToJson(this object obj)
        {
            var data = JsonConvert.SerializeObject(obj);
            return data;
        }


        public static T FromJson<T>(this string obj)
        {
            var data = JsonConvert.DeserializeObject<T>(obj);
            return data;
        }

        
        

        //public static string FromXmlToJson(this string xml)
        //{
        //    var result = xml.Replace("<S>", "<Data>").Replace("</S>", "</Data>");
        //    XmlDocument document = new XmlDocument();
        //    document.LoadXml(result);

        //    var jResult = JsonConvert.SerializeXmlNode(document, Newtonsoft.Json.Formatting.Indented, true);

        //    return jResult;
        //}
    }
}
