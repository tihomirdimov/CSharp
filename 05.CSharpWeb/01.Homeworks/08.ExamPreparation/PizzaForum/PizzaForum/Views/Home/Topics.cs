namespace PizzaForum.Views.Home
{
    using System.IO;
    using System.Text;
    using SimpleMVC.Interfaces;
    using System.Collections.Generic;
    using PizzaForum.Models;
    using PizzaForum.ViewModels;
    using PizzaForum.Views.Categories;
    using SimpleMVC.Interfaces.Generic;

    public class Topics : IRenderable<IEnumerable<TopicViewModel>>
    {
        public IEnumerable<TopicViewModel> Model { get; set; }

        public string Render()
        {
            string header = File.ReadAllText(Constants.ContentPath + Constants.Header);
            string navigation;
            User currentUser = ViewBag.GetUserName();
            if (currentUser != null)
            {
                navigation = File.ReadAllText(Constants.ContentPath + Constants.NavLogged);
            }
            else
            {
                navigation = File.ReadAllText(Constants.ContentPath + Constants.NavNotLogged);
            }
            StringBuilder topicsCollection = new StringBuilder();
            foreach (var topicViewModel in Model)
            {
                topicsCollection.Append(topicViewModel);
            }

            string footer = File.ReadAllText(Constants.ContentPath + Constants.Footer);
            StringBuilder builder = new StringBuilder();
            builder.Append(header);
            builder.Append(navigation);
            builder.Append(topicsCollection);
            builder.Append(footer);

            return builder.ToString();
        }


    }
}
