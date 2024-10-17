using System.ComponentModel.DataAnnotations;

namespace Practice3.Models
{

    public enum Gender
    {
        Male, //0
        Female, //1
        other, //2
    }
    public class User
    {
        public int UserId { get; set; }
        [Required]
        public string? UserName { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string? Address { get; set; }
        [Required]
        public Gender? Gender { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
    }

}
