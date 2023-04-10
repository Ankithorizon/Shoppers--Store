using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLib.ShoppersStore.DTO
{
    public class ProductFileAddResponse
    {
        public int ProductFileId { get; set; }
        public string ProductImage { get; set; }
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; } 
    }
}
