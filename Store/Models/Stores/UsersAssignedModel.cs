using Store.Essential;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Models.Stores
{
    public class WorkorderAssignedUsersModel : BaseModel
    {
        
        [Display(Name ="کد پرسنلی")]
        public int PersonnelCode { get; set; }

        [Display(Name = "نام و نام خانوادگی ")]
        public string NameFamily { get; set; }

        [Display(Name = "متراژ")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "صرفا رقم وارد نمایید.")]
        public int Area { get; set; }
        public int DetailId { get; set; }

        [Display(Name = "عنوان گروه کاری")]
        public string WorkgroupTitle { get; set; }

        [Display(Name = "شماره دستور کار")]
        public string WorkorderTitle { get; set; }
    }
}