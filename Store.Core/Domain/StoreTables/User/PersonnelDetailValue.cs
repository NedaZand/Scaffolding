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
    public class PersonnelDetailValue : BaseEntity
    {
       
        [Display(Name ="مقدار")]
        public string Value { get; set; }

        #region Relations

        [ForeignKey("Detail")]
        public int PersonnelDetailId { get; set; }
        public virtual PersonnelDetail Detail { get; set; }

        #endregion Relations

    }
}
