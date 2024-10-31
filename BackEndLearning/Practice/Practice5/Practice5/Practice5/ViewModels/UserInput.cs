using Practice5.Enum;
using Practice5.Models;
using System.ComponentModel.DataAnnotations;

namespace Practice5.ViewModels
{
    public class UserInput : BaseModel
    {
        [Required(ErrorMessage = "User name can't be null")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password can't be null")]
        public string Password { get; set; }

        [EmailAddress(ErrorMessage = "email format is not correct")]
        public string? Email { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string? Address { get; set; }

        [PhoneValidation]
        public string? Phone { get; set; }
    }
    public class AddUserInput : UserInput { }
    public class UpdateUserInput : UserInput { }
}
