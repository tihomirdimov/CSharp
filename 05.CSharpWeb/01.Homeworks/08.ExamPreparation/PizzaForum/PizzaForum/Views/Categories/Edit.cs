

namespace PizzaForum.Views.Categories
{
    using System.IO;
    using System.Text;
    using PizzaForum.ViewModels;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;

    class Edit : IRenderable<EditCategoryViewModel>
    {
        public EditCategoryViewModel Model { get; set; }

        public string Render()
        {
            string header = File.ReadAllText(Constants.ContentPath + Constants.Header);
            string navigation = File.ReadAllText(Constants.ContentPath + Constants.NavNotLogged);
            navigation = string.Format(navigation, ViewBag.Bag["username"]);
            string editCategory = File.ReadAllText(Constants.ContentPath + Constants.AdminCategoryEdit);
            editCategory = string.Format(editCategory, Model);
            string footer = File.ReadAllText(Constants.ContentPath + Constants.Footer);

            StringBuilder builder = new StringBuilder();
            builder.Append(header);
            builder.Append(navigation);
            builder.Append(editCategory);
            builder.Append(footer);

            return builder.ToString();
        }
    }
}
