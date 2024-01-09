using GameStore.Api.Data;
using GameStore.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Repositories;

public class EFGamesRepository : IGamesRepository
{

    private readonly GameStoreContext dbContext;

    public EFGamesRepository(GameStoreContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public Game Create(Game game)
    {
        dbContext.Games.Add(game);
        dbContext.SaveChanges();
        return game;
    }

    public void Delete(int id)
    {
        dbContext.Games.Where(g => g.Id == id).ExecuteDelete();
    }

    public IEnumerable<Game> GetAll()
    {
        return dbContext.Games.AsNoTracking().ToList();
    }

    public Game? GetById(int id)
    {
        return dbContext.Games.Find(id);
    }

    public void Update(Game game)
    {
        dbContext.Update(game);
        dbContext.SaveChanges();
    }
}