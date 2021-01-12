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
    public class Stock 
    {
        
        [Display(Name = "موجودی آماده به کار هر تجهیز")]
        public int StockReady { get; set; }

        [Display(Name = "موجودی کل هر تجهیز")]
        public int TotalStock{ get; set; }

        [Display(Name = "موجودی معیوب هر تجهیز")]
        public int DefectiveNumberStock { get; set; }

        [Display(Name = "موجودی مفقود شده هر تجهیز")]
        public int MissingNumberStock { get; set; }

        [Display(Name = "موجودی اصلی")]
        public int MainStock { get; set; }
        [NotMapped]
        public string EquipmentTitle { get; set; }


        #region Relations

        [Required]
        [Display(Name = "تجهیز")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EquipmentId { get; set; }
        //public virtual Equipment Equipment { get; set; }

        #endregion Relations

    }
}
