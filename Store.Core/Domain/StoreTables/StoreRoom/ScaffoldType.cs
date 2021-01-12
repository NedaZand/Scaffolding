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
    public class ScaffoldType : BaseEntity
    {
        [Required]
        [Display(Name = "عنوان")]
        public string Title { get; set; }
        public string SystemName { get; set; }

        [Display(Name = "تصویر")]
        public int Image { get; set; }
        
    }
}
