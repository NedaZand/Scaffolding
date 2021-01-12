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
    public class BuySearchModel : BaseModel
    {
        public BuySearchModel()
        {
            CompanyList = new List<SelectListItem>();
            EquipmentList = new List<SelectListItem>();
        }

        [Display(Name = "تعداد خریداری شده")]
        public int Count { get; set; }

        [Display(Name = "قیمت")]
        public decimal? Price { get; set; }

        [Display(Name = "تاریخ خرید از")]
        [UIHint("DateTime2")]
        public DateTime? BuyDate { get; set; }

        [Display(Name = "تا")]
        [UIHint("DateTime2")]
        public DateTime? ToBuyDate { get; set; }

        [Display(Name = "تجهیز")]
        public int? EquipmentId { get; set; }
        public IList<SelectListItem> EquipmentList { get; set; }

        [Display(Name = "شرکت فروشنده ")]
        public int? CompanyStoreRoomId { get; set; }
        public IList<SelectListItem> CompanyList { get; set; }
    }
}