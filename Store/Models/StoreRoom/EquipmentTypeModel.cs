using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Store.Models.StoreRoom
{
    public class EquipmentTypeModel
    {
        [Required(ErrorMessage = "{0} الزامی است")]
        [Display(Name = "عنوان")]
        public string Title { get; set; }
    }
}