using Store.Core.Domain.StoreTables.StoreRoom;
using Store.Core.Domain.StoreTables.Work;
using Store.Essential;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Models.Stores.StoreRoom
{
    public class ScaffoldModel : BaseModel
    {

        public ScaffoldModel()
        {
            Buildings = new List<SelectListItem>();
            WorkOrders = new List<SelectListItem>();
            ScaffoldTypes = new List<SelectListItem>();
            Earths = new List<SelectListItem>();
            PersonnelList = new List<SelectListItem>();
            WorkOrderModel = new WorkOrderModel();
            EquipmentList = new List<int>();
            KeshabiEquipmentList = new List<int>();
            PlateEquipmentList = new List<int>();
            BaseEquipmentList = new List<int>();
            Companies = new List<SelectListItem>();
            UnitList = new List<SelectListItem>();
            SectionList = new List<SelectListItem>();
        }
        [Required(ErrorMessage = "{0} الزامی است")]
        [Display(Name = "شماره داربست")]
        public string Title { get; set; }

        [Display(Name = "تگ")]
        public string Tag { get; set; }
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "{0} الزامی است")]
        [Display(Name = "تاریخ درخواست")]
        [UIHint("DateTime2")]
        public DateTime? Date { get; set; }
        public string ShamsiDate { get; set; }

        [Display(Name = "نام کارشناس")]
        public string ExpertName { get; set; }

        [Display(Name = "شماره پرمیت")]
        public string PermitNumber { get; set; }

        [Display(Name = "تاریخ ثبت تگ ایمنی")]
        public DateTime? RegistrationDate { get; set; }
        public string ShamsiRegistrationDate { get; set; }

        [Display(Name = "تاریخ انقضا")]
        [UIHint("DateTime2")]
        public DateTime? ExpireDate { get; set; }
        public string ShamsiExpireDate { get; set; }
        public string AlertExpireDate { get; set; }
        public string AlertRegisterTagDate { get; set; }

        [RegularExpression(@"^\d+(.\d{1,2})?$", ErrorMessage = "از اعداد معتبر استفاده نمائید")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [Display(Name = "عرض")]
        public double Width { get; set; }

        [RegularExpression(@"^\d+(.\d{1,2})?$", ErrorMessage = "از اعداد معتبر استفاده نمائید")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [Display(Name = "ارتفاع")]
        public double Height { get; set; }

        [RegularExpression(@"^\d+(.\d{1,2})?$", ErrorMessage = "از اعداد معتبر استفاده نمائید")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [Display(Name = "طول")]
        //[RegularExpression("^[0-9]*$", ErrorMessage = "صرفا رقم وارد نمایید.")]
        public double Length { get; set; }

        [Display(Name = "شرکت")]
        public int? CompanyId { get; set; }

        [Display(Name = "بخش")]
        public int? SectionId { get; set; }

        [Display(Name = "واحد")]
        public int? UnitId { get; set; }

        [Display(Name = "انقضا برچسب ایمنی")]
        [UIHint("DateTime2")]
        public DateTime? SafetyTagExpire { get; set; }
        public string ShamsiSafetyTagExpire { get; set; }

        [Display(Name = "نوع بنا")]
        [Required(ErrorMessage = "{0} الزامی است")]
        public int BuildingId { get; set; }
        public string BuildingTitle { get; set; }
        public IList<SelectListItem> Buildings { get; set; }

        [Display(Name = "تایید ")]
        public bool confirmed { get; set; }

        [Display(Name = "مجموع امتیازات")]
        public int TotalPoints { get; set; }

        //[Display(Name ="نوع متریال")]
        //public bool MaterialType { get; set; }

        [Display(Name = "نوع زمین")]
        [Required(ErrorMessage = "{0} الزامی است")]
        public int EarthId { get; set; }
        public string EarthTitle { get; set; }
        public IList<SelectListItem> Earths { get; set; }

        [Display(Name = "شماره درخواست ")]
        [Required(ErrorMessage = "{0} الزامی است")]
        public int WorkOrderId { get; set; }
        public string WorkOrderTitle { get; set; }
        public IList<SelectListItem> WorkOrders { get; set; }

        [Display(Name = "نوع داربست")]
        [Required(ErrorMessage = "{0} الزامی است")]
        public int ScaffoldTypeId { get; set; }
        public string ScaffoldTypeTitle { get; set; }

        [Display(Name = "تصویر")]
        [UIHint("Picture")]
        public int Image { get; set; }
        public IList<SelectListItem> ScaffoldTypes { get; set; }

        [Display(Name = "استادکار  ")]
        public int? PersonnelId { get; set; }
        public IList<SelectListItem> PersonnelList { get; set; }
        public WorkOrderModel WorkOrderModel { get; set; }
        public IList<int> EquipmentList { get; set; }

        public IList<int> KeshabiEquipmentList { get; set; }

        public IList<int> PlateEquipmentList { get; set; }

        public IList<int> BaseEquipmentList { get; set; }

        public IList<SelectListItem> Companies { get; set; }
        public IList<SelectListItem> UnitList { get; set; }
        public IList<SelectListItem> SectionList { get; set; }

        [Display(Name = "وضعیت داربست")]
        public string ScaffoldStates { get; set; }

    }

}