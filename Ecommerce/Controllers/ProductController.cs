using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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

namespace Ecommerce.Controllers
{
    [UserAuth]
    [MyErrorHandler]
    public class ProductController : Controller
    {
        private IProductService productService;
        private ICategoryService categoryService;
        public ProductController()
        {
            productService = InstanceFactory.GetInstance<ProductService>();
            categoryService = InstanceFactory.GetInstance<CategoryService>();
        }

        // GET: Product
        public ActionResult Index()
        {
            var products = productService.GetAll();
            return View(products.ToList());
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = productService.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.categoryId = new SelectList(categoryService.GetAll(), "categoryId", "name");
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "productId,name,description,unitPrice,stockQuantity,categoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                productService.Insert(product);
                return RedirectToAction("Index");
            }

            ViewBag.categoryId = new SelectList(categoryService.GetAll(), "categoryId", "name", product.categoryId);
            return View(product);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = productService.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoryId = new SelectList(categoryService.GetAll(), "categoryId", "name", product.categoryId);
            return View(product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "productId,name,description,unitPrice,stockQuantity,categoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                productService.Update(product);
                return RedirectToAction("Index");
            }
            ViewBag.categoryId = new SelectList(categoryService.GetAll(), "categoryId", "name", product.categoryId);
            return View(product);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = productService.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            productService.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
