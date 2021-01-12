using Store.Core.Domain.StoreTables.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Domain.StoreTables.StoreRoom
{
    public enum EquipmentType
    {
        [Display(Name = "انتخاب")]
        Unknown = 0,

        [Display(Name = "سیستمی")]
        System = 1,

        [Display(Name = "سنتی")]
        Scaffold = 2,

    }
}
