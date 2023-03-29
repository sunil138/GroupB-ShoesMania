using User_UAuthentication.DataAccess;
using User_UAuthentication.Models;
using User_UAuthentication.Models.DTO;

namespace User_UAuthentication.Repository
{
    public class UserRepo : IUser
    {
        private readonly UserUAuthContext _context;

        public UserRepo(UserUAuthContext context)
        {
            _context = context;
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.Find(id);
        }

        public string DeleteUser(int id)
        {
            var delId = _context.Users.Find(id);
            if (delId != null)
            {
                _context.Users.Remove(delId);
                _context.SaveChanges();
                return "Deleted Successfully";
            }
            else
            {
                return "Not Found";
            }
        }

        public string UpdateUser(UserDto user)
        {

            var updateuserId = _context.Users.Find(user.UserId);
            if (updateuserId != null)
            {
                //_context.Users.Update(updateuserId); 
                updateuserId.UserName = user.UserName;
                updateuserId.Email = user.Email;
                updateuserId.Role = user.Role;
                updateuserId.City = user.City;
                updateuserId.Address = user.Address;
                _context.SaveChanges();
                return "update successfully";
            }
            else
            {
                return "cannot update the details";
            }
        }

    }
}
