using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Store.Models.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="نام کاربری الزامی است")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "رمز عبور الزامی است")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public bool CheckoutAsGuest { get; set; }
    }
}