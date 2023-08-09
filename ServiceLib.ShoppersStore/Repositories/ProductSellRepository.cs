using System;
using System.Collections.Generic;
using System.Text;
using ServiceLib.ShoppersStore.DTO;
using ServiceLib.ShoppersStore.Interfaces;
using EF.Core.ShoppersStore.ShoppersStoreDB;
using EF.Core.ShoppersStore.ShoppersStoreDB.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ServiceLib.ShoppersStore.Repositories
{
    public class ProductSellRepository : IProductSellRepository
    {
        private readonly ShoppersStoreContext appDbContext;

        public ProductSellRepository(ShoppersStoreContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        // checked for in-built transaction & exception@last moment
        public async Task<BillDTO> ProductBillCreate(BillDTO bill)
        {
            using var transaction = appDbContext.Database.BeginTransaction();
            try
            {
                bill.BillRefCode = null;

                // generate refcode
                var refCode = RefCodeGenerator.RandomString(6);

                // 1)
                // insert @ Payment
                var payment = await appDbContext.Payments.AddAsync(new Payment()
                {
                    AmountPaid = bill.Payment.AmountPaid,
                    BillRefCode = refCode,
                    CardCVV = bill.Payment.CardCVV,
                    CardNumber = bill.Payment.CardNumber,
                    CardType = bill.Payment.CardType,
                    PaymentType = bill.Payment.PaymentType,
                    ValidMonth = bill.Payment.ValidMonth,
                    ValidYear = bill.Payment.ValidYear,
                    TransactionDate = DateTime.Now
                });
                await appDbContext.SaveChangesAsync();

                // check for exception
                // throw new Exception();

                // 2)
                // insert @ ProductSell / Cart
                foreach (var product in bill.Cart.Products)
                {
                    var _product = await appDbContext.Products
                                        .Where(x => x.ProductId == product.ProductId).FirstOrDefaultAsync();
                    ProductSell productDb = new ProductSell()
                    {
                        ProductId = _product.ProductId,
                        BasePrice = _product.Price,
                        CurrentPrice = product.CurrentPrice,
                        BillQty = product.QtyBuy,
                        DiscountPercentage = _product.DiscountPercentage,
                        BillRefCode = refCode,
                        PaymentId = payment.Entity.PaymentId
                    };
                    await appDbContext.ProductSells.AddAsync(productDb);
                }
                await appDbContext.SaveChangesAsync();

                // check for exception
                // throw new Exception();

                // commit 1 & 2
                transaction.Commit();

                bill.BillRefCode = refCode;
                return bill;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                bill.BillRefCode = null;
                return bill;
            }            
        }
    }
}
