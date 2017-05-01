using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using PersonalFinanceManager.Data.Models;
using PersonalFinanceManager.Interfaces;
using PersonalFinanceManager.Services.ApplicationUsersService;
using PersonalFinanceManager.Services.BooksService;
using PersonalFinanceManager.Services.CategoriesService;
using PersonalFinanceManager.Services.MoneyStreamsService;
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

        public ActionResult Index(int id)
        {
            string currentUserId = User.Identity.GetUserId();
            if (BooksService.CheckIfValidBook(id, currentUserId))
            {
                MoneyStreamIndexViewModel model = new MoneyStreamIndexViewModel();
                model.MoneyStreamManageViewModel.Categories = CategoriesService.GetCategories(currentUserId);
                model.MoneyStreamManageViewModel.BookId = id;
                model.MoneyStreamsListViewModel.MoneyStreams = MoneyStreamsService.GetMoneyStreamsList(id, currentUserId);
                model.MoneyStreamsListViewModel.BookId = id;
                return View(model);
            }
            return RedirectToAction("Index", "Books");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MoneyStreamManageViewModel model)
        {
            string currentUserId = User.Identity.GetUserId();
            if (BooksService.CheckIfValidBook(model.BookId, currentUserId))
            {
                MoneyStream toAdd = Mapper.Map<MoneyStreamManageViewModel, MoneyStream>(model);
                toAdd.Name = model.MoneyStream.Name;
                toAdd.Amount = model.MoneyStream.Amount;
                toAdd.Date = model.MoneyStream.Date;
                toAdd.IsIncome = model.MoneyStream.IsIncome;
                toAdd.Book = BooksService.GetBook(model.BookId, currentUserId);
                toAdd.Category = CategoriesService.GetCategory(model.MoneyStream.Category.Id, currentUserId);
                toAdd.Owner = ApplicationUsersService.GetUser(currentUserId);
                MoneyStreamsService.SaveMoneyStream(toAdd);
            }
            MoneyStreamsListViewModel outputModel = new MoneyStreamsListViewModel();
            outputModel.MoneyStreams = MoneyStreamsService.GetMoneyStreamsList(model.BookId, currentUserId);
            outputModel.BookId = model.BookId;
            return PartialView("_MoneyStreamsListPartial", outputModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(MoneyStreamManageViewModel model)
        {
            string currentUserId = User.Identity.GetUserId();
            if (MoneyStreamsService.CheckIfValidMoneyStream(model.MoneyStream.Id, model.BookId, currentUserId))
            {
                MoneyStreamsService.DeleteMoneyStream(model.MoneyStream.Id, currentUserId);
            }
            MoneyStreamsListViewModel outputModel = new MoneyStreamsListViewModel();
            outputModel.MoneyStreams = MoneyStreamsService.GetMoneyStreamsList(model.BookId, currentUserId);
            outputModel.BookId = model.BookId;
            return PartialView("_MoneyStreamsListPartial", outputModel);
        }
    }
}
