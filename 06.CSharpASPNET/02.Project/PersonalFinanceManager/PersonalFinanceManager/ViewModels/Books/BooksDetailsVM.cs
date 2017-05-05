using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonalFinanceManager.ViewModels.Books
{
    public class BooksDetailsVM
    {
        public BooksDetailsVM()
        {
            this.ExpensesByCategory = new Dictionary<string, decimal>();
        }
        public string Name { get; set; }
        public string Currency { get; set; }
        [Display(Name = "Average Daily Budget")]
        public decimal AverageDailyBudget { get; set; }
        [Display(Name = "Expenses by Category")]
        public IDictionary<string, decimal> ExpensesByCategory { get; set; }
    }
}