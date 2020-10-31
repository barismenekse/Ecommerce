using Ecommerce.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.Abstract
{
   public interface IUserService
    {
         List<User> GetAll();
         User GetById(params Object[] id);
         void Insert(User obj);
         void Update(User obj);
         void Delete(params Object[] id);
         User Select(Expression<Func<User, bool>> predicate);
         List<User> SelectAll(Expression<Func<User, bool>> predicate);
    
    }
}
