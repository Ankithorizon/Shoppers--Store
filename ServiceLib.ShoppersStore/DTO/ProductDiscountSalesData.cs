using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLib.ShoppersStore.DTO
{
    public class ProductDiscountSalesData
    {
        public string SelectedYear { get; set; } // ip
        public int SelectedProductId { get; set; } // ip
        public string SelectedProductName { get; set; }
        public int DiscountPercentage { get; set; } // group by
        public decimal TotalSales { get; set; }

    }
}
