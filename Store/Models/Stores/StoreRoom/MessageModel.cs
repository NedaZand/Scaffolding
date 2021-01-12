using Store.Core.Domain.StoreTables.StoreRoom;
using Store.Core.Domain.StoreTables.Work;
using Store.Essential;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Models.Stores.StoreRoom
{
    public class MessageModel : BaseModel
    {
        public MessageModel()
        {
            Scaffoldings = new List<SelectListItem>();
        }

        [Display(Name = "موضوع")]
        public string Subject { get; set; }

        [Display(Name = "محتوا")]
        public string Content { get; set; }

        [Display(Name = "تاریخ ارسال")]
        public DateTime SendTime { get; set; }

        [Display(Name = "تاریخ بازدید ")]
        public DateTime? SeenTime { get; set; }

        [Display(Name = "داربست")]
        public int ScaffoldingId { get; set; }

        [Display(Name = "لیست داربست ")]
        public IList<SelectListItem> Scaffoldings { get; set; }

    }
}