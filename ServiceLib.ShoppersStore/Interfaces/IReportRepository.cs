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
        Task<List<YearlyProductWiseSalesData>> MonthlyProductWise(YearlyProductWiseSalesData data);
        Task<List<MonthlyProductWiseSalesData>> SelectedProductWise(MonthlyProductWiseSalesData data);
        Task<List<ProductDiscountSalesData>> DiscountWise(ProductDiscountSalesData data);
    }
}
