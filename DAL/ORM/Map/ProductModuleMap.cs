using DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ORM.Map
{
    public class ProductModuleMap:BaseMap<ProductModule>
    {
        public ProductModuleMap()
        {
            ToTable("dbo.ProductModule");
            Property(x => x.Name).IsOptional();
            Property(x => x.Description).IsOptional();
            Property(x => x.ReleaseDate).HasColumnType("datetime2").IsOptional();

        }
    }
}
