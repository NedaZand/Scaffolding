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
    public class PesonnelHasDetail : BaseEntity
    {

        #region Relations

        [ForeignKey("Personnel")]
        public int PersonnelCode { get; set; }
        public virtual Personnel Personnel { get; set; }

        [ForeignKey("Detail")]
        public int PersonnelDetailValueId { get; set; }
        public virtual PersonnelDetailValue Detail { get; set; }

        #endregion Relations

    }
}
