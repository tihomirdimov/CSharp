using System.Collections.Generic;
using PersonalFinanceManager.Data.Models;

namespace PersonalFinanceManager.ViewModels.MoneyStreams
{
    public class MoneyStreamManageViewModel
    {
        public MoneyStreamManageViewModel()
        {
            this.MoneyStream = new MoneyStream();
            this.Book = new Book();
            this.Categories = new List<Category>();
        }
        public MoneyStream MoneyStream { get; set; }
        public Book Book { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}