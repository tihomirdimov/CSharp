using System;
using System.Collections.Generic;
using System.Linq;
using PersonalFinanceManager.Data.Data;
using PersonalFinanceManager.Data.Models;

namespace PersonalFinanceManager.Services.CategoriesService
{
    public class CategoriesService : DbService
    {
        public Category GetCategory(int categoryId, string userId)
        {
            return this.Context.Categories.FirstOrDefault(c => c.Id == categoryId && c.Owner.Id == userId);
        }

        public ICollection<Category> GetCategories(string userId)
        {
            return this.Context.Categories
                .Where(c => c.Owner.Id == userId && c.IsDeleted == false)
                .OrderBy(c => c.Name).ToList();
        }

        public void SaveCategory()
        {
            this.Context.SaveChanges();
        }

        public void SaveCategory(Category category)
        {
            this.Context.Categories.Add(category);
            this.Context.SaveChanges();
        }

        public void DeleteCategory(int categoryId, string userId)
        {
            this.Context
                .Categories
                .FirstOrDefault(c => c.Id == categoryId && c.Owner.Id == userId)
                .IsDeleted = true;
            this.Context.SaveChanges();
        }

        public Dictionary<string, decimal> GetCurrentMonthExpensesCategories(int bookId, string userId)
        {
            var expenses = this.Context.MoneyStreams.Where(ms => ms.Book.Id == bookId &&
                                                     ms.Owner.Id == userId &&
                                                     ms.IsIncome == false &&
                                                     ms.IsDeleted == false &&
                                                     ms.Date.Month == DateTime.Today.Month).ToList();
            Dictionary<string, decimal> currentMonthExpenseCategories = new Dictionary<string, decimal>();
            foreach (var expense in expenses)
            {
                if (currentMonthExpenseCategories.ContainsKey(expense.Category.Name))
                {
                    currentMonthExpenseCategories[expense.Category.Name] += expense.Amount;
                }
                else
                {
                    currentMonthExpenseCategories.Add(expense.Category.Name, expense.Amount);
                }
            }
            var orderedByAmountSpent = currentMonthExpenseCategories
                .OrderByDescending(c => c.Value)
                .ToDictionary(c => c.Key, c => c.Value);
            return orderedByAmountSpent;
        }
    }
}
