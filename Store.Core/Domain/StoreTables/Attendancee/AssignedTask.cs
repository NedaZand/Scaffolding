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
   public class AssignedTask : BaseEntity
    {

        [Display(Name = "تاریخ اختصاص")]
        public DateTime Date { get; set; }

        #region Relations
        

        [Display(Name = "کار روتین")]
        [ForeignKey("Routine")]
        public int RoutineId{ get; set; }
        public virtual Routine Routine { get; set; }
        
        public virtual ICollection<AssignedTaskUsers> Users { get; set; }

        #endregion Relations

    }
}
