using Store.Essential;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Models.Stores
{
    public class AssignedWorkorderDetailModel : BaseModel
    {
        public AssignedWorkorderDetailModel()
        {
            Personnels = new List<SelectListItem>();
            UserIds = new List<int>();
            Workgroups = new List<SelectListItem>();
            WorkgroupIds = new List<string>();
            UserSelected = new List<string>();
        }

        [Display(Name = "عنوان دستور کار  ")]
        public string WorkorderTitle { get; set; }

        [Display(Name = "تاریخ فعالیت ")]
        [UIHint("DateTime")]
        [Required(ErrorMessage = "{0} الزامی است")]
        public DateTime? Date { get; set; }
        public string ShamsiDate { get; set; }

        [Display(Name = "متراژ کل")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "صرفا رقم وارد نمایید.")]
        public int TotalArea { get; set; }
        public int AssignedWorkorderId { get; set; }

        [Display(Name = "لیست کاربران تخصیص داده شده به دستور کار")]
        public IList<int> UserIds { get; set; }
        public IList<string> UserSelected { get; set; }

        [Display(Name = "لیست پرسنل ")]
        public IList<SelectListItem> Personnels { get; set; }

        [Display(Name = "لیست گروه کاری ")]
        public IList<SelectListItem> Workgroups { get; set; }

        [Display(Name = " گروه های کاری تخصیص داده شده به دستور کار")]
        public IList<string> WorkgroupIds { get; set; }

    }
}