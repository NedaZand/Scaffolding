using Store.Essential;
using System.ComponentModel.DataAnnotations;

namespace Store.Models.Stores.StoreRoom
{
    public class InputHasEquipmentModel : BaseModel
    {
        [Display(Name = "عنوان تجهیز")]
        public string Title { get; set; }

        [Display(Name = "تعداد")]
        public int Count { get; set; }

        [Display(Name = "تعداد معیوب شده")]
        public int DefectiveNumber { get; set; }

        [Display(Name = "تعداد مفقود شده")]
        public int MissingNumber { get; set; }

        [Display(Name = "تعداد سالم")]
        public int HealthyNumber { get; set; }


        [Display(Name = "تاریخ ورود")]
        public string EntryDate { get; set; }
    }
}
