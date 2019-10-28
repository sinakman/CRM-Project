using DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ORM.Map
{
    public class EmployeeMap:BaseMap<Employee>
    {
        public EmployeeMap()
        {
            ToTable("dbo.Employee");
            Property(x => x.Email).IsOptional();
            Property(x => x.Name).IsOptional();
            Property(x => x.Password).HasMaxLength(8).IsRequired();
            Property(x => x.Phone).IsOptional();
            Property(x => x.Surname).IsOptional();
            Property(x => x.TCNo).HasMaxLength(11).IsRequired();
            Property(x => x.UserName).IsRequired();
        }
    }
}
