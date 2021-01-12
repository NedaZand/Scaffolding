using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Store.Models.Account
{
    public class RegisterViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "ایمیل الزامی است")]
        //[DataType(DataType.EmailAddress, ErrorMessage = "ایمیل نامعتبر است")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "ایمیل نامعتبر است")]
        public string Email { get; set; }
        [Required(ErrorMessage = "نام کاربری الزامی است")]
     
        public string UserName { get; set; }
          [Required(ErrorMessage = "رمز عبور الزامی است")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "موبایل الزامی است")]
   
        [RegularExpression("^(\\+98|0)?9\\d{9}$", ErrorMessage = "موبایل نامعتبر است")]

        public string Mobile { get; set; }
      
        [Compare("Password", ErrorMessage = "رمزهای عبور یکسان نیستند")]
        public string ConfirmPassword { get; set; }
        [Display(Name ="کاربر آژانس")]
        public bool IsUserStore { get; set; }
        
    }
}