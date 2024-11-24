using System.ComponentModel.DataAnnotations;

namespace Week8.Validations
{
    public class NameValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            if (value == null)
            {
                return new ValidationResult("Please enter name");
            }

            var enterName = value.ToString();

            if (enterName.Length >= 60)
            {
                return new ValidationResult("Name Should not be more than 60 charcters");
            }
            return ValidationResult.Success;
        }
        }
}
