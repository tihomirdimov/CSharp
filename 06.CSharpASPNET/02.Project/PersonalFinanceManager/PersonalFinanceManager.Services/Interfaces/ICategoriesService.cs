using System.Collections.Generic;
using PersonalFinanceManager.Data.Models;

namespace PersonalFinanceManager.Services.Interfaces
{
    public interface ICategoriesService
    {
        Category GetCategory(int categoryId, string userId);

        ICollection<Category> GetCategories(string userId);

        void SaveCategory();

        void SaveCategory(Category category);

        void DeleteCategory(int categoryId, string userId);

        Dictionary<string, decimal> GetCurrentMonthExpensesCategories(int bookId, string userId);
    }
}
