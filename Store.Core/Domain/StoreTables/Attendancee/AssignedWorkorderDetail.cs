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
   public class AssignedWorkorderDetail : BaseEntity
    {
        public AssignedWorkorderDetail()
        {
            //WorkorderAssignedUsers = new List<WorkorderAssignedUsers>();
        }

        [Display(Name = "تاریخ فعالیت ")]
        public DateTime Date { get; set; }

        [Display(Name = "متراژ کل")]
        public int TotalArea { get; set; }
        [NotMapped]
        public WorkOrderStatus Status { get; set; }
        [NotMapped]
        public DateTime? StartDate { get; set; }
        [NotMapped]
        public DateTime? EndDate { get; set; }

        #region Relations

        public int WorkorderId { get; set; }

        [ForeignKey("WorkorderId")]
        public virtual WorkOrder Workorder { get; set; }
        public int CompanyId { get; set; }

        [Display(Name = "بخش")]
        public int? SectionId { get; set; }
        
        [Display(Name = "واحد")]
        public int? UnitId { get; set; }

        public virtual ICollection<WorkorderAssignedUsers> WorkorderAssignedUsers { get; set; }

        #endregion Relations

    }
}
