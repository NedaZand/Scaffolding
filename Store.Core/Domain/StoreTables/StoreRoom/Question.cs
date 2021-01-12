using Store.Core.Domain.StoreTables.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Domain.StoreTables.StoreRoom
{
    public class Question : BaseEntity
    {
        [Required]
        [Display(Name = "متن سوال")]
        public string Text { get; set; }
        
        [Display(Name = "امتیاز ")]
        public int Score { get; set; }
        [NotMapped]
        public bool IsChecked { get; set; }

        [NotMapped]
        public int AnswerId { get; set; }

    }
}
