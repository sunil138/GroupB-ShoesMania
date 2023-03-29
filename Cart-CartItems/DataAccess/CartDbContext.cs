using Cart_CartItems.Models;
using Microsoft.EntityFrameworkCore;

namespace Cart_CartItems.DataAccess
{
    public class CartDbContext:DbContext
    {

        public CartDbContext(DbContextOptions<CartDbContext> options):base(options)
        {

        }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<CartItems> CartItems { get; set; }
    }
}
