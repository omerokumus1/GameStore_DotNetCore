using System.Reflection;
using GameStore.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data;

public class GameStoreContext: DbContext
{
    // Initial dbset for games. This represents the table in the database.
    // We can add more dbsets for other tables.
    // We can also add more properties to this class for more tables.
    // We can also add more classes like this for more databases.
    // We can query the database using these dbsets.
    public DbSet<Game> Games => Set<Game>();
    public GameStoreContext(DbContextOptions<GameStoreContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }
}