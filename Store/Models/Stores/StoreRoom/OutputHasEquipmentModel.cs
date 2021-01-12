using Store.Essential;
using System.ComponentModel.DataAnnotations;

namespace Store.Models.Stores.StoreRoom
{
    public class OutputHasEquipmentModel : BaseModel
    {
        [Display(Name = "عنوان تجهیز")]
        public string Title { get; set; }

        [Display(Name = "تعداد")]
        public int Count { get; set; }
        
        [Display(Name = "تاریخ خروج")]
        public string ExitDate { get; set; }

    }
}
