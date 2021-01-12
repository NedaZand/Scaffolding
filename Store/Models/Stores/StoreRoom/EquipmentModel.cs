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
    public class EquipmentModel : BaseModel
    {
        public EquipmentModel()
        {
            Units = new List<SelectListItem>();
            EquipmentTypes = new List<SelectListItem>();
        }

        [Required(ErrorMessage = "{0} الزامی است")]
        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [Display(Name = "تصویر")]
        [UIHint("Picture")]
        public int Image { get; set; }

        [Display(Name = "تعداد ")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "صرفا رقم وارد نمایید.")]
        public int Count { get; set; }

        [Display(Name = "وزن  تجهیز")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "صرفا رقم وارد نمایید.")]
        public int Weight { get; set; }

        [Display(Name = "حداقل موجودی تجهیز")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "صرفا رقم وارد نمایید.")]
        public int MinimumInventory { get; set; }

        [Display(Name = "حداقل موجودی به درصد")]
        [Required(ErrorMessage = "{0} الزامی است")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "صرفا رقم وارد نمایید.")]
        public int MinimumInventoryPercentage { get; set; }

        public string ImageUrl { get; set; }

        [Display(Name = "نوع ")]
        [Required(ErrorMessage = "{0} الزامی است")]
        public EquipmentType EquipmentType { get; set; }
        public string EquipmentTypeTitle { get; set; }

        [Display(Name = "لیست واحد ها")]
        public IList<SelectListItem> Units { get; set; }
        [Display(Name = "لیست انواع")]
        public IList<SelectListItem> EquipmentTypes { get; set; }

    }
}