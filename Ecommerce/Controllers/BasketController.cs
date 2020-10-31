using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ecommerce.Business;
using Ecommerce.Context;
using Ecommerce.Entity;
using Ecommerce.Filter;
using Ecommerce.Ninject;
using Ecommerce.Session;

namespace Ecommerce.Controllers
{
    [UserAuth]
    [MyErrorHandler]
    public class BasketController : Controller
    {
        private UserService userService;
        private BasketService basketService;
        private BasketItemService basketItemService;
        private ProductService productService;
        private User currentUser;
        public BasketController()
        {
            productService = InstanceFactory.GetInstance<ProductService>();
            basketService = InstanceFactory.GetInstance<BasketService>();
            basketItemService = InstanceFactory.GetInstance<BasketItemService>();
            userService = InstanceFactory.GetInstance<UserService>();
            currentUser = CurrentSession.getCurrentUser();
        }
        // GET: Basket
        public ActionResult Index()
        {
            Basket currentBasket = basketService.Select(a => a.user.userId == currentUser.userId);
            if (currentBasket == null)
            {
                basketService.Insert(new Basket() { user = userService.GetById(currentUser.userId), userId = currentUser.userId });
                currentBasket = basketService.Select(a => a.user.userId == currentUser.userId);
            }
            return View(currentBasket);
        }

        // GET: Basket/RemoveItem/5
        public ActionResult RemoveItem(int id)
        {
            Product product = productService.GetById(id);
            Basket currentBasket = basketService.Select(a => a.user.userId == currentUser.userId);
            BasketItem basketItem;
            if (currentBasket == null || currentBasket.basketItems == null || currentBasket.basketItems.Count == 0)
                return RedirectToAction("Index");
            if (product != null)
            {
                basketItem = currentBasket.basketItems.FirstOrDefault(x => x.productId == id);
                basketService.removeItem(currentBasket, basketItem);
                return RedirectToAction("Index");
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        }

        // GET: Basket/AddItem/5
        public ActionResult AddItem(int id)
        {
            Basket currentBasket = basketService.Select(a => a.user.userId == currentUser.userId);
            if (currentBasket == null)
            {
                basketService.Insert(new Basket() { user = userService.GetById(currentUser.userId), userId = currentUser.userId });
                currentBasket = basketService.Select(a => a.user.userId == currentUser.userId);
            }
            basketService.addItem(currentBasket, id);
            return RedirectToAction("Index", "Product");

        }


    }
}
