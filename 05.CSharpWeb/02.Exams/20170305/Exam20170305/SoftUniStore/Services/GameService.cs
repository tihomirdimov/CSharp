using SoftUniStore.Models;

namespace SoftUniStore.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using SoftUniStore.ViewModels;

    class GameService:Service
    {
        public GameDetailsViewModel ViewDetailsGame(int id)
        {
            Game currentGame = Data.Data.Context.Games.FirstOrDefault(game => game.Id == id);
            GameDetailsViewModel current = new GameDetailsViewModel() { 
                Title = currentGame.Title,
                Trailer = currentGame.Trailer,
                Description = currentGame.Description,
                Price = currentGame.Price,
                Size = currentGame.Size,
                ReleaseDate = currentGame.ReleaseDate,
                Id = currentGame.Id
            };
            return current;
        }
    }
}
