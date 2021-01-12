using Store.Core.Domain.StoreTables.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Domain.StoreTables.Work
{
    public enum WorkOrderPriority
    {
        [Display(Name = "انتخاب")]
        Unassigned,

        [Display(Name = "فوری")]
        Fast,

        [Display(Name = "عادی")]
        Normal,

       
    }
}
