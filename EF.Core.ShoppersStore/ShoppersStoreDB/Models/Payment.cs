using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace EF.Core.ShoppersStore.ShoppersStoreDB.Models
{
    public class Payment
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentId { get; set; }
        public int PaymentType { get; set; }
        public decimal AmountPaid { get; set; }
        public string CardNumber { get; set; }
        public int CardCVV { get; set; }
        public string CardType { get; set; }
        public int ValidMonth { get; set; }
        public int ValidYear { get; set; }
        
        [Required]
        public string BillRefCode { get; set; }
        
        public DateTime TransactionDate { get; set; }

        public ICollection<ProductSell> ProductSells { get; set; }
    }

}
