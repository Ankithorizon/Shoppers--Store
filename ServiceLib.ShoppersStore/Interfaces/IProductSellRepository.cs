using System;
using System.Collections.Generic;
using System.Text;
using ServiceLib.ShoppersStore.DTO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ServiceLib.ShoppersStore.Interfaces
{
    public interface IProductSellRepository
    {
        Task<BillDTO> ProductBillCreate(BillDTO bill);
    }
}
