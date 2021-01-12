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
    public class PositionType : BaseEntity
    {

        [Required]
        [Display(Name = "عنوان ")]
        [Column(TypeName = "NVARCHAR")]
        [StringLength(500)]
        [Index("IX_Title", IsUnique = true)]
        public string Title { get; set; }
        public string SystemName { get; set; }
        #region Relations
        public virtual IList<ApplicationUser> Users { get; set; }

        #endregion Relations

    }
}
