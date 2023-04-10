using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ServiceLib.ShoppersStore.DTO
{
    public class AddProductFile
    {
        public int ProductFileId { get; set; }
        [Required(ErrorMessage = "File Name is Required!")]
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public int ProductId { get; set; }
    }
}
