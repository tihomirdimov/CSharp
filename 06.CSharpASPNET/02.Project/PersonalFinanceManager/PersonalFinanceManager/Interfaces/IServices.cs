using PersonalFinanceManager.Services.ControllerServices;

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
