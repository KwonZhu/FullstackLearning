using Practice5.Models;

namespace Practice5.IServices
{
    public interface IUserService
    {
        bool AddUser(User user);
        List<User> GetUsers();

        //bool UpdateUsers(User user);

        //bool DeleteUser(int id);
    }
}
