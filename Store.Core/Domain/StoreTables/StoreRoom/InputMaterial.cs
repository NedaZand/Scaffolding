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
    public class InputMaterial : BaseEntity
    {
        
        [Display(Name = "تعداد وارد شده")]
        public int Count { get; set; }

        [Display(Name = "تعداد معیوب شده")]
        public int DefectiveNumber { get; set; }

        [Display(Name = "تعداد مفقود شده")]
        public int MissingNumber { get; set; }

        [Display(Name = "تعداد سالم")]
        public int HealthyNumber { get; set; }

        [Display(Name = "تاریخ ورود")]
        public DateTime? Date { get; set; }

        #region Relations

        [Required]
        [Display(Name = "تجهیز")]
        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EquipmentId { get; set; }
        public virtual Equipment Equipment { get; set; }

        [Required]
        [Display(Name = "خروجی")]
        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OutputMaterialId { get; set; }
        public virtual OutputMaterial OutputMaterial { get; set; }

        [Display(Name = "شماره درخواست ")]
        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WorkOrderId { get; set; }
        public virtual WorkOrder WorkOrder { get; set; }


        [Display(Name = "شماره داربست ")]
        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ScaffoldingId { get; set; }
        public virtual Scaffolding Scaffolding { get; set; }


        #endregion Relations
    }
}
