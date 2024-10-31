using Practice5.Enum;
using System.Reflection;

namespace Practice5.Models
{
    public class User : BaseModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? Email { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
    }
}
