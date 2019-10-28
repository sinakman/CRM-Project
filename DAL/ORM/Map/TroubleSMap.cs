using DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ORM.Map
{
    public class TroubleSMap:BaseMap<TroubleShoot>
    {
        public TroubleSMap()
        {
            ToTable("dbo.TroubleShoot");
            Property(x => x.EndDate).HasColumnType("datetime2").IsOptional();
        }
    }
}
