using Store.Essential;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Models.User
{
    public class ApplicationUserModel:BaseModel
    {
        public ApplicationUserModel()
        {
            PersonnelList = new List<SelectListItem>();
            RoleSelected = new List<string>();
            Roles = new List<SelectListItem>();
        }
        [Required(ErrorMessage = "{0} الزامی است")]
        [Display(Name = "نام کاربری ")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "{0} الزامی است")]
        [Display(Name = "کد پرسنلی ")]

        public string PersonnelCode { get; set; }

        [Required(ErrorMessage = "{0} الزامی است")]
        [DataType(DataType.Password)]
        [Display(Name = "گذرواژه ")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تکرار گذرواژه")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "رمزعبور باهم مطابقت ندارند")]
        public  string ConfirmPassword { get; set; }
        
        [DataType(DataType.Password)]
        [Display(Name = "گذرواژه جدید ")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تکرار گذرواژه")]
        [System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessage = "رمزعبور باهم مطابقت ندارند")]
        public string ConfirmNewPassword { get; set; }

        [Display(Name = "تاریخ انقضاء")]
        [UIHint("DateTime2")]
        public DateTime? DateExpire { get; set; }
        public string ShamsiDateExpire { get; set; }

        [Display(Name = "فعال")]
        public bool UserStatus { get; set; } = true;
        public string  UserId { get; set; }
        public string RoleName { get; set; }

        [Required(ErrorMessage = "{0} الزامی است")]
        [Display(Name = "نقش کاربر")]
        public string RoleId { get; set; }
        public IList<string> RoleSelected { get; set; }
        public IList<SelectListItem> Roles { get; set; }
        public IList<SelectListItem> PersonnelList { get; set; }

    }
}