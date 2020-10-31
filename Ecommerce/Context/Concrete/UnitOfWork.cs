using Ecommerce.Context.Abstract;
using Ecommerce.Entity;
using Ecommerce.Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.Context
{
    public class UnitOfWork:IDisposable,IUnitOfWork
    {
        private BaseEcommerceContext context;

        private IRepository<Product> productRepository;
        private IRepository<Basket> basketRepository;
        private IRepository<BasketItem> basketItemRepository;
        private IRepository<Category> categoryRepository;
        private IRepository<Order> orderRepository;
        private IRepository<OrderDetail> orderDetailRepository;
        private IRepository<User> userRepository;

        public UnitOfWork()
        {
            context = InstanceFactory.GetInstance<BaseEcommerceContext>();
            productRepository = InstanceFactory.GetInstance<Repository<Product>>();
            basketRepository = InstanceFactory.GetInstance<Repository<Basket>>();
            basketItemRepository = InstanceFactory.GetInstance<Repository<BasketItem>>();
            categoryRepository = InstanceFactory.GetInstance<Repository<Category>>();
            orderRepository = InstanceFactory.GetInstance<Repository<Order>>();
            orderDetailRepository = InstanceFactory.GetInstance<Repository<OrderDetail>>();
            userRepository = InstanceFactory.GetInstance<Repository<User>>();
        }

        public BaseEcommerceContext Context
        {
            get
            {
                return context;
            }
        }

        public IRepository<Product> ProductRepository
        {
            get
            {
                return productRepository;
            }
        }

        public IRepository<Basket> BasketRepository
        {
            get
            {
                return basketRepository;
            }
        }

        public IRepository<BasketItem> BasketItemRepository
        {
            get
            {
                return basketItemRepository;
            }
        }

        public IRepository<Category> CategoryRepository
        {
            get
            {
                return categoryRepository;
            }
        }

        public IRepository<Order> OrderRepository
        {
            get
            {
                return orderRepository;
            }
        }

        public IRepository<OrderDetail> OrderDetailRepository
        {
            get
            {
                return orderDetailRepository;
            }
        }


        public IRepository<User> UserRepository
        {
            get
            {
                return userRepository;
            }
        }

    

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {

        }

    }
}