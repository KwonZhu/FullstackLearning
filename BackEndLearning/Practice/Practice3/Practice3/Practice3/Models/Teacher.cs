using Practice3.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practice3.Models
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
//public class Teacher
//{
//    [Key]  // 主键
//    public int TeacherID { get; set; }
//    public string Subject { get; set; }

//    // 外键，指向 User 表
//    public int UserID { get; set; }

//    // 导航属性
//    [ForeignKey("UserID")]
//    public User User { get; set; }  // 通过导航属性，可以直接访问关联的 User 实体
//}

//public class Teacher
//{
//    [Key]  // 主键
//    public int TeacherID { get; set; }
//    public string Subject { get; set; }

//    // 外键，指向 User 表
//    [ForeignKey("UserID")]
//    public int UserID { get; set; }
//}