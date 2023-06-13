using Microsoft.EntityFrameworkCore;
using EF.Core.ShoppersStore.ShoppersStoreDB;
using EF.Core.ShoppersStore.ShoppersStoreDB.Models;
using ServiceLib.ShoppersStore.DTO;
using ServiceLib.ShoppersStore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLib.ShoppersStore.Repositories
{
    public class ReportRepository : IReportRepository
    {

        private readonly ShoppersStoreContext appDbContext;
        public ReportRepository(ShoppersStoreContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }



        public List<ProductWithImageDTO> GetProductsWithImage()
        {
            throw new NotImplementedException();
        }

        public List<MonthlyTotalSalesData> TextReportMonthly(MonthlyTotalSalesData data)
        {
            List<MonthlyTotalSalesData> datas = new List<MonthlyTotalSalesData>();

            var selectedYear = data.SelectedYear;

            var groupedMonthly = from p in appDbContext.Payments
                          .Where(x => x.TransactionDate.Year == Convert.ToInt32(selectedYear))
                                 group p
                                   by new { month = p.TransactionDate.Month } into d
                                 select new
                                 {
                                     Month = d.Key.month,
                                     SelectedYear = selectedYear,
                                     TotalSales = d.Sum(x => x.AmountPaid)
                                 };

            foreach (var data_ in groupedMonthly)
            {
                datas.Add(new MonthlyTotalSalesData()
                {
                    SelectedYear = data_.SelectedYear,
                    MonthNumber = data_.Month,
                    TotalSales = data_.TotalSales
                });
            }


            var missingMonths = Enumerable
                .Range(1, 12)
                .Except(datas.Select(m => m.MonthNumber));
            // Insert missing months back into months list
            foreach (var month in missingMonths)
            {
                datas.Insert(month - 1, new MonthlyTotalSalesData()
                {
                    MonthNumber = month,
                    SelectedYear = data.SelectedYear,
                    TotalSales = 0.0M
                });
            }


            return datas;
        }

        public List<MonthlyProductWiseSalesData> TextReportMonthlyProductWise(MonthlyProductWiseSalesData data)
        {
            throw new NotImplementedException();
        }

        public List<ProductDiscountSalesData> TextReportProductDiscountWise(ProductDiscountSalesData data)
        {
            throw new NotImplementedException();
        }

        public List<YearlyProductWiseSalesData> TextReportYearlyProductWise(YearlyProductWiseSalesData data)
        {
            throw new NotImplementedException();
        }
    }
}
