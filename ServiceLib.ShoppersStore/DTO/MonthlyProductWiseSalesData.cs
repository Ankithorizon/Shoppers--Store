using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ServiceLib.ShoppersStore.DTO
{
    public class MonthlyProductWiseSalesData
    {
        public int SelectedYear { get; set; } // ip
        public int SelectedMonth { get; set; } // ip // 1,2,3,...12
        public int SelectedProductId { get; set; } // ip
        public string SelectedProductName { get; set; }
        public decimal TotalSales { get; set; }
        public string SelectedMonthName
        {
            get
            {
                return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(this.SelectedMonth);
            }
        }
    }
}
