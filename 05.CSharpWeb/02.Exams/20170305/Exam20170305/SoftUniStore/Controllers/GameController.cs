using System.Collections;
using System.Collections.Generic;

namespace SoftUniStore.Controllers
{
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces.Generic;
    using SoftUniStore.Services;
    using SoftUniStore.ViewModels;

    class GameController : Controller
    {
        private GameService service;

        public GameController()
        {
            this.service = new GameService();
        }

        [HttpGet]
        public IActionResult<GameDetailsViewModel> Details(int id, HttpResponse response, HttpSession session)
        {
            if (!this.IsAuthenticated(session.Id, response))
            {
                this.Redirect(response, "/store/login");
                return null;
            }
            GameDetailsViewModel currentGame = this.service.ViewDetailsGame(id);
            return this.View(currentGame);
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
