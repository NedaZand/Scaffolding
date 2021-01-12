using Store.Core.Domain.StoreTables.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Domain.StoreTables.Attendancee
{
   public class Attendance:BaseEntity
    {
        [Required]
        [Display(Name = "تاریخ ورود")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "ساعت ورود")]
        public TimeSpan Time { get; set; }

        [Required]
        [Display(Name = "نوع تردد")]
        public PresenceStatus PresenceStatus { get; set; }
        //public virtual PresenceStatus PresenceStatus { get; set; }

        #region Relations
        
        
        [Display(Name = "کد پرسنلی")]

        [ForeignKey("Personnel")]
        public int PersonnelCode { get; set; }
        public virtual Personnel Personnel { get; set; }

        #endregion Relations

    }
}
