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

    public class PositionTypeController : BaseController
    {
        #region Fields
        private readonly IPositionTypeService _positionTypeService;
        private readonly ICheckingRole _checkingRoleService;
        private readonly IUserService _userService;
        #endregion
        #region Ctor
        public PositionTypeController(IPositionTypeService positionTypeService, ICheckingRole checkingRoleService, IUserService userService)
        {
            _positionTypeService = positionTypeService;
            _checkingRoleService = checkingRoleService;
            _userService = userService;
        }
        #endregion
        #region Utilities


        [NonAction]
        protected virtual void PrepareAllPositionTypeModel(PositionTypeModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            model.PositionTypes.Add(new SelectListItem
            {
                Text = " پست سازمانی",
                Value = "0"
            });
            //var companies = SelectListHelper.GetCompanyList(_companyService);
            var positionTypes = _positionTypeService.GetAll();
            foreach (var c in positionTypes)
            {
                model.PositionTypes.Add(new SelectListItem
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
            var model = new PositionTypeModel();

            if (!_checkingRoleService.HasAccess(PermissionList.PositionTypeList, CurrentUser.GetCurrentUser))
            {
                return View("Inaccessibility");
            }

            return View(model);
        }
        public ActionResult Create()
        {
            var model = new PositionTypeModel();

            if (!_checkingRoleService.HasAccess(PermissionList.PositionTypeCreate, CurrentUser.GetCurrentUser))
            {
                return PartialView("_Inaccessibility");
            }


            return PartialView(model);
        }
        [HttpPost]
        public ActionResult Create(PositionTypeModel model)
        {
            var result = new ReturnAjaxForm();
            var positionType = new PositionType();


            if (ModelState.IsValid)
            {
                try
                {
                    positionType.Title = model.Title;
                    positionType.CreatedDate = DateTime.Now;
                    positionType.ActionUserId = User.Identity.GetUserId();


                    ///عملیات ثبت در دیتابیس
                    _positionTypeService.Insert(positionType);
                    ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                    ShowMessageToUser(result, "با موفقیت ثبت شد .", ResultType.Success);

                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null && ex.InnerException.InnerException != null && ex.InnerException.InnerException.Message != null && ex.InnerException.InnerException.Message.Contains("Cannot insert duplicate key row in object 'dbo.PositionTypes' with unique index 'IX_Title'"))
                    {
                        ///نمایش پیام خطا به کاربر

                        ShowMessageToUser(result, " عنوان وارد شده از قبل در دیتابیس موجود است.", ResultType.Failure);



                    }
                    else
                    {
                        ///نمایش پیام خطا به کاربر

                        ShowMessageToUser(result, "عملیات با خطا مواجه شد.", ResultType.Failure);


                    }
                    /// لاگ خطا

                    LogException.Write(ex, "CreateMethodInPositionTypeController");



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

        [HttpGet]
        public ActionResult Edit(int id)
        {

            var model = new PositionTypeModel();

            if (!_checkingRoleService.HasAccess(PermissionList.PositionTypeEdit, CurrentUser.GetCurrentUser))
            {

                return PartialView("_Inaccessibility");
            }

            var entity = _positionTypeService.GetById(id);
            model.Id = entity.Id;
            model.Title = entity.Title;

            return PartialView(model);
        }
        [HttpPost]
        public ActionResult Edit(PositionTypeModel model)
        {
            var result = new ReturnAjaxForm();

            var positionType = _positionTypeService.GetById(model.Id);


            if (ModelState.IsValid)
            {
                try
                {
                    positionType.Title = model.Title;
                    positionType.ModifiedDate = DateTime.Now;
                    positionType.LastActionUserId = User.Identity.GetUserId();

                    ///عملیات ویرایش در دیتابیس

                    _positionTypeService.Update(positionType);
                    ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                    ShowMessageToUser(result, "با موفقیت ویرایش شد .", ResultType.Success);

                }
                catch (Exception ex)
                {

                    /// لاگ خطا

                    LogException.Write(ex, "EditMethodInPositionTypeController");


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
        [HttpGet]
        public JsonResult List(DataTableRequest request, [ModelBinder(typeof(DataTableModelBinder))]DataTableRequestFilter filter)

        {
            if (request.length == -1)
            {
                request.length = int.MaxValue;
            }
            var data = _positionTypeService.FilterData(request.start, request.length, filter.Search, filter.SortColumn, filter.SortDirection);


            var gridModel = new DataTableResponse<EmployeeTypeModel>()
            {
                data = data.Select(x =>
                {

                    var m = new EmployeeTypeModel();
                    m.Title = x.Title;
                    m.ShamsiCreateDate = x.CreatedDate != null ? ConvertAdToJalaliDateTime(x.CreatedDate.Value) : "";

                    m.ActionUserName = x.ActionUserId != null ? _userService.GetById(x.ActionUserId).UserName : "توسط سیستم";

                    m.ShamsiCreateDate = x.ModifiedDate != null ? ConvertAdToJalaliDateTime(x.ModifiedDate.Value) : "";

                    m.EditUserName = x.LastActionUserId != null ? _userService.GetById(x.LastActionUserId).UserName : "";

                    m.Id = x.Id;
                    m.ShamsiEditDate = x.ModifiedDate != null ? ConvertAdToJalaliDateTime(x.ModifiedDate.Value) : "";



                    return m;
                }).ToList(),
                recordsTotal = _positionTypeService.Count(filter.Search),
                recordsFiltered = _positionTypeService.Count(filter.Search),
                draw = request.draw
            };



            return Json(gridModel, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var result = new ReturnAjaxForm();

            if (!_checkingRoleService.HasAccess(PermissionList.PositionTypeDelete, CurrentUser.GetCurrentUser))
            {
                ///نمایش پیام عدم دسترسی به کاربر

                ShowMessageToUser(result, " کاربر گرامی،شما  مجوز حذف رکورد را ندارید!", ResultType.NotAllow);


                //return Json(result);
            }



            try
            {
                var entity = _positionTypeService.GetById(id);

                if (entity.Title == PositionTypeEnum.MasterOfWork.ToString())
                {
                    ///نمایش پیام خطا به کاربر

                    ShowMessageToUser(result, "امکان حذف  رکورد وجود ندارد.", ResultType.Failure);
                }
                else
                {

                    _positionTypeService.Remove(entity);

                    ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                    ShowMessageToUser(result, "با موفقیت حذف شد .", ResultType.Success);
                }

            }
            catch (Exception ex)
            {

                /// لاگ خطا

                LogException.Write(ex, "DeleteMethodInPositionTypeController");


                ///نمایش پیام خطا به کاربر

                ShowMessageToUser(result, "امکان حذف  رکورد وجود ندارد.", ResultType.Failure);

            }

            return Json(result, JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetAllPositionType()
        {
            var model = new PositionTypeModel();

            PrepareAllPositionTypeModel(model);

            return Json(model.PositionTypes, JsonRequestBehavior.AllowGet);

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