using System.ComponentModel.DataAnnotations;

namespace Practice3.Models
{
    public class Teacher
    {
        [Required]
        public string? Deoartment { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        [Required]
        public string? Specialty { get; set; }
    }
}
