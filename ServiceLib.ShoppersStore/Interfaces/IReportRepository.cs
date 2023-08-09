using System;
using System.Collections.Generic;
using System.Text;
using ServiceLib.ShoppersStore.DTO;
using EF.Core.ShoppersStore.ShoppersStoreDB.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace ServiceLib.ShoppersStore.Interfaces
{
    public interface IReportRepository
    {
        Task<List<ProductWithImageDTO>> GetProductsWithImage();
        Task<List<MonthlyTotalSalesData>> MonthlyStoreWise(MonthlyTotalSalesData data);
        List<YearlyProductWiseSalesData> MonthlyProductWise(YearlyProductWiseSalesData data);
        List<MonthlyProductWiseSalesData> SelectedProductWise(MonthlyProductWiseSalesData data);
        List<ProductDiscountSalesData> DiscountWise(ProductDiscountSalesData data);
    }
}
