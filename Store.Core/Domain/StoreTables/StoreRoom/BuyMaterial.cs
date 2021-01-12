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
    public class BuyMaterial : BaseEntity
    {
        
        [Display(Name = "تعداد خریداری شده")]
        public int Count { get; set; }

        [Display(Name = "قیمت")]
        public decimal Price{ get; set; }

        [Display(Name = "تاریخ خرید")]
        public DateTime? Date { get; set; }

        #region Relations

        [Required]
        [Display(Name = "تجهیز")]
        public int EquipmentId { get; set; }
        public virtual Equipment Equipment { get; set; }
        
        [Display(Name = "شرکت فروشنده ")]
        public int? CompanyStoreRoomId { get; set; }
        public CompanyStoreRoom Company { get; set; }
        
        [Display(Name = "واحد")]
        public int? UnitId { get; set; }

        #endregion Relations
    }
}
