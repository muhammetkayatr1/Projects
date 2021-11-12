using HesOperation.Uyumsoft;
using Uyumsoft;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace HesOperation.ProlizOperation
{
    public class UyumsoftServiceManager : IUyumsoftServiceManager
    {

        private string _serviceUserName = "webservice";
        private string _servicePassword = "1q2w3e4r5!_";

        public List<EmployeeOut> GetAllEmployee()
        {
            List<EmployeeOut> employees = new List<EmployeeOut>();
            using (var uyumsoftService = new SCHServiceSoapClient(SCHServiceSoapClient.EndpointConfiguration.SCHServiceSoap))
            {
                var token = new Token();
                token.UserName = _serviceUserName;
                token.Password = _servicePassword;
                token.BranchCode = "0";
                token.BranchId = 0;
                token.CoId = 0;
                token.BranchDesc = "0";
                token.DeviceId = "0";

                var value = new EmployeeIn();
                value.TC_KimlikNo = "";
                value.SorguTarihi = DateTime.Now;

                var con = new ServiceRequestOfEmployeeIn();
                con.Token = token;
                con.PageIndex = 0;
                con.Attachment = "0";
                con.PageSize = 0;
                con.Value = value;
               
                var result = uyumsoftService.GetEmployee(con);

                foreach (var item in result.Value)
                {
                    employees.Add(item);
                }

                
                return employees;
            }
            }
        

    public EmployeeOut GetEmployee(string tc)
    {
        EmployeeOut employee = new EmployeeOut();
        using (var uyumsoftService = new SCHServiceSoapClient(SCHServiceSoapClient.EndpointConfiguration.SCHServiceSoap))
        {
            var token = new Token();
            token.UserName = _serviceUserName;
            token.Password = _servicePassword;
            token.BranchCode = "0";
            token.BranchId = 0;
            token.CoId = 0;
            token.BranchDesc = "0";
            token.DeviceId = "0";

            var value = new EmployeeIn();
            value.TC_KimlikNo = tc;
            value.SorguTarihi = DateTime.Now;

            var con = new ServiceRequestOfEmployeeIn();
            con.Token = token;
            con.PageIndex = 0;
            con.Attachment = "0";
            con.PageSize = 0;
            con.Value = value;

            var result = uyumsoftService.GetEmployee(con);
                if (result.Value != null)
                {
                    employee = result.Value[0];
                }
           


            return employee;
        }
        }
    }
}


