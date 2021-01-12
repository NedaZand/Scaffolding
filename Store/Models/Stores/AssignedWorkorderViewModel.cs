using Store.Core.Domain.StoreTables.Attendancee;
using Store.Essential;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace Store.Models.Stores
{
    public class AssignedWorkorderViewModel : BaseModel
    {
        public AssignedWorkorderViewModel()
        {

            Companies = new List<SelectListItem>();
            Personnels = new List<SelectListItem>();
            Workgroups = new List<SelectListItem>();
            Works = new List<SelectListItem>();
            RoutineModel = new List<AssignedRoutineModel>();
            StoredRoutineModel = new List<AssignedRoutineModel>();
            AssignedWorkorderModelList = new List<AssignedWorkorderModel>();
            Routins = new List<AssignedRoutineModel>();
            Statuses = new List<SelectListItem>();
        }

        public IList<SelectListItem> Companies { get; set; }
        public List<AssignedWorkorderModel> AssignedWorkorderModelList { get; set; }
        public AssignedWorkorderModel AssignedWorkorderModel { get; set; }

        [Display(Name = "لیست پرسنل ")]

        public IList<SelectListItem> Personnels { get; set; }

        [Display(Name = "لیست گروه کاری ")]

        public IList<SelectListItem> Workgroups { get; set; }


        [Display(Name = "لیست دستور کار")]
        public IList<SelectListItem> Works { get; set; }

        [Display(Name = "لیست کارهای روتین")]
        public IList<AssignedRoutineModel> Routins { get; set; }
        public IList<AssignedRoutineModel> RoutineModel { get; set; }
        public IList<AssignedRoutineModel> StoredRoutineModel { get; set; }
        public AssignedRoutineModel OneRoutineModel { get; set; }
        public IList<SelectListItem> Statuses { get; set; }

        [Display(Name = "دستورکار")]
        public int WorkorderId { get; set; }

        [Display(Name = "سکشن")]
        public int SectionId { get; set; }

        [Display(Name = "واحد  ")]
        public int UnitId { get; set; }
        public bool showTodayAssigned { get; set; }
        public PagedList.IPagedList<IGrouping<DateTime, AssignedWorkorderDetail>> Data2 { get; set; }
        public PagedList.IPagedList<IGrouping<DateTime, AssignedTask>> Data3 { get; set; }

        [Display(Name = "از تاریخ ")]
        [UIHint("DateTime2")]
        public DateTime? FromDate { get; set; }

        [Display(Name = "تا تاریخ ")]
        [UIHint("DateTime2")]
        public DateTime? ToDate { get; set; }
        public int StandbyPersonnel { get; set; }
        public int CurrentPersonnel { get; set; }
        public int ProjectPersonnel { get; set; }
        public int BulkyPersonnel { get; set; }
        public string RoutineTitle { get; set; }
        public int RoutineId { get; set; }

        [Display(Name = "تاریخ فعالیت")]
        public DateTime? ActivityDates { get; set; }

    }
}