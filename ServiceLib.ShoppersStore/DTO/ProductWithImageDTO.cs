using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLib.ShoppersStore.DTO
{
    public class ProductWithImageDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal CurrentPrice { get; set; }
        public string ProductImage { get; set; }        
    }
}
