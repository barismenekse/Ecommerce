using Ecommerce.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.Abstract
{
    public interface IProductService
    {
         List<Product> GetAll();
         Product GetById(params Object[] id);
         void Insert(Product obj);
         void Update(Product obj);
         void Delete(params Object[] id);
         Product Select(Expression<Func<Product, bool>> predicate);
         List<Product> SelectAll(Expression<Func<Product, bool>> predicate);
        
    }
}
