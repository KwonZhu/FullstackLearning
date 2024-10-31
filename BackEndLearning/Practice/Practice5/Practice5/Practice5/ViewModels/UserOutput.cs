using Practice5.Models;

namespace Practice5.ViewModels
{
    public class UserOutput : BaseModel
    {
        public string UserName { get; set; }
        public string? Email { get; set; }
    }
}
