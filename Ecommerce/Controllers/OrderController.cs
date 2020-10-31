using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ecommerce.Business;
using Ecommerce.Business.Abstract;
using Ecommerce.Context;
using Ecommerce.Entity;
using Ecommerce.Filter;
using Ecommerce.Ninject;
using Ecommerce.Session;
namespace Ecommerce.Controllers
{
    [UserAuth]
    [MyErrorHandler]
    public class OrderController : Controller
    {
        IBasketService basketService;
        IBasketItemService basketItemService;
        IOrderService orderService;
        IOrderDetailService orderDetailService;
        IUserService userService;
        public OrderController()
        {
            basketService = InstanceFactory.GetInstance<BasketService>();
            basketItemService = InstanceFactory.GetInstance<BasketItemService>();
            orderService = InstanceFactory.GetInstance<OrderService>();
            orderDetailService = InstanceFactory.GetInstance<OrderDetailService>();
            userService = InstanceFactory.GetInstance<UserService>();
        }
        // GET: Order
        public ActionResult Create()
        {
            User user = userService.GetById(CurrentSession.getCurrentUser().userId);
            Basket currentBasket = basketService.Select(x => x.userId == user.userId);
            if (currentBasket == null || currentBasket.basketItems == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            try
            {
                orderService.Create(currentBasket);
                basketService.Delete(currentBasket.basketId);
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotAcceptable);
            }

            return RedirectToAction("Index", "Product");
        }
    }
}