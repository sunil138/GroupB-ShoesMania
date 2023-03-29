using Orders.Models.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Orders.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public int? UserId { get; set; }

        public string? UserName { get; set; }

        public string? UserEmail { get; set; }

         public DateTime? OrderedOn { get; set; }

        public double? TotalAmount { get; set; }

        public string? OrderStatus { get; set; } 

        public List<OrderItems>? orderItems { get; set; }
    }
}
