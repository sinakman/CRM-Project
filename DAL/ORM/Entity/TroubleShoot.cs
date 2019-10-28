using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ORM.Entity
{
    public class TroubleShoot:BaseEntity
    {
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
        public DateTime? EndDate { get; set; }


    }
}
