using Practice5.Models;

namespace Practice5.ViewModels
{
    public class LoginOutput : BaseModel
    {
        public string UerName { get; set; }

        public string Email { get; set; }
        public string AccessToken { get; set; }
    }
}
