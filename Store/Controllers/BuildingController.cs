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
    public class BuildingController : BaseController
    {
        #region Fields
        private readonly IBuildingService _buildingService;
        private readonly ICheckingRole _checkingRoleService;
        private readonly IUserService _userService;
        #endregion
        #region Ctor
        
        public BuildingController(IBuildingService buildingService, ICheckingRole checkingRoleService, IUserService userService)
        {
            _buildingService = buildingService;
            _checkingRoleService = checkingRoleService;
            _userService = userService;
        }
        #endregion
        #region Utilities

        [NonAction]
        protected virtual void PrepareAllBuildingModel(ScaffoldModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            model.Buildings.Add(new SelectListItem
            {
                Text = " نوع بنا",
                Value = "0"
            });
            //var companies = SelectListHelper.GetCompanyList(_companyService);
            var buildings = _buildingService.GetAll();
            foreach (var c in buildings)
            {
                model.Buildings.Add(new SelectListItem
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
            var model = new BuildingModel();

            if (!_checkingRoleService.HasAccess(PermissionList.BuildingList, CurrentUser.GetCurrentUser))
            {
                return View("Inaccessibility");
            }

            return View(model);
        }
        public ActionResult Create()
        {
            var model = new BuildingModel();

            if (!_checkingRoleService.HasAccess(PermissionList.BuildingCreate, CurrentUser.GetCurrentUser))
            {

                return PartialView("_Inaccessibility");
            }
            
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult Create(BuildingModel model)
        {
            var result = new ReturnAjaxForm();
            var building = new Building();
            
            if (ModelState.IsValid)
            {
                try
                {
                    building.Title = model.Title;
                    building.CreatedDate = DateTime.Now;
                    building.ActionUserId = User.Identity.GetUserId();

                    ///عملیات ثبت در دیتابیس
                    _buildingService.Insert(building);

                    ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر
                    
                    ShowMessageToUser(result, "با موفقیت ثبت شد", ResultType.Success);
                    
                }
                catch (Exception ex)
                {
                    LogException.Write(ex, "CreateMethodInBuildingController");

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

            var model = new BuildingModel();

            if (!_checkingRoleService.HasAccess(PermissionList.BuildingEdit, CurrentUser.GetCurrentUser))
            {
                return PartialView("_Inaccessibility");
            }

            var building = _buildingService.GetById(id);
            model.Title = building.Title;
            model.Id = building.Id;
            
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult Edit(BuildingModel model)
        {
            var result = new ReturnAjaxForm();

            var company = _buildingService.GetById(model.Id);
           


            if (ModelState.IsValid)
            {
                try
                {
                    company.Title = model.Title;
                    company.ModifiedDate = DateTime.Now;
                    company.LastActionUserId = User.Identity.GetUserId();

                    ///عملیات ویرایش در دیتابیس

                    _buildingService.Update(company);

                    ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                    ShowMessageToUser(result, "با موفقیت ویرایش شد", ResultType.Success);
                   
                }
                catch (Exception ex)
                {
                    /// لاگ خطا
                    
                    LogException.Write(ex, "EditMethodInBuildingController");

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
            var data = _buildingService.FilterData(request.start, request.length, filter.Search, filter.SortColumn, filter.SortDirection);


            var gridModel = new DataTableResponse<BuildingModel>()
            {
                data = data.Select(x =>
                {

                    var m = new BuildingModel();
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
                recordsTotal = _buildingService.Count(filter.Search),
                recordsFiltered = _buildingService.Count(filter.Search),
                draw = request.draw
            };



            return Json(gridModel, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var result = new ReturnAjaxForm();

            if (!_checkingRoleService.HasAccess(PermissionList.BuildingDelete, CurrentUser.GetCurrentUser))
            {
                ///نمایش پیام عدم دسترسی  به کاربر

                ShowMessageToUser(result, "کاربر گرامی،شما  مجوز حذف رکورد را ندارید! ", ResultType.NotAllow);

          
                //return Json(result, JsonRequestBehavior.AllowGet);
            }
            
            try
            {
                var entity = _buildingService.GetById(id);
                _buildingService.Remove(entity);

                ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                ShowMessageToUser(result, "با موفقیت حذف شد", ResultType.Success);

            }
            catch (Exception ex)
            {
                /// لاگ خطا

                LogException.Write(ex, "RemoveMethodInBuildingController");

                ///نمایش پیام خطا به کاربر

                ShowMessageToUser(result, "امکان حذف وجود ندارد.", ResultType.Failure);
            }

            return Json(result);

        }

        public JsonResult GetAllBuilding()
        {
            var model = new ScaffoldModel();

            PrepareAllBuildingModel(model);

            return Json(model.Buildings, JsonRequestBehavior.AllowGet);

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