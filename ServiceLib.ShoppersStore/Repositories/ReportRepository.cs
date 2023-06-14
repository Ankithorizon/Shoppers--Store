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
            List<ProductWithImageDTO> datas = new List<ProductWithImageDTO>();

            var products = appDbContext.Products;
            if (products != null && products.Count() > 0)
            {
                foreach (var product in products)
                {
                    var productFile = appDbContext.ProductFiles
                                        .Where(x => x.ProductFileId == product.ProductFileId).FirstOrDefault();
                    if (productFile != null)
                    {
                        datas.Add(new ProductWithImageDTO()
                        {
                            ProductId = product.ProductId,
                            CurrentPrice = product.DiscountPrice == 0.0M ? product.Price : product.DiscountPrice,
                            ProductName = product.ProductName,
                            ProductImage = productFile.FileName
                        });
                    }
                    else
                    {
                        // product with no image
                        datas.Add(new ProductWithImageDTO()
                        {
                            ProductId = product.ProductId,
                            CurrentPrice = product.DiscountPrice == 0.0M ? product.Price : product.DiscountPrice,
                            ProductName = product.ProductName,
                            ProductImage = "N/A"
                        });
                    }
                }
            }
            return datas;
        }

        public List<MonthlyTotalSalesData> MonthlyStoreWise(MonthlyTotalSalesData data)
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

        // add group by
        /*
        select sum(AmountPaid)
        from Payments
        where PaymentId in (select PaymentId from ProductSells where ProductId=8)
        */
        public List<YearlyProductWiseSalesData> MonthlyProductWise(YearlyProductWiseSalesData data)
        {
            List<YearlyProductWiseSalesData> datas = new List<YearlyProductWiseSalesData>();
            List<ProductSellDTO> productSellsData = new List<ProductSellDTO>();

            var selectedProduct = appDbContext.Products
                                    .Include(x => x.ProductSells)
                                    .Where(x => x.ProductId == data.SelectedProductId).FirstOrDefault();

            var productName = "";

            if (selectedProduct != null)
            {
                productName = selectedProduct.ProductName;

                if (selectedProduct.ProductSells != null && selectedProduct.ProductSells.Count() > 0)
                {
                    foreach (var ps in selectedProduct.ProductSells)
                    {
                        var payment = appDbContext.Payments
                                        .Where(x => x.BillRefCode == ps.BillRefCode && x.TransactionDate.Year == Convert.ToInt32(data.SelectedYear)).FirstOrDefault();
                        if (payment != null)
                        {
                            productSellsData.Add(new ProductSellDTO()
                            {
                                BasePrice = ps.BasePrice,
                                BillDate = payment.TransactionDate,
                                BillQty = ps.BillQty,
                                BillRefCode = ps.BillRefCode,
                                CurrentPrice = ps.CurrentPrice,
                                DiscountPercentage = ps.DiscountPercentage,
                                ProductId = ps.ProductId,
                                AmountPaid = payment.AmountPaid
                            });
                        }
                        else
                        {
                            // related payment refcode or year not matched
                        }
                    }

                    // group by on productSellsData

                    // group by with no order by 
                    /*
                    var groupedMonthly = from ps in productSellsData
                                         group ps
                                           by new { month = ps.BillDate.Month } into d
                                         select new
                                         {
                                             Month = d.Key.month,
                                             TotalSales = d.Sum(x => (x.CurrentPrice * x.BillQty))
                                         };
                    foreach (var data_ in groupedMonthly)
                    {
                        datas.Add(new YearlyProductWiseSalesData()
                        {
                            MonthNumber = data_.Month,
                            TotalSales = data_.TotalSales,
                            SelectedProductId = data.SelectedProductId,
                            SelectedProductName = productName,
                            SelectedYear = data.SelectedYear
                        });
                    }
                    */


                    // group by with order by month number
                    var query = productSellsData.GroupBy(ps => ps.BillDate.Month)
                        .Select(group =>
                            new {
                                Month = group.Key,
                                // TotalSales = group.Sum(x => (x.CurrentPrice * x.BillQty)),
                                TotalSales = group.Sum(x => (x.AmountPaid)),
                                SellsData = group.OrderBy(x => x.BillDate.Month)
                            })
                        .OrderBy(group => group.SellsData.First().BillDate.Month);
                    foreach (var data_ in query)
                    {
                        datas.Add(new YearlyProductWiseSalesData()
                        {
                            MonthNumber = data_.Month,
                            TotalSales = data_.TotalSales,
                            SelectedProductId = data.SelectedProductId,
                            SelectedProductName = productName,
                            SelectedYear = data.SelectedYear
                        });
                    }
                }
                else
                {
                    // product found
                    // but this product has 0 sales
                }
            }

            var missingMonths = Enumerable
               .Range(1, 12)
               .Except(datas.Select(m => m.MonthNumber));
            // Insert missing months back into months list
            foreach (var month in missingMonths)
            {
                datas.Insert(month - 1, new YearlyProductWiseSalesData()
                {
                    SelectedProductId = data.SelectedProductId,
                    SelectedProductName = productName,
                    SelectedYear = data.SelectedYear,
                    MonthNumber = month,
                    TotalSales = 0.0M
                });
            }

            return datas;

        }

    }
}
