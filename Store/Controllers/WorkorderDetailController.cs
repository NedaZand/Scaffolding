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

namespace Store.Controllers
{
    [Authorize]
    public class WorkorderDetailController : BaseController
    {
        #region Fields
        private readonly IAssignedWorkorderService _assignedTaskService;
        private readonly IAttendanceService _attendanceService;
        private readonly ICompanyService _companyService;
        private readonly IUserService _userService;
        private readonly IWorkOrderService _workOrderService;
        private readonly IPersonnelService _personnelService;
        private readonly IRoutinService _routinService;
        private readonly IWorkgroupService _workgroupService;
        private readonly IWorkorderAssignedUsersService _workorderAssignedUsersService;
        private readonly IAssignedWorkorderDetailService _workorderAssignedDetailService;
        #endregion


        #region Utilities

        [NonAction]
        protected virtual List<SelectListItem> PrepareAllWorkgroupsModel()
        {
            var workgroupList = new List<SelectListItem>();

            var attendanceList = _attendanceService.GetAll(DateTime.Now.Date, PresenceStatus.Entry);

            workgroupList.Add(new SelectListItem
            {
                Text = "انتخاب گروه کاری",
                Value = " "
            });

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
                            personnelName.Append("-");
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
        protected virtual void PrepareAllPersonnelsModel(AssignedWorkorderDetailModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            model.Personnels.Add(new SelectListItem
            {
                Text = "[None]",
                Value = " "
            });
            var personnels = _personnelService.GetAll();
            foreach (var c in personnels)
            {
                model.Personnels.Add(new SelectListItem
                {

                    Text = c.PositionType != null ? $"{c.UserNameFmaily} - {c.PositionType.Title}" : c.UserNameFmaily,
                    Value = c.PersonnelCode.ToString()
                });
            }
        }

        #endregion


        #region List

        [HttpGet]
        public JsonResult PersonnelList(DataTableRequest request, [ModelBinder(typeof(DataTableModelBinder))]DataTableRequestFilter filter, int detailId = 0)

        {
            if (request.length == -1)
            {
                request.length = int.MaxValue;
            }
            var data = _workorderAssignedUsersService.FilterData(request.start, request.length, filter.Search, filter.SortColumn, filter.SortDirection, detailId);


            var gridModel = new DataTableResponse<WorkorderAssignedUsersModel>()
            {
                data = data.Select(x =>
                {

                    var m = new WorkorderAssignedUsersModel();
                    m.PersonnelCode = x.PersonnelCode;
                    m.NameFamily = x.Personnel.UserNameFmaily;
                    m.WorkgroupTitle = _workgroupService.GetById(x.WorkgroupId).Title;
                    m.Area = x.Area;
                    m.Id = x.Id;


                    return m;
                }).ToList(),
                recordsTotal = _workorderAssignedUsersService.Count(detailId),
                recordsFiltered = _workorderAssignedUsersService.Count(detailId),
                draw = request.draw
            };



            return Json(gridModel, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult List(DataTableRequest request, [ModelBinder(typeof(DataTableModelBinder))]DataTableRequestFilter filter, int assignedTaskId = 0)

        {
            if (request.length == -1)
            {
                request.length = int.MaxValue;
            }
            var data = _workorderAssignedDetailService.FilterData(request.start, request.length, filter.Search, filter.SortColumn, filter.SortDirection, assignedTaskId: assignedTaskId);


            var gridModel = new DataTableResponse<AssignedWorkorderDetailModel>()
            {
                data = data.Select(x =>
                {

                    var m = new AssignedWorkorderDetailModel();
                    m.ShamsiDate = ConvertAdToJalali(x.Date);
                    m.TotalArea = x.TotalArea;
                    m.WorkorderTitle = x.Workorder.Title;
                    //m.RealArea = x.RealArea;
                    m.Id = x.Id;


                    return m;
                }).ToList(),
                recordsTotal = _workorderAssignedUsersService.Count(assignedTaskId),
                recordsFiltered = _workorderAssignedUsersService.Count(assignedTaskId),
                draw = request.draw
            };



            return Json(gridModel, JsonRequestBehavior.AllowGet);
        }

        #endregion List

        #region Ctor
        public WorkorderDetailController(IWorkgroupService workgroupService, IWorkorderAssignedUsersService workorderAssignedUsersService, IAssignedWorkorderService assignedTaskService, ICompanyService companyService, IUserService userService, IAttendanceService attendanceService, IWorkOrderService workOrderService, IPersonnelService personnelService, IRoutinService routinService, IAssignedWorkorderDetailService workorderAssignedDetailService)
        {
            this._assignedTaskService = assignedTaskService;
            this._companyService = companyService;
            this._userService = userService;
            this._attendanceService = attendanceService;
            this._workOrderService = workOrderService;
            this._personnelService = personnelService;
            this._routinService = routinService;
            this._workgroupService = workgroupService;
            this._workorderAssignedUsersService = workorderAssignedUsersService;
            this._workorderAssignedDetailService = workorderAssignedDetailService;
        }
        #endregion


        public ActionResult Index(int id)
        {
            var model = new AssignedWorkorderDetailModel();
            model.AssignedWorkorderId = id;

            return View(model);

        }


        public ActionResult Create(int id)
        {
            var model = new AssignedWorkorderDetailModel();

            model.AssignedWorkorderId = id;

            //PrepareAllPersonnelsModel(model);

            ///بدست آوردن لیست گروه کاری که دارای پرسنل می باشند
            model.Workgroups = PrepareAllWorkgroupsModel();

            return PartialView(model);

        }
        [HttpPost]
        public ActionResult Create(AssignedWorkorderDetailModel model)
        {
            var result = new ReturnAjaxForm();
            var details = new List<AssignedWorkorderDetail>();

            if (model.WorkgroupIds.Count == 0)
                ModelState.AddModelError("UserIds", "حداقل یک گروه کاری انتخاب نمایید");

            if (!model.Date.HasValue)
                ModelState.AddModelError("Date", "تاریخ شروع کار را انتخاب نمایید");

            if (ModelState.IsValid)
            {
                try
                {
                    var entity = _assignedTaskService.GetById(model.AssignedWorkorderId);
                    var detail = new AssignedWorkorderDetail();
                    var personnels = new List<WorkorderAssignedUsers>();
                    int getArea = 0;


                    ///ثبت جزییات

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

                        var getWorkgroup = _workgroupService.GetById(workgroupID);

                        if (model.TotalArea > 0)
                            getArea = ((model.TotalArea) / (model.WorkgroupIds.Count)) / personnelIDs.Count();


                        foreach (var personnelId in personnelIDs)
                        {
                            var getpersonnel = _personnelService.GetById(personnelId);

                            personnels.Add(new WorkorderAssignedUsers
                            {
                                PersonnelCode = personnelId,
                                AssignedWorkorderDetailId = detail.Id,
                                WorkorderId = entity.WorkOrderId,
                                WorkgroupId = workgroupID,
                                Area = getArea,



                            });


                        }



                    }

                    #endregion اختصاص پرسنل به دستور کار

                    #region اختصاص روزانه دستورکار

                    detail.Date = model.Date.Value;
                    detail.TotalArea = model.TotalArea;
                    detail.ActionUserId = User.Identity.GetUserId();
                    detail.WorkorderId = model.AssignedWorkorderId;
                    detail.WorkorderAssignedUsers = personnels;

                    #endregion  اختصاص روزانه دستورکار


                    ///عملیات ثبت در دیتابیس
                    _workorderAssignedDetailService.Insert(detail);

                    /// 
                    ///
                    //var entity = new AssignedWorkorderDetail()
                    //{
                    //    Date = model.Date.Value,
                    //    TotalArea = model.TotalArea,
                    //    ActionUserId = User.Identity.GetUserId(),
                    //    AssignedWorkorderId = model.AssignedWorkorderId,
                    //    WorkorderAssignedUsers = personnels

                    //};

                    //foreach (var personnelCode in model.UserIds)
                    //{
                    //    personnels.Add(new WorkorderAssignedUsers
                    //    {
                    //        PersonnelCode = personnelCode,
                    //        AssignedWorkorderDetailId = entity.Id,
                    //        Area=(model.TotalArea/(model.UserIds.Count)),
                    //       // RealArea= (model.RealArea / (model.UserIds.Count))
                    //    });
                    //}


                    ///ثبت در دیتابیس
                   // _workorderAssignedDetailService.Insert(entity);

                    ///


                    ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                    ShowMessageToUser(result, "با موفقیت ثبت شد", ResultType.Success);
                }
                catch (Exception ex)
                {

                    /// لاگ خطا

                    LogException.Write(ex, "CreateMethodInWorkorderDetailController");


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

        public ActionResult Edit(int id)
        {
            var model = new AssignedWorkorderDetailModel();

            var entity = _workorderAssignedDetailService.GetById(id);

            model.Id = entity.Id;
            model.Date = entity.Date;
            model.TotalArea = entity.TotalArea;
            //model.RealArea = entity.RealArea;

            model.Workgroups = PrepareAllWorkgroupsModel();

            foreach (var personnels in entity.WorkorderAssignedUsers.GroupBy(x=>x.WorkgroupId))
            {
                var personnelID = new StringBuilder();
                personnelID.Append(personnels.FirstOrDefault().WorkgroupId);
                personnelID.Append(",");

                foreach (var personnel in personnels)
                {

                   
                    personnelID.Append(personnel.Personnel.PersonnelCode);
                    personnelID.Append(",");

                }
                model.UserSelected.Add(personnelID.ToString());
            }


            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(AssignedWorkorderDetailModel model)
        {
            var result = new ReturnAjaxForm();
            var personnels = new List<WorkorderAssignedUsers>();

            if (model.WorkgroupIds.Count == 0)
                ModelState.AddModelError("WorkgroupIds", "حداقل یک گروه کاری انتخاب نمایید");

            if (!model.Date.HasValue)
                ModelState.AddModelError("StartDate", "تاریخ شروع کار را انتخاب نمایید");

            if (ModelState.IsValid)
            {
                try
                {
                    int getArea = 0;
                    var entity = _workorderAssignedDetailService.GetById(model.Id);

                    foreach (var user in entity.WorkorderAssignedUsers.ToList())
                    {
                        _workorderAssignedUsersService.Remove(_workorderAssignedUsersService.GetById(user.Id));
                    }
                    entity.WorkorderAssignedUsers = new List<WorkorderAssignedUsers>();
                    _workorderAssignedDetailService.Update(entity);

                    entity.Date = model.Date.Value;
                    entity.TotalArea = model.TotalArea;
                    entity.ModifiedDate = DateTime.Now;
                    entity.LastActionUserId = User.Identity.GetUserId();
                    entity.WorkorderAssignedUsers = personnels;


                    //foreach (var personnelCode in model.UserIds)
                    //{
                    //    personnels.Add(new WorkorderAssignedUsers
                    //    {
                    //        PersonnelCode = personnelCode,
                    //        AssignedWorkorderDetailId = entity.Id,
                    //        Area = model.TotalArea / (model.UserIds.Count),
                    //        //RealArea=model.RealArea/(model.UserIds.Count)
                    //    });
                    //}

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

                        var getWorkgroup = _workgroupService.GetById(workgroupID);
                        if (model.TotalArea > 0)
                            getArea = ((model.TotalArea) / (model.WorkgroupIds.Count)) / personnelIDs.Count();



                        foreach (var personnelId in personnelIDs)
                        {
                          
                            personnels.Add(new WorkorderAssignedUsers
                            {
                                PersonnelCode = personnelId,
                                AssignedWorkorderDetailId = entity.Id,
                                WorkorderId = entity.WorkorderId,
                                WorkgroupId = workgroupID,
                                Area = getArea,


                            });


                        }



                    }

                    #endregion اختصاص پرسنل به دستور کار

                    ///ثبت در دیتابیس
                    _workorderAssignedDetailService.Update(entity);

                    ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                    ShowMessageToUser(result, "با موفقیت ویرایش شد", ResultType.Success);

                }
                catch (Exception ex)
                {
                    /// لاگ خطا

                    LogException.Write(ex, "EditMethodInWorkorderDetailController");


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


        public ActionResult GetPersonnelList(int id)
        {
            var model = new WorkorderAssignedUsersModel();
            model.DetailId = id;

            return PartialView("Personnel", model);

        }
    }
}
