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

namespace Store.Controllers
{
    [Authorize]
    //[ServerDown]
    public class PersonnelDetailController : BaseController
    {
        #region Fields
        private readonly IPersonnelService _personnelService;
        private readonly IUserService _userService;
        private readonly IPositionTypeService _positionService;
        private readonly IEmployeeTypeService _employeeService;
        private readonly ICompanyService _companyService;
        private readonly ICheckingRole _checkingRoleService;
        #endregion

        #region Ctor
        public PersonnelDetailController(IPersonnelService personnelService, ICheckingRole checkingRoleService,IEmployeeTypeService employeeService,IPositionTypeService positionService, ICompanyService companyService, IUserService userService)
        {
            _personnelService = personnelService;
            _checkingRoleService = checkingRoleService;
            _positionService = positionService;
            _employeeService = employeeService;
            _companyService = companyService;
            _userService = userService;
        }
        #endregion

        #region Utilities

      
        [NonAction]
        public void PreparePositionType(PersonnelModel model)
        {
            var positions = _positionService.GetAll();

            model.Positions = (from c in positions
                               select new SelectListItem
                               {
                                   Text = c.Title,
                                   Value = c.Id.ToString(),
                                   Selected = false
                               }).ToList();
            model.Positions.Add(new SelectListItem
            {
                Text = "انتخاب پست سازمانی",
                Value = "",
                Selected = true
            });

        }
        [NonAction]
        protected virtual void PrepareAllCompaniesModel(PersonnelModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            model.Companies.Add(new SelectListItem
            {
                Text = "[None]",
                Value = " "
            });
            var companies = SelectListHelper.GetCompanyList(_companyService);
            foreach (var c in companies)
                model.Companies.Add(c);
        }

        [NonAction]
        public void PrepareEmployeeType(PersonnelModel model)
        {
            var employees = _employeeService.GetAll();

            model.Employees = (from c in employees
                               select new SelectListItem
                               {
                                   Text = c.Title,
                                   Value = c.Id.ToString(),
                                   Selected = false
                               }).ToList();

            model.Employees.Add(new SelectListItem
            {
                Text = "انتخاب نوع همکاری",
                Value = "",
                Selected = true
            });

        }

        #endregion
        #region ActionMethod
        public ActionResult Index()
        {
            var model = new PersonnelModel();

            if (!_checkingRoleService.HasAccess(PermissionList.PersonnelList, CurrentUser.GetCurrentUser))
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

            return View(model);
        }
        [HttpPost]
      
