using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ServiceLib.ShoppersStore.DTO
{
    public class MonthlyTotalSalesData
    {
        public string SelectedYear { get; set; } // ip
        public int MonthNumber { get; set; }
        public decimal TotalSales { get; set; }
        public string MonthName
        {
            get
            {
                return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(this.MonthNumber);
            }
        }
    }
}
