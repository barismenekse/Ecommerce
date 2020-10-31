using Ecommerce.Business;
using Ecommerce.Business.Abstract;
using Ecommerce.Context;
using Ecommerce.Context.Abstract;
using Ecommerce.Entity;
using Ecommerce.Entity.Abstract;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.Ninject
{
    public class InstanceModule:NinjectModule
    {
        public override void Load()
        {
            
            Bind<IRepository<IEntity>>().To<Repository<IEntity>>().InSingletonScope();
            Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
            Bind<IBasketItemService>().To<BasketItemService>().InSingletonScope();
            Bind<IBasketService>().To<BasketService>().InSingletonScope();
            Bind<ICategoryService>().To<CategoryService>().InSingletonScope();
            Bind<IOrderDetailService>().To<OrderDetailService>().InSingletonScope();
            Bind<IOrderService>().To<OrderService>().InSingletonScope();
            Bind<IProductService>().To<ProductService>().InSingletonScope();
            Bind<IUserService>().To<UserService>().InSingletonScope();
            Bind<BaseEcommerceContext>().To<EcommerceContext>().InSingletonScope();
            
        }
    }
}