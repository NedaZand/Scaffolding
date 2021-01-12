using Store.Models;
using Store.Service;
using Store.WebEssential.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.Service.User;
using System.Text;
using Store.Core.CommonHelper;
using Store.WebEssential.ModelBinder;
using Store.Models.User;
using System.Threading.Tasks;
using Store.Core.Domain.StoreTables.User;
using Store.WebEssential.UserControl;
using Microsoft.AspNet.Identity.EntityFramework;
using Store.Service.Stores;
using Microsoft.AspNet.Identity;
using Store.WebEssential.Helper;
using Store.WebEssential.Extensions;
using System.Data.SqlClient;
using Store.Essential.Model;
using Store.Core.Domain.StoreTables;
using Store.Core.Domain.StoreTables.Attendancee;

namespace Store.Controllers
{
    [Authorize]
    //[ServerDown]
    public class PersonnelController : BaseController
    {
        #region Fields
        private readonly IPersonnelService _personnelService;
        private readonly IUserService _userService;
        private readonly IPositionTypeService _positionService;
        private readonly IEmployeeTypeService _employeeService;
        private readonly ICompanyService _companyService;
        private readonly IWorkgroupService _workgroupService;
        private readonly ICheckingRole _checkingRoleService;
        private readonly IAttendanceService _attendanceService;
        #endregion

        #region Ctor
        public PersonnelController(IAttendanceService attendanceService, IPersonnelService personnelService, IWorkgroupService workgroupService, ICheckingRole checkingRoleService, IEmployeeTypeService employeeService, IPositionTypeService positionService, ICompanyService companyService, IUserService userService)
        {
            _personnelService = personnelService;
            _checkingRoleService = checkingRoleService;
            _positionService = positionService;
            _employeeService = employeeService;
            _companyService = companyService;
            _userService = userService;
            _workgroupService = workgroupService;
            _attendanceService = attendanceService;
        }
        #endregion

        #region Utilities


        [NonAction]
        public void PreparePositionType(PersonnelModel model)
        {
            var positions = _positionService.GetAll();

            model.Positions.Add(new SelectListItem
            {
                Text = "انتخاب پست سازمانی",
                Value = "0"
            });

            foreach (var c in positions)
            {

                model.Positions.Add(new SelectListItem
                {
                    Text = c.Title,
                    Value = c.Id.ToString(),
                    Selected = false
                });
            }

        }

        [NonAction]
        public void PrepareWorkGroups(PersonnelModel model)
        {
            var workgroups = _workgroupService.GetAll();

            model.Workgroups.Add(new SelectListItem
            {
                Text = "انتخاب گروه کاری",
                Value = " "
            });

            foreach (var c in workgroups)
            {

                model.Workgroups.Add(new SelectListItem
                {
                    Text = c.Title,
                    Value = c.Id.ToString(),
                    Selected = false
                });
            }

        }
        [NonAction]
        protected virtual void PrepareAllCompaniesModel(PersonnelModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            model.Companies.Add(new SelectListItem
            {
                Text = "انتخاب مجموعه",
                Value = " "
            });
            var companies = SelectListHelper.GetCompanyList(_companyService);
            foreach (var c in companies)
            {

                if (Convert.ToInt32(c.Value) != 0)
                    model.Companies.Add(c);
            }
        }

        [NonAction]
        public void PrepareEmployeeType(PersonnelModel model)
        {
            var employees = _employeeService.GetAll();

            model.Employees.Add(new SelectListItem
            {
                Text = "انتخاب نوع همکاری",
                Value = " "
            });


            foreach (var c in employees)
            {

                model.Employees.Add(new SelectListItem
                {
                    Text = c.Title,
                    Value = c.Id.ToString(),
                    Selected = false
                });
            }


        }

        #endregion
        #region ActionMethod
        public ActionResult Index()
        {
            var personnelModel = new PersonnelModel();
            var model = new PersonnelReportModel();

            if (!_checkingRoleService.HasAccess(PermissionList.PersonnelList, CurrentUser.GetCurrentUser))
            {
                return View("Inaccessibility");
            }

            ///آماده سازی نوع همکاری
            PrepareEmployeeType(personnelModel);
            model.Employees = personnelModel.Employees;

            ///آماده سازی پست سازمانی
            PreparePositionType(personnelModel);
            model.Positions = personnelModel.Positions;

            ///آماده سازی شرکت ها
            PrepareAllCompaniesModel(personnelModel);
            model.Companies = personnelModel.Companies;

            ///آماده سازی لیست وضعیت تاهل
            model.MaritalStatuses = MaritalStatus.Unknown.ToSelectList().ToList();


            return View(model);
        }

