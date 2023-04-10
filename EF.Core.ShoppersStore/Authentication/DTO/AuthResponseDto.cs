using System;
using System.Collections.Generic;
using System.Text;

namespace EF.Core.ShoppersStore.Authentication.DTO
{
    public class AuthResponseDto
    {
        public bool IsAuthSuccessful { get; set; }
        public string ErrorMessage { get; set; }
        public string Token { get; set; }
        public bool Is2StepVerificationRequired { get; set; }
        public string Provider { get; set; }
        public string UserName { get; set; }
        public string myRole { get; set; }
    }
}
