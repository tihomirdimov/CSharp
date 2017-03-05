namespace SoftUniStore.Controllers
{
    using SimpleHttpServer.Models;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;
    using SoftUniStore.Services;
    using SimpleMVC.Attributes.Methods;
    using SoftUniStore.BindingModels;
    using SoftUniStore.Models;

    public class StoreController : Controller
    {
        private StoreService service;

        public StoreController()
        {
            this.service = new StoreService();
        }

        [HttpGet]
        public IActionResult Register(HttpSession session, HttpResponse response)
        {
            if (this.IsAuthenticated(session.Id, response))
            {
                return null;
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Register(HttpResponse response, RegisterUserBindingModel registerUserBindingModel)
        {
            if (!this.service.IsRegisterViewModelValid(registerUserBindingModel))
            {
                this.Redirect(response, "/store/register");
                return null;
            }
            User user = this.service.GetUserFromRegisterBind(registerUserBindingModel);
            this.service.RegisterUser(user);
            this.Redirect(response, "/store/login");
            return null;
        }

        [HttpGet]
        public IActionResult Login(HttpSession session, HttpResponse response)
        {
            if (this.IsAuthenticated(session.Id, response))
            {
                return null;
            }
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(HttpResponse response, HttpSession session,
            LoginUserBindingModel loginUserBindingModel)
        {
            if (!this.service.IsLoginViewModelValid(loginUserBindingModel))
            {
                this.Redirect(response, "/store/login");
                return null;
            }
            User user = this.service.GetUserFromLoginBind(loginUserBindingModel);
            this.service.LoginUser(user, session.Id);
            this.Redirect(response, "/home/games");
            return null;
        }

        [HttpGet]
        public void Logout(HttpResponse response, HttpSession session)
        {
            Utilities.UserAuthenticationManager.Logout(response, session.Id);
            this.Redirect(response, "/store/login");
        }

        private bool IsAuthenticated(string sessionId, HttpResponse response)
        {
            if (Utilities.UserAuthenticationManager.IsAuthenticated(sessionId))
            {
                this.Redirect(response, "/store/login");
                return true;
            }
            return false;
        }
    }
}
