using Store.Core.Domain.StoreTables.User;
using Store.Essential;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models.Stores
{
   public class AssignedTaskUsersModel : BaseModel
    {
        
        [Required(ErrorMessage = "{0}الزامی است " )]
        [Display(Name = "کد پرسنلی")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "صرفا رقم وارد نمایید.")]
        [ForeignKey("Personnel")]
        public int PersonnelCode { get; set; }
        public string NameFamily { get; set; }
        public int AssignedTaskId { get; set; }

       

    }
}
