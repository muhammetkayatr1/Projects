using Uyumsoft;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HesOperation.Uyumsoft
{
    public interface IUyumsoftServiceManager
    {
        List<EmployeeOut> GetAllEmployee();
        EmployeeOut GetEmployee(string tc);
    }
}
