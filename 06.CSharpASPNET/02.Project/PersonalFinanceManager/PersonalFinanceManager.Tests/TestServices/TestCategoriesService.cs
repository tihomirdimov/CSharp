using System.Collections.Generic;
using PersonalFinanceManager.Data.Models;
using PersonalFinanceManager.Services.Interfaces;

namespace PersonalFinanceManager.Tests.TestServices
{
    class TestCategoriesService : ICategoriesService
    {
        void ICategoriesService.DeleteCategory(int categoryId, string userId)
        {          
        }

        ICollection<Category> ICategoriesService.GetCategories(string userId)
        {
            return new List<Category>()
            {
                new Category() { Id = 1, Name = "Food", IsDeleted = false, OwnerId = "owner1"},
                new Category() { Id = 2, Name = "Booze", IsDeleted = false, OwnerId = "owner1"},
                new Category() { Id = 2, Name = "Sports", IsDeleted = false, OwnerId = "owner1"}
            };
        }

        Category ICategoriesService.GetCategory(int categoryId, string userId)
        {
            return new Category() {Id = 2, Name = "Sports", IsDeleted = false, OwnerId = "owner4"};
        }

        Dictionary<string, decimal> ICategoriesService.GetCurrentMonthExpensesCategories(int bookId, string userId)
        {
            return new Dictionary<string, decimal>()
            {
                {"Booze", 120 },
                {"Booze", 140 },
                {"Booze", 111 }
            };
        }

        void ICategoriesService.SaveCategory()
        {
        }

        void ICategoriesService.SaveCategory(Category category)
        {
        }
    }
}
