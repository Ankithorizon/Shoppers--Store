using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace ServiceLib.ShoppersStore.DTO
{
    public class ProductDiscountDTO
    {
        [Required(ErrorMessage = "Product is Required!")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Discount is Required!")]
        public int DiscountPercentage { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
        public APIResponse APIResponse { get; set; }
    }
}
