using System.ComponentModel.DataAnnotations;

namespace GameStore.Api;

// DTO to sent
public record GameDto(
    int Id,
    string Name,
    string Genre,
    decimal Price,
    DateTime ReleaseDate,
    string ImageUri
);

// DTO to receive to create a game
public record CreateGameDto(
    [Required][StringLength(50)] string Name,
    [Required][StringLength(20)] string Genre,
    [Range(0.01, 999.99)] decimal Price,
    DateTime ReleaseDate,
    [Url] string ImageUri
);

// DTO to receive to update a game
public record UpdateGameDto(
    [Required][StringLength(50)] string Name,
    [Required][StringLength(20)] string Genre,
    [Range(0.01, 999.99)] decimal Price,
    DateTime ReleaseDate,
    [Url] string ImageUri
);