using System.ComponentModel.DataAnnotations;

namespace Practice3.Models
{
    public class Teacher
    {
        public int UserId { get; set; }
        [Required]
        public string? Department { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        [Required]
        public string? Specialty { get; set; }
    }
}
