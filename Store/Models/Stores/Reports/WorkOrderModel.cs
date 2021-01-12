using Store.Core.Domain.StoreTables.Work;
using Store.Essential;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Models.Stores.Reports
{
    public class WorkOrderReportModel : BaseModel
    {
        public WorkOrderReportModel()
        {
            WorkOrders = new List<SelectListItem>();
         

        }
        
        [Display(Name = "تا تاریخ")]
        [UIHint("DateTime2")]
        public DateTime? ToDate { get; set; }

        [Display(Name = "از تاریخ")]
        [UIHint("DateTime2")]
        public DateTime? FromDate { get; set; }
       
        [Display(Name = "داربست")]
        public int? WorkOrderId { get; set; }
   
        [Display(Name = "لیست وضعیت")]
        public IList<SelectListItem> WorkOrders { get; set; }

    }
}