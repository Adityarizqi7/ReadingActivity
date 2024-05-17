using api_web_first.Models;
using book_note_app.Dtos.Genre;
using book_note_app.Helpers;

namespace book_note_app.Interfaces
{
    public interface IGenreRepository
    {
        Task<List<Genre>> GetAllAsync(QueryObjectGenre query);
        Task<Genre> GetGenreBySlugAsync(string slug);
        Task<Genre> CreateGenreAsync(Genre genreModel);
        Task<Genre> UpdateGenreAsync(int id, UpdateGenreRequestDto genreDto);
        Task<Genre> DeleteGenreAsync(int id);
        Task<bool> BookExist(int id);
    }
}
