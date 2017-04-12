using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PFM.Models;
using PFM.ViewModels;

namespace PFM.Controllers
{
    public class MoneyStreamsController : Controller
    {
        private PFMDbContext db = new PFMDbContext();

        // GET: MoneyStreams
        public ActionResult Index()
        {
            return View(db.MoneyStreams.ToList());
        }

        // GET: MoneyStreams/Details/5
        public ActionResult Details(int? id)
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

        // GET: MoneyStreams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MoneyStreams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Date,Amount,isIncome")] MoneyStream moneyStream)
        {
            if (ModelState.IsValid)
            {
                db.MoneyStreams.Add(moneyStream);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(moneyStream);
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
