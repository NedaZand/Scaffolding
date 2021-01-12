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
    public class Answer : BaseEntity
    { 
        [Display(Name = "مطلوب ")]
        [Required]
        public bool Desirable { get; set; }

        #region Relationships

        [Required]
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
        [Required]
        public int ScaffoldingId { get; set; }
        public virtual Scaffolding Scaffolding { get; set; }

        #endregion

    }
}
