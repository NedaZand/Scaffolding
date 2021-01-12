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
   public class WorkorderAssignedUsers : BaseEntity
    {
       
        [Display(Name = "متراژ روزانه")]
        public int Area { get; set; }

        #region Relations

        [Required(ErrorMessage = "{0}الزامی است " )]
        [Display(Name = "کد پرسنلی")]
  
        public int PersonnelCode { get; set; }

        [ForeignKey("PersonnelCode")]
        public virtual Personnel Personnel { get; set; }

        [ForeignKey("Detail")]
        public int AssignedWorkorderDetailId { get; set; }
        public virtual AssignedWorkorderDetail Detail{ get; set; }

        [Display(Name = "دستور کار")]
        public int WorkorderId { get; set; }

        [Display(Name = "گروه کاری")]
        public int WorkgroupId { get; set; }

        [Display(Name = "پست سازمانی ")]
        public int? PositionTypeId { get; set; }

        [Display(Name = "استادکار ")]
        public bool IsMasterOfWork { get; set; }

        [Display(Name = "نوع همکاری")]
        public int? EmployeeTypeId { get; set; }

        #endregion Relations

    }
}
