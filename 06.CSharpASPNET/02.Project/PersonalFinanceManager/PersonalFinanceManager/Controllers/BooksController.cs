using System;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PersonalFinanceManager.Data.Models;
using PersonalFinanceManager.Interfaces;
using PersonalFinanceManager.Services.ApplicationUsersService;
using PersonalFinanceManager.Services.BooksService;
using PersonalFinanceManager.Services.CategoriesService;
using PersonalFinanceManager.Services.MoneyStreamsService;
using PersonalFinanceManager.ViewModels.Books;

namespace PersonalFinanceManager.Controllers
{
    [Authorize]
    public class BooksController : Controller, IServices
    {
        public BooksController()
        {
            this.ApplicationUsersService = new ApplicationUsersService();
            this.BooksService = new BooksService();
            this.CategoriesService = new CategoriesService();
            this.MoneyStreamsService = new MoneyStreamsService();
        }

        public ApplicationUsersService ApplicationUsersService { get; set; }
        public BooksService BooksService { get; set; }
        public CategoriesService CategoriesService { get; set; }
        public MoneyStreamsService MoneyStreamsService { get; set; }

        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            BooksViewModel booksViewModel = new BooksViewModel();
            booksViewModel.Book = new Book();
            booksViewModel.Books = BooksService.GetBooks(currentUserId);
            return View(booksViewModel);
        }

        public ActionResult Details(int id)
        {
            string currentUserId = User.Identity.GetUserId();
            if (BooksService.CheckIfValidBook(id, currentUserId))
            {
                BookDetailsViewModel model = new BookDetailsViewModel();
                model.Book = BooksService.GetBook(id, currentUserId);
                model.AverageDailyBudget = MoneyStreamsService.GetCurrentMonthDailyBudget(model.Book.Id, currentUserId);
                return View(model);           
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            string currentUserId = User.Identity.GetUserId();
            var currentBook = BooksService.GetBook(book.Id, currentUserId);
            if (currentBook != null)
            {
                currentBook.Name = book.Name;
                currentBook.Currency = book.Currency;
                CategoriesService.SaveCategory();
            }
            else
            {
                Book toAdd = new Book();
                toAdd.Name = book.Name;
                toAdd.Currency = book.Currency;
                toAdd.Owner = ApplicationUsersService.GetUser(currentUserId);
                BooksService.SaveBook(toAdd);
            }
            return this.PartialView("_BooksListPartial", BooksService.GetBooks(currentUserId));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id)
        {
            string currentUserId = User.Identity.GetUserId();
            Book model = BooksService.GetBook(id, currentUserId);
            return this.PartialView("_BooksCreatePartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            string currentUserId = User.Identity.GetUserId();
            BooksService.DeleteBook(id, currentUserId);
            return this.PartialView("_BooksListPartial", BooksService.GetBooks(currentUserId));
        }
    }
}
