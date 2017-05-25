using System;
using System.Diagnostics;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using PersonalFinanceManager.Data.Models;
using PersonalFinanceManager.Services.ControllerServices;
using PersonalFinanceManager.Services.Interfaces;
using PersonalFinanceManager.ViewModels.Books;

namespace PersonalFinanceManager.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private readonly IBooksService _booksService;
        private readonly ICategoriesService _categoriesService;
        private readonly IMoneyStreamsService _moneyStreamsService;

        public BooksController(IBooksService booksService, ICategoriesService categoriesService, IMoneyStreamsService moneyStreamsService)
        {
            this._booksService = booksService;
            this._categoriesService = categoriesService;
            this._moneyStreamsService = moneyStreamsService;
        }

        [HandleError(View = "Home/Index")]
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            BooksVM booksVm = new BooksVM();
            booksVm.BookFormVm = new BooksFormVM();
            booksVm.Books = _booksService.GetBooks(currentUserId);
            return View(booksVm);
        }

        [HandleError(View = "Books/Index")]
        public ActionResult Details(int id)
        {
            string currentUserId = User.Identity.GetUserId();
            if (_booksService.CheckIfValidBook(id, currentUserId))
            {
                BooksDetailsVM model = new BooksDetailsVM();
                Book currentBook = _booksService.GetBook(id, currentUserId);
                model.Name = currentBook.Name;
                model.Currency = currentBook.Currency;
                model.AverageDailyBudget = _moneyStreamsService.GetCurrentMonthDailyBudget(id, currentUserId);
                model.ExpensesByCategory = _categoriesService.GetCurrentMonthExpensesCategories(id, currentUserId);
                return View(model);
            }
            return RedirectToAction("Index");
        }

        [HandleError(View = "_ErrorPartial")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BooksFormVM booksFormVM)
        {
            string currentUserId = User.Identity.GetUserId();
            if (booksFormVM.Id != 0)
            {
                var currentBook = _booksService.GetBook(booksFormVM.Id, currentUserId);
                currentBook.Name = booksFormVM.Name;
                currentBook.Currency = booksFormVM.Currency;
                _booksService.SaveBook();
            }
            else
            {
                var toAdd = Mapper.Map<BooksFormVM, Book>(booksFormVM);
                toAdd.OwnerId = currentUserId;
                _booksService.SaveBook(toAdd);
            }
            return this.PartialView("_BooksListPartial", _booksService.GetBooks(currentUserId));
        }

        [HandleError(View = "_ErrorPartial")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id)
        {
            string currentUserId = User.Identity.GetUserId();
            Book currentBook = _booksService.GetBook(id, currentUserId);
            try
            {
                var model = Mapper.Map<Book, BooksFormVM>(currentBook);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            var model2 = Mapper.Map<Book, BooksFormVM>(currentBook);
            return this.PartialView("_BooksFormPartial", model2);
        }

        [HandleError(View = "_ErrorPartial")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            string currentUserId = User.Identity.GetUserId();
            _booksService.DeleteBook(id, currentUserId);
            return this.PartialView("_BooksListPartial", _booksService.GetBooks(currentUserId));
        }
    }
}
