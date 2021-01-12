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
    public class OutputMaterialModel : BaseModel
    {
        public OutputMaterialModel()
        {
          
            EquipmentList = new List<SelectListItem>();
            WorkOrderList = new List<SelectListItem>();
            InputMaterialModel = new InputMaterialModel();
            Companies = new List<SelectListItem>();
            UnitList = new List<SelectListItem>();
            SectionList = new List<SelectListItem>();
            Count = new List<int>();
            EquipmentId = new List<int>();
        }
        
        [Display(Name = "تعداد خارج شده")]
        [Required(ErrorMessage = "{0} الزامی است")]
        public List<int> Count { get; set; } 

        [Display(Name = "تاریخ خروج")]
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
        public string WorkOrderTitle { get; set; }
        public string Id2 { get; set; }

        [Display(Name = "گروه کاری ")]
        public int AssignedWorkorderDetailId { get; set; }
        public int AssignedWorkorderId { get; set; }

        [Display(Name = "شرکت")]
        public int CompanyId { get; set; }

        [Display(Name = "بخش")]
        public int? SectionId { get; set; }

        [Display(Name = "واحد")]
        public int? UnitId { get; set; }

        [Display(Name = "لیست تجهیزات")]
        public IList<SelectListItem> EquipmentList { get; set; }

        [Display(Name = "لیست دستور کار")]
        public IList<SelectListItem> WorkOrderList { get; set; }

        public InputMaterialModel InputMaterialModel { get; set; }
        public IList<SelectListItem> Companies { get; set; }
        public IList<SelectListItem> UnitList { get; set; }
        public IList<SelectListItem> SectionList { get; set; }
    }
}
