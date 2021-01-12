﻿using Store.Models;
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
    public class CompanyStoreRoomController : BaseController
    {
        #region Fields
        private readonly ICompanyStoreRoomService _companyService;
        private readonly ICheckingRole _checkingRoleService;
        private readonly IUserService _userService;
        #endregion
        #region Ctor
        
        public CompanyStoreRoomController(ICompanyStoreRoomService companyService, ICheckingRole checkingRoleService, IUserService userService)
        {
            _companyService = companyService;
            _checkingRoleService = checkingRoleService;
            _userService = userService;
        }
        #endregion
        #region Utilities

    
      
        #endregion
        #region ActionMethod
        public ActionResult Index()
        {
            var model = new CompanyStoreRoomModel();

            if (!_checkingRoleService.HasAccess(PermissionList.CompanyStoreRoomList, CurrentUser.GetCurrentUser))
            {
                return View("Inaccessibility");
            }

            return View(model);
        }
        public ActionResult Create()
        {
            var model = new CompanyStoreRoomModel();

            if (!_checkingRoleService.HasAccess(PermissionList.CompanyStoreRoomCreate, CurrentUser.GetCurrentUser))
            {

                return View("Inaccessibility");
            }
            
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(CompanyStoreRoomModel model)
        {
            var result = new ReturnAjaxForm();
            var company = new CompanyStoreRoom();
            
            if (ModelState.IsValid)
            {
                try
                {
                    company.Title = model.Title;
                    company.Address = model.Address;
                    company.Phone = model.Phone;
                    company.ActionUserId = User.Identity.GetUserId();
                   
                    ///عملیات ثبت در دیتابیس
                    _companyService.Insert(company);

                    ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر
                    
                    ShowMessageToUser(result, "با موفقیت ثبت شد", ResultType.Success);
                    
                }
                catch (Exception ex)
                {
                    /// لاگ خطا

                    LogException.Write(ex, "CreateMethodInCompanyStoreRoomController");

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

            var model = new CompanyStoreRoomModel();

            if (!_checkingRoleService.HasAccess(PermissionList.CompanyStoreRoomEdit, CurrentUser.GetCurrentUser))
            {
                return PartialView("_Inaccessibility");
            }

            var company = _companyService.GetById(id);
            model.Title = company.Title;
            model.Address = company.Address;
            model.Phone = company.Phone;
            model.Id = company.Id;
            
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult Edit(CompanyStoreRoomModel model)
        {
            var result = new ReturnAjaxForm();

            var company = _companyService.GetById(model.Id);
           


            if (ModelState.IsValid)
            {
                try
                {
                    company.Title = model.Title;
                    company.Address = model.Address;
                    company.Phone = model.Phone;
                    company.ModifiedDate = DateTime.Now;
                    company.LastActionUserId = User.Identity.GetUserId();

                    ///عملیات ویرایش در دیتابیس

                    _companyService.Update(company);

                    ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                    ShowMessageToUser(result, "با موفقیت ویرایش شد", ResultType.Success);
                   
                }
                catch (Exception ex)
                {
                    /// لاگ خطا

                    LogException.Write(ex, "EditMethodInCompanyStoreRoomController");

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
            var data = _companyService.FilterData(request.start, request.length, filter.Search, filter.SortColumn, filter.SortDirection);


            var gridModel = new DataTableResponse<CompanyStoreRoomModel>()
            {
                data = data.Select(x =>
                {

                    var m = new CompanyStoreRoomModel();
                    m.Title = x.Title;
                    m.Address = x.Address;
                    m.Phone = x.Phone;
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
                recordsTotal = _companyService.Count(filter.Search),
                recordsFiltered = _companyService.Count(filter.Search),
                draw = request.draw
            };



            return Json(gridModel, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var result = new ReturnAjaxForm();

            if (!_checkingRoleService.HasAccess(PermissionList.CompanyStoreRoomDelete, CurrentUser.GetCurrentUser))
            {
                ///نمایش پیام عدم دسترسی  به کاربر

                ShowMessageToUser(result, "کاربر گرامی،شما  مجوز حذف رکورد را ندارید! ", ResultType.NotAllow);

          
                //return Json(result, JsonRequestBehavior.AllowGet);
            }
            
            try
            {
                var entity = _companyService.GetById(id);
                _companyService.Remove(entity);

                ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                ShowMessageToUser(result, "با موفقیت حذف شد", ResultType.Success);

            }
            catch (Exception ex)
            {
                /// لاگ خطا

                LogException.Write(ex, "DeleteMethodInCompanyStoreRoomController");

                ///نمایش پیام خطا به کاربر

                ShowMessageToUser(result, " امکان حذف رکورد وجود ندارد.", ResultType.Failure);
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