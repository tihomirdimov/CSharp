using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using PersonalFinanceManager.Data.Data;
using PersonalFinanceManager.Data.Models;

namespace PersonalFinanceManager.Services.CategoriesService
{
    public class CategoriesService : DbService
    {
        public Category GetCategory(int categoryId, string userId)
        {
            return Context.Categories.FirstOrDefault(c => c.Id == categoryId && c.Owner.Id == userId);
        }

        public ICollection<Category> GetCategories(string userId)
        {
            return Context.Categories.Where(c => c.Owner.Id == userId && c.isDeleted == false).OrderBy(c => c.Name).ToList();
        }

        public void SaveCategory()
        {
            Context.SaveChanges();
        }

        public void SaveCategory(Category category)
        {
            Context.Categories.Add(category);
            Context.SaveChanges();
        }

        public void DeleteCategory(int categoryId, string userId)
        {
            Context.Categories.FirstOrDefault(c => c.Id == categoryId && c.Owner.Id == userId).isDeleted = true;
            Context.SaveChanges();
        }
    }
}
