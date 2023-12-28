
using System.Text.RegularExpressions;
using GameStore.Api.Entities;

List<Game> games = new()
{
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


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var group = app.MapGroup("/games")
    .WithParameterValidation();

group.MapGet("/", () => games);

group.MapGet("/{id}", (int id) =>
{
    Game? game = games.FirstOrDefault(g => g.Id == id);
    if (game is not null)
    {
        return Results.Ok(game);
    }
    return Results.NotFound();
}).WithName("GetGameById");

group.MapPost("/", (Game game) =>
{
    game.Id = games.Max(g => g.Id) + 1;
    games.Add(game);
    return Results.CreatedAtRoute(
        "GetGameById",
        new { id = game.Id },
        game);
});

group.MapPut("/{id}", (int id, Game game) =>
{
    Game? existingGame = games.FirstOrDefault(g => g.Id == id);
    if (existingGame is null)
    {
        return Results.NotFound();
    }
    game.Id = existingGame.Id;
    games[games.IndexOf(existingGame)] = game;

    // return Results.Ok(game);
    return Results.NoContent(); // 204 No Content
});

group.MapDelete("/{id}", (int id) =>
{
    Game? existingGame = games.FirstOrDefault(g => g.Id == id);
    if (existingGame is null)
    {
        return Results.NotFound();
    }
    games.Remove(existingGame);
    return Results.NoContent();
});

app.Run();
