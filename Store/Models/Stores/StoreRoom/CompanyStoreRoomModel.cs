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
    public class CompanyStoreRoomModel : BaseModel
    {
        [Required(ErrorMessage = "{0} الزامی است")]
        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [Display(Name = "تلفن")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "صرفا رقم وارد نمایید.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "حداکثر طول تلفن 11 کاراکتر است !")]
        public string Phone { get; set; }

        [Display(Name = "آدرس")]
        public string Address { get; set; }

    }
}