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
    public class EmployeeType : BaseEntity
    {
       
        [Required]
        [Display(Name ="عنوان")]
        public string Title { get; set; }

        //#region Relations
        //public virtual ICollection<ApplicationUser> Users { get; set; }

        //#endregion Relations

    }
}
