using Store.Models;
using Store.WebEssential.Mvc;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Text;
using Microsoft.AspNet.Identity;
using Store.Core.CommonHelper;
using Store.WebEssential.ModelBinder;
using Store.WebEssential.UserControl;
using Store.Service.User;
using Store.WebEssential.Extensions;
using System.Configuration;
using Store.Service.Stores;
using Store.Core.Domain.StoreTables;
using Store.Models.Stores;
using Store.Service;
using Store.Essential.Model;

namespace Store.Controllers
{
    [Authorize]
    public class EmployeeTypeController : BaseController
    {
        #region Fields
        private readonly IEmployeeTypeService _employeeTypeService;
        private readonly ICheckingRole _checkingRoleService;
        private readonly IUserService _userService;
        #endregion
        #region Ctor
        public EmployeeTypeController(IEmployeeTypeService employeeTypeService, ICheckingRole checkingRoleService, IUserService userService)
        {
            _employeeTypeService = employeeTypeService;
            _checkingRoleService = checkingRoleService;
            _userService = userService;
        }
        #endregion
        #region Utilities

        [NonAction]
        protected virtual void PrepareAllEmployeeTypeModel(EmployeeTypeModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            model.EmployeeTypes.Add(new SelectListItem
            {
                Text = " نوع همکاری ",
                Value = "0"
            });
            //var companies = SelectListHelper.GetCompanyList(_companyService);
            var employeeTypes = _employeeTypeService.GetAll();

            foreach (var c in employeeTypes)
            {
                model.EmployeeTypes.Add(new SelectListItem
                {
                    Text = c.Title,
                    Value = c.Id.ToString()
                });
            }

        }


