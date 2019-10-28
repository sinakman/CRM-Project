using DAL.ORM.Context;
using DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.BaseService
{
    public class BaseService<T> : IServiceBase<T> where T : BaseEntity
    {
        private ProjectContext _context;
        public BaseService()
        {
            _context = new ProjectContext();

        }

        public void Add(T item)
        {
            _context.Set<T>().Add(item);
            Save();
        }

        public void Add(List<T> items)
        {
            _context.Set<T>().AddRange(items);
            Save();

        }

        public bool Any(Expression<Func<T, bool>> exp) => _context.Set<T>().Any(exp);

        public virtual List<T> GetActive() => _context.Set<T>().Where(x => x.Status == DAL.ORM.Entity.Enum.Status.Active).ToList();

        public List<T> GetAll() => _context.Set<T>().ToList();
        

        public T GetByDefault(Expression<Func<T, bool>> exp) => _context.Set<T>().Where(exp).FirstOrDefault();

        public T GetById(int id) => _context.Set<T>().Find(id);

        public List<T> GetDefault(Expression<Func<T, bool>> exp) => _context.Set<T>().Where(exp).ToList();

        public void Remove(T item)
        {
            item.Status = DAL.ORM.Entity.Enum.Status.Deleted;
            Update(item);
        }

        public void Remove(int id)
        {
            T item = GetById(id);
            item.Status = DAL.ORM.Entity.Enum.Status.Deleted;
            Update(item);
        }

        public void RemoveAll(Expression<Func<T, bool>> exp)
        {
            foreach (var item in GetDefault(exp))
            {
                item.Status = DAL.ORM.Entity.Enum.Status.Deleted;
                Update(item);
            }
        }

        public int Save() => _context.SaveChanges();

        public void Update(T item)
        {
            T updated = GetById(item.ID);
            DbEntityEntry entry = _context.Entry(updated);
            entry.CurrentValues.SetValues(item);
            Save();
        }
    }
}
