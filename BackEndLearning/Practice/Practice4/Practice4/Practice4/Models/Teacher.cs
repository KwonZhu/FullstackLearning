using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Practice4.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        [Required]
        public string? Department { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        [Required]
        public string? Specialty { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }

        //Navigation Property
        //This property allows you to directly access the corresponding User entity through a Teacher instance, without having to manually query the User table.
        //[ForeignKey("UserId")]
        //public User User { get; set; } 
    }
}
