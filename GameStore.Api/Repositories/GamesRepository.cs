using GameStore.Api.Entities;

namespace GameStore.Api.Repositories;   

public class GamesRepository
{
    private readonly List<Game> games = new() {
        new Game()
        {
            Id = 1,
            Name = "Street Fighter II",
            Genre = "Fighting",
            Price = 19.99M,
            ReleaseDate = new DateTime(1991, 2, 1),
            ImageUri = "https://placeholder.co/100"
        },
        new Game()
        {
            Id = 2,
            Name = "Final Fantasy IV",
            Genre = "Roleplaying",
            Price = 59.99M,
            ReleaseDate = new DateTime(2010, 9, 30),
            ImageUri = "https://placeholder.co/100"
        },

        new Game()
        {
            Id = 3,
            Name = "FIFA 23",
            Genre = "Sports",
            Price = 69.99M,
            ReleaseDate = new DateTime(2022, 9, 27),
            ImageUri = "https://placeholder.co/100"
        },
    };

    public IEnumerable<Game> GetAll() => games;

    public Game? GetById(int id) => games.Find(g => g.Id == id);

    public void Create(Game game)
    {
        game.Id = games.Max(g => g.Id) + 1;
        games.Add(game);
    }

    public void Update(Game game)
    {
        Game? existingGame = games.Find(g => g.Id == game.Id);
        if (existingGame is null)
        {
            return;
        }
        game.Id = existingGame.Id;
        games[games.IndexOf(existingGame)] = game;
    }

    public void Delete(int id) {
        Game? existingGame = games.Find(g => g.Id == id);
        if (existingGame is null)
        {
            return;
        }
        games.Remove(existingGame);
    }
}