using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Orders.Models.DTOs
{
    public class CartItemsDto
    {
        public int Id { get; set; }


        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public double ProductPrice { get; set; }

        public int ProductQuantity { get; set; }


        public int? CartId { get; set; }

        [JsonIgnore]
        public int Cart { get; set; }

    }
}
