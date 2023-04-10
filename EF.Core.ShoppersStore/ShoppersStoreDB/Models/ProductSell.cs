using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EF.Core.ShoppersStore.ShoppersStoreDB.Models
{
    public class ProductSell
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SellId { get; set; }


        [Required]
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public decimal BasePrice { get; set; }
        public int DiscountPercentage { get; set; }
        public decimal CurrentPrice { get; set; }

        public int BillQty { get; set; }
        
        public Product Product { get; set; }

        [Required]
        public string BillRefCode { get; set; }
        
        [Required]
        public int PaymentId { get; set; }
        public Payment Payment { get; set; }
    }
}
