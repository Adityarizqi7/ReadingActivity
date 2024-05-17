using book_note_app.Models;
using System.ComponentModel.DataAnnotations;

namespace book_note_app.Dtos.Book
{
    public class CreateBookRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Title Book should be at least 3 characters.")]
        [MaxLength(250, ErrorMessage = "Title Book must be 280 characters at most.")]
        public required string Title { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Author Book should be at least 3 characters.")]
        [MaxLength(250, ErrorMessage = "Author Book must be 280 characters at most.")]
        public required string Author { get; set; }
        [Range(1, 1000000000)]
        public int? Total_pages { get; set; }
        public int[]? Genre_id { get; set; }
    }
}
