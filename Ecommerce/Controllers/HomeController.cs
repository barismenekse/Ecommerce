using Ecommerce.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    [UserAuth]
    [MyErrorHandler]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return RedirectToAction("Index", "Product");
        }
    }
}
