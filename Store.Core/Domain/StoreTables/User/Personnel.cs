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
    public class Personnel 
    {
        public Personnel()
        {
            WorkingGroupPersonnels = new List<WorkingGroupPersonnel>();
            Attendances = new List<Attendancee.Attendance>();
        }
        [Display(Name = "کد پرسنلی")]
        [Required(ErrorMessage = "{0} الزامی است")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonnelCode { get; set; }

        [Required(ErrorMessage = "{0} الزامی است")]
        [Display(Name = "نام و نام خانوادگی")]
        public string UserNameFmaily { get; set; }

        [Display(Name = "وضعیت کاربر (کاربر را میتوان در یک زمان خاص از دسترسی به سیستم منع کرد)")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "تاریخ استخدام")]
        public DateTime? DateEmployeement { get; set; }

        [Display(Name = "وضعیت تاهل")]
        public MaritalStatus? MaritalStatus { get; set; }

        [Display(Name = "وضعیت حضور")]
        public PersonnelStatus? StatusPresence { get; set; }

        //[Required(ErrorMessage = "{0} الزامی است")]
        [Display(Name = "کد ملی")]
        public string NationalCode { get; set; }

        [Display(Name = "(تاریخ ایجاد( زمان جاری سیستم ")]
        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        [Display(Name = "(تاریخ ویرایش( زمان جاری سیستم ")]
        public DateTime? ModifiedDate { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Display(Name = "کاربری که عملیات ثبت انجام داده است")]
        public string ActionUserId { get; set; }

        [Display(Name = "آخرین کاربری که عملیات ویرایش انجام داده است")]
        public string LastEditUserId { get; set; }
        //[NotMapped]
        public virtual IList<WorkingGroupPersonnel> WorkingGroupPersonnels { get; set; }
        public virtual IList<Attendancee.Attendance> Attendances { get; set; }

        #region Relations

        [Display(Name = "پست سازمانی")]
        public int? PositionTypeId { get; set; }
        public virtual PositionType PositionType { get; set; }

        [Display(Name = "نوع همکاری")]
        public int? EmployeeTypeId { get; set; }
        public virtual EmployeeType EmployeeType { get; set; }

        [Display(Name = "شرکت")]
        public int? CompanyId { get; set; }
        public virtual Company Company { get; set; }

        #endregion Relations
    }
}
