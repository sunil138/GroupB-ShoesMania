using Microsoft.EntityFrameworkCore;
using Orders.Models;

namespace Orders.DataAccess
{
    public class OrdersDbContext:DbContext
    {
        public OrdersDbContext(DbContextOptions<OrdersDbContext> options):base(options) { }
        

        public DbSet<Order> Orders { get; set; }
    }
}
