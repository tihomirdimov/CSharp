using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using PersonalFinanceManager.Data.Models;

namespace PersonalFinanceManager.ViewModels.Books
{
    public class BookDetailsViewModel
    {
        public BookDetailsViewModel()
        {
            this.ExpensesByCategory = new Dictionary<string, decimal>();
        }
        public Book Book { get; set; }
        [Display(Name = "Average Daily Budget")]
        public decimal AverageDailyBudget { get; set; }
        public IDictionary<string, decimal> ExpensesByCategory { get; set; }
    }
}