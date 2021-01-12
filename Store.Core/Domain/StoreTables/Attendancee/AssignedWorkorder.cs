using Store.Core.Domain.StoreTables.User;
using Store.Core.Domain.StoreTables.Work;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Domain.StoreTables.Attendancee
{
   public class AssignedWorkorder : BaseEntity
    {

        public AssignedWorkorder()
        {
            Details = new List<AssignedWorkorderDetail>();
        }
        [Display(Name = "تاریخ شروع")]
        public DateTime StartDate { get; set; }

        [Display(Name = "تاریخ پایان")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "متراژ واقعی")]
        public int RealArea { get; set; }

        #region Relations

        [Display(Name = "دستور کار ")]
        [ForeignKey("WorkOrder")]
        public int WorkOrderId { get; set; }
        public virtual WorkOrder WorkOrder { get; set; }
        public virtual ICollection<AssignedWorkorderDetail> Details { get; set; }

        #endregion Relations

    }
}
