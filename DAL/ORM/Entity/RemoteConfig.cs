using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ORM.Entity
{
    public class RemoteConfig:BaseEntity
    {
        public int CustomerPersonID { get; set; }
        public virtual CustomerPerson CustomerPerson { get; set; }
        public int EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
        public DateTime? Date { get; set; }

    }
}
