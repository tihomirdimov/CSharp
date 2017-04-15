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
    [Authorize]
    public class BooksController : Controller
    {
        private PFMDbContext db = new PFMDbContext();

        public ActionResult Index()
        {
            var current = User.Identity.GetUserId();
            return View(db.Books.Where(book => book.Owner.Id == current).ToList());
        }

        public ActionResult Details(int? id)
        {
            var current = User.Identity.GetUserId();
            Book book = db.Books.First(b => b.Id == id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            if (book == null)
            {
                return HttpNotFound();
            }
            if (book.Owner.Id != current)
            {
                return RedirectToAction("Index");
            }
            return View(book);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Currency")] Book book)
        {
            var current = User.Identity.GetUserId();
            var owner = db.Users.FirstOrDefault(user => user.Id == current);
            book.Owner = owner;
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book);
        }

        public ActionResult Edit(int? id)
        {
            var current = User.Identity.GetUserId();
            Book book = db.Books.First(b => b.Id == id);
            if (book == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (book.Owner.Id != current)
            {
                return RedirectToAction("Index");
            }
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Currency")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            var current = User.Identity.GetUserId();
            if (book.Owner.Id != current)
            {
                return RedirectToAction("Index");
            }
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
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
