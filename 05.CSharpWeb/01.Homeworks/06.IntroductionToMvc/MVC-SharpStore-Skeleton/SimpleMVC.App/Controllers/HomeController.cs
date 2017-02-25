using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SharpStore.Services;
using SharpStore.ViewModels;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;

namespace SharpStore.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contacts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult<IEnumerable<ProductViewModel>> Products()
        {
            KnivesService service = new KnivesService(Data.Data.Context);
            IEnumerable<ProductViewModel> viewModels = service.GetProducts();
            return this.View(viewModels);
        }
    }
}
