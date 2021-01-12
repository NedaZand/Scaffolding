using Store.Essential;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Models.Stores
{
    public class CompanyModel : BaseModel
    {
        public CompanyModel()
        {
            Companies = new List<SelectListItem>();
            Sections = new List<SelectListItem>();
        }
        [Required(ErrorMessage = "{0} الزامی است")]
        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [Display(Name = "عنوان")]
        public string SectionTitle { get; set; }

        [Display(Name = "عنوان")]
        public string UnitTitle { get; set; }

        [Display(Name = "عنوان")]
        public string CompanyTitle { get; set; }

        //[Required(ErrorMessage = "{0} الزامی است")]
        [Display(Name = "آدرس")]
        public string Address { get; set; }

        [Display(Name = "شرکت")]
        public int CompanyId { get; set; }

        [Display(Name = "واحد")]
        public int UnitId { get; set; }

        [Display(Name = "عنوان شرکت")]
        public string ParentName{ get; set; }

        [Display(Name = "لیست شرکت ها")]
        public IList<SelectListItem> Companies { get; set; }

        [Display(Name = "لیست شرکت ها")]
        public IList<SelectListItem> Sections { get; set; }

    }
}