using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLib.ShoppersStore.DTO
{
    public class BillDTO
    {
        public string BillRefCode { get; set; }
        public PaymentDTO Payment { get; set; }
        public CartDTO Cart { get; set; }
    }
}
