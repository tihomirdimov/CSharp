using PersonalFinanceManager.Services.ApplicationUsersService;
using PersonalFinanceManager.Services.BooksService;
using PersonalFinanceManager.Services.CategoriesService;
using PersonalFinanceManager.Services.MoneyStreamsService;

namespace PersonalFinanceManager.Interfaces
{
    public interface IServices
    {
        string CurrentUserId { get; set; }
        ApplicationUsersService ApplicationUsersService { get; set; }
        BooksService BooksService { get; set; }
        CategoriesService CategoriesService { get; set; }
        MoneyStreamsService MoneyStreamsService { get; set; }
    }
}
