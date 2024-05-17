using api_web_first.Data;
using api_web_first.Models;
using book_note_app.Dtos.Book;
using book_note_app.Helpers;
using book_note_app.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace book_note_app.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDBContext _context;

        public BookRepository(ApplicationDBContext context) 
        {
            _context = context;
        }

        public async Task<List<Book>> GetAllAsync(QueryObjectBook query)
        {
            var books = _context.Books
                .Include(genre => genre.Genres)
                .Include(activities => activities.Activities)
                .AsQueryable();

            if(!string.IsNullOrWhiteSpace(query.sort_type))
            {
                if(query.sort_type.Equals("DESC", StringComparison.Ordinal))
                {
                    books = books.OrderByDescending(book => book.Id);
                }
                if(query.sort_type.Equals("ASC", StringComparison.Ordinal))
                {
                    books = books.OrderBy(book => book.Id);
                }
            }

            if (!string.IsNullOrWhiteSpace(query.search))
            {
                books = books.Where(activity => activity.Title.Contains(query.search) || activity.Author.Contains(query.search));
            }

            if (!string.IsNullOrWhiteSpace(query.genre))
            {
                books = books.Where(book => book.Genres.Any(genre => genre.Slug.Equals(query.genre, StringComparison.Ordinal)));
            }

            var skipData = (query.page - 1) * query.per_page;

            return await books.Skip((query.page - 1) * query.per_page).Take(query.per_page).ToListAsync();
        }

        public async Task<Book> GetBookBySlugAsync(string slug)
        {
            var book_detail = _context.Books.Include(genre => genre.Genres).Include(activity => activity.Activities).SingleOrDefaultAsync(book => book.Slug == slug);

            return await book_detail;
        }

        public Task<bool> BookExist(int id)
        {
            return _context.Books.AnyAsync(book => book.Id == id);
        }

        public async Task<Book> CreateBookAsync(Book bookModel)
        {
               
            await _context.AddAsync(bookModel);
            await _context.SaveChangesAsync();

            return bookModel;
        }

        public async Task<Book> UpdateBookAsync(int id, UpdateBookRequestDto bookDto)
        {
            var existingBook = await _context.Books.Include(b => b.Genres).SingleOrDefaultAsync(b => b.Id == id);

            if (existingBook == null)
            {
                return null;
            } 
            else
            {

                existingBook.Title = bookDto.Title.ToUpper();
                existingBook.Slug = Regex.Replace(bookDto.Title, @"[^\w\s]", "").ToLower().Replace(" ", "-");
                existingBook.Author = bookDto.Author;
                existingBook.Total_pages = bookDto.Total_pages;

                await _context.SaveChangesAsync();

                return existingBook;
            }
        }

        public async Task<Book> DeleteBookAsync(int id)
        {
            var bookModel = await _context.Books.SingleOrDefaultAsync(book => book.Id == id);

            if (bookModel == null)
            {
                return null;

            }

            _context.Books.Remove(bookModel);

            await _context.SaveChangesAsync();

            return bookModel;
        }
    }
}