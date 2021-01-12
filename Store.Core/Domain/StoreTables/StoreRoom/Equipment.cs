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
    public class Equipment : BaseEntity
    {
        public Equipment()
        {
            Properties = new List<EquipmentHasProperty>();
        }

        [Required]
        [Display(Name = "عنوان")]
        public string Title { get; set; }
        public string SystemName { get; set; }

        [Display(Name = "تصویر")]
        public int? Image { get; set; }

        [Display(Name = "وزن")]
        public int Weight { get; set; }

        [Display(Name = "  حداقل موجودی تجهیز به درصد")]
        public int MinimumInventoryPercentage { get; set; }

        [Display(Name = "  حداقل موجودی تجهیز  ")]
        public int MinimumInventory { get; set; }
        #region Relations

        [Display(Name = "نوع ")]
        public EquipmentType EquipmentType { get; set; }

        [Display(Name = "لیست ویژگی ها")]
        public virtual ICollection<EquipmentHasProperty> Properties { get; set; }


        #endregion Relations
    }
}
