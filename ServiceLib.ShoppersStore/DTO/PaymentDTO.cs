using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace ServiceLib.ShoppersStore.DTO
{
    public class PaymentDTO
    {
        public int PaymentType { get; set; } // 1=cash, 2=cc
        public decimal AmountPaid { get; set; }
        public string CardNumber { get; set; }
        public int CardCVV { get; set; }
        public string CardType { get; set; }
        public int ValidMonth { get; set; }
        public int ValidYear { get; set; }
    }
}
