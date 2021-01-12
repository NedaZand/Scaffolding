using Store.Core;
using Store.Core.Domain.StoreTables.User;
using Store.Core.Domain.StoreTables.Work;
using Store.Essential;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Store.Models.Stores.StoreRoom
{
    public class ScaffoldEquipmentModel : BaseModel
    {
        public ScaffoldEquipmentModel()
        {
            EquipmentList = new List<SelectListItem>();
            ScaffoldingList = new List<SelectListItem>();
            EquipmentId = new List<int>();
        }
        

        [Display(Name = "تجهیزات")]
        public IList<int> EquipmentId { get; set; }

        [Display(Name = "داربست")]
        public int ScaffoldingId { get; set; }
        public IList<SelectListItem> EquipmentList { get; set; }
        public IList<SelectListItem> ScaffoldingList { get; set; }
    }
}
