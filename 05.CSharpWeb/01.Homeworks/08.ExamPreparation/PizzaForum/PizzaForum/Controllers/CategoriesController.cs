using PizzaForum.BindingModels;

namespace PizzaForum.Controllers
{
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;
    using SimpleHttpServer.Models;
    using PizzaForum.Models;
    using PizzaForum.Service;
    using PizzaForum.ViewModels;
    using SimpleMVC.Interfaces.Generic;
    using SimpleMVC.Attributes.Methods;

    public class CategoriesController : Controller
    {
        private CategoriesService service;

        public CategoriesController()
        {
            this.service = new CategoriesService();
        }

        [HttpGet]
        public IActionResult<AllViewModel> All(HttpSession session, HttpResponse response)
        {
            User activeUser = GetAuthenticatedUser(response, session);
            if (activeUser==null)
            {
                return null;
            }
            AllViewModel viewModel = this.service.GetAllViewModel(activeUser);
            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult New(HttpResponse response, HttpSession session)
        {
            User activeUser = GetAuthenticatedUser(response, session);
            return this.View();
        }

        [HttpPost]
        public void New(HttpResponse response, HttpSession session, NewCategoryBindingModel newCategoryBindingModel)
        {
            User activeUser = GetAuthenticatedUser(response, session);
            if (this.service.IsNewCategoryValid(newCategoryBindingModel))
            {
                this.Redirect(response, "/categories/new");
            }
            this.service.AddNewCategory(newCategoryBindingModel);
            this.Redirect(response, "/categories/all");
        }

        [HttpPost]
        public void Delete(HttpResponse response, HttpSession session, int id)
        {
            GetAuthenticatedUser(response, session);
            this.service.DeleteCategory(id);
            this.Redirect(response, "/categories/all");
        }

        [HttpGet]
        public IActionResult<EditCategoryViewModel> Edit(HttpResponse response, HttpSession session, int id)
        {
            User user = GetAuthenticatedUser(response, session);
            if (user == null)
            {
                return null;
            }
            EditCategoryViewModel viewModel = service.GetEditCategoryViewModel(id);
            return this.View(viewModel);
        }

        [HttpPost]
        public void Edit(HttpResponse response, HttpSession session, EditCategoryBindingModel editCategoryBindingModel)
        {
            User user = GetAuthenticatedUser(response, session);
            if (user == null)
            {
                return;
            }
            service.EditCategory(editCategoryBindingModel);
            this.Redirect(response, "/categories/all");
        }

        private User GetAuthenticatedUser(HttpResponse response, HttpSession session)
        {
            if (!Utilities.AuthenticationManager.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "/forum/login");
                return null;
            }
            User activeUser = Utilities.AuthenticationManager.GetAuthenticatedUser(session.Id);
            if (!activeUser.IsAdmin)
            {
                this.Redirect(response, "/forum/topics");
            }
            return activeUser;
        }
    }
}
