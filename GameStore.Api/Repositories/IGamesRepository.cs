using GameStore.Api.Entities;

namespace GameStore.Api.Repositories;

public interface IGamesRepository
{
    IEnumerable<Game> GetAll();
    Game? GetById(int id);
    Game Create(Game game);
    void Update(Game game);
    void Delete(int id);
}
