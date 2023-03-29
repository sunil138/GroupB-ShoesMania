using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Product_PCategory.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;

        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; } 

       

        public virtual ProductCategory? Category { get; set; }


        //public int? CategoryId { get; set; }

        public double? Price { get; set; }
        
    }
}
