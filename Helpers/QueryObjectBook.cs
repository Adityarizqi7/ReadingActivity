using System.ComponentModel.DataAnnotations;

namespace book_note_app.Helpers
{
    public class QueryObjectBook
    {
        public string? search {  get; set; } = null;
        public string? sort_type { get; set; } = "ASC";
        public int per_page { get; set; } = 6;
        public int page { get; set; } = 1;
        public string? genre { get; set; }
    }
}