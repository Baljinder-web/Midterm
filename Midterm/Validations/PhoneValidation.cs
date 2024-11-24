using System.ComponentModel.DataAnnotations;


namespace Week8.Validations
{
    public class PhoneValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Please enter phone number");
            }

            var phoneNumber = value.ToString();


            if (phoneNumber.Length == 12)
            {
                if (phoneNumber[3] == '-' && phoneNumber[7] == '-')
                {
                    for (int i = 0; i < phoneNumber.Length; i++)
                    {
                        if (i != 3 && i != 7)
                        {
                            if (!char.IsDigit(phoneNumber[i]))
                            {

                                return new ValidationResult("Phone must contain numbers only");
                            }





                        }

                    } return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Phone number must have dashes");
                }
            }
            else
            {
                return new ValidationResult("Phone number length must be 12");
            }


        }
    

    }
}

