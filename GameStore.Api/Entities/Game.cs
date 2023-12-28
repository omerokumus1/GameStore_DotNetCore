using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Entities;

public class Game
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public required string Name { get; set; }

    [Required]
    [StringLength(20)]
    public required string Genre { get; set; }

    [Range(0.01, 999.99)]
    public decimal Price { get; set; }
    public DateTime ReleaseDate { get; set; }

    [Url]
    public required string ImageUri { get; set; }

}
