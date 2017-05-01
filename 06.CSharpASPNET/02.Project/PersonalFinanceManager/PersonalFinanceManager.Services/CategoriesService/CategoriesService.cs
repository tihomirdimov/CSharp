using System.Collections.Generic;
using System.Linq;
using PersonalFinanceManager.Data.Models;

namespace PersonalFinanceManager.Services.CategoriesService
{
    public class CategoriesService : DbService
    {
        public Category GetCategory(int categoryId, string userId)
        {
            return this.Context.Categories.FirstOrDefault(c => c.Id == categoryId && c.Owner.Id == userId);
        }

        public ICollection<Category> GetCategories(string userId)
        {
            return this.Context.Categories.Where(c => c.Owner.Id == userId && c.IsDeleted == false).OrderBy(c => c.Name).ToList();
        }

        public void SaveCategory()
        {
            this.Context.SaveChanges();
        }

        public void SaveCategory(Category category)
        {
            this.Context.Categories.Add(category);
            this.Context.SaveChanges();
        }

        public void DeleteCategory(int categoryId, string userId)
        {
            this.Context.Categories.FirstOrDefault(c => c.Id == categoryId && c.Owner.Id == userId).IsDeleted = true;
            this.Context.SaveChanges();
        }
    }
}
