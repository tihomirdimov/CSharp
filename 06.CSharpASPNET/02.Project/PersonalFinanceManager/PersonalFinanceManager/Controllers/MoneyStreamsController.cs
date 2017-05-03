using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PersonalFinanceManager.Data.Data;
using PersonalFinanceManager.Data.Models;
using PersonalFinanceManager.Services.ControllerServices;
using PersonalFinanceManager.Services.Interfaces;
using PersonalFinanceManager.ViewModels.MoneyStreams;

namespace PersonalFinanceManager.Controllers
{
    [Authorize]
    public class MoneyStreamsController : Controller
    {
        private readonly IApplicationUserService _applicationUsersService;
        private readonly IBooksService _booksService;
        private readonly ICategoriesService _categoriesService;
        private readonly IMoneyStreamsService _moneyStreamsService;

        public MoneyStreamsController()
        {
            this._booksService = new BooksService();
            this._categoriesService = new CategoriesService();
            this._moneyStreamsService = new MoneyStreamsService();
            this._applicationUsersService = new ApplicationUsersService();
        }

        public MoneyStreamsController(IApplicationUserService applicationUsersService, IBooksService booksService,
            ICategoriesService categoriesService, IMoneyStreamsService moneyStreamsService) : this()
        {
            this._booksService = booksService;
            this._categoriesService = categoriesService;
            this._moneyStreamsService = moneyStreamsService;
            this._applicationUsersService = applicationUsersService;
        }

        [HandleError(View = "Home/Index")]
        public ActionResult Index(int id)
        {
            string currentUserId = User.Identity.GetUserId();
            if (_booksService.CheckIfValidBook(id, currentUserId))
            {
                MoneyStreamsIndexVM model = new MoneyStreamsIndexVM();
                model.MoneyStreamsFormVM.Categories = _categoriesService.GetCategories(currentUserId);
                model.MoneyStreamsFormVM.BookId = id;
                model.MoneyStreamsListVM.MoneyStreams = _moneyStreamsService.GetMoneyStreamsList(id, currentUserId);
                model.MoneyStreamsListVM.BookId = id;
                return View(model);
            }
            return RedirectToAction("Index", "Books");
        }

        [HandleError(View = "_ErrorPartial")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MoneyStreamsFormVM model)
        {
            string currentUserId = User.Identity.GetUserId();
            PfmDbContext context = new PfmDbContext();
            if (_booksService.CheckIfValidBook(model.BookId, currentUserId))
            {
                MoneyStream toAdd = new MoneyStream();
                toAdd.Name = model.Name;
                toAdd.Amount = model.Amount;
                toAdd.Date = model.Date;
                toAdd.IsIncome = model.IsIncome;
                toAdd.Book = _booksService.GetBook(model.BookId, currentUserId);
                toAdd.Category = _categoriesService.GetCategory(model.CategoryId, currentUserId);
                toAdd.Owner = _applicationUsersService.GetUser(currentUserId);
                _moneyStreamsService.SaveMoneyStream(toAdd);
            }
            MoneyStreamsListVM outputModel = new MoneyStreamsListVM();
            outputModel.MoneyStreams = _moneyStreamsService.GetMoneyStreamsList(model.BookId, currentUserId);
            outputModel.BookId = model.BookId;
            return PartialView("_MoneyStreamsListPartial", outputModel);
        }

        [HandleError(View = "_ErrorPartial")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, int bookId)
        {
            string currentUserId = User.Identity.GetUserId();
            PfmDbContext context = new PfmDbContext();
            if (_moneyStreamsService.CheckIfValidMoneyStream(id, bookId, currentUserId))
            {
                _moneyStreamsService.DeleteMoneyStream(id, currentUserId);
            }
            MoneyStreamsListVM outputModel = new MoneyStreamsListVM();
            outputModel.MoneyStreams = _moneyStreamsService.GetMoneyStreamsList(bookId, currentUserId);
            outputModel.BookId = bookId;
            return PartialView("_MoneyStreamsListPartial", outputModel);
        }
    }
}
