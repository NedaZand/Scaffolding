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
   public class AssignedTaskUsers : BaseEntity
    {
        
        #region Relations

        [Required(ErrorMessage = "{0}الزامی است " )]
        [Display(Name = "کد پرسنلی")]
        [ForeignKey("Personnel")]
        public int PersonnelCode { get; set; }
        public virtual Personnel Personnel { get; set; }

        
        [ForeignKey("Task")]
        public int AssignedTaskId { get; set; }
        public virtual AssignedTask Task { get; set; }

        [Display(Name = "پست سازمانی ")]
        public int? PositionTypeId { get; set; }

        [Display(Name = "نوع همکاری")]
        public int? EmployeeTypeId { get; set; }
        #endregion Relations

    }
}
