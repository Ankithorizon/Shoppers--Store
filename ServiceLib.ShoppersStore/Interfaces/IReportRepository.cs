using System;
using System.Collections.Generic;
using System.Text;
using ServiceLib.ShoppersStore.DTO;
using EF.Core.ShoppersStore.ShoppersStoreDB.Models;


namespace ServiceLib.ShoppersStore.Interfaces
{
    public interface IReportRepository
    {
        List<MonthlyTotalSalesData> TextReportMonthly(MonthlyTotalSalesData data);
        List<MonthlyProductWiseSalesData> TextReportMonthlyProductWise(MonthlyProductWiseSalesData data);
        List<ProductWithImageDTO> GetProductsWithImage();
        List<YearlyProductWiseSalesData> TextReportYearlyProductWise(YearlyProductWiseSalesData data);
        List<ProductDiscountSalesData> TextReportProductDiscountWise(ProductDiscountSalesData data);
    }
}
