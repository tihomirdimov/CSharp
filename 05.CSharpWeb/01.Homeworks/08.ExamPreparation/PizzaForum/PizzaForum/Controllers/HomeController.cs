
using PizzaForum.Models;
using PizzaForum.Utilities;
using SimpleHttpServer.Models;

namespace PizzaForum.Controllers
{
    using PizzaForum.Service;
    using PizzaForum.ViewModels;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;
    using System.Collections.Generic;

    public class HomeController:Controller
    {
        private HomeService service;

        public HomeController()
        {
            service = new HomeService();
        }

        [HttpGet]
        public IActionResult<IEnumerable<TopicViewModel>> Topics(HttpSession session)
        {
            ViewBag.Bag["username"] = AuthenticationManager.GetAuthenticatedUser(session.Id);
            IEnumerable<TopicViewModel> topics = service.GetTopTenLatestTopics();
            return this.View(topics);
        }
    }
}
