using api_web_first.Data;
using api_web_first.Models;
using book_note_app.Helpers;
using book_note_app.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace book_note_app.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDBContext _context;

        public GenreRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public Task<bool> BookExist(int id)
        {
            return _context.Genres.AnyAsync(genre => genre.Id == id);
        }

        public async Task<List<Genre>> GetAllAsync(QueryObjectGenre query)
        {
            var genres = _context.Genres
                                .Include(book => book.Books)
                                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.sort_type))
            {
                if (query.sort_type.Equals("DESC", StringComparison.Ordinal))
                {
                    genres = genres.OrderByDescending(genre => genre.Id);
                }
                if (query.sort_type.Equals("ASC", StringComparison.Ordinal))
                {
                    genres = genres.OrderBy(genre => genre.Id);
                }
            }

            if (!string.IsNullOrWhiteSpace(query.search))
            {
                genres = genres.Where(genre => genre.Name.Contains(query.search));
            }

            var skipData = (query.page - 1) * query.per_page;

            return await genres.Skip((query.page - 1) * query.per_page).Take(query.per_page).ToListAsync();
        }
    }
}
