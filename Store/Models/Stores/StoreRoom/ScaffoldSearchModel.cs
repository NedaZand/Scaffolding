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
    public class ScaffoldSearchModel : BaseModel
    {

        public ScaffoldSearchModel()
        {
            Buildings = new List<SelectListItem>();
            WorkOrders = new List<SelectListItem>();
            ScaffoldTypes = new List<SelectListItem>();
            Earths = new List<SelectListItem>();
        }

        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [Display(Name = "تگ")]
        public string Tag { get; set; }
        
        [Display(Name = "تاریخ درخواست از")]
        [UIHint("DateTime2")]
        public DateTime? FromDate { get; set; }

        [Display(Name = "تاریخ درخواست تا")]
        [UIHint("DateTime2")]
        public DateTime? ToDate { get; set; }

        [Display(Name = "تاریخ انقضا از")]
        [UIHint("DateTime2")]
        public DateTime? FromExpireDate { get; set; }

        [Display(Name = "تاریخ انقضا تا")]
        [UIHint("DateTime2")]
        public DateTime? ToExpireDate { get; set; }

        [Display(Name = "عرض")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "صرفا رقم وارد نمایید.")]
        public int? Width { get; set; }

        [Display(Name = "ارتفاع")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "صرفا رقم وارد نمایید.")]
        public int? Height { get; set; }

        [Display(Name = "طول")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "صرفا رقم وارد نمایید.")]
        public int? Lengthh { get; set; }

        [Display(Name = "انقضا برچسب ایمنی از")]
        [UIHint("DateTime2")]
        public DateTime? FromSafetyTagExpire { get; set; }

        [Display(Name = "انقضا برچسب ایمنی تا")]
        [UIHint("DateTime2")]
        public DateTime? ToSafetyTagExpire { get; set; }

        [Display(Name = "نوع ساختمان")]
        public int? BuildingId { get; set; }

        [Display(Name = "فاقد تگ ایمنی")]
        public bool NotTag { get; set; } = false;
        public IList<SelectListItem> Buildings { get; set; }

        [Display(Name = "نوع زمین")]
        public int? EarthId { get; set; }
        public IList<SelectListItem> Earths { get; set; }

        [Display(Name = "دستور کار")]
        public int? WorkOrderId { get; set; }
        public IList<SelectListItem> WorkOrders { get; set; }

        [Display(Name = "نوع داربست")]
        public int? ScaffoldTypeId { get; set; }
        public IList<SelectListItem> ScaffoldTypes { get; set; }



    }
}