using Store.Essential;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.Core.Domain.StoreTables.StoreRoom;
using Store.Models.Stores.StoreRoom;

namespace Store.Models.Stores
{
    public class QuestionModel : BaseModel
    {
        public QuestionModel()
        {

            QuestionList = new List<Question>();
            IdList = new List<int>();
            AnswerList = new List<int>();
            DescList = new List<string>();
            ScaffoldingList = new List<SelectListItem>();
            WorkOrders = new List<SelectListItem>();
            PersonnelList = new List<SelectListItem>();
            AnswerIds= new List<int>();
            ScaffoldModel = new ScaffoldModel();
        }
        
        [Display(Name = "لیست سوالات ")]
        public IList<Question> QuestionList { get; set; }

        [Display(Name = "لیست سوالات ")]
        public IList<int> IdList { get; set; }

        [Display(Name = "لیست سوالات ")]
        public IList<int> AnswerList { get; set; }
        public IList<int> AnswerIds { get; set; }

        [Display(Name = "لیست سوالات ")]
        public IList<string> DescList { get; set; }

        [Display(Name = "داربست  ")]
        [Required(ErrorMessage = "{0} الزامی است")]
        public int ScaffoldingId { get; set; }

        [Display(Name = "لیست داربست ")]
        public IList<SelectListItem> ScaffoldingList { get; set; }

        [Display(Name = "نام کارشناس")]
        [Required(ErrorMessage = "{0} الزامی است")]
        public string ExpertName { get; set; }

        [Display(Name = "شماره پرمیت")]
        public string PermitNumber { get; set; }

        [Display(Name = "تاریخ ثبت تگ ایمنی")]
        public DateTime? RegistrationDate { get; set; }

        [Display(Name = "استادکار  ")]
        [Required(ErrorMessage = "{0} الزامی است")]
        public int PersonnelId { get; set; }
        public IList<SelectListItem> PersonnelList { get; set; }

        [Display(Name = "شماره درخواست ")]
        [Required(ErrorMessage = "{0} الزامی است")]
        public int WorkOrderId { get; set; }
        public IList<SelectListItem> WorkOrders { get; set; }

        [Display(Name = "متراژ واقعی")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "صرفا رقم وارد نمایید.")]
        public int RealArea { get; set; }
        public string WorkOrderTitle { get; set; }
        public string Name { get; set; }
        public string CompanyTitle { get; set; }
        public string SectionTitle { get; set; }
        public string UnitTitle { get; set; }
        public string Tag { get; set; }
        public ScaffoldModel ScaffoldModel { get; set; }
    }
}