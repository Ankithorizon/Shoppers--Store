using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Core.ShoppersStore.ShoppersStoreDB.Models
{
    public class Category
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Category Name is Required!")]
        public string CategoryName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