        public ActionResult Create(PersonnelModel model)
        {
            var result = new ReturnAjaxForm();

            var personnel =new Personnel();

            if (ModelState.IsValid)
            {
                try
                {
                    personnel.UserNameFmaily = model.UserNameFmaily;
                    personnel.PositionTypeId = model.PositionId;
                    personnel.EmployeeTypeId = model.EmployeeId;
                    personnel.MaritalStatus = model.MaritalStatus.Value;
                    personnel.NationalCode = model.NationalCode;
                    personnel.BirthDate = model.BirthDate;
                    personnel.DateEmployeement = model.DateEmployeement;
                    personnel.Description = model.Description;
                    personnel.PersonnelCode = model.PersonnelCode.Value;
                    personnel.CompanyId = model.CompanyId;
                    personnel.MaritalStatus = model.MaritalStatus.Value;

                    ///کدام کاربر و در چه تاریخی ثبت را انجام داده است
                    personnel.CreatedDate = DateTime.Now;
                    personnel.ActionUserId = User.Identity.GetUserId();

                    ///عملیات ثبت در دیتابیس

                    _personnelService.Insert(personnel);

                    ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                    ShowMessageToUser(result, "با موفقیت ثبت شد", ResultType.Success);
                }
              
                catch (Exception e)
                {
                    if(e.InnerException.InnerException.Message.Contains("Violation of PRIMARY KEY constraint 'PK_dbo.Personnels'"))
                    {

                        ///نمایش پیام خطا به کاربر

                        ShowMessageToUser(result, " کد پرسنلی از قبل در دیتابیس موجود است.", ResultType.Failure);

                        
                    }
                    else
                    {
                        ///نمایش پیام خطا به کاربر

                        ShowMessageToUser(result, e.Message, ResultType.Failure);
                     
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

            model.BirthDate = personnel.BirthDate;
            model.PersonnelCode = personnel.PersonnelCode;
            model.UserNameFmaily = personnel.UserNameFmaily;
            model.PositionId = personnel.PositionTypeId;
            model.EmployeeId = personnel.EmployeeTypeId;
            model.DateEmployeement = personnel.DateEmployeement;
            model.Description = personnel.Description;
            model.MaritalStatus = personnel.MaritalStatus;
            model.NationalCode = personnel.NationalCode;
            model.CompanyId = personnel.CompanyId;
            model.MaritalStatus = personnel.MaritalStatus;
            


            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(PersonnelModel model)
        {
            var result = new ReturnAjaxForm();

            var personnel = _personnelService.GetById(model.Id);

            if (ModelState.IsValid)
            {
                try
                {
                    personnel.UserNameFmaily = model.UserNameFmaily;
                    personnel.PositionTypeId = model.PositionId;
                    personnel.EmployeeTypeId = model.EmployeeId;
                    personnel.MaritalStatus = model.MaritalStatus.Value;
                    personnel.NationalCode = model.NationalCode;
                    personnel.BirthDate = model.BirthDate;
                    personnel.DateEmployeement = model.DateEmployeement;
                    personnel.Description = model.Description;
                    personnel.PersonnelCode = model.PersonnelCode.Value;
                    personnel.CompanyId = model.CompanyId;
                    personnel.MaritalStatus = model.MaritalStatus.Value;

                    ///کدام کاربر و در چه تاریخی ویرایش  انجام داده است
                    personnel.ModifiedDate = DateTime.Now;
                    personnel.LastEditUserId = User.Identity.GetUserId();

                    ///عملیات ویرایش در دیتابیس

                    _personnelService.Update(personnel);
                    ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                    ShowMessageToUser(result, "با موفقیت ویرایش شد", ResultType.Success);
                }
                catch (Exception e)
                {
                    ///نمایش پیام خطا به کاربر

                    ShowMessageToUser(result, e.Message, ResultType.Failure);
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
            catch (Exception e)
            {
                ///نمایش پیام خطا به کاربر

                ShowMessageToUser(result, e.Message, ResultType.Failure);
            }

            return Json(result, JsonRequestBehavior.AllowGet);

        }
        #endregion
        #region List
        public JsonResult List(DataTableRequest request, [ModelBinder(typeof(DataTableModelBinder))]DataTableRequestFilter filter,PersonnelModel model)

        {
            if (request.length == -1)
            {
                request.length = int.MaxValue;

            }
          
            var data = _personnelService.FilterData(request.start, request.length, filter.Search, filter.SortColumn, filter.SortDirection,null,null, model.BirthDate, model.ToBirthDate,model.DateEmployeement, model.ToDateEmployeement, model.MaritalStatus, model.NationalCode, model.UserNameFmaily, model.PersonnelCode, model.PositionId, model.EmployeeId, model.CompanyId);
            var gridModel = new DataTableResponse<PersonnelModel>();
            gridModel.draw = request.draw;

            data.ForEach(x =>
            {
                var personnel = new PersonnelModel();
                personnel.PersonnelCode = x.PersonnelCode;
                personnel.NationalCode = x.NationalCode;
                personnel.UserNameFmaily = x.UserNameFmaily;
                personnel.Description = x.Description;
                personnel.ActionUserName = _userService.GetById(x.ActionUserId).UserName;
                personnel.ShamsiCreateDate = ConvertAdToJalaliDateTime(x.CreatedDate.Value);

                if(x.ModifiedDate.HasValue)
                personnel.ShamsiEditDate = ConvertAdToJalaliDateTime(x.ModifiedDate.Value);

                if (x.DateEmployeement.HasValue)
                    personnel.ShamsiDateEmployeement = ConvertAdToJalali(x.DateEmployeement.Value);

                if (x.BirthDate.HasValue)
                    personnel.ShamsiBirthDate = ConvertAdToJalali(x.BirthDate.Value);

                if (x.PositionTypeId.HasValue)
                    personnel.PositionName =x.PositionType.Title;

                if (x.EmployeeTypeId.HasValue)
                    personnel.EmployeeName = x.EmployeeType.Title;

                if (x.CompanyId.HasValue)
                    personnel.CompanyName = x.Company.Title;

                if (x.LastEditUserId!=null)
                    personnel.EditUserName = _userService.GetById(x.LastEditUserId).UserName;

                personnel.UserNameFmaily = x.UserNameFmaily;
                personnel.MaritalStatusTitle = x.MaritalStatus.GetDisplayName();
                gridModel.data.Add(personnel);
            });

            gridModel.recordsFiltered = _personnelService.Count(filter.Search);
            gridModel.recordsTotal = _personnelService.Count(filter.Search);

            return Json(gridModel, JsonRequestBehavior.AllowGet);
        }
        #endregion List

    }
}