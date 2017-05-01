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
            CategoryViewModel categoriesViewModel = new CategoryViewModel();
            categoriesViewModel.Categories = CategoriesService.GetCategories(currentUserId);
            return View(categoriesViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            string currentUserId = User.Identity.GetUserId();
            var currentCategory = CategoriesService.GetCategory(category.Id, currentUserId);
            if (currentCategory != null)
            {
                currentCategory.Name = category.Name;
                CategoriesService.SaveCategory();
            }
            else
            {
                Category toAdd = new Category();
                toAdd.Name = category.Name;
                toAdd.Owner = ApplicationUsersService.GetUser(currentUserId);
                CategoriesService.SaveCategory(toAdd);
            }
            return this.PartialView("_CategoriesListPartial", CategoriesService.GetCategories(currentUserId));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id)
        {
            string currentUserId = User.Identity.GetUserId();
            Category model = CategoriesService.GetCategory(id, currentUserId);
            return this.PartialView("_CategoriesCreatePartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            string currentUserId = User.Identity.GetUserId();
            CategoriesService.DeleteCategory(id, currentUserId);
            return this.PartialView("_CategoriesListPartial", CategoriesService.GetCategories(currentUserId));
        }
    }

}