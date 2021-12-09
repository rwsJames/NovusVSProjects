using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCProductsApp.Context;
using MVCProductsApp.Models;

namespace MVCProductsApp.Controllers
{
    public class ProductController : Controller
    {
        private ProductContext _db = new ProductContext();

        // GET: Product
        public ActionResult Index()
        {
            return View(_db.Products.ToList());
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Product product = _db.Products.Find(id);
            if (product == null)
                return HttpNotFound();

            return View(product);
        }

        // GET: Product/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Products.Add
                    (product);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Product product = _db.Products.Find(id);
            if (product == null)
                return HttpNotFound();

            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(product);
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Product product = _db.Products.Find(id);
            if (product == null)
                return HttpNotFound();

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, Product prod)
        {
            try
            {
                Product product = new Product();
                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                    product = _db.Products.Find(id);
                    if (product == null)
                        return HttpNotFound();
                    _db.Products.Remove(product);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(product);
            }
            catch
            {
                return View();
            }
        }
    }
}
