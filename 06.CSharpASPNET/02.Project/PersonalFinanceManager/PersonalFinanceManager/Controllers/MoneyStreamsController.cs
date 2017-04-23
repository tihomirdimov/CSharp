using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PersonalFinanceManager.Data.Data;
using PersonalFinanceManager.Data.Models;
using PersonalFinanceManager.ViewModels.MoneyStreams;

namespace PersonalFinanceManager.Controllers
{
    [Authorize]
    public class MoneyStreamsController : Controller
    {
        private PfmDbContext db = new PfmDbContext();

        public ActionResult Index(int id)
        {
            var current = User.Identity.GetUserId();
            MoneyStreamIndexViewModel model = new MoneyStreamIndexViewModel();
            model.MoneyStream.Book = db.Books.FirstOrDefault(b => b.Id == id && b.Owner.Id == current);
            model.MoneyStreams = db.MoneyStreams.Where(ms => ms.Owner.Id == current && ms.Book.Id == id && ms.isDeleted == false).ToList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MoneyStream moneyStream)

        {
            var current = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                if (db.MoneyStreams.FirstOrDefault(b => b.Id == moneyStream.Id) != null)
                {
                    db.MoneyStreams.FirstOrDefault(b => b.Id == moneyStream.Id).Name = moneyStream.Name;
                    db.MoneyStreams.FirstOrDefault(b => b.Id == moneyStream.Id).Amount = moneyStream.Amount;
                    db.MoneyStreams.FirstOrDefault(b => b.Id == moneyStream.Id).Date = moneyStream.Date;
                    db.MoneyStreams.FirstOrDefault(b => b.Id == moneyStream.Id).isIncome = moneyStream.isIncome;
                    db.SaveChanges();
                }
                else
                {
                    var owner = db.Users.FirstOrDefault(user => user.Id == current);
                    MoneyStream toAdd = new MoneyStream();
                    toAdd.Name = moneyStream.Name;
                    toAdd.Amount = moneyStream.Amount;
                    toAdd.Date = moneyStream.Date;
                    toAdd.isIncome = moneyStream.isIncome;
                    toAdd.Book = moneyStream.Book;
                    toAdd.Owner = owner;
                    db.MoneyStreams.Add(toAdd);
                    db.SaveChanges();
                }
                List<MoneyStream> model = db.MoneyStreams.Where(ms => ms.Owner.Id == current && ms.Book == moneyStream.Book && ms.isDeleted == false).ToList();
                return this.PartialView("_MoneyStreamsListPartial", model);
            }
            List<MoneyStream> model2 = db.MoneyStreams.Where(ms => ms.Owner.Id == current && ms.Book == moneyStream.Book && ms.isDeleted == false).ToList();
            return this.PartialView("_MoneyStreamsListPartial", model2);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Book book)
        {
            var current = User.Identity.GetUserId();
            MoneyStream model = db.MoneyStreams.FirstOrDefault(ms => ms.Owner.Id == current && ms.Book == book && ms.Id == id);
            return this.PartialView("_MoneyStreamsCreatePartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Book book)
        {
            var current = User.Identity.GetUserId();
            db.MoneyStreams.FirstOrDefault(ms => ms.Owner.Id == current && ms.Book == book && ms.Id == id).isDeleted = true;
            db.SaveChanges();
            List<MoneyStream> model = db.MoneyStreams.Where(ms => ms.Owner.Id == current && ms.Book == book && ms.isDeleted == false).ToList();
            return this.PartialView("_MoneyStreamsListPartial", model);
        }
    }
}
