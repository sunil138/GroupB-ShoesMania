using System.ComponentModel.DataAnnotations;

namespace Cart_CartItems.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public int  UserId { get; set; }
        public ICollection<CartItems> CartItems { get; set; } 
    }
}
