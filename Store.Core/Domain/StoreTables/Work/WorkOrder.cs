using Store.Core.Domain.StoreTables.StoreRoom;
using Store.Core.Domain.StoreTables.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Domain.StoreTables.Work
{
    public class WorkOrder : BaseEntity
    {
        [Required]
        [Display(Name = "شماره درخواست")]
        [Column(TypeName = "NVARCHAR")]
        //[StringLength(500)]
        //[Index("IX_Title",IsUnique =true)]
        public string Title { get; set; }

        //[Required]
        [Display(Name = "تگ")]
        public string Tag { get; set; }

        [Required]
        [Display(Name = "تاریخ درخواست")]
        public DateTime Date { get; set; }

        //[Required]
        [Display(Name = "تاریخ انقضا")]
        public DateTime? ExpireDate { get; set; }

        [Display(Name = "تاریخ شروع کار")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "تاریخ پایان کار")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "متراژ واقعی")]
        public int RealArea { get; set; }


        #region Relations


        [Display(Name = "شماره داربست ")]
        [ForeignKey("Scaffolding")]
        public int? ScaffoldingId { get; set; }
        public virtual Scaffolding Scaffolding { get; set; }

        [Required]
        [Display(Name = "شرکت یا مشتری")]
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        [Display(Name = "بخش")]
        [ForeignKey("Section")]
        public int? SectionId { get; set; }
        public virtual Company Section { get; set; }


        [Display(Name = "واحد")]
        [ForeignKey("Unit")]
        public int? UnitId { get; set; }
        public virtual Company Unit { get; set; }

        [Required]
        [Display(Name = "اولویت")]
        public WorkOrderPriority Priority { get; set; } = WorkOrderPriority.Unassigned;

        [Required]
        [Display(Name = "وضعیت")]
        public WorkOrderStatus Status { get; set; } = WorkOrderStatus.Unassigned;

        [Required]
        [Display(Name = "نوع")]
        public WorkOrderType TypeId { get; set; } = WorkOrderType.Unassigned;


        #endregion Relations


    }
}