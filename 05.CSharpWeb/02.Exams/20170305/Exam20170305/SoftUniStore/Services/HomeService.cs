using SoftUniStore.Models;

namespace SoftUniStore.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using SoftUniStore.ViewModels;

    public class HomeService
    {
        public IEnumerable<GameViewModel> GetGames()
        {
            IEnumerable<GameViewModel> games = Data.Data.Context.Games.Select(game => new GameViewModel()
            {
                Image = game.Image,
                Title = game.Title,
                Price = game.Price,
                Size = game.Size,
                Description = game.Description.Substring(0, 299),
                Id = game.Id
            });
            return games;
        }

        public IEnumerable<GameViewModel> GetOwnGames(string sessionId)
        {
            User currentUser = Data.Data.Context.Logins.FirstOrDefault(login => login.SessionId == sessionId && login.IsActive).User;
            IEnumerable<GameViewModel> games =
                Data.Data.Context.Users.FirstOrDefault(user => user.Id == currentUser.Id)
                .GamesList.Select(game => new GameViewModel(){
                    Image = game.Image,
                    Title = game.Title,
                    Price = game.Price,
                    Size = game.Size,
                    Description = game.Description.Substring(0, 299),
                    Id = game.Id
                });
            return games;
        }

    }
}