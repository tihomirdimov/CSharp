using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PFM.Data;
using PFM.Models;
using PFM.ViewModels;

namespace PFM.Controllers
{
    public class CategoriesController : Controller
    {
        private PFMDbContext db = new PFMDbContext();

        public ActionResult Index()
        {
            var current = User.Identity.GetUserId();
            return View(db.Categories.Where(book => book.Owner.Id == current).ToList());
        }

        public ActionResult Details(int? id)
        {    
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.First(b => b.Id == id);
            if (category == null)
            {
                return HttpNotFound();
            }
            var current = User.Identity.GetUserId();
            if (category.Owner.Id != current)
            {
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Category category)
        {
            var current = User.Identity.GetUserId();
            var owner = db.Users.FirstOrDefault(user => user.Id == current);
            category.Owner = owner;
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        public ActionResult Edit(int? id)
        {          
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.First(b => b.Id == id);
            if (category == null)
            {
                return HttpNotFound();
            }
            var current = User.Identity.GetUserId();
            if (category.Owner.Id != current)
            {
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            var current = User.Identity.GetUserId();
            if (category.Owner.Id != current)
            {
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
