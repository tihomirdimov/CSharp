using PizzaForum.BindingModels;namespace PizzaForum.Service
{
    using System.Collections.Generic;
    using System.Linq;
    using PizzaForum.Models;
    using PizzaForum.ViewModels;
    using SimpleHttpServer.Models;

    public class CategoriesService : Service
    {
        public AllViewModel GetAllViewModel(User activeUser)
        {
            AllViewModel view = new AllViewModel();
            LoggedInUserViewModel loggedIn = new LoggedInUserViewModel()
            {
                Username = activeUser.Username
            };
            IEnumerable<AllCategoryViewModel> categoeries =
                this.Context.Categories.Select(category => new AllCategoryViewModel()
                {
                    Id = category.Id,
                    CategoryName = category.Name
                });
            view.Categories = categoeries;

            return view;
        }

        public bool IsNewCategoryValid(NewCategoryBindingModel newCategoryBindingModel)
        {
            if (!string.IsNullOrEmpty(newCategoryBindingModel.Name))
            {
                return false;
            }
            return true;
        }

        public void AddNewCategory(NewCategoryBindingModel newCategoryBindingModel)
        {
            this.Context.Categories.Add(new Category()
            {
                Name = newCategoryBindingModel.Name
            });
            this.Context.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            this.Context.Categories.Remove(this.Context.Categories.Find(id));
            this.Context.SaveChanges();
        }

        public EditCategoryViewModel GetEditCategoryViewModel(int categoryId)
        {
            Category category = Context.Categories.Find(categoryId);
            return new EditCategoryViewModel()
            {
                CategoryName = category.Name,
                Id = categoryId
            };
        }

        public void EditCategory(EditCategoryBindingModel editCategoryBindingModel)
        {
            Category category = Context.Categories.Find(editCategoryBindingModel.CategoryId);
            if (category != null)
            {
                category.Name = editCategoryBindingModel.CategoryName;
            }
            Context.SaveChanges();
        }
    }
}
