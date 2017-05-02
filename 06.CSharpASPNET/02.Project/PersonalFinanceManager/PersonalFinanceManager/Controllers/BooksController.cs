using System;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PersonalFinanceManager.Data.Data;
using PersonalFinanceManager.Data.Models;
using PersonalFinanceManager.Interfaces;
using PersonalFinanceManager.Services.ControllerServices;
using PersonalFinanceManager.Services.Interfaces;
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

        [HandleError(View = "Home/Index")]
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            PfmDbContext context = new PfmDbContext();
            BooksVM booksVM= new BooksVM();
            booksVM.BookFormVm = new BooksFormVM();
            booksVM.Books = BooksService.GetBooks(context, currentUserId);
            return View(booksVM);
        }

        [HandleError(View = "Books/Index")]
        public ActionResult Details(int id)
        {
            string currentUserId = User.Identity.GetUserId();
            PfmDbContext context = new PfmDbContext();
            if (BooksService.CheckIfValidBook(context, id, currentUserId))
            {
                BooksDetailsVM model = new BooksDetailsVM();
                Book currentBook = BooksService.GetBook(context, id, currentUserId);
                model.Name = currentBook.Name;
                model.Currency = currentBook.Currency;    
                model.AverageDailyBudget = MoneyStreamsService.GetCurrentMonthDailyBudget(context, id, currentUserId);
                model.ExpensesByCategory = CategoriesService.GetCurrentMonthExpensesCategories(context, id, currentUserId);
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
            PfmDbContext context = new PfmDbContext();
            var currentBook = BooksService.GetBook(context, booksFormVM.Id, currentUserId);
            if (currentBook != null)
            {
                currentBook.Name = booksFormVM.Name;
                currentBook.Currency = booksFormVM.Currency;
                BooksService.SaveBook(context);
            }
            else
            {
                Book toAdd = new Book();
                toAdd.Name = booksFormVM.Name;
                toAdd.Currency = booksFormVM.Currency;
                toAdd.Owner = ApplicationUsersService.GetUser(context, currentUserId);
                BooksService.SaveBook(context, toAdd);
            }
            return this.PartialView("_BooksListPartial", BooksService.GetBooks(context, currentUserId));
        }

        [HandleError(View = "_ErrorPartial")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id)
        {
            string currentUserId = User.Identity.GetUserId();
            PfmDbContext context = new PfmDbContext();
            Book currentBook = BooksService.GetBook(context, id, currentUserId);
            BooksFormVM model = new BooksFormVM();
            model.Id = currentBook.Id;
            model.Name = currentBook.Name;
            model.Currency = currentBook.Currency;
            return this.PartialView("_BooksFormPartial", model);
        }

        [HandleError(View = "_ErrorPartial")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            string currentUserId = User.Identity.GetUserId();
            PfmDbContext context = new PfmDbContext();
            BooksService.DeleteBook(context, id, currentUserId);
            return this.PartialView("_BooksListPartial", BooksService.GetBooks(context, currentUserId));
        }
    }
}
