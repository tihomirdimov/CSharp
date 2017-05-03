using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PersonalFinanceManager.Data.Data;
using PersonalFinanceManager.Data.Models;
using PersonalFinanceManager.Services.ControllerServices;
using PersonalFinanceManager.Services.Interfaces;
using PersonalFinanceManager.ViewModels.Categories;
using AutoMapper.Mappers;

namespace PersonalFinanceManager.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        private readonly IApplicationUserService _applicationUsersService;
        private readonly IBooksService _booksService;
        private readonly ICategoriesService _categoriesService;
        private readonly IMoneyStreamsService _moneyStreamsService;

        public CategoriesController()
        {
            this._booksService = new BooksService();
            this._categoriesService = new CategoriesService();
            this._moneyStreamsService = new MoneyStreamsService();
            this._applicationUsersService = new ApplicationUsersService();
        }

        public CategoriesController(IApplicationUserService applicationUsersService, IBooksService booksService,
            ICategoriesService categoriesService, IMoneyStreamsService moneyStreamsService) : this()
        {
            this._booksService = booksService;
            this._categoriesService = categoriesService;
            this._moneyStreamsService = moneyStreamsService;
            this._applicationUsersService = applicationUsersService;
        }

        [HandleError(View = "_ErrorPartial")]
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            CategoriesVM categoriesVM = new CategoriesVM();
            categoriesVM.Categories = _categoriesService.GetCategories(currentUserId);
            return View(categoriesVM);
        }

        [HandleError(View = "_ErrorPartial")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoriesFormVM categoryFormVM)
        {
            string currentUserId = User.Identity.GetUserId();
            var currentCategory = _categoriesService.GetCategory(categoryFormVM.Id, currentUserId);
            if (currentCategory != null)
            {
                currentCategory.Name = categoryFormVM.Name;
                _categoriesService.SaveCategory();
            }
            else
            {
                Category toAdd = new Category();
                toAdd.Name = categoryFormVM.Name;
                toAdd.Owner = _applicationUsersService.GetUser(currentUserId);
                _categoriesService.SaveCategory(toAdd);
            }
            return this.PartialView("_CategoriesListPartial", _categoriesService.GetCategories(currentUserId));
        }

        [HandleError(View = "_ErrorPartial")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id)
        {
            string currentUserId = User.Identity.GetUserId();
            Category currentCategory = _categoriesService.GetCategory(id, currentUserId);
            CategoriesFormVM model = new CategoriesFormVM();
            model.Id = currentCategory.Id;
            model.Name = currentCategory.Name;
            return this.PartialView("_CategoriesFormPartial", model);
        }

        [HandleError(View = "_ErrorPartial")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            string currentUserId = User.Identity.GetUserId();
            _categoriesService.DeleteCategory(id, currentUserId);
            return this.PartialView("_CategoriesListPartial", _categoriesService.GetCategories(currentUserId));
        }
    }

}