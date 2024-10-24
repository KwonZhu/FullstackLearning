using Practice3.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Practice3.Models
{

    public enum GenderEnum
    {
        Male, //0
        Female, //1
        other, //2
    }
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Username cannot be empty.")]
        public string? UserName { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string? Address { get; set; }
        [Required(ErrorMessage = "Gender is required.")]
        public GenderEnum? Gender { get; set; }
        public string? Password { get; set; }
        [PhoneValidation]
        public string? Phone { get; set; }
    }
}
