using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Context.Abstract
{
    public interface IRepository<T> where T : class
    {
         List<T> GetAll();
         T GetById(params Object[] id);
         T Insert(T obj);
         void Update(T obj);
         void Delete(params Object[] id);
         T Select(Expression<Func<T, bool>> predicate);
         List<T> SelectAll(Expression<Func<T, bool>> predicate);
     
    }
}
