using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLib.ShoppersStore.DTO
{
    public class ProductSellDTO
    {  
        public int ProductId { get; set; }
        public decimal BasePrice { get; set; }
        public int DiscountPercentage { get; set; }
        public decimal CurrentPrice { get; set; }
        public int BillQty { get; set; }
        public string BillRefCode { get; set; }
        public DateTime BillDate { get; set; }
    }
}
