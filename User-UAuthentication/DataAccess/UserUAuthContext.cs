using Microsoft.EntityFrameworkCore;
using User_UAuthentication.Models;

namespace User_UAuthentication.DataAccess
{
    public class UserUAuthContext:DbContext
    {

        public UserUAuthContext(DbContextOptions<UserUAuthContext> options):base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}
