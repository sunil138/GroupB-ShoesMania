using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Http.Headers;

namespace Cart_CartItems.Models
{
    public class CartItems
    {
        [Key]
        public int Id { get; set; }

        
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public double ProductPrice { get; set; }

        public int ProductQuantity { get; set; }

       
        public int? CartId { get; set; }

        [ForeignKey("CartId")]
        public Cart Cart { get; set; }
    }
}
