using System;
using System.Collections.Generic;
using System.Text;
using ServiceLib.ShoppersStore.DTO;
using EF.Core.ShoppersStore.ShoppersStoreDB.Models;


namespace ServiceLib.ShoppersStore.Interfaces
{
    public interface IReportRepository
    {
        List<ProductWithImageDTO> GetProductsWithImage();
        List<MonthlyTotalSalesData> MonthlyStoreWise(MonthlyTotalSalesData data);
        List<YearlyProductWiseSalesData> MonthlyProductWise(YearlyProductWiseSalesData data);
        List<MonthlyProductWiseSalesData> SelectedProductWise(MonthlyProductWiseSalesData data);
        List<ProductDiscountSalesData> DiscountWise(ProductDiscountSalesData data);
    }
}
