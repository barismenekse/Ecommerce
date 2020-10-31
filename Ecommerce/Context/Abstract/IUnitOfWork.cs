using Ecommerce.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Context.Abstract
{
    public interface IUnitOfWork
    {
         BaseEcommerceContext Context
        {
            get;
        }
         IRepository<Product> ProductRepository
        {
            get;
        }
        IRepository<Basket> BasketRepository
        {
            get;
        }
        IRepository<BasketItem> BasketItemRepository
        {
            get;
        }
        IRepository<Category> CategoryRepository
        {
            get;
        }
        IRepository<Order> OrderRepository
        {
            get;
        }
        IRepository<OrderDetail> OrderDetailRepository
        {
            get;
        }
        IRepository<User> UserRepository
        {
            get;
        }
        void Save();
       

    }
}
