using Ecommerce.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.Abstract
{
    public interface IBasketItemService
    {
        List<BasketItem> GetAll();
        BasketItem GetById(params Object[] id);
        void Insert(BasketItem obj);
        void Update(BasketItem obj);
        void Delete(params Object[] id);
        BasketItem Select(Expression<Func<BasketItem, bool>> predicate);
        List<BasketItem> SelectAll(Expression<Func<BasketItem, bool>> predicate);
    }
}
