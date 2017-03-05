namespace SoftUniStore.Views.Home
{
    using System.IO;
    using System.Text;
    using SoftUniStore.ViewModels;
    using SimpleMVC.Interfaces.Generic;
    using System.Collections.Generic;
    using System;

    public class Own : IRenderable<IEnumerable<GameViewModel>>
    {
        public IEnumerable<GameViewModel> Model { get; set; }

        public string Render()
        {
            string header = File.ReadAllText(Constants.ContentPath + Constants.Header);
            string navigation = File.ReadAllText(Constants.ContentPath + Constants.NavLogged);
            string home = File.ReadAllText(Constants.ContentPath + Constants.Home);
            StringBuilder games = new StringBuilder();
            if (Model != null)
            {               
                foreach (var game in Model)
                {
                    games.Append(game);
                }
            }
            games.Append("Seems you have a life...We suggest leaving your GF, buy some games and a nice Core i7 PC");
            string homeAll = String.Format(home, games.ToString());
            string footer = File.ReadAllText(Constants.ContentPath + Constants.Footer);

            StringBuilder builder = new StringBuilder();
            builder.Append(header);
            builder.Append(navigation);
            builder.Append(homeAll);
            builder.Append(footer);

            return builder.ToString();
        }
    }
}
