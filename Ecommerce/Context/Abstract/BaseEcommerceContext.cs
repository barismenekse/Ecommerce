using Ecommerce.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Context.Abstract
{
    public abstract class BaseEcommerceContext:DbContext
    {
        protected BaseEcommerceContext(string v): base("name="+v)
        {
        }

         DbSet<Basket> baskets { get; set; }
         DbSet<BasketItem> basketItems { get; set; }
         DbSet<Category> categories { get; set; }
         DbSet<Order> orders { get; set; }
         DbSet<OrderDetail> orderDetails { get; set; }
         DbSet<Product> products { get; set; }
         DbSet<User> users { get; set; }
    }
}
