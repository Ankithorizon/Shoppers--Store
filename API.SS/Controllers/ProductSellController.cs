using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceLib.ShoppersStore.Interfaces;
using ServiceLib.ShoppersStore.Repositories;
using Microsoft.AspNetCore.Authorization;
using EF.Core.ShoppersStore.ShoppersStoreDB.Models;
using ServiceLib.ShoppersStore.DTO;
using System.IO;

namespace API.SS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSellController : ControllerBase
    {
        private readonly IProductSellRepository _productSellRepo;

        public ProductSellController(IProductSellRepository productSellRepo)
        {
            _productSellRepo = productSellRepo;
        }

        [Authorize("Shopper")]
        [HttpPost]
        [Route("billCreate")]
        public async Task<IActionResult> ProductBillCreate(BillDTO bill)
        {
            bool modelInvalid = false;
            try
            {
                // throw new Exception();

                if (bill.Payment.PaymentType == 1)
                {
                    // cash
                    if (bill.Payment.AmountPaid <= 0)
                    {
                        modelInvalid = true;
                        ModelState.AddModelError("Amount Paid", "Amount Paid is Required !");
                        return BadRequest(ModelState);
                    }
                    bill = await _productSellRepo.ProductBillCreate(bill);
                    return Ok(bill);
                }
                else
                {
                    // cc
                    if (bill.Payment.CardNumber == null)
                    {
                        modelInvalid = true;
                        ModelState.AddModelError("Card Number", "Card Number is Required !");                        
                    }
                    if (bill.Payment.CardCVV <= 0)
                    {
                        modelInvalid = true;
                        ModelState.AddModelError("Card CVV", "Card CVV is Required !");
                    }
                    if (bill.Payment.ValidMonth <= 0)
                    {
                        modelInvalid = true;
                        ModelState.AddModelError("Month", "Month is Required !");
                    }
                    if (bill.Payment.ValidYear <= 0)
                    {
                        modelInvalid = true;
                        ModelState.AddModelError("Year", "Year is Required !");
                    }
                    if (!modelInvalid)
                    {
                        bill = await _productSellRepo.ProductBillCreate(bill);
                        return Ok(bill);
                    }
                    else
                    {
                        return BadRequest(ModelState);
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Server Error !");
            }
        }
    }
}
