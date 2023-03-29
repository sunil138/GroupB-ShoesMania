using User_UAuthentication.Models;
using User_UAuthentication.Models.DTO;

namespace User_UAuthentication.DataAccess
{
    public interface IUser
    {
        List<User> GetAllUsers();
        User GetUserById(int id);

        string UpdateUser(UserDto user);
        string DeleteUser(int id);
    }
}
