using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EF.Core.ShoppersStore.ShoppersStoreDB.Models;
using ServiceLib.ShoppersStore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http.Headers;
using ServiceLib.ShoppersStore.DTO;
using Microsoft.AspNetCore.Authorization;

namespace API.SS.Controllers
{
    [Authorize("Manager")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportRepository _reportRepo;

        public ReportController(IReportRepository reportRepo)
        {
            _reportRepo = reportRepo;
        }

        [HttpGet]
        [Route("productsWithImage")]
        public IActionResult GetProductsWithImage()
        {
            try
            {
                var allProducts = _reportRepo.GetProductsWithImage();
                return Ok(allProducts);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("monthlyStoreWise")]
        public IActionResult MonthlyStoreWise(MonthlyTotalSalesData data)
        {
            try
            {
                List<MonthlyTotalSalesData> datas = _reportRepo.MonthlyStoreWise(data);
                return Ok(datas);
            }
            catch (Exception ex)
            {
                return BadRequest("Invalid Data !");
            }
        }

        [HttpPost]
        [Route("monthlyProductWise")]
        public IActionResult MonthlyProductWise(YearlyProductWiseSalesData data)
        {
            try
            {
                List<YearlyProductWiseSalesData> datas = _reportRepo.MonthlyProductWise(data);
                return Ok(datas);
            }
            catch (Exception ex)
            {
                return BadRequest("Invalid Data !");
            }
        }

        [HttpPost]
        [Route("selectedProductWise")]
        public IActionResult SelectedProductWise(MonthlyProductWiseSalesData data)
        {
            try
            {
                List<MonthlyProductWiseSalesData> datas = _reportRepo.SelectedProductWise(data);
                return Ok(datas);
            }
            catch (Exception ex)
            {
                return BadRequest("Invalid Data !");
            }
        }
    }
}
