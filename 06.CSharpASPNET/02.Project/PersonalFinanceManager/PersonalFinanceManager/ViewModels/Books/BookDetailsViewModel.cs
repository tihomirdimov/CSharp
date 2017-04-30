using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PersonalFinanceManager.Data.Models;

namespace PersonalFinanceManager.ViewModels.Books
{
    public class BookDetailsViewModel
    {
        public BookDetailsViewModel()
        {
            this.ExpensesByCategory = new Dictionary<Category, decimal>();
        }
        public Book Book { get; set; }
        [Display(Name = "Average Daily Budget")]
        public decimal AverageDailyBudget { get; set; }
        public IDictionary<Category,decimal> ExpensesByCategory { get; set; }
    }
}