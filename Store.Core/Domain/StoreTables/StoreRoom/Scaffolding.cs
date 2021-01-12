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
    public class Scaffolding : BaseEntity
    {
        [Required]
        [Display(Name = "شماره داربست")]
        [Column(TypeName = "NVARCHAR")]
        [StringLength(500)]
        [Index("IX_Title", IsUnique = true)]
        public string Title { get; set; }

        [Display(Name = "نام کارشناس")]
        public string ExpertName { get; set; }

        [Display(Name = "شماره پرمیت")]
        public string PermitNumber { get; set; }

        [Display(Name = "تاریخ ثبت تگ ایمنی")]
        public DateTime? RegistrationDate { get; set; }

        [Display(Name = "تگ")]
        public string Tag { get; set; }

        [Required]
        [Display(Name = "تاریخ درخواست")]
        public DateTime Date { get; set; }

        [Display(Name = "تاریخ انقضا")]
        public DateTime? ExpireDate { get; set; }

        [Display(Name = "عرض")]
        public double Width { get; set; }

        [Display(Name = "ارتفاع")]
        public double Height { get; set; }

        [Display(Name = "طول")]
        public double Length { get; set; }

        [Display(Name = "انقضا برچسب ایمنی")]
        public DateTime? SafetyTagExpire { get; set; }

        [Display(Name = "تصویر")]
        public int? Image { get; set; }

        [Display(Name = "تایید شده")]
        public bool confirmed { get; set; } = false;

        [Display(Name = "مجموع امتیازات")]
        public int TotalPoints { get; set; }

        [Display(Name = "متراژ واقعی")]
        public int RealArea { get; set; }

        [Display(Name = "وضعیت داربست")]
        public ScaffoldStates ScaffoldStates { get; set; }


        #region Relations

        [Display(Name = "ساختمان")]
        [ForeignKey("Building")]
        public int BuildingId { get; set; }
        public virtual Building Building { get; set; }

        [Display(Name = "زمین")]
        [ForeignKey("Earth")]
        public int EarthId { get; set; }
        public virtual Earth Earth { get; set; }

        [Display(Name = "نوع داربست")]
        [ForeignKey("ScaffoldType")]
        public int ScaffoldTypeId { get; set; }
        public virtual ScaffoldType ScaffoldType { get; set; }

        [Display(Name = "استادکار  ")]
        [ForeignKey("Personnel")]
        public int? PersonnelCode { get; set; }
        public virtual Personnel Personnel { get; set; }
        [NotMapped]
        public int WorkOrderId { get; set; }
        #endregion Relations


    }
    public enum ScaffoldStates
    {
        [Display(Name = "ثبت شده")]
        Submited = 1,
        [Display(Name = "اختصاص متریال")]
        Material = 2,
        [Display(Name = "اختصاص نیرو")]
        Running = 3,
        [Display(Name = "تمام شده")]
        Finished = 4,
        [Display(Name = "ایمنی")]
        Secure = 5,
        [Display(Name = "منقضی شده")]
        Expire = 6,
        [Display(Name = "بازگشایی شده")]
        Opened = 7
    }
}
