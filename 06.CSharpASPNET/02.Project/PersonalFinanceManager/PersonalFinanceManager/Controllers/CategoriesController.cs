using System;
using System.Diagnostics;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using PersonalFinanceManager.Data.Models;
using PersonalFinanceManager.Services.ControllerServices;
using PersonalFinanceManager.Services.Interfaces;
using PersonalFinanceManager.ViewModels.Categories;

namespace PersonalFinanceManager.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        private readonly ICategoriesService _categoriesService;

        public CategoriesController() : this(new CategoriesService())
        {
        }

        public CategoriesController(ICategoriesService categoriesService)
        {
            this._categoriesService = categoriesService;
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
            if (categoryFormVM.Id != 0) // update
            {
                var currentCategory = _categoriesService.GetCategory(categoryFormVM.Id, currentUserId);
                currentCategory.Name = categoryFormVM.Name;
                _categoriesService.SaveCategory();
            }
            else // add
            {
                var toAdd = Mapper.Map<CategoriesFormVM, Category>(categoryFormVM);
                toAdd.OwnerId = currentUserId;
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
            try
            {
                var model2 = Mapper.Map<Category, CategoriesFormVM>(currentCategory);
            }
            catch (Exception e)
            {
                    
                Debug.WriteLine(e);
            }
            var model = Mapper.Map<Category,CategoriesFormVM>(currentCategory);
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