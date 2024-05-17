using book_note_app.Models;
using System.ComponentModel.DataAnnotations;

namespace book_note_app.Dtos.Genre
{
    public class CreateGenreRequestDto
    {
        [Required]
        [MinLength(2, ErrorMessage = "Name Book should be at least 2 characters.")]
        [MaxLength(250, ErrorMessage = "Name Book must be 280 characters at most.")]
        public required string Name { get; set; }
    }
}
