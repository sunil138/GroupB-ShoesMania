using Microsoft.EntityFrameworkCore;
using Product_PCategory.Models;

namespace Product_PCategory.DataAccess
{
    public class ProductContext:DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options):base(options)
        {

        }

       public  DbSet<Product> Products { get; set; }

       public  DbSet<ProductCategory> ProductsCategory { get; set; }
    }
}
