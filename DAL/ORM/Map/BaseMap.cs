using DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ORM.Map
{
    public class BaseMap<T> : EntityTypeConfiguration<T> where T : BaseEntity
    {
        public BaseMap()
        {
            Property(x => x.ID).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.CreateDate).HasColumnName("CreateDate").IsOptional();
            Property(x => x.CreatedUserName).HasColumnName("CreatedUserName").HasMaxLength(50).IsOptional();
            Property(x => x.CreatedCompName).HasColumnName("CreatedCompName").HasMaxLength(50).IsOptional();
            Property(x => x.UpdatedUserName).HasColumnName("UpdatedUserName").HasMaxLength(50).IsOptional();
            Property(x => x.UpdatedUserName).HasColumnName("UpdatedUserName").IsOptional();
            Property(x => x.UpdateCompnName).HasColumnName("UpdateCompnName").IsOptional();
            Property(x => x.Status).HasColumnName("Status").IsOptional();
        }
    }
}
