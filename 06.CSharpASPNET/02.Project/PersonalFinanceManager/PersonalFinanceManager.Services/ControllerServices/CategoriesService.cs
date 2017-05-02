using System;
using System.Collections.Generic;
using System.Linq;
using PersonalFinanceManager.Data.Data;
using PersonalFinanceManager.Data.Models;

namespace PersonalFinanceManager.Services.ControllerServices
{
    public class CategoriesService
    {
        public Category GetCategory(PfmDbContext context, int categoryId, string userId)
        {
            return context.Categories.FirstOrDefault(c => c.Id == categoryId && c.Owner.Id == userId);
        }

        public ICollection<Category> GetCategories(PfmDbContext context, string userId)
        {
            return context.Categories
                .Where(c => c.Owner.Id == userId && c.IsDeleted == false)
                .OrderBy(c => c.Name).ToList();
        }

        public void SaveCategory(PfmDbContext context)
        {
            context.SaveChanges();
        }

        public void SaveCategory(PfmDbContext context, Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
        }

        public void DeleteCategory(PfmDbContext context, int categoryId, string userId)
        {
            context
                 .Categories
                 .FirstOrDefault(c => c.Id == categoryId && c.Owner.Id == userId)
                 .IsDeleted = true;
            context.SaveChanges();
        }

        public Dictionary<string, decimal> GetCurrentMonthExpensesCategories(PfmDbContext context, int bookId, string userId)
        {
            var expenses = context.MoneyStreams.Where(ms => ms.Book.Id == bookId &&
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
