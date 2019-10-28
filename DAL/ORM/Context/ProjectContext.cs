using DAL.ORM.Entity;
using DAL.ORM.Map;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ORM.Context
{
    public class ProjectContext:DbContext
    {
        public ProjectContext()
        {
            Database.Connection.ConnectionString = "Server=SINAN\\SQLEXPRESS;Database=CRMProjeDB;integrated security=true;";
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new CustomerPersonMap());
            modelBuilder.Configurations.Add(new EmployeeMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new ProductModuleMap());
            modelBuilder.Configurations.Add(new RemoteConMap());
            modelBuilder.Configurations.Add(new TroubleSMap());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder); 
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerPerson> CustomerPeople { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductModule> ProductModules { get; set; }
        public DbSet<RemoteConfig> RemoteConfigs { get; set; }
        public DbSet<TroubleShoot> TroubleShoots { get; set; }


        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified || x.State == EntityState.Added).ToList();

            string identity = WindowsIdentity.GetCurrent().Name;
            string computerName = Environment.MachineName;
            DateTime dateTime = DateTime.Now;

            foreach (var item in modifiedEntries)
            {
                BaseEntity baseEntity = item.Entity as BaseEntity;

                if (item!=null)
                {
                    if (item.State==EntityState.Added)
                    {
                        baseEntity.CreatedUserName = identity;
                        baseEntity.CreatedCompName = computerName;
                        baseEntity.CreateDate = dateTime;
                    }

                    else if (item.State==EntityState.Modified)
                    {
                        baseEntity.UpdatedUserName = identity;
                        baseEntity.UpdateCompnName = computerName;
                        baseEntity.UpdateDate = dateTime;
                    }
                }
            }
            foreach (var item in modifiedEntries)
            {
                Employee employee = item.Entity as Employee;
                if (item!=null)
                {
                    if (item.State==EntityState.Added)
                    {
                        employee.Password = PassCrypto.base64Encode(employee.Password);
                    }
                    else if (item.State == EntityState.Modified)
                    {
                        employee.Password = PassCrypto.base64Encode(employee.Password);
                    }

                }
            }

            return base.SaveChanges();
        }

    }
}
