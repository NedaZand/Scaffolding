using Store.Core.Domain.StoreTables.User;
using Store.Core.Domain.StoreTables.Work;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Domain.StoreTables.StoreRoom
{
    public class Message : BaseEntity
    {
        [Display(Name = "موضوع")]
        public string Subject { get; set; }
        
        [Display(Name = "محتوا")]
        public string Content { get; set; }

        [Display(Name = "تاریخ ارسال")]
        public DateTime SendTime { get; set; }

        [Display(Name = "تاریخ بازدید ")]
        public DateTime? SeenTime { get; set; }

        #region Relations

        [Display(Name = "داربست")]
        [ForeignKey("Scaffolding")]
        public int ScaffoldingId { get; set; }
        public virtual Scaffolding Scaffolding { get; set; }

        #endregion Relations
    }
}
