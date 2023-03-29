namespace Orders.Models.DTOs
{
    public class CartDetailsDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public ICollection<CartItemsDto> CartItems { get; set; }
    }
}
