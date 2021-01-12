using Store.Models;
using Store.Service;
using Store.WebEssential.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using Store.Core.CommonHelper;
using Store.WebEssential.ModelBinder;
using Store.Models.User;
using Microsoft.AspNet.Identity;
using Store.Service.User;
using Store.Core.Domain.StoreTables.User;
using System.Threading.Tasks;
using Store.WebEssential.UserControl;
using Store.Essential.Model;

namespace Store.Controllers
{
    [Authorize]
    public class RoleController : BaseController
    {
        #region Fields
        private readonly IRoleService _roleService;
        private readonly ApplicationRoleManager _roleManager;
        private readonly IPermissionService _permissionService;
        private readonly ICheckingRole _checkingRoleService;

        #endregion

        #region Ctor
        public RoleController(IRoleService roleService, ApplicationRoleManager roleManager, IPermissionService permissionService, ICheckingRole checkingRoleService)
        {
            _roleService = roleService;
            _roleManager = roleManager;
            _permissionService = permissionService;
            _checkingRoleService = checkingRoleService;
        }
        #endregion
        #region Utilities

        [NonAction]
        public virtual void PreparePermissionList(ApplicationRoleModel model,List<Permission> permissions)
        {
            var allPermissions = _permissionService.GetAll().Where(x => !string.IsNullOrEmpty(x.Title) && !string.IsNullOrEmpty(x.SystemName)).ToList();

            List<PermissionModel> PermissionList = new List<PermissionModel>();

            foreach (var permission in allPermissions)
            {
                if(permissions!=null && permissions.Count>0)
                {
                   if( permissions.Where(x=>x.Id==permission.Id).Count()>0)
                    {
                        PermissionModel permissionModel = new PermissionModel();
                        permissionModel.Category = permission.Category;
                        permissionModel.PersianCategoryame = permission.PersianCategoryame;
                        permissionModel.Id = permission.Id;
                        permissionModel.IsChecked = true;
                        model.Permissions.Add(permissionModel);
                    }
                    else
                    {
                        PermissionModel permissionModel = new PermissionModel();
                        permissionModel.Category = permission.Category;
                        permissionModel.PersianCategoryame = permission.PersianCategoryame;
                        permissionModel.Id = permission.Id;
                        permissionModel.IsChecked = false;
                        model.Permissions.Add(permissionModel);
                    }
                }
                else
                {
                    PermissionModel permissionModel = new PermissionModel();
                    permissionModel.Category = permission.Category;
                    permissionModel.PersianCategoryame = permission.PersianCategoryame;
                    permissionModel.Id = permission.Id;
                    model.Permissions.Add(permissionModel);
                }
            
            }


        }

