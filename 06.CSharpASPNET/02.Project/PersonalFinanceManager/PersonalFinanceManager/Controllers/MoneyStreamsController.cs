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
using PersonalFinanceManager.Data;
using PFM.ViewModels;

namespace PersonalFinanceManager.Controllers
{
    public class MoneyStreamsController : Controller
    {
        private PfmDbContext db = new PfmDbContext();

        // GET: MoneyStreams
        public ActionResult Index(int id)
        {
            var current = User.Identity.GetUserId();
            if (db.Books.FirstOrDefault(b => b.Id == id).Owner.Id != current)
            {
                return RedirectToAction("Index", "Books");
            }
            MoneyStreamIndexViewModel model = new MoneyStreamIndexViewModel();
            model.BookId = id;
            model.MoneyStream = db.MoneyStreams.Where(ms => ms.Book.Id == id).ToList();
            return View(model);
        }

        // GET: MoneyStreams/Create
        public ActionResult Create(int id)
        {
            Book currentBook = db.Books.FirstOrDefault(b => b.Id == id);
            var currentUser = User.Identity.GetUserId();
            if (currentBook.Owner.Id != currentUser)
            {
                return RedirectToAction("Index", "Books");
            }
            CreateMoneyStreamViewModel model = new CreateMoneyStreamViewModel();
            model.MoneyStream.Book = currentBook;
            model.Categories = db.Categories.Where(b => b.Owner.Id == currentUser).ToList();
            return View(model);
        }

        // POST: MoneyStreams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateMoneyStreamViewModel createMoneyStreamViewModel)
        {
            string current = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                MoneyStream moneyStream = createMoneyStreamViewModel.MoneyStream;
                moneyStream.Book = db.Books.FirstOrDefault(book => book.Id == createMoneyStreamViewModel.MoneyStream.Book.Id);
                moneyStream.Category = db.Categories.FirstOrDefault(category => category.Id == createMoneyStreamViewModel.MoneyStream.Category.Id);
                moneyStream.Owner = db.Users.FirstOrDefault(user => user.Id == current);
                db.MoneyStreams.Add(moneyStream);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = moneyStream.Book.Id });
            }
            CreateMoneyStreamViewModel model = new CreateMoneyStreamViewModel();
            model.Categories = db.Categories.Where(b => b.Owner.Id == current).ToList();
            return View(model);
        }

        // GET: MoneyStreams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MoneyStream moneyStream = db.MoneyStreams.Find(id);
            if (moneyStream == null)
            {
                return HttpNotFound();
            }
            return View(moneyStream);
        }

        // POST: MoneyStreams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Date,Amount,isIncome,isDeleted")] MoneyStream moneyStream)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moneyStream).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(moneyStream);
        }

        // GET: MoneyStreams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MoneyStream moneyStream = db.MoneyStreams.Find(id);
            if (moneyStream == null)
            {
                return HttpNotFound();
            }
            return View(moneyStream);
        }

        // POST: MoneyStreams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MoneyStream moneyStream = db.MoneyStreams.Find(id);
            db.MoneyStreams.Remove(moneyStream);
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
