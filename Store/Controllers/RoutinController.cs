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
using Store.Core.Domain.StoreTables.Work;
using Store.Service;
using Store.Essential.Model;

namespace Store.Controllers
{
    [Authorize]

    public class RoutinController : BaseController
    {
        #region Fields
        private readonly IRoutinService _routinService;
        private readonly ICheckingRole _checkingRoleService;
        private readonly IUserService _userService;
        #endregion
        #region Ctor
        public RoutinController(IRoutinService routinService, ICheckingRole checkingRoleService, IUserService userService)
        {
            _routinService = routinService;
            _checkingRoleService = checkingRoleService;
            _userService = userService;
        }
        #endregion
        #region Utilities


        #endregion
        #region ActionMethod
        public ActionResult Index()
        {
            var model = new RoutineModel();

            if (!_checkingRoleService.HasAccess(PermissionList.RoutinList, CurrentUser.GetCurrentUser))
            {

                return View("Inaccessibility");
            }

            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var model = new RoutineModel();

            if (!_checkingRoleService.HasAccess(PermissionList.RoutinCreate, CurrentUser.GetCurrentUser))
            {
                return PartialView("_Inaccessibility");
            }


            return PartialView(model);
        }
        [HttpPost]
        public ActionResult Create(RoutineModel model)
        {
            var result = new ReturnAjaxForm();
            var routine = new Routine();

            if (ModelState.IsValid)
            {
                try
                {
                    routine.Title = model.Title;
                    routine.CreatedDate = DateTime.Now;
                    routine.ActionUserId = User.Identity.GetUserId();

                    ///عملیات ثبت در دیتابیس

                    _routinService.Insert(routine);


                    ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                    ShowMessageToUser(result, "با موفقیت ثبت شد .", ResultType.Success);

                }

                catch (Exception ex)
                {
                    /// لاگ خطا

                    LogException.Write(ex, "CreateMethodInRoutinController");

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
        public ActionResult Edit(int id)
        {

            var model = new RoutineModel();

            if (!_checkingRoleService.HasAccess(PermissionList.RoutinEdit, CurrentUser.GetCurrentUser))
            {

                return PartialView("_Inaccessibility");
            }

            var entity = _routinService.GetById(id);
            model.Id = entity.Id;
            model.Title = entity.Title;

            return PartialView(model);
        }
        [HttpPost]
        public ActionResult Edit(RoutineModel model)
        {
            var result = new ReturnAjaxForm();
            
            if (ModelState.IsValid)
            {
                try
                {
                    var routine = _routinService.GetById(model.Id);

                    routine.Title = model.Title;
                    routine.ModifiedDate = DateTime.Now;
                    routine.LastActionUserId = User.Identity.GetUserId();

                    ///عملیات ویرایش در دیتابیس

                    _routinService.Update(routine);

                    ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                    ShowMessageToUser(result, "با موفقیت ویرایش شد.", ResultType.Success);

                }

                catch (Exception ex)
                {
                    /// لاگ خطا

                    LogException.Write(ex, "EditMethodInRoleController");

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
            var data = _routinService.FilterData(request.start, request.length, filter.Search, filter.SortColumn, filter.SortDirection);


            var gridModel = new DataTableResponse<RoutineModel>()
            {
                data = data.Select(x =>
                {

                    var m = new RoutineModel();
                    m.Title = x.Title;
                    if (x.CreatedDate.HasValue)
                        m.ShamsiCreateDate = ConvertAdToJalaliDateTime(x.CreatedDate.Value);
                    if (x.ActionUserId != null)
                        m.ActionUserName = _userService.GetById(x.ActionUserId).UserName;

                    if (x.ModifiedDate.HasValue)
                        m.ShamsiCreateDate = ConvertAdToJalaliDateTime(x.ModifiedDate.Value);
                    if (x.LastActionUserId != null)
                        m.EditUserName = _userService.GetById(x.ActionUserId).UserName;

                    m.Id = x.Id;

                    if (x.ModifiedDate != null)
                    {
                        m.ShamsiEditDate = ConvertAdToJalaliDateTime(x.ModifiedDate.Value);
                    }


                    return m;
                }).ToList(),
                recordsTotal = _routinService.Count(),
                recordsFiltered = _routinService.Count(),
                draw = request.draw
            };



            return Json(gridModel, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var result = new ReturnAjaxForm();

            if (!_checkingRoleService.HasAccess(PermissionList.RoutinDelete, CurrentUser.GetCurrentUser))
            {
                ///نمایش پیام عدم دسترسی به کاربر

                ShowMessageToUser(result, " کاربر گرامی،شما  مجوز حذف رکورد را ندارید!", ResultType.NotAllow);


                return Json(result);
            }


            try
            {
                var entity = _routinService.GetById(id);
                _routinService.Remove(entity);

                ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                ShowMessageToUser(result, "با موفقیت حذف شد", ResultType.Success);

            }
            catch (Exception ex)
            {
                /// لاگ خطا

                LogException.Write(ex, "DeleteMethodInRoutinController");


                ///نمایش پیام خطا به کاربر

                ShowMessageToUser(result, "امکان حذف  رکورد وجود ندارد.", ResultType.Failure);
            }

            return Json(result, JsonRequestBehavior.AllowGet);

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