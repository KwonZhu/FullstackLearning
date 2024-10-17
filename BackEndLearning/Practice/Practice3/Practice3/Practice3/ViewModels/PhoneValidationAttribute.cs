using System.ComponentModel.DataAnnotations;

namespace Practice3.ViewModels
{
    public class PhoneValidationAttribute : ValidationAttribute
    {
        public PhoneValidationAttribute()
        {
             protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null) { return new ValidationResult("Phone is null")}

            var phoneNumber = value as string;
        }
        }
    }
}