        #endregion
        #region ActionMethod
        public ActionResult Index()
        {
            var model = new ApplicationRoleModel();

            if (!_checkingRoleService.HasAccess(PermissionList.RoleList, CurrentUser.GetCurrentUser))
            {

                //return View("Inaccessibility");
            }

            return View(model);
        }
        public ActionResult Create()
        {
            var model = new ApplicationRoleModel();

            if (!_checkingRoleService.HasAccess(PermissionList.RoleCreate, CurrentUser.GetCurrentUser))
            {
                return View("Inaccessibility");
            }

            PreparePermissionList(model,null);

            model.IsActive = true;

            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Create(ApplicationRoleModel model)
        {
            var result = new ReturnAjaxForm();
            StringBuilder builder = new StringBuilder();



            if (ModelState.IsValid)
            {
                try
                {

              
                //if (!_roleManager.RoleExists(model.Name))
                //{

                var role = new ApplicationRole { Name = model.Name, PersianName = model.PersianName, IsActive = model.IsActive, CreateDate = DateTime.Now };

                var roleresult = await _roleManager.CreateAsync(role);

                if (roleresult.Succeeded)
                {

                    var newrole = _roleService.GetById(role.Id);

                    for (int i = 0; i < model.PermissionId.ToList().Count; i++)
                    {
                        newrole.Permissions.Add(_permissionService.GetById(model.PermissionId[i]));
                    }
                    _roleService.Update(newrole);

                    result.ResultType = ResultType.Success;
                    result.Message = "نقش با موفقیت ثبت  شد";
                }
                else
                {
                    foreach (var err in roleresult.Errors)
                    {

                        builder.Append(err).Append("\n");

                    }
                    result.ResultType = ResultType.Failure;
                    result.Message = builder.ToString();
                }

                }
                catch (Exception ex)
                {
                    /// لاگ خطا

                    LogException.Write(ex, "CreateMethodInRoleController");

                    ///نمایش پیام خطا به کاربر

                    ShowMessageToUser(result, "عملیات با خطا مواجه شد.", ResultType.Failure);
                }
                //}
            }
            else
            {
                foreach (var e in ModelState.Values)
                {

                    if (e.Errors.Count() > 0)
                    {
                        foreach (var error in e.Errors.ToList())
                        {
                            builder.Append(error.ErrorMessage).Append("\n");
                        }
                    }
                }
                result.ResultType = ResultType.Failure;
                result.Message = builder.ToString();

            }


            return Json(result);

        }
        public ActionResult Edit(string id)
        {
            var model = new ApplicationRoleModel();

            if (!_checkingRoleService.HasAccess(PermissionList.RoleEdit, CurrentUser.GetCurrentUser))
            {
                //return View("Inaccessibility");
            }

            var role = _roleService.GetById(id);

            model.Name = role.Name;
            model.IsActive = role.IsActive;
            model.RoleId = role.Id;

            PreparePermissionList(model,role.Permissions);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ApplicationRoleModel model)
        {
            var result = new ReturnAjaxForm();
            StringBuilder builder = new StringBuilder();
         
            

            if (ModelState.IsValid)
            {
                try
                {
                    var role = _roleService.GetById(model.RoleId);

                    if (model.Name.Trim() != role.Name)
                    {
                        if (_roleManager.RoleExists(model.Name))
                        {
                            result.ResultType = ResultType.Failure;

                            result.Message = " عنوان نقش تکراری می باشد!";
                            return Json(result);
                        }
                    }
                    role.Name = model.Name;
                    role.IsActive = model.IsActive;
                    for (int i = 0; i < role.Permissions.ToList().Count; i++)
                    {
                        role.Permissions.Remove(_permissionService.GetById(model.PermissionId[i]));
                    }

                    role.Permissions = new List<Permission>();
                    _roleService.Update(role);

                    for (int i = 0; i < model.PermissionId.ToList().Count; i++)
                    {
                        role.Permissions.Add(_permissionService.GetById(model.PermissionId[i]));
                    }
                    _roleService.Update(role);
                    result.ResultType = ResultType.Success;

                    result.Message = " با موفقیت ویرایش شد!";
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
                foreach (var e in ModelState.Values)
                {

                    if (e.Errors.Count() > 0)
                    {
                        foreach (var error in e.Errors.ToList())
                        {
                            builder.Append(error.ErrorMessage).Append("\n");
                        }
                    }
                }
                result.ResultType = ResultType.Failure;
                result.Message = builder.ToString();
            }
            return Json(result);
        }

        [HttpPost]
        public ActionResult Delete(string id)
        {
            var result = new ReturnAjaxForm();

            if (!_checkingRoleService.HasAccess(PermissionList.RoleDelete, CurrentUser.GetCurrentUser))
            {
                result.ResultType = ResultType.NotAllow;
                result.Message = " کاربر گرامی،شما  مجوز حذف رکورد را ندارید!  ";
                return Json(result, JsonRequestBehavior.AllowGet);
            }


            try
            {
                var entity = _roleService.GetById(id);
                _roleService.Remove(entity);

                result.ResultType = ResultType.Success;
                result.Message = " با موفقیت حذف شد";
            }
            catch (Exception ex)
            {
                /// لاگ خطا

                LogException.Write(ex, "DeleteMethodInRoleController");


                ///نمایش پیام خطا به کاربر

                ShowMessageToUser(result, "امکان حذف  رکورد وجود ندارد.", ResultType.Failure);
            }

            return Json(result, JsonRequestBehavior.AllowGet);

        }
        #endregion

        #region List
        public JsonResult List(DataTableRequest request, [ModelBinder(typeof(DataTableModelBinder))]DataTableRequestFilter filter)

        {
            if (request.length == -1)
            {
                request.length = int.MaxValue;
            }

            var model = new DataTableResponse<ApplicationRoleModel>();
            model.draw = request.draw;

            var data = _roleService.FilterData(request.start, request.length, filter.Search, filter.SortColumn, filter.SortDirection);

            data.ForEach(x =>
            {
                var role = new ApplicationRoleModel();
                role.Name = x.Name;
                role.IsActive = x.IsActive;
                role.RoleId = x.Id;
                model.data.Add(role);
            });

            model.recordsFiltered = _roleService.Count();
            model.recordsTotal = _roleService.Count();
            if (!HttpContext.User.IsInRole("admin"))
            {
                var admin = model.data.FirstOrDefault(x => x.Name == "admin");
                model.data.Remove(admin);
                model.recordsFiltered = _roleService.Count() - 1;

            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        #endregion List
    }
}