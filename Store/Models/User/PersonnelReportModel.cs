using Store.Core.Domain.StoreTables.User;
using Store.Essential;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Models.User
{
    public class PersonnelReportModel : BaseModel
    {
        public PersonnelReportModel()
        {
            Personnels = new List<SelectListItem>();
            Positions = new List<SelectListItem>();
            Employees = new List<SelectListItem>();
            Companies = new List<SelectListItem>();
            MaritalStatuses = new List<SelectListItem>();

        }

        [Display(Name = "کد پرسنلی")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "صرفا رقم وارد نمایید.")]
        public int? PersonnelCode { get; set; }
        
        [Display(Name = "نام و نام خانوادگی ")]
        public string UserNameFmaily { get; set; }

        [Display(Name = "تاریخ استخدام")]
        [UIHint("DateTime2")]
        public DateTime? DateEmployeement { get; set; }

        [Display(Name = "تاریخ استخدام تا")]
        [UIHint("DateTime2")]
        public DateTime? ToDateEmployeement { get; set; }
        public string ShamsiDateEmployeement { get; set; }

        [Display(Name = "تاریخ تولد")]
        [UIHint("DateTime2")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "تاریخ تولد")]
        [UIHint("DateTime2")]
        public DateTime? ToBirthDate { get; set; }
        public string ShamsiBirthDate { get; set; }

        
        [Display(Name = "پست سازمانی")]
        public int? PositionId { get; set; }
        public string PositionName { get; set; }

      
        [Display(Name = "نوع همکاری")]
        public int? EmployeeId { get; set; }
        public string EmployeeName { get; set; }

      
        [Display(Name = "کد ملی")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "صرفا رقم وارد نمایید.")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "حداکثر طول کد ملی 10 کاراکتر است !")]
        public string NationalCode { get; set; }

        [Display(Name = "وضعیت تاهل")]
        public MaritalStatus? MaritalStatus { get; set; }
        public string MaritalStatusTitle { get; set; }

        [Display(Name = "شرکت")]
        public int? CompanyId { get; set; }
        public string CompanyName { get; set; }
        [UIHint("Picture")]
        public int File { get; set; }
        public IList<SelectListItem> MaritalStatuses { get; set; }
        public IList<SelectListItem> Positions { get; set; }
        public IList<SelectListItem> Employees { get; set; }
        public IList<SelectListItem> Companies { get; set; }
        public IList<SelectListItem> Personnels { get; set; }

        [Display(Name = "تاریخ از")]
        [UIHint("DateTime2")]
        public DateTime? FromDate { get; set; }

        [Display(Name = "تاریخ تا")]
        [UIHint("DateTime2")]
        public DateTime? ToDate { get; set; }
    }

}
