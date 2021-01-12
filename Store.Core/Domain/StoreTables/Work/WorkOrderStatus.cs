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
    public enum WorkOrderStatus
    {
        [Display(Name = "انتخاب")]
        Select,

        [Display(Name = "اجرا نشده یا تخصیص نیافته")]
        Unassigned,
        [Display(Name = "کنسل شده")]
        Cancel,
        [Display(Name = "تمام شده")]
        Finished,
        [Display(Name = "در حال اجرا")]
        InProcess,
      


    }
}
