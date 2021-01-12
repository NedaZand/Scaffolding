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
    public class ScaffoldTypeController : BaseController
    {
        #region Fields
        private readonly IScaffoldTypeService _scaffoldTypeService;
        private readonly ICheckingRole _checkingRoleService;
        private readonly IUserService _userService;
        #endregion
        #region Ctor
        
        public ScaffoldTypeController(IScaffoldTypeService scaffoldTypeService, ICheckingRole checkingRoleService, IUserService userService)
        {
            _scaffoldTypeService = scaffoldTypeService;
            _checkingRoleService = checkingRoleService;
            _userService = userService;
        }
        #endregion
        #region Utilities

        [NonAction]
        protected virtual void PrepareAllScaffoldTypeModel(ScaffoldModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            model.ScaffoldTypes.Add(new SelectListItem
            {
                Text = " نوع داربست",
                Value = "0"
            });
            //var companies = SelectListHelper.GetCompanyList(_companyService);
            var scaffoldTypes = _scaffoldTypeService.GetAll();
            foreach (var c in scaffoldTypes)
            {
                model.ScaffoldTypes.Add(new SelectListItem
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
            var model = new ScaffoldTypeModel();

            if (!_checkingRoleService.HasAccess(PermissionList.ScaffoldTypeList, CurrentUser.GetCurrentUser))
            {
                return View("Inaccessibility");
            }

            return View(model);
        }
        public ActionResult Create()
        {
            var model = new ScaffoldTypeModel();

            if (!_checkingRoleService.HasAccess(PermissionList.ScaffoldTypeCreate, CurrentUser.GetCurrentUser))
            {

                return PartialView("_Inaccessibility");
            }
            
            return PartialView(model);
        }
        [HttpPost]
       
        public ActionResult Create(ScaffoldTypeModel model)
        {
            var result = new ReturnAjaxForm();
            var scaffoldType = new ScaffoldType();
            
            if (ModelState.IsValid)
            {
                try
                {
                    scaffoldType.Title = model.Title;
                    scaffoldType.Image = model.Image;
                    scaffoldType.CreatedDate = DateTime.Now;
                    scaffoldType.ActionUserId = User.Identity.GetUserId();

                    ///عملیات ثبت در دیتابیس
                    _scaffoldTypeService.Insert(scaffoldType);

                    ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر
                    
                    ShowMessageToUser(result, "با موفقیت ثبت شد", ResultType.Success);
                    
                }
                catch (Exception ex)
                {
                    /// لاگ خطا

                    LogException.Write(ex, "CreateMethodInScaffoldTypeController");

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

            var model = new ScaffoldTypeModel();

            if (!_checkingRoleService.HasAccess(PermissionList.ScaffoldTypeEdit, CurrentUser.GetCurrentUser))
            {
                return PartialView("_Inaccessibility");
            }

            var scaffoldType = _scaffoldTypeService.GetById(id);
            model.Title = scaffoldType.Title;
            model.Image = scaffoldType.Image;
            model.Id = scaffoldType.Id;
            
            return PartialView(model);
        
        }
        [HttpPost]
        public ActionResult Edit(ScaffoldTypeModel model)
        {
            var result = new ReturnAjaxForm();
            

            if (ModelState.IsValid)
            {
                try
                {
                    var scaffoldType = _scaffoldTypeService.GetById(model.Id);
           
                    scaffoldType.Title = model.Title;
                    scaffoldType.Image = model.Image;
                    scaffoldType.ModifiedDate = DateTime.Now;
                    scaffoldType.LastActionUserId = User.Identity.GetUserId();

                    ///عملیات ویرایش در دیتابیس

                    _scaffoldTypeService.Update(scaffoldType);

                    ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                    ShowMessageToUser(result, "با موفقیت ویرایش شد", ResultType.Success);
                   
                }
                catch (Exception ex)
                {
                    /// لاگ خطا

                    LogException.Write(ex, "EditMethodInScaffoldTypeController");

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
            var data = _scaffoldTypeService.FilterData(request.start, request.length, filter.Search, filter.SortColumn, filter.SortDirection);


            var gridModel = new DataTableResponse<ScaffoldTypeModel>()
            {
                data = data.Select(x =>
                {

                    var m = new ScaffoldTypeModel();
                    try
                    {
                        m.Title = x.Title;
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


                    }
                    catch (Exception ex)
                    {

                        LogException.Write(ex, "ListsMethodInScaffoldTypeController");

                    }

                    return m;
                }).ToList(),
                recordsTotal = _scaffoldTypeService.Count(filter.Search),
                recordsFiltered = _scaffoldTypeService.Count(filter.Search),
                draw = request.draw
            };



            return Json(gridModel, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var result = new ReturnAjaxForm();

            if (!_checkingRoleService.HasAccess(PermissionList.ScaffoldTypeDelete, CurrentUser.GetCurrentUser))
            {
                ///نمایش پیام عدم دسترسی  به کاربر

                ShowMessageToUser(result, "کاربر گرامی،شما  مجوز حذف رکورد را ندارید! ", ResultType.NotAllow);

          
                //return Json(result, JsonRequestBehavior.AllowGet);
            }
            
            try
            {
                var entity = _scaffoldTypeService.GetById(id);
                if(entity.SystemName!=null)
                {
                    if (entity.SystemName.Trim().Contains("SingleWallIndependentBlockingScaffold") || entity.SystemName.Trim().Contains("IndependentAngularScaffolding") || entity.SystemName.Trim().Contains("PolyScaffolding") || entity.SystemName.Trim().Contains("MovableScaffold") || entity.SystemName.Trim().Contains("CylinderTankScaffold") || entity.SystemName.Trim().Contains("SphericalTankScaffold") || entity.SystemName.Trim().Contains("CageScaffold"))
                    {

                        ShowMessageToUser(result, "امکان حذف  رکورد وجود ندارد.", ResultType.Failure);
                    }
                    else
                    {

                        _scaffoldTypeService.Remove(entity);

                        ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                        ShowMessageToUser(result, "با موفقیت حذف شد", ResultType.Success);
                    }
                }

                else
                {

                    _scaffoldTypeService.Remove(entity);

                    ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                    ShowMessageToUser(result, "با موفقیت حذف شد", ResultType.Success);
                }
            }
            catch (Exception ex)
            {
                /// لاگ خطا

                LogException.Write(ex, "DeleteMethodInScaffoldTypeController");


                ///نمایش پیام خطا به کاربر

                ShowMessageToUser(result, "امکان حذف  رکورد وجود ندارد.", ResultType.Failure);
            }

            return Json(result);

        }
        public JsonResult GetAllScaffoldType()
        {
            var model = new ScaffoldModel();

            PrepareAllScaffoldTypeModel(model);

            return Json(model.ScaffoldTypes, JsonRequestBehavior.AllowGet);

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