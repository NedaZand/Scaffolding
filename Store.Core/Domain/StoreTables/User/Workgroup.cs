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
    public class Workgroup : BaseEntity
    {
        public Workgroup()
        {
            WorkingGroupPersonnels = new List<WorkingGroupPersonnel>();
        }
       
        [Required]
        [Display(Name ="عنوان")]
        public string Title { get; set; }

        #region Relations
        public virtual IList<WorkingGroupPersonnel> WorkingGroupPersonnels { get; set; }

        #endregion Relations

    }
}
