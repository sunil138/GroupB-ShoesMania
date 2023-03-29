namespace Orders.Models.DTOs
{
    public class OrderPlacedResponseDto
    {
        public int OrderId { get; set; }

        public int? UserId { get; set; }

        public DateTime? OrderDate { get; set; }


        public double? TotalAmount { get; set; }

        public string? OrderStatus { get; set; }

        public List<OrderItems>? OrderItems { get; set; }

       
    }
}
