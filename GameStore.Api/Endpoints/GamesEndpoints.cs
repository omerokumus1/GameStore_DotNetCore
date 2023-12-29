using GameStore.Api.Entities;
using GameStore.Api.Repositories;

namespace GameStore.Api.Endpoints;

public static class GamesEndpoints
{


    public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/games")
            .WithParameterValidation();

        group.MapGet("/", (IGamesRepository repository) =>
            repository.GetAll().Select(game => game.AsDto()));

        group.MapGet("/{id}", (IGamesRepository repository, int id) =>
        {
            Game? game = repository.GetById(id);
            return game is not null
                ? Results.Ok(game.AsDto())
                : Results.NotFound();

        }).WithName("GetGameById");

        group.MapPost("/", (IGamesRepository repository, CreateGameDto game) =>
        {
            var gameCreated = repository.Create(game.AsEntity());
            return Results.CreatedAtRoute(
                "GetGameById",
                new { id = gameCreated.Id },
                gameCreated.AsDto());
        });

        group.MapPut("/{id}", (IGamesRepository repository, int id, UpdateGameDto updateGameDto) =>
        {
            Game? existingGame = repository.GetById(id);
            if (existingGame is null)
            {
                return Results.NotFound();
            }
            repository.Update(updateGameDto.AsEntity());

            // return Results.Ok(game);
            return Results.NoContent(); // 204 No Content
        });

        group.MapDelete("/{id}", (IGamesRepository repository, int id) =>
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