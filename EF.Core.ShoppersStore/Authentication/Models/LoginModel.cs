using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace EF.Core.ShoppersStore.Authentication.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "User Name is Required !")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is Required !")]
        public string Password { get; set; }
    }
}
