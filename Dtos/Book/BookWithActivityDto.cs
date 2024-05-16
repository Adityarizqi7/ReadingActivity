namespace book_note_app.Dtos.Book
{
    public class BookWithActivityDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string Slug { get; set; }
        public required string Author { get; set; }
        public int? Total_pages { get; set; }
    }
}
