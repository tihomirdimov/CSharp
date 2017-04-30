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
    public class CategoriesService
    {
        public CategoriesService(PfmDbContext context)
        {
            this.Context = context;
        }

        private PfmDbContext Context { get; set; }

        public Category GetCategory(int id)
        {
            return Context.Categories.FirstOrDefault(c => c.Id == id);
        }

        public ICollection<Category> GetCategories(string user)
        {
            return Context.Categories.Where(c => c.Owner.Id == user && c.isDeleted == false).OrderBy(c => c.Name).ToList();
        }
    }
}
