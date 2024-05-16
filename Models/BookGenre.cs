using api_web_first.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace book_note_app.Models
{
    [Table("BookGenres")]
    public class BookGenre
    {
        public int BookId { get; set; }
        public int GenreId { get; set; }
        public Book Book { get; set; } = null!;
        public Genre Genre { get; set; } = null!;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
