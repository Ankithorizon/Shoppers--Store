using System;
using System.Collections.Generic;
using System.Text;
using ServiceLib.ShoppersStore.DTO;

namespace ServiceLib.ShoppersStore.Interfaces
{
    public interface IProductSellRepository
    {
        BillDTO ProductBillCreate(BillDTO bill);
    }
}
