using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ServiceLib.ShoppersStore.DTO
{
    public class AddProductFile_
    {
        public string ProductId { get; set; }
        public IFormFile ProductFile { get; set; }
    }
}
