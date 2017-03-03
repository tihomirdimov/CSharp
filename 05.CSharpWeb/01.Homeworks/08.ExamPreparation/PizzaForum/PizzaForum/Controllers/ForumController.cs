using PizzaForum.Models;

namespace PizzaForum.Controllers
{
    using PizzaForum.BindingModels;
    using PizzaForum.Service;
    using SimpleMVC.Attributes.Methods;
    using SimpleHttpServer.Models;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;

    public class ForumController : Controller
    {
        private ForumService service;

        public ForumController()
        {
            this.service = new ForumService();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(HttpResponse response, RegisterUserBindingModel registerUserBindingModel)
        {
            if (!this.service.IsRegisterViewModelValid(registerUserBindingModel))
            {
                this.Redirect(response, "/forum/register");
                return null;
            }
            User user = this.service.GetUserFromRegisterBind(registerUserBindingModel);
            this.service.RegisterUser(user);
            this.Redirect(response, "/forum/login");
            return null;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(HttpResponse response, HttpSession session,
            LoginUserBindingModel loginUserBindingModel)
        {
            if (!this.service.IsLoginViewModelValid(loginUserBindingModel))
            {
                this.Redirect(response, "/forum/login");
                return null;
            }
            User user = this.service.GetUserFromLoginBind(loginUserBindingModel);
            this.service.LoginUser(user, session.Id);
            this.Redirect(response, "/home/topics");
            return null;
        }
    }
}