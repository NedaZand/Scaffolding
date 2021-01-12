using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Core;


namespace Store.Core.Domain.StoreTables.User
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {

            ApplicationRoles = new List<ApplicationRole>();
            //Permissions = new List<Permission>();
        }

        [InverseProperty("ApplicationUsers")]
        [Display(Name = "نقش کاربر")]
        public virtual ICollection<ApplicationRole> ApplicationRoles { get; set; }

        [Display(Name = "کد پرسنلی")]
        public string PersonnelCode { get; set; }

        [Display(Name = "وضعیت کاربر (کاربر را میتوان در یک زمان خاص از دسترسی به سیستم منع کرد)")]
        public bool UserStatus { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "تاریخ انقضا اکانت کاربر")]
        public DateTime? DateExpire { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        
    }
}
