using PersonalFinanceManager.Services.ApplicationUsersService;
using PersonalFinanceManager.Services.BooksService;
using PersonalFinanceManager.Services.CategoriesService;
using PersonalFinanceManager.Services.MoneyStreamsService;

namespace PersonalFinanceManager.Interfaces
{
    public interface IServices
    {
        ApplicationUsersService ApplicationUsersService { get; set; }
        BooksService BooksService { get; set; }
        CategoriesService CategoriesService { get; set; }
        MoneyStreamsService MoneyStreamsService { get; set; }
    }
}
