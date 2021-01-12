using Store.Core.Domain.StoreTables.Work;
using Store.Essential;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Models.Stores
{
    public class AssignedWorkorderModel : BaseModel
    {
        public AssignedWorkorderModel()
        {
            Companies = new List<SelectListItem>();
            Personnels = new List<SelectListItem>();
            Workgroups = new List<SelectListItem>();
            Works = new List<SelectListItem>();
            WorkgroupIds = new List<string>();
            UserSelected = new List<string>();
            RoutineModel = new AssignedRoutineModel();
        }

        [UIHint("DateTime2")]
        [Display(Name = "تاریخ شروع ")]
        public string StartDate { get; set; }


        [UIHint("DateTime3")]
        [Display(Name = "تاریخ شروع ")]
        public DateTime? EditStartDate { get; set; }

        [Display(Name = "تاریخ فعالیت ")]
        public string ShamsiDate { get; set; }

        [Display(Name = "تاریخ فعالیت ")]
        //[Required(ErrorMessage = "{0} الزامی است")]
        [UIHint("DateTime5")]
        public DateTime? Date { get; set; }
        
        [Display(Name = "تاریخ فعالیت ")]
        //[Required(ErrorMessage = "{0} الزامی است")]
        public string ActivityDate { get; set; }

        [Display(Name = "متراژ واقعی")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "صرفا رقم وارد نمایید.")]
        [Required(ErrorMessage = "{0} الزامی است")]
        public double RealArea { get; set; }

        [Display(Name = "متراژ روزانه")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "صرفا رقم وارد نمایید.")]
        public int TotalArea { get; set; }

        [UIHint("DateTime2")]
        [Display(Name = "تاریخ پایان ")]
        public string EndDate { get; set; }

        [UIHint("DateTime4")]
        [Display(Name = "تاریخ پایان ")]
        public DateTime? EidtEndDate { get; set; }

        public string ShamsiEndDate { get; set; }

        [Display(Name = "شرکت")]
        [Required(ErrorMessage = "{0} الزامی است")]        
        public int CompanyId { get; set; }

        [Display(Name = "بخش")]
        public int? SectionId { get; set; }

        [Display(Name = "واحد")]
        public int? UnitId { get; set; }

        [Display(Name = "عنوان شرکت")]
        public string ParentName { get; set; }

        [Display(Name = "لیست شرکت ها")]
        public IList<SelectListItem> Companies { get; set; }

        [Display(Name = "لیست پرسنل ")]

        public IList<SelectListItem> Personnels { get; set; }

        [Display(Name = "لیست گروه کاری ")]

        public IList<SelectListItem> Workgroups { get; set; }

        [Display(Name = "انتخاب پرسنل ")]
        public IList<int> UserIds { get; set; }

        [Display(Name = " انتخاب گروه های کاری")]
        public IList<string> WorkgroupIds { get; set; }

        [Display(Name = "لیست دستور کار")]
        public IList<SelectListItem> Works { get; set; }

        [Required(ErrorMessage = "{0} الزامی است")]
        [Display(Name = "انتخاب دستورکار")]
        public int WorkorderId { get; set; }

        public string WorkTitle { get; set; }

        public string CompanyTitle { get; set; }

        public string UnitTitle { get; set; }

        public string SectionTitle { get; set; }

        public string StatusName { get; set; }
        [Display(Name = " وضعیت")]
        public WorkOrderStatus Status { get; set; }

        public IList<string> UserSelected { get; set; }
        public AssignedRoutineModel RoutineModel { get; set; }
    }
}