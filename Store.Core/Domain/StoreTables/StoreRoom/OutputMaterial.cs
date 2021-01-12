using Store.Core.Domain.StoreTables.Attendancee;
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
    public class OutputMaterial : BaseEntity
    {
        
        [Display(Name = "تعداد خارج شده")]
        public int Count { get; set; }

        [Display(Name = "تاریخ خروج")]
        public DateTime? Date { get; set; }

        #region Relations
        
        [Required]
        [Display(Name = "تجهیز")]
        [Key]
        [Column(Order = 2)]
        [ForeignKey("InstallEquipment")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EquipmentId { get; set; }
        public virtual Equipment InstallEquipment{ get; set; }

        [Required]
        [Display(Name = "شماره درخواست ")]
        [Key]
        [Column(Order = 3)]
        [ForeignKey("InstallWorkOrder")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WorkOrderId { get; set; }
        public virtual WorkOrder InstallWorkOrder { get; set; }
        
        [Display(Name = "شماره داربست ")]
        [Key]
        [Column(Order = 4)]
        [ForeignKey("Scaffolding")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ScaffoldingId { get; set; }
        public virtual Scaffolding Scaffolding { get; set; }

        #endregion Relations
    }
}
