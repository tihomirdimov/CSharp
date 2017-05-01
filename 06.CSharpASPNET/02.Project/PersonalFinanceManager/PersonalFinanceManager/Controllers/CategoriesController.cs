using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PersonalFinanceManager.Data.Models;
using PersonalFinanceManager.Interfaces;
using PersonalFinanceManager.Services.ApplicationUsersService;
using PersonalFinanceManager.Services.BooksService;
using PersonalFinanceManager.Services.CategoriesService;
using PersonalFinanceManager.Services.MoneyStreamsService;
using PersonalFinanceManager.ViewModels.Categories;

namespace PersonalFinanceManager.Controllers
{
    [Authorize]
    public class CategoriesController : Controller, IServices
    {
        public CategoriesController()
        {
            this.CurrentUserId = User.Identity.GetUserId();
            this.ApplicationUsersService = new ApplicationUsersService();
            this.BooksService = new BooksService();
            this.CategoriesService = new CategoriesService();
            this.MoneyStreamsService = new MoneyStreamsService();
        }

        public string CurrentUserId { get; set; }
        public ApplicationUsersService ApplicationUsersService { get; set; }
        public BooksService BooksService { get; set; }
        public CategoriesService CategoriesService { get; set; }
        public MoneyStreamsService MoneyStreamsService { get; set; }

        public ActionResult Index()
        {
            CategoryViewModel categoriesViewModel = new CategoryViewModel();
            categoriesViewModel.Categories = CategoriesService.GetCategories(CurrentUserId);
            return View(categoriesViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            var currentCategory = CategoriesService.GetCategory(category.Id,CurrentUserId);
            if (currentCategory != null)
            {
                currentCategory.Name = category.Name;
                CategoriesService.SaveCategory();
            }
            else
            {
                Category toAdd = new Category();
                toAdd.Name = category.Name;
                toAdd.Owner = ApplicationUsersService.GetUser(CurrentUserId);
                CategoriesService.SaveCategory(toAdd);
            }
            return this.PartialView("_CategoriesListPartial", CategoriesService.GetCategories(CurrentUserId));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id)
        {
            Category model = CategoriesService.GetCategory(id, CurrentUserId);
            return this.PartialView("_CategoriesCreatePartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            CategoriesService.DeleteCategory(id, CurrentUserId);
            return this.PartialView("_CategoriesListPartial", CategoriesService.GetCategories(CurrentUserId));
        }
    }

}