using Store.Essential;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Store.Models.Stores
{
    public class WorkOrderStatusModel : BaseModel
    {
        [Required(ErrorMessage = "{0} الزامی است")]
        [Display(Name = "عنوان")]
        public string Title { get; set; }

    }
}