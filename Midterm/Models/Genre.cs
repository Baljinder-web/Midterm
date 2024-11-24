using System.ComponentModel.DataAnnotations;

namespace Midterm.Models
{
    public class Genre
    {
        [Required(ErrorMessage = "Please enter the book Genre")]
        public string? GenreId { get; set; }

        public string? Name { get; set; }
    }
}
