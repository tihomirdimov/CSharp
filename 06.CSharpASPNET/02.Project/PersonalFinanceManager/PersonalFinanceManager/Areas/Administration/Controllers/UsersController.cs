using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PersonalFinanceManager.Areas.Administration.ViewModels;
using PersonalFinanceManager.Data.Data;
using PersonalFinanceManager.Data.Models;
using AutoMapper;
using PersonalFinanceManager.Services.ControllerServices;
using PersonalFinanceManager.Services.Interfaces;

namespace PersonalFinanceManager.Areas.Administration.Controllers
{
    [Authorize]
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly IApplicationUserService _applicationUsersService;

        public UsersController()
        {
            this._applicationUsersService = new ApplicationUsersService();
        }

        public UsersController(IApplicationUserService applicationUsersService) : this()
        {
            this._applicationUsersService = applicationUsersService;
        }

        public ActionResult Index()
        {
            string current = User.Identity.GetUserId();
            ICollection<ApplicationUser> inputData = _applicationUsersService.GetUsers();
            inputData.Remove(inputData.FirstOrDefault(user => user.Id == current));
            var model = Mapper.Map<ICollection<ApplicationUser>, ICollection<LockUserVM>>(inputData);
            return View(model);
        }

        public ActionResult LockUser(string id)
        {
            ApplicationUser userToManage = _applicationUsersService.GetUser(id);
            var model = Mapper.Map<ApplicationUser, LockUserVM>(userToManage);
            return View(model);
        }

        [HttpPost]
        public ActionResult LockUser(LockUserVM model)
        {
            PfmDbContext db = new PfmDbContext();
            db.Users.FirstOrDefault(user => user.Id == model.Id).LockoutEnabled = model.LockoutEnabled;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}