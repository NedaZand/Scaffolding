using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Domain.StoreTables.StoreRoom
{
    public class inputMaterialHasEquipment : BaseEntity
    {
        public int InputMaterialId { get; set; }

        public int EquipmentId { get; set; }

        public int Count { get; set; }

        public int DefectiveNumber { get; set; }

        public int MissingNumber { get; set; }

        public int HealthyNumber { get; set; }

        public virtual Equipment Equipment { get; set; }
        public virtual InputMaterial InputMaterial { get; set; }

    }
}
