using api_web_first.Models;
using book_note_app.Dtos.Book;
using book_note_app.Helpers;

namespace book_note_app.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllAsync(QueryObjectBook query);
        Task<Book> GetBookBySlugAsync(string slug);
        Task<Book> CreateBookAsync(Book bookModel);
        Task<Book> UpdateBookAsync(int id, UpdateBookRequestDto bookDto);
        Task<Book> DeleteBookAsync(int id);
        Task<bool> BookExist(int id);

    }
}
