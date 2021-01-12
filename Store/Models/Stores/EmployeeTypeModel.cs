using Store.Essential;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Models.Stores
{
    public class EmployeeTypeModel:BaseModel
    {
        public EmployeeTypeModel()
        {
            EmployeeTypes = new List<SelectListItem>();
        }
        [Required(ErrorMessage = "{0} الزامی است")]
        [Display(Name = "عنوان همکاری")]
        public string Title { get; set; }

        public IList<SelectListItem> EmployeeTypes { get; set; }
    }
}