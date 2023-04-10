using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;


namespace ServiceLib.ShoppersStore.DTO
{
    public class ProductDTO
    {
        public int CategoryId { get; set; }
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product Name is Required!")]
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Price is Required!")]
        [Required(ErrorMessage = "Price is Required!")]
        public decimal Price { get; set; }

        public int ProductFileId { get; set; }
        public string ProductImage { get; set; }
        public decimal CurrentPrice { get; set; }
        public int CurrentDiscountPercentage { get; set; }
    }
}
