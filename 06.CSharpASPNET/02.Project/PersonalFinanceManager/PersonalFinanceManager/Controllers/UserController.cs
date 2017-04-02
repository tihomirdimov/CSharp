using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonalFinanceManager.Data;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.Controllers
{
    public class UserController : Controller
    {
        private PFMContext context = new PFMContext();

        [HttpGet]
        public ActionResult Register([Bind(Include = "Email,Password,FirstName,LastName")] User bind)
        {
            context.Users.Add(bind);
            context.SaveChanges();
            return View();
        }
    }
}