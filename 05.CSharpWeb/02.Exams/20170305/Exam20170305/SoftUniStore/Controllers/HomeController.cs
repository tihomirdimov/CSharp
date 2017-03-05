using System.Collections.Generic;
using SimpleMVC.Interfaces.Generic;
using SoftUniStore.ViewModels;

namespace SoftUniStore.Controllers
{
    using SimpleMVC.Attributes.Methods;
    using SimpleHttpServer.Models;
    using SimpleMVC.Controllers;
    using SoftUniStore.Services;
    using SimpleMVC.Interfaces;

    public class HomeController : Controller
    {
        private HomeService service;

        public HomeController()
        {
            this.service = new HomeService();
        }

        [HttpGet]
        public IActionResult<IEnumerable<GameViewModel>> Games(HttpSession session, HttpResponse response)
        {
            if (!this.IsAuthenticated(session.Id, response))
            {
                this.Redirect(response, "/store/login");
                return null;            
            }
            IEnumerable<GameViewModel> games = this.service.GetGames();
            return this.View(games);
        }

        [HttpGet]
        public IActionResult<IEnumerable<GameViewModel>> Own(HttpSession session, HttpResponse response)
        {
            if (!this.IsAuthenticated(session.Id, response))
            {
                this.Redirect(response, "/store/login");
                return null;
            }
            IEnumerable<GameViewModel> games = this.service.GetOwnGames(session.Id);
            return this.View(games);
        }

        private bool IsAuthenticated(string sessionId, HttpResponse response)
        {
            if (Utilities.UserAuthenticationManager.IsAuthenticated(sessionId))
            {
                return true;
            }
            return false;
        }
    }

}
