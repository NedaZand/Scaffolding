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
    public class EquipmentHasPropertyModel : BaseModel
    {
        public EquipmentHasPropertyModel()
        {
            EquipmentList = new List<SelectListItem>();
            Properties = new List<SelectListItem>();
            PropertyId = new List<int>();
            Values = new List<decimal>();
            UnitId = new List<int?>();
            Units = new List<SelectListItem>();
        }

        [Required(ErrorMessage = "{0} الزامی است")]
        [Display(Name = "مقدار")]
        public IList<decimal> Values { get; set; }

        [Display(Name = "مقدار")]
        public decimal Value { get; set; }

        [Display(Name = "واحد")]
        public int? Unit{ get; set; }

        [Display(Name = "تجهیز")]
        [Required(ErrorMessage = "{0} الزامی است")]
        public int EquipmentId { get; set; }

        [Display(Name = "واحد")]
        [Required(ErrorMessage = "{0} الزامی است")]
        public IList<int?> UnitId { get; set; }
        public string UnitTitle { get; set; }

        [Display(Name = "ویژگی")]
        public IList<int> PropertyId { get; set; }
        public string PropertyTitle { get; set; }
        public string EquipmentTitle { get; set; }
        public IList<SelectListItem> EquipmentList { get; set; }
        [Display(Name = "لیست واحد ها")]
        public IList<SelectListItem> Units { get; set; }
        public IList<SelectListItem> Properties { get; set; }
    }
}
