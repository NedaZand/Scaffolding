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
using Rotativa;

namespace Store.Controllers
{
    [Authorize]
    public class CompanyController : BaseController
    {
        #region Fields
        private readonly ICompanyService _companyService;
        private readonly ICheckingRole _checkingRoleService;
        private readonly IUserService _userService;
        #endregion
        #region Ctor
        
        public CompanyController(ICompanyService companyService, ICheckingRole checkingRoleService, IUserService userService)
        {
            _companyService = companyService;
            _checkingRoleService = checkingRoleService;
            _userService = userService;
        }
        #endregion
        #region Utilities

        [NonAction]
        protected virtual void PrepareAllCompaniesModel(CompanyModel model,int? parentId = null)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            model.Companies.Add(new SelectListItem
            {
                Text = "[None]",
                Value = "0"
            });
            //var companies = SelectListHelper.GetCompanyList(_companyService);
            var companies = _companyService.GetAll(parentId:parentId);
            foreach (var c in companies)
            {
                model.Companies.Add(new SelectListItem{
                    Text=c.Title,
                    Value=c.Id.ToString()
                });
            }
              
        }

      
        #endregion
        #region ActionMethod
        public ActionResult Index()
        {
            var model = new CompanyModel();

            if (!_checkingRoleService.HasAccess(PermissionList.CompanyList, CurrentUser.GetCurrentUser))
            {
                return View("Inaccessibility");
            }

            return View(model);
        }

        public ActionResult Create()
        {
            var model = new CompanyModel();

            if (!_checkingRoleService.HasAccess(PermissionList.CompanyCreate, CurrentUser.GetCurrentUser))
            {

                return View("Inaccessibility");
            }

            PrepareAllCompaniesModel(model);
            return View(model);
        }
        [HttpPost]
       
        public ActionResult Create(CompanyModel model)
        {
            var result = new ReturnAjaxForm();
            var company = new Company();
            
            if (ModelState.IsValid)
            {
                try
                {
                    company.Title = model.Title;
                    company.Address = model.Address;

                    if (model.UnitId != 0)
                        company.ParentID = model.UnitId;
                    else if(model.CompanyId!=0)
                        company.ParentID = model.CompanyId;

                    company.ActionUserId = User.Identity.GetUserId();

                    ///عملیات ثبت در دیتابیس
                    _companyService.Insert(company);

                    ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر
                    
                    ShowMessageToUser(result, "با موفقیت ثبت شد", ResultType.Success);
                    
                }
                catch (Exception ex)
                {
                    /// لاگ خطا

                    LogException.Write(ex, "CreateMethodInCompanyController");


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

            var model = new CompanyModel();

            if (!_checkingRoleService.HasAccess(PermissionList.CompanyEdit, CurrentUser.GetCurrentUser))
            {
                return PartialView("_Inaccessibility");
            }

            var company = _companyService.GetById(id);
            model.Title = company.Title;
            model.Address = company.Address;
            //model.CompanyId = company.ParentID.Value;
            model.Id = company.Id;
       
            PrepareAllCompaniesModel(model);
            GetCompaniesByParentId(company.Id);
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult Edit(CompanyModel model)
        {
            var result = new ReturnAjaxForm();

            var company = _companyService.GetById(model.Id);
           


            if (ModelState.IsValid)
            {
                try
                {
                    company.Title = model.Title;
                    company.Address = model.Address;
                    //company.ParentID = model.CompanyId;
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

                    LogException.Write(ex, "EditMethodInCompanyController");

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


            var gridModel = new DataTableResponse<CompanyModel>()
            {
                data = data.Select(x =>
                {

                    var m = new CompanyModel();
                    m.Title = x.Title;
                    m.Address = x.Address;
                    //m.ParentName =x.ParentID!=0? _companyService.GetById(x.ParentID).Title:"";
                    m.ParentName = x.GetFormattedBreadCrumb(_companyService);
               

                    m.CompanyTitle = x.Title;
                      
                    if (x.CreatedDate.HasValue)
                        m.ShamsiCreateDate = ConvertAdToJalaliDateTime(x.CreatedDate.Value);
                    if (x.ActionUserId != null)
                        m.ActionUserName = _userService.GetById(x.ActionUserId).UserName;
                    if (x.ModifiedDate.HasValue)
                        m.ShamsiEditDate = ConvertAdToJalaliDateTime(x.ModifiedDate.Value);
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

            if (!_checkingRoleService.HasAccess(PermissionList.CompanyDelete, CurrentUser.GetCurrentUser))
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

                LogException.Write(ex, "DeleteMethodInCompanyController");


                ///نمایش پیام خطا به کاربر

                ShowMessageToUser(result, "امکان حذف  رکورد وجود ندارد.", ResultType.Failure);
            }

            return Json(result);

        }
        
        public JsonResult GetAllCompany()
        {
            CompanyModel model = new CompanyModel();

            PrepareAllCompaniesModel(model);

            return Json(model.Companies,JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult GetAddress(int companyId)
        {
            try
            {
                var address = _companyService.GetById(companyId).Address;
                return Json(address);
            }
            catch (Exception)
            {

                
            }
            return Json(string.Empty);
        }

        [HttpPost]
        public JsonResult GetCompaniesByParentId(int parentId)

        {
            var model = new CompanyModel();

            if(parentId!=0)
            PrepareAllCompaniesModel(model, parentId);

            return Json(model.Companies);
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