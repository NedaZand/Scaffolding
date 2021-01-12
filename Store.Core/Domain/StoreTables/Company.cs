using Store.Core.Domain.StoreTables.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Domain.StoreTables
{
    public class Company : BaseEntity
    {
        [Required]
        [Display(Name = "عنوان")]
        [Column(TypeName = "NVARCHAR")]
        //[StringLength(500)]
        //[Index("IX_Title", IsUnique = true)]
        public string Title { get; set; }

        [Display(Name = "آدرس")]
        public string Address { get; set; }

        [Display(Name = "شرکت")]
        [ForeignKey("company")]
        public int? ParentID { get; set; }
        //public int ParentID { get; set; } = 0;
        public Company company { get; set; }
        //public virtual ICollection<ApplicationUser> Users { get; set; }

    }
}
