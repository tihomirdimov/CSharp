using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PersonalFinanceManager.Data.Data;
using PersonalFinanceManager.Data.Models;
using PersonalFinanceManager.Interfaces;
using PersonalFinanceManager.Services.ControllerServices;
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



        [HandleError(View = "_ErrorPartial")]
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            PfmDbContext context = new PfmDbContext();
            CategoriesVM categoriesVM = new CategoriesVM();
            categoriesVM.Categories = CategoriesService.GetCategories(context, currentUserId);
            return View(categoriesVM);
        }

        [HandleError(View = "_ErrorPartial")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoriesFormVM categoryFormVM)
        {
            string currentUserId = User.Identity.GetUserId();
            PfmDbContext context = new PfmDbContext();
            var currentCategory = CategoriesService.GetCategory(context, categoryFormVM.Id, currentUserId);
            if (currentCategory != null)
            {
                currentCategory.Name = categoryFormVM.Name;
                CategoriesService.SaveCategory(context);
            }
            else
            {
                Category toAdd = new Category();
                toAdd.Name = categoryFormVM.Name;
                toAdd.Owner = ApplicationUsersService.GetUser(context, currentUserId);
                CategoriesService.SaveCategory(context, toAdd);
            }
            return this.PartialView("_CategoriesListPartial", CategoriesService.GetCategories(context, currentUserId));
        }

        [HandleError(View = "_ErrorPartial")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id)
        {
            string currentUserId = User.Identity.GetUserId();
            PfmDbContext context = new PfmDbContext();
            Category currentCategory = CategoriesService.GetCategory(context, id, currentUserId);
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
            PfmDbContext context = new PfmDbContext();
            CategoriesService.DeleteCategory(context, id, currentUserId);
            return this.PartialView("_CategoriesListPartial", CategoriesService.GetCategories(context, currentUserId));
        }
    }

}