using Store.Service;
using Store.WebEssential.Mvc;
using System;
using System.Linq;
using System.Web.Mvc;
using Store.Service.Stores;
using Store.WebEssential.Helper;
using Store.Models.Stores;
using Microsoft.AspNet.Identity;
using Store.Core.Domain.StoreTables.Attendancee;
using System.Collections.Generic;
using System.Text;
using Store.Core.CommonHelper;
using Store.WebEssential.ModelBinder;
using Store.Core.Domain.StoreTables.Work;
using Store.Essential.Model;
using Store.WebEssential.UserControl;
using Store.Service.User;
using Store.WebEssential.Extensions;
using Store.Core.Domain.StoreTables;
using PagedList;
using Store.Core.Domain.StoreTables.StoreRoom;

namespace Store.Controllers
{
    [Authorize]
    public class AssignedTaskController : BaseController
    {
        #region Fields
        private readonly IAttendanceService _attendanceService;
        private readonly ICompanyService _companyService;
        private readonly IUserService _userService;
        private readonly IWorkOrderService _workOrderService;
        private readonly IPersonnelService _personnelService;
        private readonly IPositionTypeService _positionTypeService;
        private readonly IWorkgroupService _workgroupService;
        private readonly IRoutinService _routinService;
        private readonly IWorkorderAssignedUsersService _workorderAssignedUsersService;
        private readonly IAssignedWorkorderDetailService _workorderAssignedDetailService;
        private readonly IAssignedTaskService _assignedTaskService;
        private readonly IAssignedTaskUserService _assignedTaskUserService;
        private readonly ICheckingRole _checkingRoleService;
        private readonly IScaffoldingService _scaffoldingService;
        private readonly IAssignedWorkorderService _assignedWorkorderService;
        #endregion

        #region Ctor
        public AssignedTaskController(IAttendanceService attendanceService,
            ICompanyService companyService,
            IUserService userService,
            IWorkOrderService workOrderService,
            IPersonnelService personnelService,
            IPositionTypeService positionTypeService,
            IWorkgroupService workgroupService,
            IRoutinService routinService,
            IWorkorderAssignedUsersService workorderAssignedUsersService,
            IAssignedWorkorderDetailService workorderAssignedDetailService,
            IAssignedTaskService assignedTaskService,
            IAssignedTaskUserService assignedTaskUserService,
            ICheckingRole checkingRoleService,
            IScaffoldingService scaffoldingService,
            IAssignedWorkorderService assignedWorkorderService)
        {
            _attendanceService = attendanceService;
            _companyService = companyService;
            _userService = userService;
            _workOrderService = workOrderService;
            _personnelService = personnelService;
            _positionTypeService = positionTypeService;
            _workgroupService = workgroupService;
            _routinService = routinService;
            _workorderAssignedUsersService = workorderAssignedUsersService;
            _workorderAssignedDetailService = workorderAssignedDetailService;
            _assignedTaskService = assignedTaskService;
            _assignedTaskUserService = assignedTaskUserService;
            _checkingRoleService = checkingRoleService;
            _scaffoldingService = scaffoldingService;
            _assignedWorkorderService = assignedWorkorderService;
        }

        #endregion

        #region Utilities

        private double GetScaffoldSize(int workorderId, double area)
        {
            try
            {
                var getWorkorder = _workOrderService.GetById(workorderId);

                if (getWorkorder != null)
                {
                    if (getWorkorder.Scaffolding != null)
                    {
                        area = getWorkorder.Scaffolding.Length * getWorkorder.Scaffolding.Width * getWorkorder.Scaffolding.Height;
                    }
                    else
                    {
                        if (getWorkorder.ScaffoldingId.HasValue)
                        {
                            var getScaffolding = _scaffoldingService.GetById(getWorkorder.ScaffoldingId.Value);
                            area = getScaffolding.Length * getScaffolding.Width * getScaffolding.Height;
                        }

                    }
                }
            }
            catch (Exception)
            {

                area = 0;
            }

            return area;
        }

        [NonAction]
        protected virtual void PrepareAllCompaniesModel(AssignedWorkorderViewModel model, int? parentId = null)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            model.Companies.Add(new SelectListItem
            {
                Text = "انتخاب ",
                Value = " "
            });

            //var companies = SelectListHelper.GetCompanyList(_companyService);
            var companies = _companyService.GetAll(parentId: parentId);
            foreach (var c in companies)
            {
                model.Companies.Add(new SelectListItem
                {
                    Text = c.Title,
                    Value = c.Id.ToString()
                });
            }
        }

        [NonAction]
        protected virtual List<SelectListItem> PrepareAllPersonnelsModel()
        {
            var personnelList = new List<SelectListItem>();

            var attendanceList = _attendanceService.GetAll(DateTime.Now.Date, PresenceStatus.Entry);


            personnelList.Add(new SelectListItem
            {
                Text = "انتخاب پرسنل",
                Value = " "
            });
            var personnels = _personnelService.GetAll();

            //personnels = personnels
            //    .Where(w => attendanceList
            //    .Any(a => a.PersonnelCode == w.PersonnelCode)).ToList();

            foreach (var personnel in personnels)
            {
                personnelList.Add(new SelectListItem
                {
                    Text = personnel.PositionType != null ? $"{personnel.UserNameFmaily} - {personnel.PositionType.Title}" : personnel.UserNameFmaily,
                    Value = personnel.PersonnelCode.ToString()
                });
            }

            return personnelList;
        }

        [NonAction]
        protected virtual List<SelectListItem> PrepareAllWorkgroupsModel()
        {
            var workgroupList = new List<SelectListItem>();

            var attendanceList = _attendanceService.GetAll(DateTime.Now.Date, PresenceStatus.Entry);



            var workgroups = _workgroupService.GetAll();

            foreach (var workgroup in workgroups)
            {
                ///انتخاب گروه کاری که دارای پرسنل می باشد

                if (workgroup.WorkingGroupPersonnels.Count > 0)
                {
                    var personnels = workgroup.WorkingGroupPersonnels
                     .Where(w => attendanceList
                     .Any(a => a.PersonnelCode == w.PersonnelCode));

                    if (personnels.Count() > 0)
                    {
                        var personnelName = new StringBuilder();
                        foreach (var per in personnels)
                        {
                            personnelName.Append(per.Personnel.PositionType != null ? $"{per.Personnel.UserNameFmaily} - {per.Personnel.PositionType.Title}" : per.Personnel.UserNameFmaily);

                            //if (per.Personnel.StatusPresence == PersonnelStatus.Absent)
                            //    personnelName.Append("(عدم حضور)");

                            personnelName.Append(" - ");
                        }
                        var personnelID = new StringBuilder();

                        foreach (var per in personnels)
                        {
                            personnelID.Append(per.Personnel.PersonnelCode);
                            personnelID.Append(",");
                        }
                        workgroupList.Add(new SelectListItem
                        {
                            Text = $"{workgroup.Title}({personnelName.ToString()})",
                            Value = $"{ workgroup.Id.ToString()},{personnelID.ToString()}"
                        });
                    }



                }

            }

            return workgroupList;
        }


