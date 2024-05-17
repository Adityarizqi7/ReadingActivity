using api_web_first.Data;
using api_web_first.Models;
using book_note_app.Dtos.Book;
using book_note_app.Dtos.Genre;
using book_note_app.Helpers;
using book_note_app.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using static System.Reflection.Metadata.BlobBuilder;

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

            if (!string.IsNullOrWhiteSpace(query.book))
            {
                genres = genres.Where(book => book.Books.Any(boook => boook.Slug.Equals(query.book, StringComparison.Ordinal)));
            }

            var skipData = (query.page - 1) * query.per_page;

            return await genres.Skip((query.page - 1) * query.per_page).Take(query.per_page).ToListAsync();
        }

        public async Task<Genre> GetGenreBySlugAsync(string slug)
        {
            var genre_detail = _context.Genres.Include(book => book.Books).SingleOrDefaultAsync(genre => genre.Slug == slug);

            return await genre_detail;
        }

        public async Task<Genre> CreateGenreAsync(Genre genreModel)
        {

            await _context.AddAsync(genreModel);
            await _context.SaveChangesAsync();

            return genreModel;
        }

        public async Task<Genre> UpdateGenreAsync(int id, UpdateGenreRequestDto genreDto)
        {
            var existingGenre = await _context.Genres.SingleOrDefaultAsync(b => b.Id == id);

            if (existingGenre == null)
            {
                return null;
            }
            else
            {

                existingGenre.Name = genreDto.Name;
                existingGenre.Slug = Regex.Replace(genreDto.Name, @"[^\w\s-]", "").ToLower().Replace(" ", "-");
;

                await _context.SaveChangesAsync();

                return existingGenre;
            }
        }
        public async Task<Genre> DeleteGenreAsync(int id)
        {
            var genreModel = await _context.Genres.SingleOrDefaultAsync(genre => genre.Id == id);

            if (genreModel == null)
            {
                return null;

            }

            _context.Genres.Remove(genreModel);

            await _context.SaveChangesAsync();

            return genreModel;
        }
    }
}
