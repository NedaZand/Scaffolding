using Store.Core.Domain.StoreTables.User;
using Store.Core.Domain.StoreTables.Work;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Domain.StoreTables.StoreRoom
{
    public class EquipmentHasProperty : BaseEntity
    {
        [Required]
        [Display(Name = "مقدار")]
        public decimal value { get; set; }

        #region Relations

        [Display(Name = "تجهیزات")]
        [ForeignKey("Equipment")]
        public int EquipmentId { get; set; }
        public virtual Equipment Equipment { get; set; }

        [Display(Name = "ویژگی")]
        [ForeignKey("Property")]
        public int PropertyId { get; set; }
        public virtual Property Property { get; set; }

        [Display(Name = "واحد")]
        [ForeignKey("Unit")]
        public int? UnitId { get; set; }
        public virtual Unit Unit { get; set; }

        #endregion Relations
    }
}
