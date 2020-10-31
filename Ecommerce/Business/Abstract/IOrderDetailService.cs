using Ecommerce.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.Abstract
{
    public interface IOrderDetailService
    {
        List<OrderDetail> GetAll();
        OrderDetail GetById(params Object[] id);
        OrderDetail Insert(OrderDetail obj);
        void Update(OrderDetail obj);
        void Delete(params Object[] id);
        OrderDetail Select(Expression<Func<OrderDetail, bool>> predicate);
        List<OrderDetail> SelectAll(Expression<Func<OrderDetail, bool>> predicate);
    }
}
