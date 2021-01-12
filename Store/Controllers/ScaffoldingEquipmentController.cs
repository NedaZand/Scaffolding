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
    public class ScaffoldingEquipmentController : BaseController
    {
        #region Fields
        private readonly IEquipmentService _equipmentService;
        private readonly ICheckingRole _checkingRoleService;
        private readonly IUserService _userService;
        private readonly IScaffoldingService _scaffoldingService;
        private readonly IScaffoldHasEquipmentService _ScaffoldEquipmentService;
        #endregion
        #region Ctor

        public ScaffoldingEquipmentController(IScaffoldHasEquipmentService ScaffoldEquipmentService, IScaffoldingService scaffoldingService, IUserService userService, IEquipmentService equipmentService, ICheckingRole checkingRoleService)
        {
            _equipmentService = equipmentService;
            _checkingRoleService = checkingRoleService;
            _userService = userService;
            _scaffoldingService = scaffoldingService;
            _ScaffoldEquipmentService = ScaffoldEquipmentService;
        }
        #endregion
        #region Utilities

        [NonAction]
        protected virtual void PrepareAllEquipments(ScaffoldEquipmentModel model)
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
        protected virtual void PrepareAllScaffoldingsModel(ScaffoldEquipmentModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            model.ScaffoldingList.Add(new SelectListItem
            {
                Text = "انتخاب داربست ",
                Value = " ",
                Selected = true
            });
            var scaffoldings = _scaffoldingService.GetAll();

            foreach (var c in scaffoldings)
            {
                model.ScaffoldingList.Add(new SelectListItem
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
            var model = new ScaffoldEquipmentModel();

            if (!_checkingRoleService.HasAccess(PermissionList.CompanyList, CurrentUser.GetCurrentUser))
            {
                return View("Inaccessibility");
            }

            return View(model);
        }
        public ActionResult Create()
        {
            var model = new ScaffoldEquipmentModel();

            if (!_checkingRoleService.HasAccess(PermissionList.CompanyCreate, CurrentUser.GetCurrentUser))
            {

                return View("Inaccessibility");
            }

            ///آماده سازی داربست ها
            PrepareAllScaffoldingsModel(model);

            ///آماده سازی  تجهیزات
            PrepareAllEquipments(model);

            return View(model);
        }
        [HttpPost]
        public ActionResult Create(ScaffoldEquipmentModel model)
        {
            var result = new ReturnAjaxForm();
            var equipments = new List<ScaffoldHasEquipment>();

            if (ModelState.IsValid)
            {
                try
                {
                    foreach (var item in model.EquipmentId)
                    {

                        equipments.Add(new ScaffoldHasEquipment
                        {
                            
                            EquipmentId=item,
                            ScaffoldingId=model.ScaffoldingId,
                            ActionUserId = User.Identity.GetUserId()
                        });


                    }

                    
                    ///عملیات ثبت در دیتابیس
                    _ScaffoldEquipmentService.Insert(equipments);

                    ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                    ShowMessageToUser(result, "با موفقیت ثبت شد", ResultType.Success);

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
            return Json(result);
        }




        [HttpGet]
        public ActionResult Edit(int id)
        {

            var model = new EquipmentModel();

            if (!_checkingRoleService.HasAccess(PermissionList.CompanyEdit, CurrentUser.GetCurrentUser))
            {
                return PartialView("Inaccessibility");
            }

            var equipment = _equipmentService.GetById(id);
            model.Title = equipment.Title;
            model.UnitId = equipment.UnitId;
            model.Price = equipment.Price;
            model.Image = equipment.Image.Value;
            model.EquipmentType = equipment.EquipmentType;
            model.Id = equipment.Id;

           

            return PartialView(model);
        }
        [HttpPost]
        public ActionResult Edit(EquipmentModel model)
        {
            var result = new ReturnAjaxForm();

            var equipment = _equipmentService.GetById(model.Id);



            if (ModelState.IsValid)
            {
                try
                {
                    equipment.Title = model.Title;
                    equipment.Image = model.Image;
                    equipment.Price = model.Price;
                    equipment.UnitId = model.UnitId;
                    equipment.EquipmentType = model.EquipmentType;

                    equipment.ModifiedDate = DateTime.Now;
                    equipment.LastActionUserId = User.Identity.GetUserId();

                    ///عملیات ویرایش در دیتابیس

                    _equipmentService.Update(equipment);

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
            return Json(result);
        }
        [HttpGet]
        public JsonResult List(DataTableRequest request, [ModelBinder(typeof(DataTableModelBinder))]DataTableRequestFilter filter)

        {
            if (request.length == -1)
            {
                request.length = int.MaxValue;
            }
            var data = _scaffoldingService.FilterData(request.start, request.length, filter.Search, filter.SortColumn, filter.SortDirection);


            var gridModel = new DataTableResponse<ScaffoldEquipmentModel>()
            {
                data = data.Select(x =>
                {

                    var m = new ScaffoldEquipmentModel();
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

            if (!_checkingRoleService.HasAccess(PermissionList.CompanyDelete, CurrentUser.GetCurrentUser))
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
            catch (Exception e)
            {
                ///نمایش پیام خطا به کاربر

                ShowMessageToUser(result, e.Message, ResultType.Failure);
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