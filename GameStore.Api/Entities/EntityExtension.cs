namespace GameStore.Api.Entities;
public static class EntityExtension
{
    public static GameDto AsDto(this Game game)
    {
        return new GameDto(
            game.Id,
            game.Name,
            game.Genre,
            game.Price,
            game.ReleaseDate,
            game.ImageUri
        );
    }

    public static Game AsEntity(this CreateGameDto game)
    {
        return new Game()
        {
            Name = game.Name,
            Genre = game.Genre,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate,
            ImageUri = game.ImageUri
        };
    }

    public static Game AsEntity(this UpdateGameDto game)
    {
        return new Game()
        {
            Name = game.Name,
            Genre = game.Genre,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate,
            ImageUri = game.ImageUri
        };
    }


}