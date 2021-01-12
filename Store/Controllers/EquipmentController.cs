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

namespace Store.Controllers
{
    [Authorize]
    public class EquipmentController : BaseController
    {
        #region Fields
        private readonly IEquipmentService _equipmentService;
        private readonly ICheckingRole _checkingRoleService;
        private readonly IUnitService _unitService;
        private readonly IUserService _userService;
        private readonly IPictureService _pictureService;
        #endregion
        #region Ctor

        public EquipmentController(IPictureService pictureService, IUserService userService,IEquipmentService equipmentService, ICheckingRole checkingRoleService, IUnitService unitService)
        {
            _equipmentService = equipmentService;
            _checkingRoleService = checkingRoleService;
            _unitService = unitService;
            _userService = userService;
            _pictureService = pictureService;
        }
        #endregion
        #region Utilities

        [NonAction]
        protected virtual void PrepareAllUnits(EquipmentModel model)
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
        protected virtual void PrepareAllTypesModel(EquipmentModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            model.EquipmentTypes = EquipmentType.Unknown.ToSelectList().ToList();
        }


        #endregion
        #region ActionMethod
        public ActionResult Index()
        {
            var model = new EquipmentModel();

            if (!_checkingRoleService.HasAccess(PermissionList.EquipmentList, CurrentUser.GetCurrentUser))
            {
                return View("Inaccessibility");
            }

            return View(model);
        }
        public ActionResult Create()
        {
            var model = new EquipmentModel();

            if (!_checkingRoleService.HasAccess(PermissionList.EquipmentCreate, CurrentUser.GetCurrentUser))
            {

                return View("Inaccessibility");
            }

            ///آماده سازی واحدها
            PrepareAllUnits(model);

            ///آماده سازی  نوع
            PrepareAllTypesModel(model);

            return View(model);
        }
        [HttpPost]
        public ActionResult Create(EquipmentModel model)
        {
            var result = new ReturnAjaxForm();
            var equipment = new Equipment();

            if (model.EquipmentType == EquipmentType.Unknown)
                ModelState.AddModelError("EquipmentType", "نوع تجهیز الزامی است");

            ModelState.Remove("Image");

            if (ModelState.IsValid)
            {
                try
                {
                    equipment.Title = model.Title;
                    equipment.Image = model.Image;
                    equipment.Weight = model.Weight;
                    equipment.MinimumInventory = model.MinimumInventory;
                    equipment.MinimumInventoryPercentage = model.MinimumInventoryPercentage;
                    equipment.EquipmentType = model.EquipmentType;
                    
                    equipment.ActionUserId = User.Identity.GetUserId();

                    ///عملیات ثبت در دیتابیس
                    _equipmentService.Insert(equipment);

                    ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                    ShowMessageToUser(result, "با موفقیت ثبت شد", ResultType.Success);

                }
                catch (Exception ex)
                {
                    /// لاگ خطا

                    LogException.Write(ex, "CreateMethodInEquipmentController");

                    ///نمایش پیام خطا به کاربر

                    ShowMessageToUser(result, " عملیات با خطا مواجه شد.", ResultType.Failure);
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

            var model = new EquipmentModel();

            if (!_checkingRoleService.HasAccess(PermissionList.EquipmentEdit, CurrentUser.GetCurrentUser))
            {
                return PartialView("_Inaccessibility");
            }

            var equipment = _equipmentService.GetById(id);
            model.Title = equipment.Title;
            if(equipment.Image.HasValue)
            model.Image = equipment.Image.Value;
            model.EquipmentType = equipment.EquipmentType;
            model.Weight = equipment.Weight;
            model.MinimumInventory = equipment.MinimumInventory;
            model.MinimumInventoryPercentage = equipment.MinimumInventoryPercentage;
            model.Id = equipment.Id;

            ///آماده سازی واحدها
            PrepareAllUnits(model);
            ///آماده سازی  نوع
            PrepareAllTypesModel(model);

            return PartialView(model);
        }
        [HttpPost]
        public ActionResult Edit(EquipmentModel model)
        {
            var result = new ReturnAjaxForm();
            
            if (ModelState.IsValid)
            {
                try
                {
                    var equipment = _equipmentService.GetById(model.Id);

                    equipment.Title = model.Title;
                    equipment.Image = model.Image;
                    equipment.EquipmentType = model.EquipmentType;
                    equipment.Weight = model.Weight;
                    equipment.MinimumInventoryPercentage = model.MinimumInventoryPercentage;
                    equipment.MinimumInventory = model.MinimumInventory;
                    equipment.ModifiedDate = DateTime.Now;
                    equipment.LastActionUserId = User.Identity.GetUserId();

                    ///عملیات ویرایش در دیتابیس

                    _equipmentService.Update(equipment);

                    ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                    ShowMessageToUser(result, "با موفقیت ویرایش شد", ResultType.Success);

                }
                catch (Exception ex)
                {
                    /// لاگ خطا

                    LogException.Write(ex, "EditMethodInEquipmentController");

                    ///نمایش پیام خطا به کاربر

                    ShowMessageToUser(result, " عملیات با خطا مواجه شد.", ResultType.Failure);

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
        public JsonResult List(DataTableRequest request, [ModelBinder(typeof(DataTableModelBinder))]DataTableRequestFilter filter,int scaffoldId=0)

        {
            if (request.length == -1)
            {
                request.length = int.MaxValue;
            }
            var data = _equipmentService.FilterData(request.start, request.length, filter.Search, filter.SortColumn, filter.SortDirection);


            var gridModel = new DataTableResponse<EquipmentModel>()
            {
                data = data.Select(x =>
                {

                    var m = new EquipmentModel();
                    m.Title = x.Title;
                    m.ImageUrl = x.Image!=null ? (_pictureService.GetPictureUrl(x.Image.Value)) :" ";
                    m.EquipmentTypeTitle = x.EquipmentType.GetDisplayName();
                    m.MinimumInventory = x.MinimumInventory;
                    m.MinimumInventoryPercentage = x.MinimumInventoryPercentage;
                    m.Weight = x.Weight;
                    m.ShamsiCreateDate = ConvertAdToJalaliDateTime(x.CreatedDate.Value);
                    if(x.ActionUserId!=null)
                    m.ActionUserName = _userService.GetById(x.ActionUserId).UserName;
                    if (x.ModifiedDate.HasValue)
                        m.ShamsiCreateDate = ConvertAdToJalaliDateTime(x.ModifiedDate.Value);
                    if (x.LastActionUserId != null)
                        m.EditUserName = _userService.GetById(x.LastActionUserId).UserName;

                    m.Id = x.Id;

                    if (x.ModifiedDate != null)
                    {
                        m.ShamsiEditDate = ConvertAdToJalaliDateTime(x.ModifiedDate.Value);
                    }


                    return m;
                }).ToList(),
                recordsTotal = _equipmentService.Count(filter.Search),
                recordsFiltered = _equipmentService.Count(filter.Search),
                draw = request.draw
            };



            return Json(gridModel, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var result = new ReturnAjaxForm();

            if (!_checkingRoleService.HasAccess(PermissionList.EquipmentDelete, CurrentUser.GetCurrentUser))
            {
                ///نمایش پیام عدم دسترسی  به کاربر

                ShowMessageToUser(result, "کاربر گرامی،شما  مجوز حذف رکورد را ندارید! ", ResultType.NotAllow);


                //return Json(result, JsonRequestBehavior.AllowGet);
            }

            try
            {
                var entity = _equipmentService.GetById(id);
                _equipmentService.Remove(entity);

                ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                ShowMessageToUser(result, "با موفقیت حذف شد", ResultType.Success);

            }
            catch (Exception ex)
            {
                /// لاگ خطا

                LogException.Write(ex, "DeleteMethodInEquipmentController");

                ///نمایش پیام خطا به کاربر


                ShowMessageToUser(result, "امکان حذف  رکورد وجود ندارد.", ResultType.Failure);
            }

            return Json(result);

        }

        [HttpPost]
        public ActionResult GetPropertiesById(int id)
        {
            var model = new EquipmentModel();
 
             model.Id = id;

            return PartialView("ShowProperties", model);

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