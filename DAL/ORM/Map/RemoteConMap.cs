using DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ORM.Map
{
    public class RemoteConMap:BaseMap<RemoteConfig>
    {
        public RemoteConMap()
        {
            ToTable("dbo.RemoteConfig");
            Property(x => x.Date).HasColumnType("datetime2");
        }
    }
}
