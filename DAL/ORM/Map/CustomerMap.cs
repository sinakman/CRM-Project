using DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ORM.Map
{
    public class CustomerMap:BaseMap<Customer>
    {
        public CustomerMap()
        {
            ToTable("dbo.Customer");
            Property(x => x.Address).IsOptional();
            Property(x => x.Name).IsOptional();
            Property(x => x.Phone).IsOptional();
            Property(x => x.DBType).IsOptional();
            Property(x => x.AppServer).IsOptional();
        }
    }
}
