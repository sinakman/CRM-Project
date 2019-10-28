using DAL.ORM.Context;
using DAL.ORM.Entity;
using Service.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Option
{
    public class ProductModuleService:BaseService<ProductModule>
    {
        //private ProjectContext _context;
        //public ProductModuleService()
        //{
        //    _context = new ProjectContext();

        //}


        //public override List<ProductModule> GetActive() => _context.Set<ProductModule>().Where(x => x.ProductID==x.Product.ID).ToList();

    }
}
