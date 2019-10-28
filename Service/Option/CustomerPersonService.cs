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
    public class CustomerPersonService:BaseService<CustomerPerson>
    {
        private ProjectContext _context;
        public CustomerPersonService()
        {
            _context = new ProjectContext();

        }
        public override List<CustomerPerson> GetActive() => _context.Set<CustomerPerson>().Where(x => x.CustomerID == x.Customer.ID).ToList();
    }
}
