using Store.Core.Domain.StoreTables.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core
{
    public class BaseEntity
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id{ get; set; }

        [Display(Name = "(تاریخ ایجاد( زمان جاری سیستم ")]
        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        [Display(Name = "(تاریخ ویرایش( زمان جاری سیستم ")]
        public DateTime? ModifiedDate { get; set; }
        
        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Display(Name = "کاربری که عملیات ثبت را انجام داده است")]
        public string ActionUserId { get; set; }

        [Display(Name = "کاربری که عملیات ویرایش را انجام داده است")]
        public string LastActionUserId { get; set; }

        public bool IsDeletede { get; set; } = false;
        //[ForeignKey("ActionUserId")]
        //public virtual ApplicationUser ActionUser { get; set; }

    }
}
