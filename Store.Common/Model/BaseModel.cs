using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Essential
{
    public class BaseModel
    {
        public int Id { get; set; }
        public string ShamsiCreateDate { get; set; }
        public string ShamsiEditDate { get; set; }
        public string ActionUserName { get; set; }
        public string EditUserName { get; set; }

        [Display(Name ="توضیحات")]
        public string Description { get; set; }

        [Display(Name = "این فیلد جهت کنترل سطح دسترسی استفاده می شود و داخل جدول ثبت نمی شود")]
        public bool NotAllow { get; set; }
    }

}


