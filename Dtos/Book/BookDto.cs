using book_note_app.Dtos.Activity;
using book_note_app.Dtos.Genre;

namespace book_note_app.Dtos.Book
{
    public class BookDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public string? Slug { get; set; }
        public int? Total_pages { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        public List<ActivityDto> Activities { get; set; }
        public List<GenreDto> Genres { get; set; }
    }
}
