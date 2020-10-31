using Ecommerce.Business;
using Ecommerce.Business.Abstract;
using Ecommerce.Context;
using Ecommerce.Entity;
using Ecommerce.Filter;
using Ecommerce.Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    [MyErrorHandler]
    public class SecurityController : Controller
    {
        private IUserService userService;
        public SecurityController()
        {
            userService = InstanceFactory.GetInstance<UserService>();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View(new User());
        }

        [HttpPost]
        public ActionResult Login(User model)
        {
            ModelState.Remove("Name");
            if (ModelState.IsValid)
            {
                User user = userService.GetById(model.userId);
                if (user == null)
                {
                    ModelState.AddModelError("Id", "User Not Found.");
                    return View(model);
                }
                if (model.password.Equals(user.password))
                {
                    Session.Add("user", user);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("Password", "Parola Error");
                return View(model);
            }

            return View(model);

        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}