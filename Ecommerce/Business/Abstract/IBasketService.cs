using Ecommerce.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.Abstract
{
    public interface IBasketService
    {
        List<Basket> GetAll();
        Basket GetById(params Object[] id);
        void Insert(Basket obj);
        void Update(Basket obj);
        void Delete(params Object[] id);
        Basket Select(Expression<Func<Basket, bool>> predicate);
        List<Basket> SelectAll(Expression<Func<Basket, bool>> predicate);
        void addItem(Basket basket, int? productId);
        void removeItem(Basket basket, BasketItem item);
    }
}