        public ActionResult SuspendedPersonnelList()
        {
            var personnelModel = new PersonnelModel();
            var model = new PersonnelReportModel();

            if (!_checkingRoleService.HasAccess(PermissionList.PersonnelList, CurrentUser.GetCurrentUser))
            {
                return View("Inaccessibility");
            }

            ///آماده سازی نوع همکاری
            PrepareEmployeeType(personnelModel);
            model.Employees = personnelModel.Employees;

            ///آماده سازی پست سازمانی
            PreparePositionType(personnelModel);
            model.Positions = personnelModel.Positions;

            ///آماده سازی شرکت ها
            PrepareAllCompaniesModel(personnelModel);
            model.Companies = personnelModel.Companies;

            ///آماده سازی لیست وضعیت تاهل
            model.MaritalStatuses = MaritalStatus.Unknown.ToSelectList().ToList();


            return View(model);
        }
        public ActionResult Create()
        {

            var model = new PersonnelModel();

            if (!_checkingRoleService.HasAccess(PermissionList.PersonnelCreate, CurrentUser.GetCurrentUser))
            {
                return View("Inaccessibility");
            }

            ///آماده سازی نوع همکاری
            PrepareEmployeeType(model);

            ///آماده سازی پست سازمانی
            PreparePositionType(model);

            ///آماده سازی شرکت ها
            PrepareAllCompaniesModel(model);

            ///آماده سازی لیست وضعیت تاهل
            model.MaritalStatuses = MaritalStatus.Unknown.ToSelectList().ToList();

            ///آماده سازی گروه کاری 
            PrepareWorkGroups(model);

            return View(model);
        }
        [HttpPost]
        public ActionResult Create(PersonnelModel model)
        {
            var result = new ReturnAjaxForm();

            var personnel = new Personnel();

            if (model.PositionId == 0 && model.WorkgroupId.Count > 1)
            {
                ModelState.AddModelError("PositionId", "پست سازمانی الزامی است");
            }
            if (model.PositionId!=0 && _positionService.GetById(model.PositionId).SystemName != PositionTypeEnum.MasterOfWork.ToString() && model.WorkgroupId.Count>1)
            {
                ModelState.AddModelError("WorkgroupId", "تنها استادکار می تواند عضو چند گروه کاری باشد.");
            }


            if (ModelState.IsValid)
            {
                try
                {
                  
                    personnel.UserNameFmaily = model.UserNameFmaily;
                    personnel.PositionTypeId = model.PositionId;
                    personnel.EmployeeTypeId = model.EmployeeId;
                    if(model.MaritalStatus.HasValue)
                    personnel.MaritalStatus = model.MaritalStatus.Value;
                    personnel.NationalCode = model.NationalCode;
                    personnel.BirthDate = model.BirthDate;
                    personnel.DateEmployeement = model.DateEmployeement;
                    personnel.Description = model.Description;
                    personnel.PersonnelCode = model.PersonnelCode.Value;
                    personnel.CompanyId = model.CompanyId;

                    ///کدام کاربر  ثبت را انجام داده است
                    personnel.ActionUserId = User.Identity.GetUserId();

                    if(model.WorkgroupId.Count>0)
                    {
                        foreach(var item in model.WorkgroupId)
                        {
                            if(item!=0)
                            {
                                personnel.WorkingGroupPersonnels.Add(new WorkingGroupPersonnel
                                {
                                    PersonnelCode = model.PersonnelCode.Value,
                                    WorkgroupId = item.Value
                                });
                            }
                          
                        }
                       
                    }
                   

                    ///عملیات ثبت در دیتابیس
                    Exception addResult = _personnelService.Insert(personnel);

                    if (addResult == null)

                    {
                        ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                        ShowMessageToUser(result, "با موفقیت ثبت شد", ResultType.Success);

                    }
                    else if(addResult.InnerException!=null && addResult.InnerException.InnerException!=null && addResult.InnerException.InnerException.Message!=null && addResult.InnerException.InnerException.Message.Contains("Cannot insert duplicate key in object 'dbo.Personnels'") )
                    {
                        ///نمایش پیام خطا به کاربر

                        ShowMessageToUser(result, " کد پرسنلی از قبل در دیتابیس موجود است.", ResultType.Failure);



                    }
                    else
                    {
                        ///نمایش پیام خطا به کاربر

                        ShowMessageToUser(result, "عملیات با خطا مواجه شد.", ResultType.Failure);


                    }

                }

                catch (Exception ex)
                {
                    /// لاگ خطا

                    LogException.Write(ex, "CreateMethodInPersonnelController");


                    if (ex.InnerException != null && ex.InnerException.InnerException != null && ex.InnerException.InnerException.Message.Contains("Violation of PRIMARY KEY constraint 'PK_dbo.Personnels'"))
                    {

                        ///نمایش پیام خطا به کاربر

                        ShowMessageToUser(result, " کد پرسنلی از قبل در دیتابیس موجود است.", ResultType.Failure);


                    }
                    else
                    {
                        ///نمایش پیام خطا به کاربر

                        ShowMessageToUser(result, "عملیات با خطا مواجه شد.", ResultType.Failure);


                    }
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
            var model = new PersonnelModel();

            if (!_checkingRoleService.HasAccess(PermissionList.PersonnelEdit, CurrentUser.GetCurrentUser))
            {
                return View("Inaccessibility");
            }

            var personnel = _personnelService.GetById(id);


            ///آماده سازی نوع همکاری
            PrepareEmployeeType(model);

            ///آماده سازی پست سازمانی
            PreparePositionType(model);

            ///آماده سازی شرکت ها
            PrepareAllCompaniesModel(model);

            ///آماده سازی لیست وضعیت تاهل
            model.MaritalStatuses = MaritalStatus.Unknown.ToSelectList().ToList();

            ///آماده سازی گروه کاری 
            PrepareWorkGroups(model);

            model.BirthDate = personnel.BirthDate;
            model.PersonnelCode = personnel.PersonnelCode;
            model.UserNameFmaily = personnel.UserNameFmaily;
            if(personnel.PositionTypeId.HasValue)
            model.PositionId = personnel.PositionTypeId.Value;
            model.EmployeeId = personnel.EmployeeTypeId;
            model.DateEmployeement = personnel.DateEmployeement;
            model.Description = personnel.Description;
            model.MaritalStatus = personnel.MaritalStatus;
            model.NationalCode = personnel.NationalCode;
            model.CompanyId = personnel.CompanyId;


            foreach (var workingGroup in personnel.WorkingGroupPersonnels)
            {

                model.WorkgroupId.Add(workingGroup.WorkgroupId);


            }
           
            model.MaritalStatus = personnel.MaritalStatus;



            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(PersonnelModel model)
        {
            var result = new ReturnAjaxForm();

            ModelState.Remove("PersonnelCode");

            if (model.PositionId == 0 && model.WorkgroupId.Count > 1)
            {
                ModelState.AddModelError("PositionId", "پست سازمانی الزامی است");
            }
            if (model.PositionId != 0 && _positionService.GetById(model.PositionId).SystemName != PositionTypeEnum.MasterOfWork.ToString() && model.WorkgroupId.Count > 1)
            {
                ModelState.AddModelError("WorkgroupId", "تنها استادکار می تواند عضو چند گروه کاری باشد.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var personnel = new Personnel();
                    personnel.UserNameFmaily = model.UserNameFmaily;
                    personnel.PositionTypeId = model.PositionId;
                    personnel.EmployeeTypeId = model.EmployeeId;
                    if(model.MaritalStatus.HasValue)
                    personnel.MaritalStatus = model.MaritalStatus.Value;
                    personnel.NationalCode = model.NationalCode;
                    personnel.BirthDate = model.BirthDate;
                    personnel.DateEmployeement = model.DateEmployeement;
                    personnel.Description = model.Description;
                    personnel.CompanyId = model.CompanyId;
                    personnel.PersonnelCode = model.Id;

                    if (model.WorkgroupId.Count > 0)
                    {
                        foreach (var item in model.WorkgroupId)
                        {
                            if (item != 0)
                            {
                                personnel.WorkingGroupPersonnels.Add(new WorkingGroupPersonnel
                                {
                                    PersonnelCode = model.Id,
                                    WorkgroupId = item.Value
                                });
                            }

                        }

                    }
                    ///کدام کاربر و در چه تاریخی ویرایش  انجام داده است
                    personnel.ModifiedDate = DateTime.Now;
                    personnel.LastEditUserId = User.Identity.GetUserId();

                    ///عملیات ویرایش در دیتابیس
                    
                    Exception addResult = _personnelService.Update(personnel);

                    if (addResult == null)

                    {
                        ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                        ShowMessageToUser(result, "با موفقیت ویرایش شد", ResultType.Success);

                    }
                    else if (addResult != null && addResult.InnerException != null && addResult.InnerException.InnerException != null && addResult.InnerException.InnerException.Message != null && addResult.InnerException.InnerException.Message.Contains(""))
                    {
                        ///نمایش پیام خطا به کاربر

                        ShowMessageToUser(result, " کد پرسنلی از قبل در دیتابیس موجود است.", ResultType.Failure);



                    }
                    else
                    {
                        ///نمایش پیام خطا به کاربر

                        ShowMessageToUser(result, "عملیات با خطا مواجه شد.", ResultType.Failure);


                    }

                }
                catch (Exception ex)
                {
                    /// لاگ خطا

                    LogException.Write(ex, "EditMethodInPersonnelController");


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
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var result = new ReturnAjaxForm();

            if (!_checkingRoleService.HasAccess(PermissionList.PersonnelDelete, CurrentUser.GetCurrentUser))
            {
                ///نمایش  خطا عدم دسترسی به کاربر

                ShowMessageToUser(result, "کاربر گرامی،شما  مجوز حذف رکورد را ندارید !", ResultType.NotAllow);

                //return Json(result, JsonRequestBehavior.AllowGet);
            }


            try
            {
                var entity = _personnelService.GetById(id);
                _personnelService.Remove(entity);

                ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                ShowMessageToUser(result, "با موفقیت حذف شد", ResultType.Success);
            }
            catch (Exception ex)
            {
                /// لاگ خطا

                LogException.Write(ex, "DeleteMethodInPersonnelController");


                ///نمایش پیام خطا به کاربر

                ShowMessageToUser(result, "امکان حذف  رکورد وجود ندارد.", ResultType.Failure);
            }

            return Json(result, JsonRequestBehavior.AllowGet);

        }
        
        public ActionResult ChangeStatusPresence(int id,PersonnelStatus status=PersonnelStatus.NonSuspended)
        {
            var result = new ReturnAjaxForm();


            try
            {
                var entity = _personnelService.GetById(id);

                if(status==PersonnelStatus.Absent)
                {

                   
                        var attendance=new Attendance
                        {
                            PersonnelCode = id,
                            PresenceStatus = PresenceStatus.Exit,
                            Time = DateTime.Now.TimeOfDay,
                            Date = DateTime.Now.Date,
                            ActionUserId = User.Identity.GetUserId()
                        };
                    


                    ///عملیات ثبت در دیتابیس
                    _attendanceService.Insert(attendance);
                }
                else
                {
                    entity.StatusPresence = status;
                    _personnelService.UpdateStatus(entity);

                   
                }
                
                ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر
                ShowMessageToUser(result, "با موفقیت به روز رسانی شد", ResultType.Success);


            }
            catch (Exception ex)
            {
                /// لاگ خطا

                LogException.Write(ex, "ChangeStatusPresenceMethodInPersonnelController");


                ///نمایش پیام خطا به کاربر

                ShowMessageToUser(result, "عملیات با خطا مواجه شد.", ResultType.Failure);
            }

            return Json(result, JsonRequestBehavior.AllowGet);

        }
        #endregion
        #region List
        public JsonResult List(DataTableRequest request, [ModelBinder(typeof(DataTableModelBinder))]DataTableRequestFilter filter, PersonnelModel model)

        {
            if (request.length == -1)
            {
                request.length = int.MaxValue;

            }

            var data = _personnelService.FilterData(request.start, request.length, filter.Search, filter.SortColumn, filter.SortDirection, null, null, model.BirthDate, model.ToBirthDate, model.DateEmployeement, model.ToDateEmployeement, model.MaritalStatus, model.NationalCode, model.UserNameFmaily, model.PersonnelCode, model.PositionId, model.EmployeeId, model.CompanyId,model.StatusPresence);
            var gridModel = new DataTableResponse<PersonnelModel>();
            gridModel.draw = request.draw;

            data.ForEach(x =>
            {
                var personnel = new PersonnelModel();
                personnel.PersonnelCode = x.PersonnelCode;
                personnel.NationalCode = x.NationalCode;
                personnel.UserNameFmaily = x.UserNameFmaily;
                personnel.Description = x.Description;
                if(x.ActionUserId!=null)
                personnel.ActionUserName = _userService.GetById(x.ActionUserId).UserName;
                if(x.CreatedDate.HasValue)
                personnel.ShamsiCreateDate = ConvertAdToJalaliDateTime(x.CreatedDate.Value);

                if (x.ModifiedDate.HasValue)
                    personnel.ShamsiEditDate = ConvertAdToJalaliDateTime(x.ModifiedDate.Value);

                if (x.DateEmployeement.HasValue)
                    personnel.ShamsiDateEmployeement = ConvertAdToJalali(x.DateEmployeement.Value);

                if (x.BirthDate.HasValue)
                    personnel.ShamsiBirthDate = ConvertAdToJalali(x.BirthDate.Value);

                if (x.PositionTypeId.HasValue)
                    personnel.PositionName = x.PositionType.Title;

                if (x.EmployeeTypeId.HasValue)
                    personnel.EmployeeName = x.EmployeeType.Title;

                if (x.CompanyId.HasValue)
                    personnel.CompanyName = x.Company.Title;

                if (x.LastEditUserId != null)
                    personnel.EditUserName = _userService.GetById(x.LastEditUserId).UserName;

                personnel.UserNameFmaily = x.UserNameFmaily;
                personnel.MaritalStatusTitle = x.MaritalStatus != null ? x.MaritalStatus.GetDisplayName() : "";
                personnel.StatusPresenceTitle = x.StatusPresence != null ? x.StatusPresence.GetDisplayName() : "";
                gridModel.data.Add(personnel);
            });

            gridModel.recordsFiltered = _personnelService.Count(filter.Search, model.BirthDate, model.ToBirthDate, model.DateEmployeement, model.ToDateEmployeement,null,null, model.MaritalStatus, model.NationalCode, model.UserNameFmaily, model.PersonnelCode, model.PositionId, model.EmployeeId, model.CompanyId, model.StatusPresence);
            gridModel.recordsTotal = _personnelService.Count(filter.Search, model.BirthDate, model.ToBirthDate, model.DateEmployeement, model.ToDateEmployeement, null, null, model.MaritalStatus, model.NationalCode, model.UserNameFmaily, model.PersonnelCode, model.PositionId, model.EmployeeId, model.CompanyId, model.StatusPresence);

            return Json(gridModel, JsonRequestBehavior.AllowGet);
        }

       
        #endregion List

        #region Report
        [HttpPost]
        public ActionResult Report(PersonnelReportModel model)
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



            return RedirectToAction("Print");
        }
        public virtual ActionResult Print()
        {
            PersonnelReportModel model = (PersonnelReportModel)Session["filter"];
            return View();
        }
        public virtual ActionResult StiReport()
        {
            PersonnelReportModel model = (PersonnelReportModel)Session["filter"];


            // ایجاد شی جدید
            var mainReport = new Stimulsoft.Report.StiReport();
            try
            {
                mainReport["@employeeId"] = model.EmployeeId;
                if(model.PositionId==0)
                    mainReport["@positionId"] = null;
                else
                mainReport["@positionId"] = model.PositionId;
                mainReport["@companyId"] = model.CompanyId;
                mainReport["@userNameFmaily"] = model.UserNameFmaily;
                mainReport["@nationalCode"] = model.NationalCode;
                mainReport["@personnelCode"] = model.PersonnelCode;
                mainReport["@maritalStatus"] = model.MaritalStatus == MaritalStatus.Unknown ? null : model.MaritalStatus;
                mainReport["@birthDate"] = model.BirthDate;
                mainReport["@toBirthDate"] = model.ToBirthDate;
                mainReport["@dateEmployeement"] = model.DateEmployeement;
                mainReport["@toDateEmployeement"] = model.ToDateEmployeement;
            }
            catch (Exception)
            {

                mainReport["@employeeId"] = null;
                mainReport["@positionId"] = null;
                mainReport["@companyId"] = null;
                mainReport["@userNameFmaily"] = null;
                mainReport["@nationalCode"] = null;
                mainReport["@personnelCode"] = null;
                mainReport["@maritalStatus"] = null;
                mainReport["@birthDate"] = null;
                mainReport["@toBirthDate"] = null;
                mainReport["@dateEmployeement"] = null;
                mainReport["@toDateEmployeement"] = null;

            }

            // فراخوانی فایل استیمول
            mainReport.Load(Server.MapPath("~/ReportFiles/PersonnelReportFilter.mrt"));
            // 
            mainReport.Compile();

            //if (model.FromDate.HasValue)
            //    mainReport["FromDate"] = ConvertAdToJalali(model.FromDate.Value);
            //if (model.ToDate.HasValue)
            //    mainReport["ToDate"] = ConvertAdToJalali(model.ToDate.Value);
            //mainReport["DateAndTime"] = ConvertAdToJalaliDateTime(DateTime.Now);
            //mainReport["PersonelId"] =model.IDPersonel;
            //mainReport["AgencyId"] = _agencyService.GetById(model.AgencyId).IDAgent;
            //mainReport["MelliCode"] = model.MelliCode;

            return Stimulsoft.Report.Mvc.StiMvcViewer.GetReportSnapshotResult(mainReport);
        }
        public virtual ActionResult ViewerEvent()
        {
            return Stimulsoft.Report.Mvc.StiMvcViewer.ViewerEventResult(HttpContext);
        }
        #endregion
    }
}