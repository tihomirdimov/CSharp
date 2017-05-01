using System.Collections.Generic;
using PersonalFinanceManager.Data.Models;

namespace PersonalFinanceManager.ViewModels.Categories
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {
            this.Category = new Category();
            this.Categories = new List<Category>();
        }

        public Category Category { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}