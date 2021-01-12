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
using Store.Service.Media;
using System.Collections.Generic;

namespace Store.Controllers
{
    [Authorize]
    public class EquipmentPropertiesController : BaseController
    {
        #region Fields
        private readonly IEquipmentService _equipmentService;
        private readonly ICheckingRole _checkingRoleService;
        private readonly IUserService _userService;
        private readonly IUnitService _unitService;
        private readonly IEquipmentHasPropertyService _equipmentPropertyService;
        private readonly IPropertyService _propertyService;
        #endregion
        #region Ctor

        public EquipmentPropertiesController(IUnitService unitService,IPropertyService propertyService, IEquipmentHasPropertyService equipmentPropertyService, IUserService userService, IEquipmentService equipmentService, ICheckingRole checkingRoleService)
        {
            _equipmentService = equipmentService;
            _checkingRoleService = checkingRoleService;
            _userService = userService;
            _equipmentPropertyService = equipmentPropertyService;
            _propertyService = propertyService;
            _unitService = unitService;
        }
        #endregion
        #region Utilities

        [NonAction]
        protected virtual void PrepareAllUnits(EquipmentHasPropertyModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            model.Units.Add(new SelectListItem
            {
                Text = "انتخاب واحد ",
                Value = " ",
                Selected = true
            });
            var units = _unitService.GetAll();

            foreach (var c in units)
            {
                model.Units.Add(new SelectListItem
                {
                    Text = c.Title,
                    Value = c.Id.ToString()
                });
            }
        }

        [NonAction]
        protected virtual void PrepareAllEquipments(EquipmentHasPropertyModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            model.EquipmentList.Add(new SelectListItem
            {
                Text = "انتخاب تجهیزات ",
                Value = " ",
                Selected = true
            });
            var equipments = _equipmentService.GetAll();

            foreach (var c in equipments)
            {
                model.EquipmentList.Add(new SelectListItem
                {
                    Text = c.Title,
                    Value = c.Id.ToString()
                });
            }
        }

