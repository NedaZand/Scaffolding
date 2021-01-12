using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Essential;
using System.ComponentModel.DataAnnotations;

namespace Store.Models.StoreRoom
{
    public class EquipmentGroupModel : BaseModel
    {
        [Required(ErrorMessage = "{0} الزامی است")]
        [Display(Name = "نام گروه")]
        public string Title { get; set; }
    }
}