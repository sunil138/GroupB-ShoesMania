using System.ComponentModel.DataAnnotations;

namespace Product_PCategory.Models
{
    public class ProductCategory
    {
        [Key]
        public int CategoryId { get; set; }
        public string? Category { get; set; } = "";
        public string? SubCategory { get; set; } = "";

      //  public virtual ICollection<Product> Products { get; } = new List<Product>();
    }
}
