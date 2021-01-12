using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Core.Domain.StoreTables.StoreRoom
{
    public class EquipmentFeature : BaseEntity
    {
        [Required]
        [Display(Name = " مقدار ویژگی")]
        public string Value { get; set; }
        public int EquipmentId { get; set; }
        public virtual Equipment Equipment { get; set; }
    }
}
