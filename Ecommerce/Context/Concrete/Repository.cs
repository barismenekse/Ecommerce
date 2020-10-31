using Ecommerce.Context.Abstract;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Ecommerce.Context
{
    public class Repository<T>:IRepository<T> where T : class
    {

        private BaseEcommerceContext _context;
        protected DbSet<T> table;
        [Inject]
        public Repository(BaseEcommerceContext context)
        {
            _context = context;
            table = _context.Set<T>();
        }

        public List<T> GetAll()
        {
            return table.ToList();
        }
        public T GetById(params Object[] id)
        {
            return table.Find(id);
        }

        public T Insert(T obj)
        {
            return table.Add(obj);
        }
        public void Update(T obj)
        {
           obj=table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(params Object[] id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }

        public T Select(Expression<Func<T, bool>> predicate)
        {
            T obj = table.Where(predicate).FirstOrDefault();
            return obj;

        }
        public List<T> SelectAll(Expression<Func<T, bool>> predicate)
        {
            List<T> obj = table.Where(predicate).ToList();
            return obj;
        }
    }
}