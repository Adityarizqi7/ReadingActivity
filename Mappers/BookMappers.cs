using api_web_first.Models;
using book_note_app.Dtos.Book;

namespace book_note_app.Mappers
{
    public static class BookMappers
    {
        public static BookDto ToBookDto(this Book bookModel)
        {
            return new BookDto
            {
                Id = bookModel.Id,
                Title = bookModel.Title,
                Author = bookModel.Author,
                Slug = bookModel.Slug,
                Total_pages = bookModel.Total_pages,
                Created_at = bookModel.Created_at,
                Updated_at = bookModel.Updated_at,
                Activities = bookModel.Activities.Select(activity => activity.ToActivityDto()).ToList(),
                Genres = bookModel.Genres.Select(genre => genre.ToGenreDto()).ToList(),
            };
        }

        public static Book ToBookFromCreateDTO(this CreateBookRequestDto bookDto)
        {
            return new Book
            {
                Title = bookDto.Title,
                Author = bookDto.Author,
                Total_pages = bookDto.Total_pages,
             };
        }
    }
}
