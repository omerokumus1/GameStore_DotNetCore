
using GameStore.Api.Endpoints;
using GameStore.Api.Entities;
using GameStore.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services
        .AddSingleton<IGamesRepository, GamesRepository>();

var connString = builder.Configuration.GetConnectionString("GameStoreContext");

var app = builder.Build();

app.MapGamesEndpoints();

app.Run();
 