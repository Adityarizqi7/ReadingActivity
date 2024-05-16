using System.ComponentModel.DataAnnotations.Schema;

namespace api_web_first.Models
{
    [Table("Activities")]
    public class Activity
    {
        public int Id { get; set; }
        public string? Full_name { get; set; } = string.Empty;
        public int? Last_page_read { get; set; }
        public string? Last_place_read { get; set; }
        public DateTime? Last_time_read { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Updated_at { get; set; }


        public Book? Book { get; set; }
        public int? BookId { get; set; }

    }
}