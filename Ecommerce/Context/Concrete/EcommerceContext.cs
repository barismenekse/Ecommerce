using Ecommerce.Context.Abstract;
using Ecommerce.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Ecommerce.Context
{
    public class EcommerceContext:BaseEcommerceContext
    {
        public EcommerceContext() : base("Context") { }
        public virtual DbSet<Basket> baskets { get; set; }
        public virtual DbSet<BasketItem> basketItems { get; set; }
        public virtual DbSet<Category> categories { get; set; }
        public virtual DbSet<Order> orders { get; set; }
        public virtual DbSet<OrderDetail> orderDetails { get; set; }
        public virtual DbSet<Product> products { get; set; }
        public virtual DbSet<User> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().Property(m => m.parentCategoryId).IsOptional();
            base.OnModelCreating(modelBuilder);
        }
    }
}