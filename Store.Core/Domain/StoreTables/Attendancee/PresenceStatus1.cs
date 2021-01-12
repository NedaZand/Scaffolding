using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Domain.StoreTables.Attendancee
{
  public  class PresenceStatus:BaseEntity
    {
        [Required]
        [Display(Name = "عنوان")]
        public string Title { get; set; }
        
    }
}
