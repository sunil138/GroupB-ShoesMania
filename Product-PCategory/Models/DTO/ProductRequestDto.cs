﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Product_PCategory.Models.DTO
{
    public class ProductRequestDto
    {
        public int ProductId { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;

       
        public int? CategoryId { get; set; }

        public double? Price { get; set; }
    }
}
