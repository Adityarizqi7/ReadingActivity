using System.ComponentModel.DataAnnotations;

namespace book_note_app.Dtos.Activity
{
    public class UpdateActivityRequestDto
    {
        [MinLength(3, ErrorMessage = "Full Name should be at least 3 characters.")]
        [MaxLength(280, ErrorMessage = "Full Name must be 280 characters at most.")]
        public string? Full_name { get; set; } = string.Empty;
        [Range(1, 1000000000)]
        public int? Last_page_read { get; set; }
        [MinLength(3, ErrorMessage = "Last Place Read should be at least 3 characters.")]
        [MaxLength(250, ErrorMessage = "Last Place Read must be 280 characters at most.")]
        public string? Last_place_read { get; set; }
        public DateTime? Last_time_read { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Result should be at least 3 characters.")]
        public required string Result { get; set; }
    }
}
