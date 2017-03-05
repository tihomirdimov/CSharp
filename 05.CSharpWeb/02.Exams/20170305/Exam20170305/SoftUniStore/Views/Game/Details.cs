namespace SoftUniStore.Views.Game
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using SimpleMVC.Interfaces;
    using SoftUniStore.ViewModels;
    using SimpleMVC.Interfaces.Generic;
    using System.Collections.Generic;

    public class Details : IRenderable<GameDetailsViewModel>
    {
        public GameDetailsViewModel Model { get; set; }

        public string Render()
        {
            string header = File.ReadAllText(Constants.ContentPath + Constants.Header);
            string navigation = File.ReadAllText(Constants.ContentPath + Constants.NavLogged);
            string details = File.ReadAllText(Constants.ContentPath + Constants.Details);
            string detailsAll = String.Format(details, Model.ToString());
            string footer = File.ReadAllText(Constants.ContentPath + Constants.Footer);
            StringBuilder builder = new StringBuilder();
            builder.Append(header);
            builder.Append(navigation);
            builder.Append(detailsAll);
            builder.Append(footer);

            return builder.ToString();
        }
    }
}
