using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PFM.Models;

namespace PersonalFinanceManager.ViewModels.Categories
{
    public class CategoriesViewModel
    {
        public CategoriesViewModel()
        {
            this.category = new Category();
            this.categories = new List<Category>();
        }
        public Category category { get; set; }
        public ICollection<Category> categories { get; set; }
    }
}