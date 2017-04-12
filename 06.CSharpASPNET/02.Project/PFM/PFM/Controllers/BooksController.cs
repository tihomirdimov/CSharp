using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
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

        // GET: Books/Details/5
        public ActionResult Details(int id)
        {
            var current = User.Identity.GetUserId();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.First(b => b.Id == id);
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

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Books/Edit/5
        public ActionResult Edit(int id)
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

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Books/Delete/5
        public ActionResult Delete(string id)
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
            return View(book);
        }

        // POST: Books/Delete/5
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
