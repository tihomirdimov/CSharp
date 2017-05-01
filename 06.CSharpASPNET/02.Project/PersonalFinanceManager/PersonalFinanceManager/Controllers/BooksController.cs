using System.Collections.Generic;
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
        public string CurrentUserId { get; set; }
        public ApplicationUsersService ApplicationUsersService { get; set; }
        public BooksService BooksService { get; set; }
        public CategoriesService CategoriesService { get; set; }
        public MoneyStreamsService MoneyStreamsService { get; set; }

        public ActionResult Index()
        {
            BooksViewModel booksViewModel = new BooksViewModel();
            booksViewModel.Book = new Book();
            booksViewModel.Books = BooksService.GetBooks(CurrentUserId);
            return View(booksViewModel);
        }

        public ActionResult Details(int id)
        {
            if (BooksService.CheckIfValidBook(id, CurrentUserId))
            {
                var current = User.Identity.GetUserId();
                BookDetailsViewModel model = new BookDetailsViewModel();
                model.Book = BooksService.GetBook(id, CurrentUserId);
                return View(model);           
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            var currentBook = BooksService.GetBook(book.Id, CurrentUserId);
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
                toAdd.Owner = ApplicationUsersService.GetUser(CurrentUserId);
                BooksService.SaveBook(toAdd);
            }
            return this.PartialView("_BooksListPartial", BooksService.GetBooks(CurrentUserId));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id)
        {
            Book model = BooksService.GetBook(id, CurrentUserId);
            return this.PartialView("_BooksCreatePartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            BooksService.DeleteBook(id, CurrentUserId);

            return this.PartialView("_BooksListPartial", BooksService.GetBooks(CurrentUserId));
        }
    }
}
