using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore.Metadata;
using Midterm.Models;
using System.ComponentModel.DataAnnotations;


namespace Midterm.Models
{
    public class Book
    {

        public int BookId { get; set; }

        [Required(ErrorMessage = "What is the Book Title!!!")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Title must be between 2 and 100 characters.")]

        public string? Title { get; set; }


        [Required(ErrorMessage = "Book's Authors Name didn't find !!!")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Author Name must be between 2 and 50 characters.")]
        public string? Author { get; set; }

        [Required(ErrorMessage = "You may missed to fill the publication year of the Book!!")]
        [Range(1000, 2024, ErrorMessage = "Please enter the valid year of Publication")]
        public int? Year { get; set; }


        public bool IsAvailability { get; set; }


       [Required(ErrorMessage = "Please enter the book Genre")]
        public string? GenreId { get; set; }
        //navigation property
        [ValidateNever]

        public Genre Genre { get; set; }


        

    }
}

