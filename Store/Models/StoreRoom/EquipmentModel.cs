using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Store.Core.Domain.StoreTables.StoreRoom;
using Store.Essential;

namespace Store.Models.StoreRoom
{
    public class EquipmentModel : BaseModel
    {
        public EquipmentModel()
        {
            Features = new List<SelectListItem>();
            Groups = new List<SelectListItem>();
            Types = new List<SelectListItem>();
            Units = new List<SelectListItem>();
        }
        

        [Required(ErrorMessage = "{0} الزامی است")]
        [Display(Name = "نام تجهیز")]
        public string Title { get; set; }

        [Required(ErrorMessage = "{0} الزامی است")]
        [Display(Name = "تاریخ ثبت")]
        [UIHint("DateTime2")]
        public DateTime? Date { get; set; }

       // [Required(ErrorMessage = "{0} الزامی است")]
        [Display(Name = "تاریخ خرید")]
        [UIHint("DateTime2")]
        public DateTime? ExpireDate { get; set; }

        public EquipmentGroup GroupId { get; set; }
        public string GroupTitle { get; set; }

        public EquipmentUnit UnitId { get; set; }
        public string UnitTitle { get; set; }

        public EquipmentType TypeId { get; set; }
        public string TypeTitle { get; set; }


        //Navigation

        [Display(Name = "نوع تجهیزات")]
        public IList<SelectListItem> Types { get; set; }

        [Display(Name = "واحد ها")]
        public IList<SelectListItem> Units { get; set; }

        [Display(Name = "گروه")]
        public IList<SelectListItem> Groups { get; set; }

        [Display(Name = "ویژگی ها")]
        public IList<SelectListItem> Features { get; set; }


    }
}