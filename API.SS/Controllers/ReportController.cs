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
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportRepository _reportRepo;

        public ReportController(IReportRepository reportRepo)
        {
            _reportRepo = reportRepo;
        }

        [HttpPost]
        [Route("textReportMonthly")]
        public IActionResult TextReportMonthly(MonthlyTotalSalesData data)
        {
            try
            {
                List<MonthlyTotalSalesData> datas = _reportRepo.TextReportMonthly(data);
                return Ok(datas);
            }
            catch (Exception ex)
            {
                return BadRequest("Invalid Data !");
            }
        }
    }
}
