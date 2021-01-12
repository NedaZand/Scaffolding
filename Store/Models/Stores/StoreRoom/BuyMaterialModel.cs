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
    public class BuyMaterialModel : BaseModel
    {
        public BuyMaterialModel()
        {
            CompanyList = new List<SelectListItem>();
            EquipmentList = new List<SelectListItem>();
            SearchModel = new BuySearchModel();
            Units = new List<SelectListItem>();
        }

        [Display(Name = "تعداد خریداری شده")]
        public int Count { get; set; }

        [Display(Name = "قیمت")]
        public decimal Price { get; set; }
        public string PriceToString { get; set; }

        [Display(Name = "تاریخ خرید")]
        [Required(ErrorMessage = "{0} الزامی است")]
        [UIHint("DateTime2")]
        public DateTime? BuyDate { get; set; }

        [Display(Name = "تاریخ خرید از")]
        [UIHint("DateTime2")]
        public DateTime? FromBuyDate { get; set; }

        [Display(Name = " تاریخ خرید تا")]
        [UIHint("DateTime2")]
        public DateTime? ToBuyDate { get; set; }
        public string ShamsiBuyDate { get; set; }

        [Required(ErrorMessage = "{0} الزامی است")]
        [Display(Name = "تجهیز")]
        public int? EquipmentId { get; set; }
        public IList<SelectListItem> EquipmentList { get; set; }
        public string EquipmentName { get; set; }

        [Display(Name = "شرکت فروشنده ")]
        //[Required(ErrorMessage = "{0} الزامی است")]
        public int? CompanyStoreRoomId { get; set; }
        public IList<SelectListItem> CompanyList { get; set; }
        public string CompanyName { get; set; }
        public BuySearchModel SearchModel { get; set; }
        
        [Display(Name = "واحد")]
        public int? UnitId { get; set; }
        public string UnitTitle { get; set; }

        [Display(Name = "لیست واحد ها")]
        public IList<SelectListItem> Units { get; set; }
    }
}