using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PersonalFinanceManager.Data.Data;
using PersonalFinanceManager.Data.Models;
using PersonalFinanceManager.Services.Interfaces;

namespace PersonalFinanceManager.Services.ControllerServices
{
    public class CategoriesService : ICategoriesService
    {
        private readonly PfmDbContext _context;

        public CategoriesService()
        {
            _context = new PfmDbContext();
        }

        public Category GetCategory(int categoryId, string userId)
        {
            return _context.Categories.FirstOrDefault(c => c.Id == categoryId && c.OwnerId == userId);
        }

        public ICollection<Category> GetCategories(string userId)
        {
            return _context.Categories
                .Where(c => c.OwnerId == userId && c.IsDeleted == false)
                .OrderBy(c => c.Name).ToList();
        }

        public void SaveCategory()
        {
            _context.SaveChanges();
        }

        public void SaveCategory(Category category)
        {
            try
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);         
            }
            
        }

        public void DeleteCategory(int categoryId, string userId)
        {
            _context
                 .Categories
                 .FirstOrDefault(c => c.Id == categoryId && c.OwnerId == userId)
                 .IsDeleted = true;
            _context.SaveChanges();
        }

        public Dictionary<string, decimal> GetCurrentMonthExpensesCategories(int bookId, string userId)
        {
            var expenses = _context.MoneyStreams.Where(ms => ms.Book.Id == bookId &&
                                                     ms.OwnerId == userId &&
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
