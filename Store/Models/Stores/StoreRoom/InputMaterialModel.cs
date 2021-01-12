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
    public class InputMaterialModel : BaseModel
    {
        public InputMaterialModel()
        {
          
            EquipmentList = new List<SelectListItem>();
            WorkOrderList = new List<SelectListItem>();
            Companies = new List<SelectListItem>();
            UnitList = new List<SelectListItem>();
            SectionList = new List<SelectListItem>();
            ScaffoldList = new List<SelectListItem>();
            Count = new List<int>();
            EquipmentId = new List<int>();
            DefectiveNumber = new List<int>();
        }
        
        public int OutputMaterialId { get; set; }

        [Display(Name = "تعداد وارد شده")]
        //[RegularExpression("^[0-9]*$", ErrorMessage = "صرفا رقم وارد نمایید.")]
        public List<int> Count { get; set; }

        [Display(Name = "تعداد معیوب شده")]
        //[RegularExpression("^[0-9]*$", ErrorMessage = "صرفا رقم وارد نمایید.")]
        public List<int> DefectiveNumber { get; set; }

        [Display(Name = "تعداد مفقود شده")]
        //[RegularExpression("^[0-9]*$", ErrorMessage = "صرفا رقم وارد نمایید.")]
        public int MissingNumber { get; set; }

        [Display(Name = "تعداد سالم")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "صرفا رقم وارد نمایید.")]
        public int HealthyNumber { get; set; }

        [Display(Name = "تاریخ ورود")]
        [UIHint("DateTime2")]
        [Required(ErrorMessage = "{0} الزامی است")]
        public DateTime? Date { get; set; }
        public string ShamsiDate { get; set; }

        [Required(ErrorMessage = "{0} الزامی است")]
        [Display(Name = "تجهیز")]
        public List<int> EquipmentId { get; set; }

        [Required(ErrorMessage = "{0} الزامی است")]
        [Display(Name = "شماره درخواست ")]
        public int WorkOrderId { get; set; }
        public string EquipmentName { get; set; }
        public List<int> Id2 { get; set; }

        [Display(Name = "شرکت/واحد/سکشن")]
        public int CompanyId { get; set; }

        [Display(Name = "بخش")]
        public int? SectionId { get; set; }

        [Display(Name = "داربست")]
        public int? ScaffoldingId { get; set; }

        [Display(Name = "واحد")]
        public int? UnitId { get; set; }
        public string WorkOrderTitle { get; set; }

        [Display(Name = "لیست تجهیزات")]
        public IList<SelectListItem> EquipmentList { get; set; }

        [Display(Name = "لیست دستور کار")]
        public IList<SelectListItem> WorkOrderList { get; set; }
        public IList<SelectListItem> Companies { get; set; }
        public IList<SelectListItem> UnitList { get; set; }
        public IList<SelectListItem> SectionList { get; set; }
        public IList<SelectListItem> ScaffoldList { get; set; }

    }
}
