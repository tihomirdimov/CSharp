using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PersonalFinanceManager.Data.Data;
using PersonalFinanceManager.Data.Models;
using PersonalFinanceManager.ViewModels.Categories;

namespace PersonalFinanceManager.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        private PfmDbContext db = new PfmDbContext();

        // GET: Categories
        public ActionResult Index()
        {
            var current = User.Identity.GetUserId();
            CategoriesViewModel categoriesViewModel = new CategoriesViewModel();
            categoriesViewModel.Categories = db.Categories.Where(cat => cat.Owner.Id == current && cat.isDeleted == false).ToList();
            return View(categoriesViewModel);
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            var current = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                if (db.Categories.FirstOrDefault(cat => cat.Id == category.Id) != null)
                {
                    db.Categories.FirstOrDefault(cat => cat.Id == category.Id).Name = category.Name;
                    db.SaveChanges();
                }
                else
                {
                    var owner = db.Users.FirstOrDefault(user => user.Id == current);
                    Category toAdd = new Category();
                    toAdd.Name = category.Name;
                    toAdd.Owner = owner;
                    db.Categories.Add(toAdd);
                    db.SaveChanges();
                }
                List<Category> model = db.Categories.Where(cat => cat.Owner.Id == current && cat.isDeleted == false).ToList();
                return this.PartialView("_CategoriesListPartial", model);
            }
            List<Category> model2 = db.Categories.Where(cat => cat.Owner.Id == current && cat.isDeleted == false).ToList();
            return this.PartialView("_CategoriesListPartial", model2);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id)
        {
            var current = User.Identity.GetUserId();
            Category model = db.Categories.FirstOrDefault(cat => cat.Owner.Id == current && cat.Id == id);
            return this.PartialView("_CategoriesCreatePartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            db.Categories.FirstOrDefault(cat => cat.Id == id).isDeleted = true;
            db.SaveChanges();
            var current = User.Identity.GetUserId();
            List<Category> model = db.Categories.Where(cat => cat.Owner.Id == current && cat.isDeleted == false).ToList();
            return this.PartialView("_CategoriesListPartial", model);
        }
    }

}