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
    public class CategoryController : Controller
    {
        private ICategoryService categoryService;

        public CategoryController()
        {
            categoryService = InstanceFactory.GetInstance<CategoryService>();
        }

        // GET: Category
        public ActionResult Index()
        {
            var categories = categoryService.GetAll();
            return View(categories.ToList());
        }

        // GET: Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category category = categoryService.GetById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            ViewBag.parentCategoryId = new SelectList(categoryService.GetAll(), "categoryId", "name");
            return View();
        }

        // POST: Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "categoryId,name,parentCategoryId")] Category category)
        {
            if (ModelState.IsValid)
            {
                categoryService.Insert(category);
                return RedirectToAction("Index");
            }

            ViewBag.parentCategoryId = new SelectList(categoryService.GetAll(), "categoryId", "name", category.parentCategoryId);
            return View(category);
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = categoryService.GetById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            ViewBag.parentCategoryId = new SelectList(categoryService.GetAll(), "categoryId", "name", category.parentCategoryId);
            return View(category);
        }

        // POST: Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "categoryId,name,parentCategoryId")] Category category)
        {
            if (ModelState.IsValid)
            {
                categoryService.Update(category);
                return RedirectToAction("Index");
            }
            ViewBag.parentCategoryId = new SelectList(categoryService.GetAll(), "categoryId", "name", category.parentCategoryId);
            return View(category);
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = categoryService.GetById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            categoryService.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
