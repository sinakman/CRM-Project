using DAL.ORM.Entity;
using Service.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Option
{
    public class EmployeeService:BaseService<Employee>
    {

        public bool CheckCredentials(string userName, string password)
        {
            return Any(x=> x.UserName == userName && x.Password ==password);
        }

        public Employee FindByUserName(string userName)
        {
            return GetByDefault(x => x.UserName == userName);
        }
       

    }
}
