using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Domain.StoreTables.StoreRoom
{
    public class outputMaterialHasEquipment : BaseEntity
    {
        //[ForeignKey(nameof(OutputMaterial))]
        // [Column(Order = 2)]
        public int OutputMaterialId { get; set; }

        //[ForeignKey(nameof(Equipment))]
        //[Column(Order = 3)]
        public int EquipmentId { get; set; }

        public int Count { get; set; }

        public virtual Equipment Equipment { get; set; }
        public virtual OutputMaterial OutputMaterial { get; set; }

    }
}
