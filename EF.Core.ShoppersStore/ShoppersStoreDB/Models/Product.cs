using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace EF.Core.ShoppersStore.ShoppersStoreDB.Models
{
    public class Product
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product Name is Required!")]
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Price is Required!")]
        [Required(ErrorMessage = "Price is Required!")]
        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
        public int DiscountPercentage { get; set; }
        public bool Available { get; set; }

        public int ProductFileId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Category is Required!")]
        [Required(ErrorMessage = "Category is Required!")]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        [JsonIgnore]
        public Category Category { get; set; }

        public ICollection<ProductSell> ProductSells { get; set; }

        public ProductFile ProductFile { get; set; }

        public ICollection<DiscountHistory> DiscountHistories { get; set; }       
    }
}
