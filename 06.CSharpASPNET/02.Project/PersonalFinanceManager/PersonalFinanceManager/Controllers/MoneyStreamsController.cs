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
            var currentUser = User.Identity.GetUserId();
            if (db.Books.FirstOrDefault(b => b.Id == id && b.Owner.Id == currentUser) != null)
            {
                MoneyStreamIndexViewModel model = new MoneyStreamIndexViewModel();
                Book currentBook = db.Books.FirstOrDefault(b => b.Id == id);
                model.MoneyStreamManageViewModel.Book = currentBook;
                model.MoneyStreamManageViewModel.Categories = db.Categories.Where(c => c.Owner.Id == currentUser && c.isDeleted == false).OrderBy(c => c.Name).ToList();
                model.MoneyStreamsListViewModel.MoneyStreams = db.MoneyStreams.Where(ms => ms.Owner.Id == currentUser && ms.Book.Id == id && ms.IsDeleted == false).ToList();
                model.MoneyStreamsListViewModel.Book = currentBook;
                return View(model);
            }
            return RedirectToAction("Index", "Books");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MoneyStreamManageViewModel model)
        {
            var currentUser = User.Identity.GetUserId();
            var currentBook = db.Books.FirstOrDefault(b => b.Id == model.Book.Id);
            var currentMoneyStream = db.MoneyStreams.FirstOrDefault(ms => ms.Id == model.MoneyStream.Id);
            if (currentBook != null && currentBook.Owner.Id == currentUser)
            {
                if (model.MoneyStream.Id != 0 && currentMoneyStream.Owner.Id == currentUser)
                {
                    currentMoneyStream.Name = model.MoneyStream.Name;
                    currentMoneyStream.Amount = model.MoneyStream.Amount;
                    currentMoneyStream.Date = model.MoneyStream.Date;
                    currentMoneyStream.IsIncome = model.MoneyStream.IsIncome;
                    currentMoneyStream.Category = db.Categories.FirstOrDefault(c => c.Id == model.MoneyStream.Category.Id);
                    db.SaveChanges();
                }
                else
                {
                    MoneyStream toAdd = new MoneyStream();
                    toAdd.Name = model.MoneyStream.Name;
                    toAdd.Amount = model.MoneyStream.Amount;
                    toAdd.Date = model.MoneyStream.Date;
                    toAdd.IsIncome = model.MoneyStream.IsIncome;
                    toAdd.Book = db.Books.FirstOrDefault(b => b.Id == model.Book.Id);
                    toAdd.Category = db.Categories.FirstOrDefault(c => c.Id == model.MoneyStream.Category.Id);
                    toAdd.Owner = db.Users.FirstOrDefault(u => u.Id == currentUser);
                    db.MoneyStreams.Add(toAdd);
                    db.SaveChanges();
                }
                MoneyStreamsListViewModel outputModel = new MoneyStreamsListViewModel();
                outputModel.MoneyStreams =
                    db.MoneyStreams.Where(
                        ms => ms.Owner.Id == currentUser && ms.Book.Id == currentBook.Id && ms.IsDeleted == false).OrderByDescending(b => b.Date).ToList();
                outputModel.Book = currentBook;
                ModelState.Clear();
                return PartialView("_MoneyStreamsListPartial", outputModel);
            }
            return RedirectToAction("Index", "Books");
        }

        public ActionResult Edit(MoneyStreamManageViewModel model)
        {
            var currentUser = User.Identity.GetUserId();
            var currentBook = db.Books.FirstOrDefault(b => b.Id == model.Book.Id);
            var currentMoneyStream = db.MoneyStreams.FirstOrDefault(ms => ms.Id == model.MoneyStream.Id);
            if (currentBook != null && currentMoneyStream != null &&
                currentBook.Owner.Id == currentUser && currentMoneyStream.Book.Id == currentBook.Id)
            {
                MoneyStreamManageViewModel outputModel = new MoneyStreamManageViewModel();
                outputModel.MoneyStream = currentMoneyStream;
                outputModel.Book = currentBook;
                outputModel.Categories = db.Categories.Where(c => c.Owner.Id == currentUser && c.isDeleted == false).OrderBy(c => c.Name).ToList();
                ModelState.Clear();
                return PartialView("_MoneyStreamsCreatePartial", outputModel);
            }
            return RedirectToAction("Index", "Books");
        }

        public ActionResult Delete(MoneyStreamManageViewModel model)
        {
            var currentUser = User.Identity.GetUserId();
            var currentBook = db.Books.FirstOrDefault(b => b.Id == model.Book.Id);
            var currentMoneyStream = db.MoneyStreams.FirstOrDefault(ms => ms.Id == model.MoneyStream.Id);
            if (currentBook != null && currentMoneyStream != null &&
                currentBook.Owner.Id == currentUser && currentMoneyStream.Book.Id == currentBook.Id)
            {
                currentMoneyStream.IsDeleted = true;
                db.SaveChanges();
                MoneyStreamsListViewModel outputModel = new MoneyStreamsListViewModel();
                outputModel.MoneyStreams =
                    db.MoneyStreams.Where(
                        ms => ms.Owner.Id == currentUser && ms.Book.Id == currentBook.Id && ms.IsDeleted == false).OrderByDescending(b=>b.Date).ToList();
                outputModel.Book = currentBook;
                ModelState.Clear();
                return PartialView("_MoneyStreamsListPartial", outputModel);
            }
            return RedirectToAction("Index", "Books");
        }
    }
}
