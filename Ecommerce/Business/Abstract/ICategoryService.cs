using Ecommerce.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category GetById(params Object[] id);
        void Insert(Category obj);
        void Update(Category obj);
        void Delete(params Object[] id);
        Category Select(Expression<Func<Category, bool>> predicate);
        List<Category> SelectAll(Expression<Func<Category, bool>> predicate);
    }
}
