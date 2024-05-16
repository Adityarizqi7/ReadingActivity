using Azure;
using book_note_app.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_web_first.Models
{
    [Table("Books")]
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; } = string.Empty;
        public string? Author { get; set; } = string.Empty;
        public string? Slug { get; set; } = string.Empty;
        public int? Total_pages { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Updated_at { get; set; }

        public List<Activity> Activities { get; set; } = new List<Activity>();
        public List<Genre> Genres { get; set;  } = new List<Genre>();
    }
}
