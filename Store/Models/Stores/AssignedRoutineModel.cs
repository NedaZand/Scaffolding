using Store.Essential;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Models.Stores
{
    public class AssignedRoutineModel : BaseModel
    {
        public AssignedRoutineModel()
        {
          
            Personnels = new List<SelectListItem>();
            Routines = new List<AssignedRoutineModel>();
            UserIds = new List<int>();
            UserSelected = new List<int>();
        }

        //[Required(ErrorMessage = "{0} الزامی است")]
        [UIHint("DateTime5")]
        [Display(Name = "تاریخ فعالیت")]
        public string Date { get; set; }

        [Display(Name = "تاریخ فعالیت")]
        public DateTime? EditDate { get; set; }

        [Display(Name = "تاریخ فعالیت")]
        public string ShamsiDate { get; set; }

        [Display(Name = "تاریخ فعالیت از")]
        [UIHint("DateTime2")]
        public DateTime? FromDate { get; set; }

        [UIHint("DateTime2")]
        [Display(Name = "تاریخ فعالیت تا")]
        public DateTime? ToDate { get; set; }

        [Display(Name = "لیست پرسنل ")]
        public IList<SelectListItem> Personnels { get; set; }

        [Display(Name = "انتخاب پرسنل")]
        public IList<int> UserIds { get; set; }

        [Display(Name = "لیست کارهای روتین")]
        public IList<AssignedRoutineModel> Routines { get; set; }

        [Display(Name = "انتخاب پرسنل")]
        public IList<int> RoutineUserIds { get; set; }

        [Required(ErrorMessage = "{0} الزامی است")]
        [Display(Name = "انتخاب روتین")]
        public int RoutineId { get; set; }

        public string RoutineTitle { get; set; }
        public IList<int> UserSelected { get; set; }

        [Display(Name = "انتخاب پرسنل")]
        public int? PersonnelCode { get; set; }
    }
}