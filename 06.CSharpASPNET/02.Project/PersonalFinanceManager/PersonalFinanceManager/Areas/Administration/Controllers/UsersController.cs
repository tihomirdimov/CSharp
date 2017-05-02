﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PersonalFinanceManager.Areas.Administration.ViewModels;
using PersonalFinanceManager.Data.Data;
using PersonalFinanceManager.Data.Models;

namespace PersonalFinanceManager.Areas.Administration.Controllers
{
    [Authorize]
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        
        public ActionResult Index()
        {
            PfmDbContext db = new PfmDbContext();
            string current = User.Identity.GetUserId();
            List<ApplicationUser> inputData = db.Users.ToList();
            inputData.Remove(inputData.FirstOrDefault(user => user.Id == current));
            List<LockUserVM> model = inputData
                .Select(u => new LockUserVM
                {
                    Id = u.Id,
                    Email = u.Email,
                    UserName = u.UserName,
                    LockoutEnabled = u.LockoutEnabled
                }).ToList();
            return View(model);
        }

        public ActionResult LockUser(string id)
        {
            PfmDbContext db = new PfmDbContext();
            ApplicationUser userToManage = db.Users.FirstOrDefault(user => user.Id == id);
            LockUserVM model = new LockUserVM();
            model.Id = userToManage.Id;
            model.Email = userToManage.Email;
            model.UserName = userToManage.UserName;
            model.LockoutEnabled = userToManage.LockoutEnabled;
            return View(model);
        }

        [HttpPost]
        public ActionResult LockUser(LockUserVM model)
        {
            PfmDbContext db = new PfmDbContext();
            db.Users.FirstOrDefault(user => user.Id == model.Id).LockoutEnabled =
                model.LockoutEnabled;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}