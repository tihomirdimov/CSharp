namespace PizzaForum.Views.Categories
{
    using System;
    using System.IO;
    using System.Text;
    using PizzaForum.ViewModels;
    using SimpleMVC.Interfaces.Generic;

    class All : IRenderable<AllViewModel>
    {
        public AllViewModel Model { get; set; }

        public string Render()
        {
            string header = File.ReadAllText(Constants.ContentPath + Constants.Header);
            string navigation = File.ReadAllText(Constants.ContentPath + Constants.NavNotLogged);
            navigation = string.Format(navigation, ViewBag.Bag["username"]);
            string adminCategories = File.ReadAllText(Constants.ContentPath + Constants.AdminCategories);
            adminCategories = String.Format(adminCategories,Model.ToString());
            string footer = File.ReadAllText(Constants.ContentPath + Constants.Footer);
            StringBuilder builder = new StringBuilder();
            builder.Append(header);
            builder.Append(navigation);
            builder.Append(adminCategories);
            builder.Append(footer);

            return builder.ToString();
        }
    }
}
