using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PersonalFinanceManager.Data.Data;
using PersonalFinanceManager.Data.Models;
using PersonalFinanceManager.Services.BooksService;
using PersonalFinanceManager.Services.CategoriesService;
using PersonalFinanceManager.Services.MoneyStreamsService;
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
            var bookService = new BooksService(db);
            var categoriesService = new CategoriesService(db);
            var moneyStreamsService = new MoneyStreamsService(db);
            if (bookService.CheckIfValidBook(id, currentUser))
            {
                MoneyStreamIndexViewModel model = new MoneyStreamIndexViewModel();
                model.MoneyStreamManageViewModel.Categories = categoriesService.GetCategories(currentUser);
                model.MoneyStreamManageViewModel.BookId = id;
                model.MoneyStreamsListViewModel.MoneyStreams = moneyStreamsService.GetMoneyStreamsList(id, currentUser);
                model.MoneyStreamsListViewModel.BookId = id;
                return View(model);
            }
            return RedirectToAction("Index", "Books");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ChildActionOnly]
        public ActionResult Create(MoneyStreamManageViewModel model)
        {
            var currentUser = User.Identity.GetUserId();
            var categoriesService = new CategoriesService(db);
            var bookService = new BooksService(db);      
            var moneyStreamsService = new MoneyStreamsService(db);
            if (bookService.CheckIfValidBook(model.BookId, currentUser) &&
                moneyStreamsService.CheckIfValidMoneyStream(model.MoneyStream.Id, model.BookId, currentUser))
            {
                MoneyStream toAdd = new MoneyStream();
                toAdd.Name = model.MoneyStream.Name;
                toAdd.Amount = model.MoneyStream.Amount;
                toAdd.Date = model.MoneyStream.Date;
                toAdd.IsIncome = model.MoneyStream.IsIncome;
                toAdd.Book = db.Books.FirstOrDefault(b => b.Id == model.BookId);
                toAdd.Category = categoriesService.GetCategory(model.MoneyStream.Category.Id);
                toAdd.Owner = db.Users.FirstOrDefault(u => u.Id == currentUser);
                db.MoneyStreams.Add(toAdd);
                db.SaveChanges();
            }
            MoneyStreamsListViewModel outputModel = new MoneyStreamsListViewModel();
            outputModel.MoneyStreams = moneyStreamsService.GetMoneyStreamsList(model.BookId, currentUser);
            outputModel.BookId = model.BookId;
            return PartialView("_MoneyStreamsListPartial", outputModel);
        }

        [ChildActionOnly]
        public ActionResult Delete(MoneyStreamManageViewModel model)
        {
            var currentUser = User.Identity.GetUserId();
            var moneyStreamService = new MoneyStreamsService(db);
            if (moneyStreamService.CheckIfValidMoneyStream(model.MoneyStream.Id, model.BookId, currentUser))
            {
                var currentMoneyStream = moneyStreamService.GetMoneyStream(model.MoneyStream.Id);
                currentMoneyStream.IsDeleted = true;
                db.SaveChanges();
                MoneyStreamsListViewModel outputModel = new MoneyStreamsListViewModel();
                outputModel.MoneyStreams = moneyStreamService.GetMoneyStreamsList(model.BookId, currentUser);
                return PartialView("_MoneyStreamsListPartial", outputModel);
            }
            return RedirectToAction("Index", "Books");
        }
    }
}
