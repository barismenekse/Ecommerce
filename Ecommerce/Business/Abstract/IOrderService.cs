using Ecommerce.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.Abstract
{
    public interface IOrderService
    {
        List<Order> GetAll();
        Order GetById(params Object[] id);
        void Create(Basket currentBasket);
        Order Insert(Order obj);
        void Update(Order obj);
        void Delete(params Object[] id);
        Order Select(Expression<Func<Order, bool>> predicate);
        List<Order> SelectAll(Expression<Func<Order, bool>> predicate);
    }
}
