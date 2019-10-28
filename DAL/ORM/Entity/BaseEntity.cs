using DAL.ORM.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ORM.Entity
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            this.Status = Status.Active;
            this.CreateDate = DateTime.Now;
            this.CreatedUserName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            this.CreatedCompName = Environment.MachineName;
        }
        public int ID { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreatedUserName { get; set; }
        public string CreatedCompName { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdatedUserName { get; set; }
        public string UpdateCompnName { get; set; }
        public Status Status { get; set; }

    }
}
