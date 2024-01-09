
using GameStore.Api.Data;
using GameStore.Api.Endpoints;
using GameStore.Api.Entities;
using GameStore.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services
        .AddSingleton<IGamesRepository, GamesRepository>();

var connString = builder.Configuration.GetConnectionString("GameStoreContext");
builder.Services.AddSqlServer<GameStoreContext>(connString);

var app = builder.Build();

app.MapGamesEndpoints();

app.Run();
