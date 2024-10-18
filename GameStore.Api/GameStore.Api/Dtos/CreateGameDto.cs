using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Dtos;

public record class CreateGameDto
( [Required] [StringLength(50)] string Name,
//[Required] [StringLength(20)] string Genre, => because it's string, should change Genres
int GenreId,
[Range(1,100)] decimal Price,
DateOnly ReleaseDate
);
