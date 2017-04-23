using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonalFinanceManager.Data.Models;

namespace PersonalFinanceManager.ViewModels.Categories
{
    public class CategoriesViewModel
    {
        public CategoriesViewModel()
        {
            this.Category = new Category();
            this.Categories = new List<Category>();
        }
        public Category Category { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}