        [NonAction]
        protected virtual void PrepareAllPropertiesModel(EquipmentHasPropertyModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

           model.Properties.Add(new SelectListItem
            {
                Text = "انتخاب ویژگی ",
                Value = "0",
                Selected = true
            });
            var properties = _propertyService.GetAll();

            foreach (var c in properties)
            {
                model.Properties.Add(new SelectListItem
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
            var model = new EquipmentHasPropertyModel();

            if (!_checkingRoleService.HasAccess(PermissionList.EquipmentHasPropertyList, CurrentUser.GetCurrentUser))
            {
                return View("Inaccessibility");
            }

            return View(model);
        }
        public ActionResult Create()
        {
            var model = new EquipmentHasPropertyModel();

            if (!_checkingRoleService.HasAccess(PermissionList.EquipmentHasPropertyCreate, CurrentUser.GetCurrentUser))
            {

                return View("Inaccessibility");
            }

            ///آماده سازی مشخصه ها
            PrepareAllPropertiesModel(model);

            ///آماده سازی  تجهیزات
            PrepareAllEquipments(model);

            ///آماده سازی  واحد
           PrepareAllUnits(model);

            return View(model);
        }
        [HttpPost]
        public ActionResult Create(EquipmentHasPropertyModel model)
        {
            var result = new ReturnAjaxForm();
            var equipments = new List<EquipmentHasProperty>();



            //if (model.Values.Where(x => x == 0).Count() > 0)

            //    ModelState.AddModelError("Values", "  مقدار الزامی است");

            if (ModelState.IsValid)
            {
                try
                {
                    for(int i=0; i< model.PropertyId.Count;i++)
                    {
                        if(model.Values[i]!=0 && model.PropertyId[i]!=0)
                        {
                            equipments.Add(new EquipmentHasProperty
                            {
                                value = model.Values[i],
                                PropertyId = model.PropertyId[i],
                                EquipmentId = model.EquipmentId,
                                UnitId = model.UnitId[i],
                                ActionUserId = User.Identity.GetUserId()
                            });
                        }
                     


                    }
                    if(equipments.Count>0)
                    ///عملیات ثبت در دیتابیس
                    _equipmentPropertyService.Insert(equipments);
                   

                    ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                    ShowMessageToUser(result, "با موفقیت ثبت شد", ResultType.Success);

                    if(equipments.Count<=0)
                    {

                        ShowMessageToUser(result, "ویژگی برای ثبت انتخاب نشده است.", ResultType.Failure);
                    }
                }
                catch (Exception ex)
                {
                    /// لاگ خطا

                    LogException.Write(ex, "CreateMethodInEquipmentPropertiesController");

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
        public ActionResult Edit(int id)
        {

            var model = new EquipmentHasPropertyModel();

            if (!_checkingRoleService.HasAccess(PermissionList.EquipmentHasPropertyEdit, CurrentUser.GetCurrentUser))
            {
                return PartialView("_Inaccessibility");
            }

            var equipment = _equipmentPropertyService.GetById(id);
            
            model.Value=equipment.value;
            model.Unit=equipment.UnitId;
            model.Id = equipment.Id;

            ///آماده سازی  واحد
            PrepareAllUnits(model);
            
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult Edit(EquipmentHasPropertyModel model)
        {
            var result = new ReturnAjaxForm();


            if (ModelState.IsValid)
            {
                try
                {
                    var equipment = _equipmentPropertyService.GetById(model.Id);


                    equipment.value = model.Value;
                    equipment.UnitId = model.Unit;
                    equipment.ModifiedDate = DateTime.Now;
                    equipment.LastActionUserId = User.Identity.GetUserId();

                    ///عملیات ویرایش در دیتابیس

                    _equipmentPropertyService.Update(equipment);

                    ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                    ShowMessageToUser(result, "با موفقیت ویرایش شد", ResultType.Success);

                }
                catch (Exception ex)
                {
                    /// لاگ خطا

                    LogException.Write(ex, "EditMethodInEquipmentPropertiesController");

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
        public JsonResult List(DataTableRequest request, [ModelBinder(typeof(DataTableModelBinder))]DataTableRequestFilter filter, int equipmentId = 0 )

        {
            if (request.length == -1)
            {
                request.length = int.MaxValue;
            }
            var data = _equipmentPropertyService.FilterData(request.start, request.length, filter.Search, filter.SortColumn, filter.SortDirection,equipmentId: equipmentId);


            var gridModel = new DataTableResponse<EquipmentHasPropertyModel>()
            {
                data = data.Select(x =>
                {

                    var m = new EquipmentHasPropertyModel();
                    m.Value = x.value;
                    m.EquipmentTitle = x.Equipment.Title;
                    m.PropertyTitle = x.Property.Title;
                    if(x.Unit!=null)
                    m.UnitTitle = x.Unit.Title;
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
                recordsTotal = _equipmentPropertyService.Count(filter.Search,equipmentId),
                recordsFiltered = _equipmentPropertyService.Count(filter.Search,equipmentId),
                draw = request.draw
            };



            return Json(gridModel, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var result = new ReturnAjaxForm();

            if (!_checkingRoleService.HasAccess(PermissionList.EquipmentHasPropertyDelete, CurrentUser.GetCurrentUser))
            {
                ///نمایش پیام عدم دسترسی  به کاربر

                ShowMessageToUser(result, "کاربر گرامی،شما  مجوز حذف رکورد را ندارید! ", ResultType.NotAllow);


                //return Json(result, JsonRequestBehavior.AllowGet);
            }

            try
            {
                var entity = _equipmentPropertyService.GetById(id);
                _equipmentPropertyService.Remove(entity);

                ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                ShowMessageToUser(result, "با موفقیت حذف شد", ResultType.Success);

            }
            catch (Exception ex)
            {
                /// لاگ خطا

                LogException.Write(ex, "DeleteMethodInEquipmentPropertiesController");

                ///نمایش پیام خطا به کاربر

                ShowMessageToUser(result, "امکان حذف وجود ندارد.", ResultType.Failure);
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