using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Midterm.Models;
using System.ComponentModel.DataAnnotations;
using Week8.Validations;


namespace Midterm.Models
{
    public class Member
    {
        public int MemberId { get; set; }

        [Required(ErrorMessage = "Please enter the Member Name!!!")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters.")]

        public string? Name { get; set; }


        [PhoneValidation]
        public string? PhoneNumber { get; set; }



        [Required(ErrorMessage = "Please enter the Email address!!!")]
        [EmailAddress(ErrorMessage = "Invaild Email address")]
        public string? Email { get; set; }


        public bool HasIssuedBook { get; set; }


        public int?  BookId { get; set; }
        //navigation property
        [ValidateNever]

        public Book Book { get; set; }



    }
}

