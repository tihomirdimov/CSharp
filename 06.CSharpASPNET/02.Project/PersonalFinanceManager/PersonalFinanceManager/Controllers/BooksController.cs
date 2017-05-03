using System.Web.Mvc;
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
        private readonly IApplicationUserService _applicationUsersService;
        private readonly IBooksService _booksService;
        private readonly ICategoriesService _categoriesService;
        private readonly IMoneyStreamsService _moneyStreamsService;

        public BooksController()
        {
            this._booksService = new BooksService();
            this._categoriesService = new CategoriesService();
            this._moneyStreamsService = new MoneyStreamsService();
            this._applicationUsersService = new ApplicationUsersService();
        }

        public BooksController(IApplicationUserService applicationUsersService, IBooksService booksService,
            ICategoriesService categoriesService, IMoneyStreamsService moneyStreamsService) : this()
        {
            this._booksService = booksService;
            this._categoriesService = categoriesService;
            this._moneyStreamsService = moneyStreamsService;
            this._applicationUsersService = applicationUsersService;
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
            var currentBook = _booksService.GetBook(booksFormVM.Id, currentUserId);
            if (currentBook != null)
            {
                currentBook.Name = booksFormVM.Name;
                currentBook.Currency = booksFormVM.Currency;
                _booksService.SaveBook();
            }
            else
            {
                Book toAdd = new Book();
                toAdd.Name = booksFormVM.Name;
                toAdd.Currency = booksFormVM.Currency;
                toAdd.Owner = _applicationUsersService.GetUser(currentUserId);
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
            _booksService.DeleteBook(id, currentUserId);
            return this.PartialView("_BooksListPartial", _booksService.GetBooks(currentUserId));
        }
    }
}
