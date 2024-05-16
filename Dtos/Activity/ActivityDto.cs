using book_note_app.Dtos.Book;

namespace book_note_app.Dtos.Activity
{
    public class ActivityDto
    {
        public int Id { get; set; }
        public string? Full_name { get; set; } = string.Empty;
        public int? Last_page_read { get; set; }
        public string? Last_place_read { get; set; }
        public string? Result { get; set; }
        public DateTime? Last_time_read { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        public BookWithActivityDto? Book { get; set; }
    }
}
