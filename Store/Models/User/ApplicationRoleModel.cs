using Store.Essential;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Models.User
{
    public class ApplicationRoleModel:BaseModel
    {
        public ApplicationRoleModel()
        {
            Permissions = new List<PermissionModel>();
            PermissionId = new List<int>();
        }
        [Required(ErrorMessage = "عنوان  نقش الزامی است ! ")]
        [MaxLength(20, ErrorMessage = "حداکثر طول عنوان  20 کاراکتر است !")]
        [Display(Name = "عنوان نقش ")]
        public string Name { get; set; }
        public string RoleId { get; set; }

        [Display(Name = "فعال")]
        public bool IsActive { get; set; }

        [MaxLength(20, ErrorMessage = "حداکثر طول رشته 20 کاراکتر است")]
        [Display(Name = "عنوان فارسی گروه ")]
        public string PersianName { get; set; }
        public IList<PermissionModel> Permissions { get; set; }
        public IList<int> PermissionId { get; set; }
    }
}