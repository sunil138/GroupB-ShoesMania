using System.ComponentModel.DataAnnotations.Schema;

namespace Cart_CartItems.Models.DTO
{
    public class ProductDetailsDto
    {
        public int ProductId { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;

      
        public int? CategoryId { get; set; }

        public double Price { get; set; }



    }
}
