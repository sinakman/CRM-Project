using DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ORM.Map
{
    public class CustomerPersonMap:BaseMap<CustomerPerson>
    {
        public CustomerPersonMap()
        {
            ToTable("dbo.CustomerPerson");
            Property(x => x.Email).IsOptional();
            Property(x => x.MobilePhone).IsOptional();
            Property(x => x.Name).IsOptional();
            Property(x => x.Phone).IsOptional();
            Property(x => x.SurName).IsOptional();
            Property(x => x.Title).IsOptional();
        }
    }
}