        #endregion
        #region ActionMethod
        public ActionResult Index()
        {
            var model = new EmployeeTypeModel();

            if (!_checkingRoleService.HasAccess(PermissionList.EmployeeTypeList, CurrentUser.GetCurrentUser))
            {

                return View("Inaccessibility");
            }

            return View(model);
        }
        public ActionResult Create()
        {
            var model = new EmployeeTypeModel();

            if (!_checkingRoleService.HasAccess(PermissionList.EmployeeTypeCreate, CurrentUser.GetCurrentUser))
            {

                return PartialView("_Inaccessibility");
            }
            

            return PartialView(model);
        }
        [HttpPost]
        public ActionResult Create(EmployeeTypeModel model)
        {
            var result = new ReturnAjaxForm();
            var employeeType = new EmployeeType();

           
            bool IsTitleExist = false;

            /// کد پایین چک می کند عنوان تکرای وارد نشود
           
            if (_employeeTypeService.GetAll(title: model.Title).Count > 0)
            {
                IsTitleExist = true;
            }

          
            if (IsTitleExist)
            {
                ModelState.AddModelError("Title", "عنوان همکاری  تکراری است!");
            }
           

            if (ModelState.IsValid)
            {
                try
                {
                    employeeType.Title = model.Title;
                    employeeType.CreatedDate = DateTime.Now;
                    employeeType.ActionUserId = User.Identity.GetUserId();
                   
                    ///عملیات ثبت در دیتابیس
                    _employeeTypeService.Insert(employeeType);

                    result.ResultType = ResultType.Success;
                    result.Message = " با موفقیت ثبت شد";
                }
                catch (Exception ex)
                {

                    /// لاگ خطا

                    LogException.Write(ex, "CreateMethodInEmployeeTypeController");

                    ///نمایش پیام خطا به کاربر

                    ShowMessageToUser(result, " عملیات با خطا مواجه شد.", ResultType.Failure);

                }

            }
            else
            {
                StringBuilder builder = new StringBuilder();
                // Append to StringBuilder.
                foreach (var e in ModelState.Values)
                {
                    if (e.Errors.Count() > 0)
                    {
                        foreach (var error in e.Errors.ToList())
                        {
                            builder.Append(error.ErrorMessage).Append("\n");
                        }
                    }

                }
                result.ResultType =ResultType.Failure;
                result.Message = builder.ToString();
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            var model =new EmployeeTypeModel();

            if (!_checkingRoleService.HasAccess(PermissionList.EmployeeTypeEdit, CurrentUser.GetCurrentUser))
            {
                return PartialView("_Inaccessibility");
            }

            var entity = _employeeTypeService.GetById(id);
            model.Id = entity.Id;
            model.Title = entity.Title;

            return PartialView(model);
        }
        [HttpPost]
        public ActionResult Edit(EmployeeTypeModel model)
        {
            var result = new ReturnAjaxForm();
            bool IsTitleExist = false;

            var employeeType = _employeeTypeService.GetById(model.Id);


            var exist = _employeeTypeService.GetAll(title: model.Title.Trim());
            

            if (exist.Count > 0 && exist.FirstOrDefault().Id != employeeType.Id)
            {
                IsTitleExist = true;
            }
           
            if (IsTitleExist)
            {
                ModelState.AddModelError("StoreName", "عنوان همکاری تکراری است!");
            }
           
           
            if (ModelState.IsValid)
            {
                try
                {
                    employeeType.Title = model.Title;
                    employeeType.ModifiedDate = DateTime.Now;
                    employeeType.LastActionUserId = User.Identity.GetUserId();

                    ///عملیات ویرایش در دیتابیس
                   
                    _employeeTypeService.Update(employeeType);

                    result.ResultType = ResultType.Success;
                    result.Message = " با موفقیت ویرایش شد";
                }
                catch (Exception ex)
                {
                    /// لاگ خطا

                    LogException.Write(ex, "EditMethodInEmployeeTypeController");

                    ///نمایش پیام خطا به کاربر

                    ShowMessageToUser(result, " عملیات با خطا مواجه شد.", ResultType.Failure);
                }

            }
            else
            {
                StringBuilder builder = new StringBuilder();
                // Append to StringBuilder.
                foreach (var e in ModelState.Values)
                {
                    if (e.Errors.Count() > 0)
                    {
                        foreach(var error in e.Errors.ToList())
                        {
                            builder.Append(error.ErrorMessage).Append("\n");
                        }
                    }
                       
                }
                result.ResultType = ResultType.Failure;
                result.Message = builder.ToString();
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult List(DataTableRequest request, [ModelBinder(typeof(DataTableModelBinder))]DataTableRequestFilter filter)

        {
            if (request.length == -1)
            {
                request.length = int.MaxValue;
            }
            var data = _employeeTypeService.FilterData(request.start, request.length, filter.Search, filter.SortColumn, filter.SortDirection);


            var gridModel = new DataTableResponse<EmployeeTypeModel>()
            {
                data = data.Select(x =>
                {

                    var m = new EmployeeTypeModel();
                    m.Title = x.Title;
                    m.ShamsiCreateDate = ConvertAdToJalaliDateTime(x.CreatedDate.Value);
                    m.ActionUserName = x.ActionUserId != null ? _userService.GetById(x.ActionUserId).UserName : "توسط سیستم";
                    //m.ActionUserName = _userService.GetById(x.ActionUserId).UserName;
                    if (x.ModifiedDate.HasValue)
                        m.ShamsiCreateDate = ConvertAdToJalaliDateTime(x.ModifiedDate.Value);
                    m.EditUserName = x.LastActionUserId != null ? _userService.GetById(x.LastActionUserId).UserName : "";
                    //if (x.LastActionUserId != null)
                    //    m.EditUserName = _userService.GetById(x.ActionUserId).UserName;

                    m.Id = x.Id;

                    if (x.ModifiedDate != null)
                    {
                        m.ShamsiEditDate = ConvertAdToJalaliDateTime(x.ModifiedDate.Value);
                    }


                    return m;
                }).ToList(),
                recordsTotal = _employeeTypeService.Count(filter.Search),
                recordsFiltered = _employeeTypeService.Count(filter.Search),
                draw = request.draw
            };



            return Json(gridModel, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var result = new ReturnAjaxForm();

            if (!_checkingRoleService.HasAccess(PermissionList.EmployeeTypeDelete, CurrentUser.GetCurrentUser))
            {
                result.ResultType = ResultType.NotAllow;
                result.Message = " کاربر گرامی،شما  مجوز حذف رکورد را ندارید!  ";
                return Json(result, JsonRequestBehavior.AllowGet);
            }



            try
            {
                var entity = _employeeTypeService.GetById(id);
                _employeeTypeService.Remove(entity);

                result.ResultType = ResultType.Success;
                result.Message = " با موفقیت حذف شد";
            }
            catch (Exception ex)
            {
                /// لاگ خطا

                LogException.Write(ex, "DeleteMethodInEmployeeTypeController");

                ///نمایش پیام خطا به کاربر

                ShowMessageToUser(result, "امکان حذف  رکورد وجود ندارد.", ResultType.Failure);
            }

            return Json(result, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetAllEmployeeType()
        {
            var model = new EmployeeTypeModel();

            PrepareAllEmployeeTypeModel(model);

            return Json(model.EmployeeTypes, JsonRequestBehavior.AllowGet);

        }
        #endregion


        #region Report
        public virtual ActionResult Print()
        {
            return View();
        }

    



        #endregion

    }
}