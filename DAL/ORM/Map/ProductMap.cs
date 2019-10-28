using DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ORM.Map
{
    public class ProductMap:BaseMap<Product>
    {
        public ProductMap()
        {
            ToTable("dbo.Product");
            Property(x => x.Description).IsOptional();
            Property(x => x.Name).IsOptional();
            Property(x => x.ProductNumber).IsOptional();
            Property(x => x.ReleaseDate).HasColumnType("datetime2").IsOptional();
            
        }
    }
}
