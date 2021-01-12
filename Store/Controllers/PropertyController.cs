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
using Store.WebEssential.Helper;
using Store.Service;
using Store.Essential.Model;
using Store.Core.Domain.StoreTables.StoreRoom;
using Store.Models.Stores.StoreRoom;

namespace Store.Controllers
{
    [Authorize]
    public class PropertyController : BaseController
    {
        #region Fields
        private readonly IPropertyService _propertyService;
        private readonly ICheckingRole _checkingRoleService;
        private readonly IUserService _userService;
        #endregion
        #region Ctor
        
        public PropertyController(IPropertyService propertyService, ICheckingRole checkingRoleService, IUserService userService)
        {
            _propertyService = propertyService;
            _checkingRoleService = checkingRoleService;
            _userService = userService;
        }
        #endregion
        #region Utilities

    
      
        #endregion
        #region ActionMethod
        public ActionResult Index()
        {
            var model = new PropertyModel();

            if (!_checkingRoleService.HasAccess(PermissionList.PropertyList, CurrentUser.GetCurrentUser))
            {
                return View("Inaccessibility");
            }

            return View(model);
        }
        public ActionResult Create()
        {
            var model = new PropertyModel();

            if (!_checkingRoleService.HasAccess(PermissionList.PropertyCreate, CurrentUser.GetCurrentUser))
            {

                return PartialView("_Inaccessibility");
            }
            
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult Create(PropertyModel model)
        {
            var result = new ReturnAjaxForm();
            var property = new Property();
            
            if (ModelState.IsValid)
            {
                try
                {
                    property.Title = model.Title;
                    property.ActionUserId = User.Identity.GetUserId();

                    ///عملیات ثبت در دیتابیس
                    _propertyService.Insert(property);

                    ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر
                    
                    ShowMessageToUser(result, "با موفقیت ثبت شد", ResultType.Success);
                    
                }
                catch (Exception ex)
                {
                    /// لاگ خطا

                    LogException.Write(ex, "CreateMethodInPropertyController");


                    ///نمایش پیام خطا به کاربر

                    ShowMessageToUser(result, "عملیات با خطا مواجه شد.", ResultType.Failure);
                }

            }
            else
            {
                /// show Error Message To User beacuse ModelState Is Invalid
                StringBuilder builder = AddErrors();
                ShowMessageToUser(result, builder.ToString(),ResultType.Failure);
            }
            return Json(result);
        }
        

        [HttpGet]
        public ActionResult Edit(int id)
        {

            var model = new PropertyModel();

            if (!_checkingRoleService.HasAccess(PermissionList.PropertyEdit, CurrentUser.GetCurrentUser))
            {
                return PartialView("_Inaccessibility");
            }

            var property = _propertyService.GetById(id);
            model.Title = property.Title;
            model.Id = property.Id;
            
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult Edit(BuildingModel model)
        {
            var result = new ReturnAjaxForm();

            var property = _propertyService.GetById(model.Id);
           


            if (ModelState.IsValid)
            {
                try
                {
                    property.Title = model.Title;
                    property.ModifiedDate = DateTime.Now;
                    property.LastActionUserId = User.Identity.GetUserId();

                    ///عملیات ویرایش در دیتابیس

                    _propertyService.Update(property);

                    ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                    ShowMessageToUser(result, "با موفقیت ویرایش شد", ResultType.Success);
                   
                }
                catch (Exception ex)
                {   
                    /// لاگ خطا

                    LogException.Write(ex, "EditMethodInPropertyController");


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
        [HttpGet]
        public JsonResult List(DataTableRequest request, [ModelBinder(typeof(DataTableModelBinder))]DataTableRequestFilter filter)

        {
            if (request.length == -1)
            {
                request.length = int.MaxValue;
            }
            var data = _propertyService.FilterData(request.start, request.length, filter.Search, filter.SortColumn, filter.SortDirection);


            var gridModel = new DataTableResponse<PropertyModel>()
            {
                data = data.Select(x =>
                {

                    var m = new PropertyModel();
                    m.Title = x.Title;
                    m.ShamsiCreateDate = ConvertAdToJalaliDateTime(x.CreatedDate.Value);
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
                recordsTotal = _propertyService.Count(filter.Search),
                recordsFiltered = _propertyService.Count(filter.Search),
                draw = request.draw
            };



            return Json(gridModel, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var result = new ReturnAjaxForm();

            if (!_checkingRoleService.HasAccess(PermissionList.PropertyDelete, CurrentUser.GetCurrentUser))
            {
                ///نمایش پیام عدم دسترسی  به کاربر

                ShowMessageToUser(result, "کاربر گرامی،شما  مجوز حذف رکورد را ندارید! ", ResultType.NotAllow);

          
                //return Json(result, JsonRequestBehavior.AllowGet);
            }
            
            try
            {
                var entity = _propertyService.GetById(id);
                _propertyService.Remove(entity);

                ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                ShowMessageToUser(result, "با موفقیت حذف شد", ResultType.Success);

            }
            catch (Exception ex)
            {
                /// لاگ خطا

                LogException.Write(ex, "DeleteMethodInPropertyController");


                ///نمایش پیام خطا به کاربر

                ShowMessageToUser(result, "امکان حذف  رکورد وجود ندارد.", ResultType.Failure);
            }

            return Json(result);

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