        [NonAction]
        protected virtual List<AssignedRoutineModel> PrepareAllRoutinsModel()
        {

            var routinList = new List<AssignedRoutineModel>();

            var routins = _routinService.GetAll();

            foreach (var c in routins)
            {
                routinList.Add(new AssignedRoutineModel
                {
                    RoutineTitle = c.Title,
                    RoutineId = c.Id
                });
            }
            return routinList;
        }

        [NonAction]
        protected virtual void PrepareAllWorkOrderModel(AssignedWorkorderViewModel model, int? companyID = null)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            var Companies = new List<Company>();
            var statuses = new List<WorkOrderStatus>();

            statuses.Add(WorkOrderStatus.InProcess);
            statuses.Add(WorkOrderStatus.Unassigned);

            model.Works.Add(new SelectListItem
            {
                Text = "انتخاب دستور کار",
                Value = " "
            });

            Companies = _companyService.GetAllCompaniesByParentCompanyId(companyID);
            if (companyID.HasValue)
                Companies.Add(_companyService.GetById(companyID.Value));


            var works = _workOrderService.GetAll(companies: Companies, date: DateTime.Now, status: new WorkOrderStatus[] { WorkOrderStatus.InProcess, WorkOrderStatus.Unassigned, WorkOrderStatus.Select }, showTodayAssigned: true).Where(x => x.ScaffoldingId.HasValue).ToList();
            works = works.Where(d => d.Scaffolding.ScaffoldStates == ScaffoldStates.Material || d.Scaffolding.ScaffoldStates == ScaffoldStates.Running).ToList();
            foreach (var c in works)
            {
                model.Works.Add(new SelectListItem
                {
                    Text = c.Title,
                    Value = c.Id.ToString()
                });
            }

        }

        [NonAction]
        protected virtual void PrepareAllStatusModel(WorkOrderModel model)
        {

            model.Statuses = WorkOrderStatus.Select.ToSelectList().ToList();
            //if (model == null)
            //    throw new ArgumentNullException("model");

            //model.Statuses.Add(new SelectListItem
            //{
            //    Text = "[None]",
            //    Value = " "
            //});
            //var statuses =_workorderStatusService.GetAll();
            //foreach (var c in statuses)
            //    model.Statuses.Add(new SelectListItem
            //    {
            //        Text = c.Title,
            //        Value = c.Id.ToString()
            //    });
        }


        #endregion


        #region List
        [HttpGet]
        public JsonResult RoutinList(DataTableRequest request, [ModelBinder(typeof(DataTableModelBinder))] DataTableRequestFilter filter, AssignedRoutineModel model)

        {
            if (request.length == -1)
            {
                request.length = int.MaxValue;
            }



            var data = _assignedTaskService.FilterData(request.start, request.length, filter.Search, filter.SortColumn, filter.SortDirection, model.FromDate, model.ToDate, model.RoutineId, model.PersonnelCode);


            var gridModel = new DataTableResponse<AssignedRoutineModel>()
            {
                data = data.Select(x =>
                {

                    var m = new AssignedRoutineModel();
                    m.ShamsiDate = ConvertAdToJalali(x.Date);
                    m.ShamsiCreateDate = ConvertAdToJalaliDateTime(x.CreatedDate.Value);
                    m.RoutineTitle = x.Routine.Title;
                    m.ActionUserName = _userService.GetById(x.ActionUserId).UserName;
                    m.Id = x.Id;

                    if (x.ModifiedDate != null)
                    {
                        m.ShamsiEditDate = ConvertAdToJalaliDateTime(x.ModifiedDate.Value);
                    }
                    if (x.LastActionUserId != null && !string.IsNullOrEmpty(x.LastActionUserId))
                    {
                        m.EditUserName = _userService.GetById(x.LastActionUserId).UserName;
                    }


                    return m;
                }).ToList(),
                recordsTotal = _assignedTaskService.Count(filter.Search, model.FromDate, model.ToDate, model.RoutineId, model.PersonnelCode),
                recordsFiltered = _assignedTaskService.Count(filter.Search, model.FromDate, model.ToDate, model.RoutineId, model.PersonnelCode),
                draw = request.draw
            };

            return Json(gridModel, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult WorkOrderList(DataTableRequest request, [ModelBinder(typeof(DataTableModelBinder))] DataTableRequestFilter filter)

        {
            if (request.length == -1)
            {
                request.length = int.MaxValue;
            }
            var data = _workOrderService.FilterData(request.start, request.length, filter.Search, filter.SortColumn, filter.SortDirection, status: WorkOrderStatus.InProcess);


            var gridModel = new DataTableResponse<AssignedWorkorderModel>()
            {
                data = data.Select(x =>
                {

                    var m = new AssignedWorkorderModel();
                    if (x.StartDate.HasValue)
                        m.ShamsiDate = ConvertAdToJalali(x.StartDate.Value);
                    if (x.EndDate.HasValue)
                        m.ShamsiEndDate = ConvertAdToJalali(x.EndDate.Value);
                    m.ShamsiCreateDate = ConvertAdToJalaliDateTime(x.CreatedDate.Value);
                    m.WorkTitle = x.Title;
                    m.RealArea = x.RealArea;
                    m.ParentName = _companyService.GetById(x.CompanyId).GetFormattedBreadCrumb(_companyService);
                    m.StatusName = x.Status.GetDisplayName();
                    m.ActionUserName = _userService.GetById(x.ActionUserId).UserName;
                    m.Id = x.Id;

                    if (x.ModifiedDate != null)
                    {
                        m.ShamsiEditDate = ConvertAdToJalaliDateTime(x.ModifiedDate.Value);
                    }
                    if (x.LastActionUserId != null && !string.IsNullOrEmpty(x.LastActionUserId))
                    {
                        m.EditUserName = _userService.GetById(x.LastActionUserId).UserName;
                    }


                    return m;
                }).ToList(),
                recordsTotal = _workOrderService.Count(status: WorkOrderStatus.InProcess),
                recordsFiltered = _workOrderService.Count(status: WorkOrderStatus.InProcess),
                draw = request.draw
            };



            return Json(gridModel, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult WorkOrderList2(DataTableRequest request, [ModelBinder(typeof(DataTableModelBinder))] DataTableRequestFilter filter)

        {
            if (request.length == -1)
            {
                request.length = int.MaxValue;
            }
            var data = _workOrderService.FilterData(request.start, request.length, filter.Search, filter.SortColumn, filter.SortDirection, status: WorkOrderStatus.InProcess);


            var gridModel = new DataTableResponse<AssignedWorkorderModel>()
            {
                data = data.Select(x =>
                {

                    var m = new AssignedWorkorderModel();
                    if (x.StartDate.HasValue)
                        m.ShamsiDate = ConvertAdToJalali(x.StartDate.Value);
                    if (x.EndDate.HasValue)
                        m.ShamsiEndDate = ConvertAdToJalali(x.EndDate.Value);
                    m.ShamsiCreateDate = ConvertAdToJalaliDateTime(x.CreatedDate.Value);
                    m.WorkTitle = x.Title;
                    m.RealArea = x.RealArea;
                    m.ParentName = _companyService.GetById(x.CompanyId).GetFormattedBreadCrumb(_companyService);
                    m.StatusName = x.Status.GetDisplayName();
                    m.ActionUserName = _userService.GetById(x.ActionUserId).UserName;
                    m.Id = x.Id;

                    if (x.ModifiedDate != null)
                    {
                        m.ShamsiEditDate = ConvertAdToJalaliDateTime(x.ModifiedDate.Value);
                    }
                    if (x.LastActionUserId != null && !string.IsNullOrEmpty(x.LastActionUserId))
                    {
                        m.EditUserName = _userService.GetById(x.LastActionUserId).UserName;
                    }


                    return m;
                }).ToList(),
                recordsTotal = _workOrderService.Count(status: WorkOrderStatus.InProcess),
                recordsFiltered = _workOrderService.Count(status: WorkOrderStatus.InProcess),
                draw = request.draw
            };



            return Json(gridModel, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult PersonnelList(DataTableRequest request, [ModelBinder(typeof(DataTableModelBinder))] DataTableRequestFilter filter, int assignedTaskId = 0)

        {
            if (request.length == -1)
            {
                request.length = int.MaxValue;
            }
            var data = _assignedTaskUserService.FilterData(request.start, request.length, filter.Search, filter.SortColumn, filter.SortDirection, assignedTaskId: assignedTaskId);


            var gridModel = new DataTableResponse<AssignedTaskUsersModel>()
            {
                data = data.Select(x =>
                {

                    var m = new AssignedTaskUsersModel();
                    m.PersonnelCode = x.PersonnelCode;
                    m.NameFamily = x.Personnel.UserNameFmaily;
                    m.Id = x.Id;


                    return m;
                }).ToList(),
                recordsTotal = _workorderAssignedUsersService.Count(assignedTaskId),
                recordsFiltered = _workorderAssignedUsersService.Count(assignedTaskId),
                draw = request.draw
            };



            return Json(gridModel, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult List(int page = 1)
        {
            var model = new AssignedWorkorderViewModel();


            return View(model);
        }
        [HttpGet]
        public ActionResult List2(int page = 1)
        {
            var model = new AssignedWorkorderViewModel();


            return View(model);
        }

        public ActionResult getAssignedWorkorderList(DateTime? fromDate = null, DateTime? toDate = null)
        {
            var model = new AssignedWorkorderViewModel();
            if (!fromDate.HasValue)
                model.FromDate = DateTime.Now;
            else
                model.FromDate = fromDate;
            //model.ToDate = toDate;
            var getAssignedWorkorderList = _workorderAssignedDetailService.GetAll(fromDate: fromDate);

            ///بدست آوردن لیست گروه کاری که دارای پرسنل می باشند
            model.Workgroups = PrepareAllWorkgroupsModel();

            foreach (var item in getAssignedWorkorderList)
            {
                var m = new AssignedWorkorderModel();
                var getWorkOrder = _workOrderService.GetById(item.WorkorderId);

                var getGroups = item.WorkorderAssignedUsers.GroupBy(x => x.WorkgroupId);
                m.WorkorderId = item.WorkorderId;
                m.CompanyId = getWorkOrder.CompanyId;
                m.SectionId = getWorkOrder.SectionId;
                m.UnitId = getWorkOrder.UnitId;
                m.TotalArea = item.TotalArea;
                m.EditStartDate = getWorkOrder.StartDate;
                m.EidtEndDate = getWorkOrder.EndDate;
                m.RealArea = GetScaffoldSize(item.WorkorderId, m.RealArea);
                m.Date = item.Date;
                m.WorkTitle = getWorkOrder.Title;
                m.Status = getWorkOrder.Status;
                m.Id = item.Id;
                if (getWorkOrder.CompanyId != 0)
                    m.CompanyTitle = _companyService.GetById(getWorkOrder.CompanyId).Title;
                if (getWorkOrder.UnitId.HasValue)
                    m.UnitTitle = _companyService.GetById(getWorkOrder.UnitId.Value).Title;

                if (getWorkOrder.SectionId.HasValue)
                    m.SectionTitle = _companyService.GetById(getWorkOrder.SectionId.Value).Title;


                foreach (var groups in item.WorkorderAssignedUsers.GroupBy(x => x.WorkgroupId))
                {
                    var personnelID = new StringBuilder();


                    personnelID.Append(groups.Key);

                    personnelID.Append(",");

                    foreach (var group in groups)
                    {

                        personnelID.Append(group.PersonnelCode);
                        personnelID.Append(",");


                    }

                    m.UserSelected.Add(personnelID.ToString());




                }
                if (model.Workgroups.Count() == 0)
                {
                    foreach (var groups in item.WorkorderAssignedUsers.GroupBy(x => x.WorkgroupId))
                    {
                        var personnelName = new StringBuilder();
                        var personnelID = new StringBuilder();


                        foreach (var group in groups)
                        {

                            personnelName.Append(group.Personnel.PositionType != null ? $"{group.Personnel.UserNameFmaily} - {group.Personnel.PositionType.Title}" : group.Personnel.UserNameFmaily);
                            personnelName.Append("-");

                            personnelID.Append(group.Personnel.PersonnelCode);
                            personnelID.Append(",");

                        }
                        m.Works.Add(new SelectListItem
                        {
                            Text = $"{_workgroupService.GetById(Convert.ToInt32(groups.Key)).Title}({personnelName.ToString()})",
                            Value = $"{ groups.Key.ToString()},{personnelID.ToString()}"
                        });

                    }

                }

                else
                    m.Works = model.Workgroups;

                model.AssignedWorkorderModelList.Add(m);
            }


            ///آماده سازی لیست وضعیت
            model.Statuses = WorkOrderStatus.Select.ToSelectList().ToList();

            return PartialView("_WorkorderList", model);
        }


        public ActionResult getAssignedRoutinList(DateTime? fromDate = null)
        {
            var model = new AssignedWorkorderViewModel();
            model.FromDate = fromDate;
            //model.ToDate = toDate;

            var getAssignedRoutinList = _assignedTaskService.GetAll(fromDate);

            foreach (var item in getAssignedRoutinList)
            {

                var m = new AssignedRoutineModel();
                var getRoutin = _routinService.GetById(item.RoutineId);

                var getPersonnels = item.Users.ToList();
                m.RoutineId = item.Id;
                m.EditDate = item.Date;
                m.ShamsiDate = ConvertAdToJalali(item.Date);
                m.RoutineTitle = getRoutin.Title;

                foreach (var personnel in getPersonnels)
                {

                    m.UserSelected.Add(personnel.PersonnelCode);
                    m.Personnels.Add(new SelectListItem
                    {
                        Text = personnel.Personnel.UserNameFmaily,
                        Value = personnel.PersonnelCode.ToString()
                    });

                }


                model.RoutineModel.Add(m);
            }

            ///بدست آوردن لیست پرسنل
            model.Personnels = PrepareAllPersonnelsModel();
            //model.Data3 = _assignedTaskService.GetAll(fromDate: fromDate, toDate: toDate).ToPagedList(page, 1);

            return PartialView("_RoutinList", model);
        }

        #endregion

        public ActionResult Index()
        {
            if (!_checkingRoleService.HasAccess(PermissionList.AssignedTaskList, CurrentUser.GetCurrentUser))
            {

                return View("Inaccessibility");
            }

            return View();
        }

        public ActionResult Create(DateTime? ActivityDate)
        {

            if (!_checkingRoleService.HasAccess(PermissionList.AssignedTaskCreate, CurrentUser.GetCurrentUser))
            {
                return PartialView("Inaccessibility");
            }



            var model = new AssignedWorkorderViewModel();
            if (!ActivityDate.HasValue)
                model.FromDate = DateTime.Now;
            else
                model.FromDate = ActivityDate;
            model.Personnels = PrepareAllPersonnelsModel();
            // ///بدست آوردن لیست کارهای روتین
            model.Routins = PrepareAllRoutinsModel();

            foreach (var item in model.Routins)
            {
                item.Personnels = PrepareAllPersonnelsModel();
            }
            //model.ToDate = toDate;
            var getAssignedWorkorderList = _workorderAssignedDetailService.GetAll(fromDate: model.FromDate);

            ///بدست آوردن لیست گروه کاری که دارای پرسنل می باشند
            model.Workgroups = PrepareAllWorkgroupsModel();

            foreach (var item in getAssignedWorkorderList)
            {
                var m = new AssignedWorkorderModel();
                var getWorkOrder = _workOrderService.GetById(item.WorkorderId);

                var getGroups = item.WorkorderAssignedUsers.GroupBy(x => x.WorkgroupId);
                m.WorkorderId = item.WorkorderId;
                m.CompanyId = getWorkOrder.CompanyId;
                m.SectionId = getWorkOrder.SectionId;
                m.UnitId = getWorkOrder.UnitId;
                m.TotalArea = item.TotalArea;
                m.EditStartDate = getWorkOrder.StartDate;
                m.EidtEndDate = getWorkOrder.EndDate;
                m.RealArea = GetScaffoldSize(item.WorkorderId, m.RealArea);
                m.Date = item.Date;
                m.WorkTitle = getWorkOrder.Title;
                m.Status = getWorkOrder.Status;
                m.Id = item.Id;
                if (getWorkOrder.CompanyId != 0)
                    m.CompanyTitle = _companyService.GetById(getWorkOrder.CompanyId).Title;
                if (getWorkOrder.UnitId.HasValue)
                    m.UnitTitle = _companyService.GetById(getWorkOrder.UnitId.Value).Title;

                if (getWorkOrder.SectionId.HasValue)
                    m.SectionTitle = _companyService.GetById(getWorkOrder.SectionId.Value).Title;


                foreach (var groups in item.WorkorderAssignedUsers.GroupBy(x => x.WorkgroupId))
                {
                    var personnelID = new StringBuilder();


                    personnelID.Append(groups.Key);

                    personnelID.Append(",");

                    foreach (var group in groups)
                    {

                        personnelID.Append(group.PersonnelCode);
                        personnelID.Append(",");


                    }

                    m.UserSelected.Add(personnelID.ToString());




                }
                if (model.Workgroups.Count() == 0)
                {
                    foreach (var groups in item.WorkorderAssignedUsers.GroupBy(x => x.WorkgroupId))
                    {
                        var personnelName = new StringBuilder();
                        var personnelID = new StringBuilder();


                        foreach (var group in groups)
                        {

                            personnelName.Append(group.Personnel.PositionType != null ? $"{group.Personnel.UserNameFmaily} - {group.Personnel.PositionType.Title}" : group.Personnel.UserNameFmaily);
                            personnelName.Append("-");

                            personnelID.Append(group.Personnel.PersonnelCode);
                            personnelID.Append(",");

                        }
                        m.Works.Add(new SelectListItem
                        {
                            Text = $"{_workgroupService.GetById(Convert.ToInt32(groups.Key)).Title}({personnelName.ToString()})",
                            Value = $"{ groups.Key.ToString()},{personnelID.ToString()}"
                        });

                    }

                }

                else
                    m.Works = model.Workgroups;

                model.AssignedWorkorderModelList.Add(m);

            }


            ///آماده سازی لیست وضعیت
            model.Statuses = WorkOrderStatus.Select.ToSelectList().ToList();

            var getAssignedRoutinList = _assignedTaskService.GetAll(model.FromDate);

            foreach (var item in getAssignedRoutinList)
            {
                var m = new AssignedRoutineModel();
                var getRoutin = _routinService.GetById(item.RoutineId);

                var getPersonnels = item.Users.ToList();
                m.RoutineId = item.Id;
                m.EditDate = item.Date;
                m.ShamsiDate = ConvertAdToJalali(item.Date);
                m.RoutineTitle = getRoutin.Title;

                foreach (var personnel in getPersonnels)
                {

                    m.UserSelected.Add(personnel.PersonnelCode);
                    m.Personnels.Add(new SelectListItem
                    {
                        Text = personnel.Personnel.UserNameFmaily,
                        Value = personnel.PersonnelCode.ToString()
                    });

                }


                model.RoutineModel.Add(m);
            }

            ///بدست آوردن لیست پرسنل


            return View(model);
        }

        [HttpPost]
        public ActionResult Create(AssignedWorkorderViewModel Dto)
        {

            if (!_checkingRoleService.HasAccess(PermissionList.AssignedTaskCreate, CurrentUser.GetCurrentUser))
            {
                return PartialView("Inaccessibility");
            }



            var model = new AssignedWorkorderViewModel();
            if (!Dto.ActivityDates.HasValue)
                model.ActivityDates = DateTime.Now;

            model.Personnels = PrepareAllPersonnelsModel();
            // ///بدست آوردن لیست کارهای روتین
            model.Routins = PrepareAllRoutinsModel();

            foreach (var item in model.Routins)
            {
                item.Personnels = PrepareAllPersonnelsModel();
            }
            //model.ToDate = toDate;
            var getAssignedWorkorderList = _workorderAssignedDetailService.GetAll(fromDate: Dto.ActivityDates);

            ///بدست آوردن لیست گروه کاری که دارای پرسنل می باشند
            model.Workgroups = PrepareAllWorkgroupsModel();

            foreach (var item in getAssignedWorkorderList)
            {
                var m = new AssignedWorkorderModel();
                var getWorkOrder = _workOrderService.GetById(item.WorkorderId);

                var getGroups = item.WorkorderAssignedUsers.GroupBy(x => x.WorkgroupId);
                m.WorkorderId = item.WorkorderId;
                m.CompanyId = getWorkOrder.CompanyId;
                m.SectionId = getWorkOrder.SectionId;
                m.UnitId = getWorkOrder.UnitId;
                m.TotalArea = item.TotalArea;
                m.EditStartDate = getWorkOrder.StartDate;
                m.EidtEndDate = getWorkOrder.EndDate;
                m.RealArea = GetScaffoldSize(item.WorkorderId, m.RealArea);
                m.Date = item.Date;
                m.WorkTitle = getWorkOrder.Title;
                m.Status = getWorkOrder.Status;
                m.Id = item.Id;
                if (getWorkOrder.CompanyId != 0)
                    m.CompanyTitle = _companyService.GetById(getWorkOrder.CompanyId).Title;
                if (getWorkOrder.UnitId.HasValue)
                    m.UnitTitle = _companyService.GetById(getWorkOrder.UnitId.Value).Title;

                if (getWorkOrder.SectionId.HasValue)
                    m.SectionTitle = _companyService.GetById(getWorkOrder.SectionId.Value).Title;


                foreach (var groups in item.WorkorderAssignedUsers.GroupBy(x => x.WorkgroupId))
                {
                    var personnelID = new StringBuilder();


                    personnelID.Append(groups.Key);

                    personnelID.Append(",");

                    foreach (var group in groups)
                    {

                        personnelID.Append(group.PersonnelCode);
                        personnelID.Append(",");


                    }

                    m.UserSelected.Add(personnelID.ToString());




                }
                if (model.Workgroups.Count() == 0)
                {
                    foreach (var groups in item.WorkorderAssignedUsers.GroupBy(x => x.WorkgroupId))
                    {
                        var personnelName = new StringBuilder();
                        var personnelID = new StringBuilder();


                        foreach (var group in groups)
                        {

                            personnelName.Append(group.Personnel.PositionType != null ? $"{group.Personnel.UserNameFmaily} - {group.Personnel.PositionType.Title}" : group.Personnel.UserNameFmaily);
                            personnelName.Append("-");

                            personnelID.Append(group.Personnel.PersonnelCode);
                            personnelID.Append(",");

                        }
                        m.Works.Add(new SelectListItem
                        {
                            Text = $"{_workgroupService.GetById(Convert.ToInt32(groups.Key)).Title}({personnelName.ToString()})",
                            Value = $"{ groups.Key.ToString()},{personnelID.ToString()}"
                        });

                    }

                }

                else
                    m.Works = model.Workgroups;

                model.AssignedWorkorderModelList.Add(m);
            }


            ///آماده سازی لیست وضعیت
            model.Statuses = WorkOrderStatus.Select.ToSelectList().ToList();


            var getAssignedRoutinList = _assignedTaskService.GetAll(fromDate: Dto.ActivityDates);

            foreach (var item in getAssignedRoutinList)
            {
                var m = new AssignedRoutineModel();
                var getRoutin = _routinService.GetById(item.RoutineId);

                var getPersonnels = item.Users.ToList();
                m.RoutineId = item.Id;
                m.EditDate = item.Date;
                m.ShamsiDate = ConvertAdToJalali(item.Date);
                m.RoutineTitle = getRoutin.Title;

                foreach (var personnel in getPersonnels)
                {

                    m.UserSelected.Add(personnel.PersonnelCode);
                    m.Personnels.Add(new SelectListItem
                    {
                        Text = personnel.Personnel.UserNameFmaily,
                        Value = personnel.PersonnelCode.ToString()
                    });

                }


                model.RoutineModel.Add(m);
            }

            ///بدست آوردن لیست پرسنل


            return View(model);
        }


        public JsonResult PrepareItems()
        {

            var model = new AssignedWorkorderViewModel();

            // ///بدست آوردن زیر مجموعه های شرکت
            PrepareAllCompaniesModel(model);

            // ///بدست آوردن لیست گروه کاری که دارای پرسنل می باشند
            model.Workgroups = PrepareAllWorkgroupsModel();

            // ///بدست آوردن درستور کار 
            //PrepareAllWorkOrderModel(model, 0);


            // ///بدست آوردن پرسنل حاضر امروز
            model.Personnels = PrepareAllPersonnelsModel();
            return Json(new { data = model }, JsonRequestBehavior.AllowGet);

        }

        public PartialViewResult CreateOrUpdatePartial()
        {
            var model = new AssignedWorkorderModel();

            ///بدست آوردن زیر مجموعه های شرکت
            //PrepareAllCompaniesModel(model);

            ///بدست آوردن لیست گروه کاری که دارای پرسنل می باشند
            //model.Workgroups = PrepareAllWorkgroupsModel();

            ///بدست آوردن درستور کار 
           // PrepareAllWorkOrderModel(model, 0);

            return PartialView("_CreateOrUpdate", model);
        }

        [HttpPost]
        public ActionResult CreateAssignedWorkOrder(AssignedWorkorderModel model)
        {
            var result = new ReturnAjaxForm();

            ////if (model.WorkgroupIds.Count == 0)
            ////    ModelState.AddModelError("WorkgroupIds", "حداقل یک گروه کاری انتخاب نمایید");

            ////if (!model.StartDate.HasValue)
            ////    ModelState.AddModelError("StartDate", "تاریخ شروع را وارد نمایید");

            if (model.CompanyId == 0)
                ModelState.AddModelError("CompanyId", "شرکت را انتخاب کنید");

            if (model.ActivityDate == "" || model.ActivityDate == null)
                ModelState.AddModelError("ActivityDate", "تاریخ فعالیت الزامی است");


            if (ModelState.IsValid)
            {
                try
                {
                    var entity = new AssignedWorkorder();
                    var detail = new AssignedWorkorderDetail();
                    //detail.Workorder = new WorkOrder();
                    var personnels = new List<WorkorderAssignedUsers>();



                    if (model.WorkorderId > 0 && model.WorkgroupIds.Count() > 0)
                    {
                        var getWorkOrder = _workOrderService.GetById(model.WorkorderId);
                        #region اختصاص پرسنل به دستور کار

                        foreach (var workgroupId in model.WorkgroupIds)
                        {

                            string[] ids = workgroupId.Split(',');

                            var personnelIDs = new List<int>();

                            int workgroupID = Convert.ToInt32(ids[0]);

                            for (int i = 1; i < (ids.Count() - 1); i++)
                            {
                                personnelIDs.Add(Convert.ToInt32(ids[i]));
                            }


                            foreach (var personnelId in personnelIDs)
                            {
                                var getPersonnelInfo = _personnelService.GetById(personnelId);
                                var getPositionTypeInfo = new PositionType();

                                if (getPersonnelInfo != null && getPersonnelInfo.PositionTypeId.HasValue)
                                    getPositionTypeInfo = _positionTypeService.GetById(getPersonnelInfo.PositionTypeId.Value);

                                personnels.Add(new WorkorderAssignedUsers
                                {
                                    PersonnelCode = personnelId,
                                    AssignedWorkorderDetailId = detail.Id,
                                    WorkorderId = model.WorkorderId,
                                    WorkgroupId = workgroupID,
                                    EmployeeTypeId = getPersonnelInfo?.EmployeeTypeId,
                                    PositionTypeId = getPersonnelInfo?.PositionTypeId,
                                    IsMasterOfWork = getPositionTypeInfo != null ? getPositionTypeInfo.SystemName == PositionTypeEnum.MasterOfWork.ToString() : false


                                });


                            }



                        }

                        #endregion اختصاص پرسنل به دستور کار

                        #region اختصاص روزانه دستورکار

                        if (model.ActivityDate != "")
                            detail.Date = NewConvertJalaliToAd(model.ActivityDate);
                        else
                            detail.Date = DateTime.Now;
                        detail.ActionUserId = User.Identity.GetUserId();
                        detail.WorkorderId = model.WorkorderId;
                        //detail.Workorder = getWorkOrder;
                        detail.CompanyId = model.CompanyId;
                        detail.UnitId = model.UnitId;
                        detail.TotalArea = model.TotalArea;
                        detail.SectionId = model.SectionId;
                        if (model.StartDate != "" && model.StartDate != null)
                        {
                            detail.StartDate = NewConvertJalaliToAd(model.StartDate);
                        }
                        else detail.StartDate = null;
                        if (model.EndDate != "" && model.EndDate != null)
                        {
                            detail.EndDate = NewConvertJalaliToAd(model.EndDate);
                        }
                        else detail.EndDate = null;


                        detail.WorkorderAssignedUsers = personnels;

                        #endregion  اختصاص روزانه دستورکار

                        _workorderAssignedDetailService.Insert(detail);

                        ShowMessageToUser(result, "با موفقیت ثبت شد .", ResultType.Success);
                    }
                    else
                    {
                        ShowMessageToUser(result, "انتخاب دستور کار و گروه های کاری الزامی است", ResultType.Failure);
                    }



                }
                catch (Exception ex)
                {

                    /// لاگ خطا

                    LogException.Write(ex, "CreateAssignedWorkOrderActionInAssignedTaskController");
                    ///نمایش پیام خطا به کاربر

                    ShowMessageToUser(result, "عملیات با خطا مواجه شد.", ResultType.Failure);

                }

            }
            else
            {

                /// show Error Message To User beacuse ModelState Is Invalid
                StringBuilder builder = AddErrors();
                ShowMessageToUser(result, builder.ToString(), ResultType.Failure);
            }
            return Json(result);

        }

        [HttpPost]
        public ActionResult CreateAssignedRoutin(AssignedRoutineModel model)
        {
            var result = new ReturnAjaxForm();

            if (model.UserIds.Count == 0)
                ModelState.AddModelError("UserIds", "انتخاب پرسنل الزامی است");

            if (model.Date == null)
                ModelState.AddModelError("Date", "تاریخ فعالیت الزامی است");

            if (ModelState.IsValid)
            {
                var entity = new AssignedTask();
                var personnels = new List<AssignedTaskUsers>();

                entity.RoutineId = model.RoutineId;
                entity.ActionUserId = User.Identity.GetUserId();
                if (model.Date != null)
                {
                    entity.Date = NewConvertJalaliToAd(model.Date);
                }
                else
                    entity.Date = DateTime.Now;


                foreach (var personnelCode in model.UserIds)
                {
                    var getPersonnelInfo = _personnelService.GetById(personnelCode);

                    personnels.Add(new AssignedTaskUsers
                    {
                        PersonnelCode = personnelCode,
                        AssignedTaskId = entity.Id,
                        PositionTypeId = getPersonnelInfo?.PositionTypeId,
                        EmployeeTypeId = getPersonnelInfo?.EmployeeTypeId
                    });
                }

                entity.Users = personnels;
                ///عملیات ثبت در دیتابیس
                _assignedTaskService.Insert(entity);

                ShowMessageToUser(result, "با موفقیت ثبت شد .", ResultType.Success);
            }
            else
            {

                /// show Error Message To User beacuse ModelState Is Invalid
                StringBuilder builder = AddErrors();
                ShowMessageToUser(result, builder.ToString(), ResultType.Failure);
            }
            return Json(result);
        }

        public ActionResult Edit(int id)
        {
            if (!_checkingRoleService.HasAccess(PermissionList.AssignedTaskEdit, CurrentUser.GetCurrentUser))
            {

                return PartialView("_Inaccessibility");
            }

            var model = new WorkOrderModel();
            ///آماده سازی لیست وضعیت
            PrepareAllStatusModel(model);

            var entity = _workOrderService.GetById(id);

            model.Id = entity.Id;
            model.StartDate = entity.StartDate;
            model.EndDate = entity.EndDate;
            model.RealArea = entity.RealArea;
            model.Status = entity.Status;

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult EditAssignedWorkOrder(AssignedWorkorderModel model)
        {
            var result = new ReturnAjaxForm();

            if (model.WorkgroupIds.Count == 0)
                ModelState.AddModelError("WorkgroupIds", "حداقل یک گروه کاری انتخاب نمایید");

            if (model.Date == null)
                ModelState.AddModelError("Date", "تاریخ فعالیت الزامی است");


            if (ModelState.IsValid)
            {
                try
                {

                    var entity = new AssignedWorkorder();
                    var detail = new AssignedWorkorderDetail();
                    var personnels = new List<WorkorderAssignedUsers>();


                    var getWorkOrder = _workOrderService.GetById(model.WorkorderId);
                    #region اختصاص پرسنل به دستور کار

                    foreach (var workgroupId in model.WorkgroupIds)
                    {

                        string[] ids = workgroupId.Split(',');

                        var personnelIDs = new List<int>();

                        int workgroupID = Convert.ToInt32(ids[0]);

                        for (int i = 1; i < (ids.Count() - 1); i++)
                        {
                            personnelIDs.Add(Convert.ToInt32(ids[i]));
                        }


                        foreach (var personnelId in personnelIDs)
                        {
                            var getPersonnelInfo = _personnelService.GetById(personnelId);
                            var getPositionTypeInfo = new PositionType();

                            if (getPersonnelInfo != null && getPersonnelInfo.PositionTypeId.HasValue)
                                getPositionTypeInfo = _positionTypeService.GetById(getPersonnelInfo.PositionTypeId.Value);

                            personnels.Add(new WorkorderAssignedUsers
                            {
                                PersonnelCode = personnelId,
                                AssignedWorkorderDetailId = detail.Id,
                                WorkorderId = model.WorkorderId,
                                WorkgroupId = workgroupID,
                                EmployeeTypeId = getPersonnelInfo?.EmployeeTypeId,
                                PositionTypeId = getPersonnelInfo?.PositionTypeId,
                                IsMasterOfWork = getPositionTypeInfo != null ? getPositionTypeInfo.SystemName == PositionTypeEnum.MasterOfWork.ToString() : false




                            });


                        }



                    }

                    #endregion اختصاص پرسنل به دستور کار

                    #region اختصاص روزانه دستورکار

                    detail.ModifiedDate = DateTime.Now;
                    detail.LastActionUserId = User.Identity.GetUserId();
                    detail.TotalArea = model.TotalArea;
                    detail.Id = model.Id;
                    detail.Status = model.Status;
                    detail.StartDate = model.EditStartDate;
                    detail.EndDate = model.EidtEndDate;
                    if (model.Date.HasValue)
                        detail.Date = model.Date.Value;

                    detail.WorkorderAssignedUsers = personnels;

                    #endregion  اختصاص روزانه دستورکار

                    if (_workorderAssignedDetailService.Update(detail))

                        ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر
                        ShowMessageToUser(result, "با موفقیت ویرایش شد .", ResultType.Success);
                    else

                        ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر
                        ShowMessageToUser(result, "عملیات با خطا مواجه شد", ResultType.Failure);




                }
                catch (Exception ex)
                {

                    /// لاگ خطا

                    LogException.Write(ex, "CreateAssignedWorkOrderActionInAssignedTaskController");
                    ///نمایش پیام خطا به کاربر

                    ShowMessageToUser(result, "عملیات با خطا مواجه شد.", ResultType.Failure);

                }

            }
            else
            {

                /// show Error Message To User beacuse ModelState Is Invalid
                StringBuilder builder = AddErrors();
                ShowMessageToUser(result, builder.ToString(), ResultType.Failure);
            }
            return Json(result);

        }

        [HttpPost]
        public ActionResult EditAssignedWorkOrder1(WorkOrderModel model)
        {
            var result = new ReturnAjaxForm();

            ModelState.Remove(nameof(model.Status));
            ModelState.Remove(nameof(model.TypeId));
            ModelState.Remove(nameof(model.Title));
            ModelState.Remove(nameof(model.Date));
            ModelState.Remove(nameof(model.PriorityId));
            ModelState.Remove(nameof(model.CompanyId));


            if (ModelState.IsValid)
            {
                try
                {
                    var entity = _workOrderService.GetById(model.Id);

                    entity.RealArea = model.RealArea;


                    if (WorkOrderStatus.Select != model.Status.Value)
                        entity.Status = model.Status.Value;
                    entity.LastActionUserId = User.Identity.GetUserId();
                    entity.ModifiedDate = DateTime.Now;

                    ///عملیات ثبت در دیتابیس
                    _workOrderService.Update(entity);

                    ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                    ShowMessageToUser(result, "با موفقیت ویرایش شد .", ResultType.Success);

                }
                catch (Exception ex)
                {

                    /// لاگ خطا

                    LogException.Write(ex, "EditAssignedWorkOrderActionInAssignedTaskController");
                    ///نمایش پیام خطا به کاربر

                    ShowMessageToUser(result, "عملیات با خطا مواجه شد.", ResultType.Failure);

                }

            }
            else
            {
                /// show Error Message To User beacuse ModelState Is Invalid
                StringBuilder builder = AddErrors();
                ShowMessageToUser(result, builder.ToString(), ResultType.Failure);
            }
            return Json(result);

        }
        [HttpPost]
        public JsonResult GetWorkOrderByCompanyID(int companyID)

        {
            var model = new AssignedWorkorderViewModel();

            ///بدست آوردن درستور ک 
            PrepareAllWorkOrderModel(model, companyID);

            return Json(model.Works);
        }
        [HttpPost]
        public JsonResult GetCompaniesByParentId(int parentId)

        {
            var model = new AssignedWorkorderViewModel();


            PrepareAllCompaniesModel(model, parentId);

            return Json(model.Companies);
        }

        [HttpPost]
        public JsonResult GetScaffoldSizeByWorkorderId(int workorderId)

        {

            double area = 0;
            area = GetScaffoldSize(workorderId, area);

            return Json(area);
        }

        #region Routine
        public ActionResult CreateRoutin()
        {
            var model = new AssignedRoutineModel();


            ///بدست آوردن لیست پرسنل
            model.Personnels = PrepareAllPersonnelsModel();

            ///بدست آوردن لیست کارهای روتین
            //PrepareAllRoutinsModel(model);

            return View(model);
        }


        [HttpPost]
        public ActionResult AssignedRoutin(AssignedRoutineModel model)
        {
            var result = new ReturnAjaxForm();

            if (model.UserIds.Count == 0)
                ModelState.AddModelError("UserIds", "حداقل یک پرسنل انتخاب نمایید");

            if (model.Date == null)
                ModelState.AddModelError("Date", "تاریخ شروع کار را انتخاب نمایید");



            if (ModelState.IsValid)
            {
                try
                {
                    var entity = new AssignedTask();
                    var personnels = new List<AssignedTaskUsers>();

                    entity.RoutineId = model.RoutineId;
                    entity.ActionUserId = User.Identity.GetUserId();
                    entity.CreatedDate = DateTime.Now;
                    if (model.Date != null)
                    {
                        entity.Date = NewConvertJalaliToAd(model.Date);
                    }



                    foreach (var personnelCode in model.UserIds)
                    {
                        var getPersonnelInfo = _personnelService.GetById(personnelCode);

                        personnels.Add(new AssignedTaskUsers
                        {
                            PersonnelCode = personnelCode,
                            AssignedTaskId = entity.Id,
                            PositionTypeId = getPersonnelInfo?.PositionTypeId,
                            EmployeeTypeId = getPersonnelInfo?.EmployeeTypeId
                        });
                    }

                    entity.Users = personnels;
                    ///عملیات ثبت در دیتابیس
                    _assignedTaskService.Insert(entity);

                    ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر
                    ShowMessageToUser(result, "با موفقیت ثبت شد .", ResultType.Success);

                }
                catch (Exception ex)
                {

                    /// لاگ خطا

                    LogException.Write(ex, "AssignedRoutinActionInAssignedTaskController");

                    ///نمایش پیام خطا به کاربر

                    ShowMessageToUser(result, "عملیات با خطا مواجه شد", ResultType.Failure);

                }

            }
            else
            {

                /// show Error Message To User beacuse ModelState Is Invalid
                StringBuilder builder = AddErrors();
                ShowMessageToUser(result, builder.ToString(), ResultType.Failure);
            }
            return Json(result);

        }


        public ActionResult AssignedTaskPersonnel(int id)
        {
            var model = new AssignedTaskUsersModel();

            model.AssignedTaskId = id;

            return PartialView("Personnel", model);
        }

        public ActionResult EditRoutin(int id)
        {
            var model = new AssignedRoutineModel();

            var entity = _assignedTaskService.GetById(id);

            model.Id = entity.Id;
            model.Date = ConvertAdToJalali(entity.Date);
            model.RoutineId = entity.RoutineId;

            model.Personnels = PrepareAllPersonnelsModel();

            foreach (var user in entity.Users)
            {
                model.UserSelected.Add(user.PersonnelCode);
            }


            return PartialView(model);
        }

        [HttpPost]
        public ActionResult EditRoutin(AssignedRoutineModel model)
        {
            var result = new ReturnAjaxForm();
            var personnels = new List<AssignedTaskUsers>();

            if (model.UserIds.Count == 0)
                ModelState.AddModelError("UserIds", "حداقل یک پرسنل انتخاب نمایید");

            if (ModelState.IsValid)
            {
                try
                {
                    var entity = _assignedTaskService.GetById(model.Id);


                    foreach (var user in entity.Users.ToList())
                    {
                        _assignedTaskUserService.Remove(_assignedTaskUserService.GetById(user.Id));
                    }
                    entity.Users = new List<AssignedTaskUsers>();
                    _assignedTaskService.Update(entity);

                    //entity.Date = (DateTime)model.EditDate;

                    entity.ModifiedDate = DateTime.Now;
                    entity.LastActionUserId = User.Identity.GetUserId();

                    foreach (var personnelCode in model.UserIds)
                    {
                        var getPersonnelInfo = _personnelService.GetById(personnelCode);

                        personnels.Add(new AssignedTaskUsers
                        {
                            PersonnelCode = personnelCode,
                            AssignedTaskId = entity.Id,
                            PositionTypeId = getPersonnelInfo?.PositionTypeId,
                            EmployeeTypeId = getPersonnelInfo?.EmployeeTypeId
                        });
                    }

                    entity.Users = personnels;
                    ///ثبت در دیتابیس
                    _assignedTaskService.Update(entity);

                    ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                    ShowMessageToUser(result, "با موفقیت ویرایش شد .", ResultType.Success);
                }
                catch (Exception ex)
                {
                    /// لاگ خطا

                    LogException.Write(ex, "EditRoutinActionInAssignedTaskController");

                    ///نمایش پیام خطا به کاربر

                    ShowMessageToUser(result, "عملیات با خطا مواجه شد", ResultType.Failure);

                }
            }

            else
            {

                /// show Error Message To User beacuse ModelState Is Invalid
                StringBuilder builder = AddErrors();
                ShowMessageToUser(result, builder.ToString(), ResultType.Failure);
            }
            return Json(result);

        }
        public ActionResult FilterRoutin()
        {
            var model = new AssignedRoutineModel();

            ///بدست آوردن لیست پرسنل
            model.Personnels = PrepareAllPersonnelsModel();

            ///بدست آوردن لیست کارهای روتین
            model.Routines = PrepareAllRoutinsModel();

            return PartialView("_FilterRoutin", model);
        }

        public PartialViewResult CreateOrUpdateRoutinPartial()
        {
            var model = new AssignedRoutineModel();

            ///بدست آوردن لیست پرسنل
            model.Personnels = PrepareAllPersonnelsModel();

            ///بدست آوردن لیست کارهای روتین
            //PrepareAllRoutinsModel(model);

            return PartialView("_CreateOrUpdateRoutin", model);
        }
        #endregion


        [HttpPost]
        public ActionResult Detail(int id)
        {
            var model = new AssignedWorkorderDetailModel();
            model.AssignedWorkorderId = id;
            return PartialView(model);

        }


        #region Report
        [HttpPost]
        public ActionResult ReportRoutin(AssignedWorkorderViewModel model)
        {
            if (System.Web.HttpContext.Current.Session["filter"] != null)
            {
                Session.Remove("filter");
                Session.Add("filter", model);
            }
            else
            {
                Session.Add("filter", model);
            }
            return RedirectToAction("PrintRoutin");
        }
        public virtual ActionResult PrintRoutin()
        {
            AssignedWorkorderViewModel model = (AssignedWorkorderViewModel)Session["filter"];

            return View();
        }
        public virtual ActionResult StiReport()
        {
            AssignedWorkorderViewModel model = (AssignedWorkorderViewModel)Session["filter"];

            // ایجاد شی جدید
            var mainReport = new Stimulsoft.Report.StiReport();
            try
            {
                mainReport["@workorderId"] = null;
                mainReport["@date"] = model.ActivityDates;
            }
            catch (Exception ex)
            {
                mainReport["@workorderId"] = null;
                mainReport["@date"] = null;
                mainReport["@toDate"] = null;
            }
            try
            {
                // فراخوانی فایل استیمول
                mainReport.Load(Server.MapPath("~/ReportFiles/ReportOfDailyTask.mrt"));
                // 
                mainReport.Compile();
                //افراد آماده به کار
                mainReport["StandbyPersonnel"] = _attendanceService.GetAll(DateTime.Now, PresenceStatus.Entry).Count();
                ////نفرات جاری
                //mainReport["CurrentPersonnel"] = model.CurrentPersonnel;
                ////نفرات پروژه ای
                //mainReport["ProjectPersonnel"] = model.ProjectPersonnel;
                ////نفرات کارهای حجیم
                //mainReport["BulkyPersonnel"] = model.BulkyPersonnel;
            }
            catch (Exception ex)
            {
                /// لاگ خطا
                LogException.Write(ex, "StiReportinActionInAssignedTaskController");

            }
            return Stimulsoft.Report.Mvc.StiMvcViewer.GetReportSnapshotResult(mainReport);
        }
        public virtual ActionResult ViewerEvent()
        {
            return Stimulsoft.Report.Mvc.StiMvcViewer.ViewerEventResult(HttpContext);
        }
        #endregion

        #region Delete
        [HttpPost]
        public ActionResult DeleteRoutin(int id)
        {
            var result = new ReturnAjaxForm();

            if (!_checkingRoleService.HasAccess(PermissionList.AssignedTaskDelete, CurrentUser.GetCurrentUser))
            {
                ///نمایش پیام عدم دسترسی  به کاربر

                ShowMessageToUser(result, "کاربر گرامی،شما  مجوز حذف رکورد را ندارید! ", ResultType.NotAllow);


                //return Json(result, JsonRequestBehavior.AllowGet);
            }

            try
            {
                var entity = _assignedTaskService.GetById(id);

                _assignedTaskService.Remove(entity);

                ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                ShowMessageToUser(result, "با موفقیت حذف شد", ResultType.Success);

            }
            catch (Exception ex)
            {
                /// لاگ خطا

                LogException.Write(ex, "DeleteRoutinMethodInAssignedTaskController");


                ///نمایش پیام خطا به کاربر

                ShowMessageToUser(result, "امکان حذف  رکورد وجود ندارد.", ResultType.Failure);
            }

            return Json(result);

        }

        public ActionResult DeleteWork(int id)
        {
            var result = new ReturnAjaxForm();

            if (!_checkingRoleService.HasAccess(PermissionList.AssignedTaskDelete, CurrentUser.GetCurrentUser))
            {
                ///نمایش پیام عدم دسترسی  به کاربر

                ShowMessageToUser(result, "کاربر گرامی،شما  مجوز حذف رکورد را ندارید! ", ResultType.NotAllow);


                //return Json(result, JsonRequestBehavior.AllowGet);
            }

            try
            {
                var entity = _workorderAssignedDetailService.GetById(id);

                if (_workorderAssignedDetailService.Remove(entity))
                {
                    ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                    ShowMessageToUser(result, "با موفقیت حذف شد", ResultType.Success);
                }
                else
                {
                    ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                    ShowMessageToUser(result, "عملیات با خطا مواجه شد", ResultType.Failure);
                }



            }
            catch (Exception ex)
            {
                /// لاگ خطا

                LogException.Write(ex, "DeleteWorkMethodInAssignedTaskController");


                ///نمایش پیام خطا به کاربر

                ShowMessageToUser(result, "امکان حذف  رکورد وجود ندارد.", ResultType.Failure);
            }

            return Json(result);

        }
        #endregion
    }
}