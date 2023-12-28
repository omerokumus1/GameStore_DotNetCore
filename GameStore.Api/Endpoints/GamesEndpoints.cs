using GameStore.Api.Entities;
using GameStore.Api.Repositories;

namespace GameStore.Api.Endpoints;

public static class GamesEndpoints
{
    static readonly GamesRepository repository = new();


    public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/games")
            .WithParameterValidation();

        group.MapGet("/", () => repository.GetAll());

        group.MapGet("/{id}", (int id) =>
        {
            Game? game = repository.GetById(id);
            return game is not null
                ? Results.Ok(game)
                : Results.NotFound();

        }).WithName("GetGameById");

        group.MapPost("/", (Game game) =>
        {
            repository.Create(game);
            return Results.CreatedAtRoute(
                "GetGameById",
                new { id = game.Id },
                game);
        });

        group.MapPut("/{id}", (int id, Game game) =>
        {
            Game? existingGame = repository.GetById(id);
            if (existingGame is null)
            {
                return Results.NotFound();
            }
            repository.Update(game);

            // return Results.Ok(game);
            return Results.NoContent(); // 204 No Content
        });

        group.MapDelete("/{id}", (int id) =>
        {
            Game? existingGame = repository.GetById(id);
            if (existingGame is null)
            {
                return Results.NotFound();
            }
            repository.Delete(id);
            return Results.NoContent();
        });

        return group;
    }

}