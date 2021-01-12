using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Models.User
{
    public class PermissionModel
    {

        #region Constructor
        public PermissionModel()
        {
            Users = new List<SelectListItem>();
            Roles = new List<SelectListItem>();
        }
        #endregion Constructor
        #region Fields
        public bool IsChecked { get; set; }
        [Display(Name = "آی دی")]
        public int? Id { get; set; }
        [Display(Name = "شاخه")]
        public string Category { get; set; }
        [Display(Name = "نام سیستمی")]
        public string SystemType { get; set; }
        [Display(Name = "عنوان")]
        public string Title { get; set; }
        #region DropDowns
        [Display(Name = "کاربر")]
        public string UserId { get; set; }
        public string PersianCategoryame { get; set; }
        public List<SelectListItem> Users { get; set; }
        [Display(Name = "نقش")]
        public string RoleId { get; set; }
        public List<SelectListItem> Roles { get; set; }
        #endregion DropDowns
        #endregion Fields
    }
}