using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Practice3.ViewModels
{
    public class PhoneValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null) //null check
            {
                return new ValidationResult("Phone is null");
            }

            var phoneNumber = value as string;
            if (phoneNumber == null) //type check
            {
                return new ValidationResult("Type is not correct");
            }
            // Regular expression for Australian phone number (+61 or 0 followed by 9 digits)
            var regex = new Regex(@"^(\+61|0)[0-9]{9}$");
            if (!regex.IsMatch(phoneNumber))
            {
                return new ValidationResult("Not a valid Australian number");
            }

            return ValidationResult.Success;
        }
    }
}
