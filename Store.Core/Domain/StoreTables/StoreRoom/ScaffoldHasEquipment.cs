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
    public class ScaffoldHasEquipment : BaseEntity
    {
        #region Relations

        [Display(Name = "تجهیزات")]
        [ForeignKey("Equipment")]
        public int EquipmentId { get; set; }
        public virtual Equipment Equipment { get; set; }

        [Display(Name = "داربست")]
        [ForeignKey("Scaffolding")]
        public int ScaffoldingId { get; set; }
        public virtual Scaffolding Scaffolding { get; set; }


        #endregion Relations
    }
}
