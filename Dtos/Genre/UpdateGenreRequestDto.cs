using System.ComponentModel.DataAnnotations;

namespace book_note_app.Dtos.Genre
{
    public class UpdateGenreRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Title Book should be at least 3 characters.")]
        [MaxLength(250, ErrorMessage = "Title Book must be 280 characters at most.")]
        public string? Name { get; set; }
    }
}
