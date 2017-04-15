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
    public class MoneyStreamsController : Controller
    {
        private PFMDbContext db = new PFMDbContext();

        public ActionResult Index()
        {
            return View(db.MoneyStreams.ToList());
        }

        // GET: MoneyStreams/Create
        public ActionResult Create()
        {
            string current = User.Identity.GetUserId();
            CreateMoneyStreamViewModel model = new CreateMoneyStreamViewModel();
            model.Books = db.Books.Where(b => b.Owner.Id == current).ToList();
            model.Categories = db.Categories.Where(b => b.Owner.Id == current).ToList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateMoneyStreamViewModel moneyStreamViewModel)
        {
            string current = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                MoneyStream moneyStream = moneyStreamViewModel.MoneyStream;
                moneyStream.Book = db.Books.FirstOrDefault(book => book.Id == moneyStreamViewModel.MoneyStream.Book.Id);
                moneyStream.Category = db.Categories.FirstOrDefault(category => category.Id == moneyStreamViewModel.MoneyStream.Category.Id);
                moneyStream.Owner = db.Users.FirstOrDefault(user => user.Id == current);
                db.MoneyStreams.Add(moneyStream);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            CreateMoneyStreamViewModel model = new CreateMoneyStreamViewModel();
            model.Books = db.Books.Where(b => b.Owner.Id == current).ToList();
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
        public ActionResult Edit([Bind(Include = "Id,Name,Date,Amount,isIncome")] MoneyStream moneyStream)
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
