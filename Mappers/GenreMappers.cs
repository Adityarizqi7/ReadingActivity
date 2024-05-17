using api_web_first.Models;
using book_note_app.Dtos.Genre;

namespace book_note_app.Mappers
{
    public static class GenreMappers
    {
        public static GenreDto ToGenreDto(this Genre genreModel)
        {
            return new GenreDto
            {
                Id = genreModel.Id,
                Name = genreModel.Name,
                Slug = genreModel.Slug,
                Created_at = genreModel.Created_at,
                Updated_at = genreModel.Updated_at,
            };
        }

        public static Genre ToGenreFromCreateDTO(this CreateGenreRequestDto genreDto)
        {
            return new Genre
            {
                Name = genreDto.Name,
            };
        }
    }
}
