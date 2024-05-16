using book_note_app.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_web_first.Models
{
    [Table("Genres")]
    public class Genre
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Slug { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Updated_at { get; set; }


        public List<Book> Books { get; set; } = new List<Book>();
    }
}
