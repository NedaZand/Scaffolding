using Store.Core.Domain.StoreTables.Work;
using Store.Essential;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Models.User
{
    public class WorkgroupModel : BaseModel
    {
        public WorkgroupModel()
        {
            PersonnelList = new List<SelectListItem>();
            PersonnelIds = new List<int>();
            WorkgroupList = new List<SelectListItem>();
        }
        [Required(ErrorMessage = "{0} الزامی است")]
        [Display(Name = "عنوان")]
        public string Title { get; set; }
        [Display(Name = "اختصاص پرسنل")]
        public IList<int> PersonnelIds { get; set; }
        public IList<SelectListItem> PersonnelList { get; set; }
        public IList<SelectListItem> WorkgroupList { get; set; }

    }
}