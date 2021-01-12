using Store.Core.Domain.StoreTables.Work;
using Store.Essential;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Models.Stores
{
    public class WorkorderMaterialReportModel : BaseModel
    {
        public WorkorderMaterialReportModel()
        {
            Workorders = new List<SelectListItem>();
            Equipments = new List<SelectListItem>();

        }

        [Display(Name = "تا")]
        [UIHint("DateTime2")]
        public DateTime? ToDate { get; set; }

        [Display(Name = "تاریخ درخواست از")]
        [UIHint("DateTime2")]
        public DateTime? FromDate { get; set; }

        [Display(Name = "دستورکار")]
        public int? WorkorderId { get; set; }

        [Display(Name = "تجهیزات")]
        public int? EquipmentId { get; set; }

        [Display(Name = "لیست دستورکار ها")]
        public IList<SelectListItem> Workorders { get; set; }

        [Display(Name = "لیست تجهیزات")]
        public IList<SelectListItem> Equipments { get; set; }

    }
}