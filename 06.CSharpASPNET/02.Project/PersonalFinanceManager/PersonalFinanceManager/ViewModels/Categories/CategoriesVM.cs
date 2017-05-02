using System.Collections.Generic;
using PersonalFinanceManager.Data.Models;

namespace PersonalFinanceManager.ViewModels.Categories
{
    public class CategoriesVM
    {
        public CategoriesVM()
        {
            this.CategoryFormVM = new CategoriesFormVM();
            this.Categories = new List<Category>();
        }

        public CategoriesFormVM CategoryFormVM { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}