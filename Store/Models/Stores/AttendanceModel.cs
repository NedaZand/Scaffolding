using Store.Core.Domain.StoreTables.Attendancee;
using Store.Core.Domain.StoreTables.User;
using Store.Essential;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Store.Models.Stores
{
   public class AttendanceModel : BaseModel
    {
        public AttendanceModel()
        {
            PresenceStatusList = new List<SelectListItem>();
            PersonnelList = new List<SelectListItem>();
            PersonnelCode = new List<int>();
        }

        [Required(ErrorMessage = " {0} الزامی است")]
        [Display(Name = "تاریخ ")]
        [UIHint("DateTime")]
        public DateTime? Date { get; set; }
        
        [Display(Name = "از تاریخ ")]
        [UIHint("DateTime2")]
        public DateTime? FromDate { get; set; }

        [Display(Name = "تا تاریخ ")]
        [UIHint("DateTime2")]
        public DateTime? ToDate { get; set; }
        public string  ShamsiDate { get; set; }
        
        [Display(Name = "ساعت ورود")]
        //[RegularExpression("^[0-9]*$", ErrorMessage = "صرفا رقم وارد نمایید.")]
        public TimeSpan? Time { get; set; }
        public string StringTime { get; set; }

        [Required(ErrorMessage = " {0} الزامی است")]
        [Display(Name = "نوع تردد")]
        public PresenceStatus? PresenceStatus { get; set; }

        public string PresenceStatusTitle { get; set; }

        [Required(ErrorMessage = " {0} الزامی است")]
        [Display(Name = "کد پرسنلی")]
        public IList<int> PersonnelCode { get; set; }
        public int? SinglePersonnelCode { get; set; }

        [Display(Name = "نام پرسنل")]
        public string FamilyName{ get; set; }

        [UIHint("Picture")]
        public int File { get; set; }
        public IList<SelectListItem> PresenceStatusList { get; set; }
        public IList<SelectListItem> PersonnelList { get; set; }
    }
}
