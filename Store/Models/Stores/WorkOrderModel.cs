using Store.Core.Domain.StoreTables.StoreRoom;
using Store.Core.Domain.StoreTables.Work;
using Store.Essential;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Models.Stores
{
    public class WorkOrderModel : BaseModel
    {
        public WorkOrderModel()
        {
            Companies = new List<SelectListItem>();
            Units = new List<SelectListItem>();
            Sections = new List<SelectListItem>();
            Statuses = new List<SelectListItem>();
            Types = new List<SelectListItem>();
            Priorities = new List<SelectListItem>();
            Scaffoldings = new List<SelectListItem>();
            Scaffolding = new Scaffolding();

        }
        [Required(ErrorMessage = "{0} الزامی است")]
        [Display(Name = "شماره درخواست")]
        public string Title { get; set; }

        [Display(Name = "شماره درخواست")]
        public string TitleSearch { get; set; }

        [Display(Name = "تگ")]
        public string TagSearch { get; set; }

        //[Required(ErrorMessage = "{0} الزامی است")]
        [Display(Name = "تگ")]
        public string Tag { get; set; }

        [Required(ErrorMessage = "{0} الزامی است")]
        [Display(Name = "تاریخ درخواست")]
        [UIHint("DateTime2")]
        public DateTime? Date { get; set; }


        [Display(Name = "تا")]
        [UIHint("DateTime2")]
        public DateTime? ToDate { get; set; }

        [Display(Name = "تاریخ درخواست از")]
        [UIHint("DateTime2")]
        public DateTime? FromDate { get; set; }
        public string ShamsiDate { get; set; }

        //[Required(ErrorMessage = "{0} الزامی است")]
        [Display(Name = "تاریخ انقضا")]
        [UIHint("DateTime2")]
        public DateTime? ExpireDate { get; set; }


        [Display(Name = "تاریخ انقضا از")]
        [UIHint("DateTime2")]
        public DateTime? FromExpireDate { get; set; }

        [Display(Name = "تا")]
        [UIHint("DateTime2")]
        public DateTime? ToExpireDate { get; set; }

        public string ShamsiExpireDate { get; set; }

        [Display(Name = "تاریخ شروع کار")]
        [UIHint("DateTime2")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "تاریخ پایان کار")]
        [UIHint("DateTime2")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "متراژ واقعی")]
        public int RealArea { get; set; }


        [Required(ErrorMessage = "{0} الزامی است")]
        [Display(Name = "اولویت")]
        public WorkOrderPriority? PriorityId { get; set; }
        public string PriorityTitle { get; set; }

        [Required(ErrorMessage = "{0} الزامی است")]
        [Display(Name = "وضعیت")]
        public WorkOrderStatus? Status { get; set; }
        public string StatusTitle { get; set; }

        [Display(Name = "شرکت")]
        [Required(ErrorMessage = "{0} الزامی است")]
        public int? CompanyId { get; set; }

        [Display(Name = "واحد")]
        public int? UnitId { get; set; }

        [Display(Name = "بخش")]
        public int? SectionId { get; set; }
        public string CompanyName { get; set; }
        public string SectionName { get; set; }
        public string UnitName { get; set; }

        [Required(ErrorMessage = "{0} الزامی است")]
        [Display(Name = "نوع")]
        public WorkOrderType? TypeId { get; set; }

        //[Required(ErrorMessage = "{0} الزامی است")]
        [Display(Name = "داربست")]
        public int? ScaffoldingId { get; set; }
        public string ScaffoldingTitle { get; set; }
        public string TypeTitle { get; set; }

        [Display(Name = "لیست شرکت ها")]
        public IList<SelectListItem> Companies { get; set; }

        [Display(Name = "لیست  واحد")]
        public IList<SelectListItem> Units { get; set; }

        [Display(Name = "لیست بخش")]
        public IList<SelectListItem> Sections { get; set; }

        [Display(Name = "لیست اولویت")]
        public IList<SelectListItem> Priorities { get; set; }

        [Display(Name = "لیست وضعیت")]
        public IList<SelectListItem> Statuses { get; set; }

        [Display(Name = "لیست انواع")]
        public IList<SelectListItem> Types { get; set; }

        [Display(Name = "لیست داربست")]
        public IList<SelectListItem> Scaffoldings { get; set; }
        public Scaffolding Scaffolding { get; set; }

    }
}