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
    public class EarthController : BaseController
    {
        #region Fields
        private readonly IEarthService _earthService;
        private readonly ICheckingRole _checkingRoleService;
        private readonly IUserService _userService;
        #endregion
        #region Ctor
        
        public EarthController(IEarthService earthService, ICheckingRole checkingRoleService, IUserService userService)
        {
            _earthService = earthService;
            _checkingRoleService = checkingRoleService;
            _userService = userService;
        }
        #endregion
        #region Utilities

        [NonAction]
        protected virtual void PrepareAllEarthModel(ScaffoldModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            model.Earths.Add(new SelectListItem
            {
                Text = " نوع زمین",
                Value = "0"
            });
            //var companies = SelectListHelper.GetCompanyList(_companyService);
            var earths = _earthService.GetAll();
            foreach (var c in earths)
            {
                model.Earths.Add(new SelectListItem
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
            var model = new EarthModel();

            if (!_checkingRoleService.HasAccess(PermissionList.EarthList, CurrentUser.GetCurrentUser))
            {
                return View("Inaccessibility");
            }

            return View(model);
        }
        public ActionResult Create()
        {
            var model = new EarthModel();

            if (!_checkingRoleService.HasAccess(PermissionList.EarthCreate, CurrentUser.GetCurrentUser))
            {

                return PartialView("_Inaccessibility");
            }
            
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult Create(EarthModel model)
        {
            var result = new ReturnAjaxForm();
            var earth = new Earth();
            
            if (ModelState.IsValid)
            {
                try
                {
                    earth.Title = model.Title;
                    earth.CreatedDate = DateTime.Now;
                    earth.ActionUserId = User.Identity.GetUserId();

                    ///عملیات ثبت در دیتابیس
                    _earthService.Insert(earth);

                    ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر
                    
                    ShowMessageToUser(result, "با موفقیت ثبت شد", ResultType.Success);
                    
                }
                catch (Exception ex)
                {
                    /// لاگ خطا

                    LogException.Write(ex, "CreateMethodInEarthController");

                    ///نمایش پیام خطا به کاربر

                    ShowMessageToUser(result, " عملیات با خطا مواجه شد.", ResultType.Failure);

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

            var model = new EarthModel();

            if (!_checkingRoleService.HasAccess(PermissionList.EarthEdit, CurrentUser.GetCurrentUser))
            {
                return PartialView("_Inaccessibility");
            }

            var company = _earthService.GetById(id);
            model.Title = company.Title;
            model.Id = company.Id;
            
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult Edit(EarthModel model)
        {
            var result = new ReturnAjaxForm();

            var company = _earthService.GetById(model.Id);
           


            if (ModelState.IsValid)
            {
                try
                {
                    company.Title = model.Title;
                    company.ModifiedDate = DateTime.Now;
                    company.LastActionUserId = User.Identity.GetUserId();

                    ///عملیات ویرایش در دیتابیس

                    _earthService.Update(company);

                    ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                    ShowMessageToUser(result, "با موفقیت ویرایش شد", ResultType.Success);
                   
                }
                catch (Exception ex)
                {  
                    /// لاگ خطا

                    LogException.Write(ex, "EditMethodInEarthController");

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
        public JsonResult List(DataTableRequest request, [ModelBinder(typeof(DataTableModelBinder))]DataTableRequestFilter filter)

        {
            if (request.length == -1)
            {
                request.length = int.MaxValue;
            }
            var data = _earthService.FilterData(request.start, request.length, filter.Search, filter.SortColumn, filter.SortDirection);


            var gridModel = new DataTableResponse<EarthModel>()
            {
                data = data.Select(x =>
                {

                    var m = new EarthModel();
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
                recordsTotal = _earthService.Count(filter.Search),
                recordsFiltered = _earthService.Count(filter.Search),
                draw = request.draw
            };



            return Json(gridModel, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var result = new ReturnAjaxForm();

            if (!_checkingRoleService.HasAccess(PermissionList.EarthDelete, CurrentUser.GetCurrentUser))
            {
                ///نمایش پیام عدم دسترسی  به کاربر

                ShowMessageToUser(result, "کاربر گرامی،شما  مجوز حذف رکورد را ندارید! ", ResultType.NotAllow);

          
                //return Json(result, JsonRequestBehavior.AllowGet);
            }
            
            try
            {
                var entity = _earthService.GetById(id);
                _earthService.Remove(entity);

                ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                ShowMessageToUser(result, "با موفقیت حذف شد", ResultType.Success);

            }
            catch (Exception ex)
            {
                /// لاگ خطا

                LogException.Write(ex, "DeleteMethodInEarthController");

                ///نمایش پیام خطا به کاربر

                ShowMessageToUser(result, "امکان حذف  رکورد وجود ندارد.", ResultType.Failure);
            }

            return Json(result);

        }

        public JsonResult GetAllEarth()
        {
            var model = new ScaffoldModel();

            PrepareAllEarthModel(model);

            return Json(model.Earths, JsonRequestBehavior.AllowGet);

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