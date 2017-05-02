using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PersonalFinanceManager.Data.Data;
using PersonalFinanceManager.Data.Models;
using PersonalFinanceManager.Interfaces;
using PersonalFinanceManager.Services.ControllerServices;
using PersonalFinanceManager.ViewModels.MoneyStreams;

namespace PersonalFinanceManager.Controllers
{
    [Authorize]
    public class MoneyStreamsController : Controller, IServices
    {
        public MoneyStreamsController()
        {
            this.ApplicationUsersService = new ApplicationUsersService();
            this.BooksService = new BooksService();
            this.CategoriesService = new CategoriesService();
            this.MoneyStreamsService = new MoneyStreamsService();
        }

        public ApplicationUsersService ApplicationUsersService { get; set; }
        public BooksService BooksService { get; set; }
        public CategoriesService CategoriesService { get; set; }
        public MoneyStreamsService MoneyStreamsService { get; set; }

        [HandleError(View = "Home/Index")]
        public ActionResult Index(int id)
        {
            string currentUserId = User.Identity.GetUserId();
            PfmDbContext context = new PfmDbContext();
            if (BooksService.CheckIfValidBook(context, id, currentUserId))
            {
                MoneyStreamsIndexVM model = new MoneyStreamsIndexVM();
                model.MoneyStreamsFormVM.Categories = CategoriesService.GetCategories(context, currentUserId);
                model.MoneyStreamsFormVM.BookId = id;
                model.MoneyStreamsListVM.MoneyStreams = MoneyStreamsService.GetMoneyStreamsList(context, id, currentUserId);
                model.MoneyStreamsListVM.BookId = id;
                return View(model);
            }
            return RedirectToAction("Index", "Books");
        }

        [HandleError(View = "_ErrorPartial")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MoneyStreamsFormVM model)
        {
            string currentUserId = User.Identity.GetUserId();
            PfmDbContext context = new PfmDbContext();
            if (BooksService.CheckIfValidBook(context, model.BookId, currentUserId))
            {
                MoneyStream toAdd = new MoneyStream();
                toAdd.Name = model.Name;
                toAdd.Amount = model.Amount;
                toAdd.Date = model.Date;
                toAdd.IsIncome = model.IsIncome;
                toAdd.Book = BooksService.GetBook(context, model.BookId, currentUserId);
                toAdd.Category = CategoriesService.GetCategory(context, model.CategoryId, currentUserId);
                toAdd.Owner = ApplicationUsersService.GetUser(context, currentUserId);
                MoneyStreamsService.SaveMoneyStream(context, toAdd);
            }
            MoneyStreamsListVM outputModel = new MoneyStreamsListVM();
            outputModel.MoneyStreams = MoneyStreamsService.GetMoneyStreamsList(context, model.BookId, currentUserId);
            outputModel.BookId = model.BookId;
            return PartialView("_MoneyStreamsListPartial", outputModel);
        }

        [HandleError(View = "_ErrorPartial")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, int bookId)
        {
            string currentUserId = User.Identity.GetUserId();
            PfmDbContext context = new PfmDbContext();
            if (MoneyStreamsService.CheckIfValidMoneyStream(context, id, bookId, currentUserId))
            {
                MoneyStreamsService.DeleteMoneyStream(context, id, currentUserId);
            }
            MoneyStreamsListVM outputModel = new MoneyStreamsListVM();
            outputModel.MoneyStreams = MoneyStreamsService.GetMoneyStreamsList(context, bookId, currentUserId);
            outputModel.BookId = bookId;
            return PartialView("_MoneyStreamsListPartial", outputModel);
        }
    }
}
