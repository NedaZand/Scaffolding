using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Core.Domain.StoreTables.User;
using Store.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Store.Core.Domain.StoreTables
{
    public class WorkingGroupPersonnel : BaseEntity
    {

        #region Relations

        [Display(Name="گروه کاری")]
        [Required(ErrorMessage = "{0} الزامی است")]
        public int WorkgroupId { get; set; }
        public virtual Workgroup Workgroup { get; set; }

        [Display(Name = "پرسنل")]
        [Required(ErrorMessage = "{0} الزامی است")]
        public int PersonnelCode { get; set; }
        public virtual Personnel Personnel { get; set; }

        #endregion Relations

    }
}
