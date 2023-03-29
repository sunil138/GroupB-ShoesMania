using System.ComponentModel.DataAnnotations;

namespace Orders.Models
{
    public class OrderItems
    {
        [Key]
        public int OrderItemsId { get; set; }
        public int ProductId { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public double Price { get; set; }
    }
}
