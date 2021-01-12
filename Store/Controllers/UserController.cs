using Store.Models;
using Store.Service;
using Store.WebEssential.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Store.Service.User;
using System.Text;
using Store.Core.CommonHelper;
using Store.WebEssential.ModelBinder;
using Store.Models.User;
using System.Threading.Tasks;
using Store.Core.Domain.StoreTables.User;
using Store.WebEssential.UserControl;
using Microsoft.AspNet.Identity.EntityFramework;
using Store.Service.Stores;
using Store.Essential.Model;

namespace Store.Controllers
{
    [Authorize]
    //[ServerDown]
    public class UserController : BaseController
    {
        #region Fields
        private readonly IUserService _userService;
        private readonly ApplicationUserManager _userManager;
        private readonly IRoleService _roleService;
        private readonly IPositionTypeService _positionService;
        private readonly IEmployeeTypeService _employeeService;
        private readonly ICheckingRole _checkingRoleService;
        private readonly IPersonnelService _personnelService;
        #endregion

        #region Ctor
        public UserController(IPersonnelService personnelService,IUserService userService, ApplicationUserManager userManager, IRoleService roleService, ICheckingRole checkingRoleService,IEmployeeTypeService employeeService,IPositionTypeService positionService)
        {
            _userService = userService;
            _userManager = userManager;
            _roleService = roleService;
            _checkingRoleService = checkingRoleService;
            _positionService = positionService;
            _employeeService = employeeService;
            _personnelService = personnelService;
        }
        #endregion

        #region Utilities
        [NonAction]
        protected virtual void PrepareAllPersonnelsModel(ApplicationUserModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            model.PersonnelList.Add(new SelectListItem
            {
                Text = "انتخاب پرسنل",
                Value = " "
            });
            var personnels = _personnelService.GetAll();
            foreach (var c in personnels)
                model.PersonnelList.Add(new SelectListItem
                {
                    Text = $"{c.UserNameFmaily}-{c.PersonnelCode}",
                    Value = c.PersonnelCode.ToString()
                });
        }


        [NonAction]
        public virtual void PrepareRoleList(ApplicationUserModel model)
        {
           
            var roles = _roleService.GetAll();

            model.Roles.Add(new SelectListItem { Text = "انتخاب نقش", Value = " " });

            foreach (var role in roles)
            {
                if(role.Name.Trim()!="admin")
               
                model.Roles.Add(new SelectListItem { Text = role.Name, Value = role.Id });

            }


        }

        #endregion
        #region ActionMethod
        public ActionResult Index()
        {
            var model = new ApplicationUserModel();

            if (!_checkingRoleService.HasAccess(PermissionList.UserList, CurrentUser.GetCurrentUser))
            {
                return View("Inaccessibility");
            }
            return View(model);
        }
        public ActionResult Create()
        {
            
            var model = new ApplicationUserModel();

            if (!_checkingRoleService.HasAccess(PermissionList.UserCreate, CurrentUser.GetCurrentUser))
            {
                return View("Inaccessibility");
            }

           
            ///آماده سازی لیست نقش ها
            PrepareRoleList(model);
            ///آماده سازی پرسنل
            PrepareAllPersonnelsModel(model);

            model.UserStatus = true;

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ApplicationUserModel model)
        {
            var result = new ReturnAjaxForm();
            //if (model.RoleId.Count == 0)
            //    ModelState.AddModelError("RoleId", " نقش کاربر را وارد نمایید");

            try
            {
                if (ModelState.IsValid)
                {
                    var user = new ApplicationUser { PersonnelCode = model.PersonnelCode, UserName = model.UserName, UserStatus = model.UserStatus, CreateDate = DateTime.Now, DateExpire = model.DateExpire, ApplicationRoles = new List<ApplicationRole>() };


                    var registerresult = await _userManager.CreateAsync(user, model.Password);
                    if (registerresult.Succeeded)
                    {

                        var getUser = _userService.GetById(user.Id);

                        //foreach (var item in model.RoleId.ToList())
                        //{

                            getUser.ApplicationRoles.Add(_roleService.GetById(model.RoleId));
                        //}

                        _userService.Update(getUser);

                        ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                        ShowMessageToUser(result, "با موفقیت ثبت شد .", ResultType.Success);
                    }
                    else
                    {
                        StringBuilder builder=new StringBuilder();
                        foreach (var err in registerresult.Errors)
                        {

                            builder.Append(err).Append("\n");

                        }

                        /// show Error Message To User beacuse ModelState Is Invalid
                       
                        ShowMessageToUser(result, builder.ToString(), ResultType.Failure);
                    }
                }
                else
                {
                    /// show Error Message To User beacuse ModelState Is Invalid
                    StringBuilder builder = AddErrors();
                    ShowMessageToUser(result, builder.ToString(), ResultType.Failure);

                }
            }
            catch (Exception ex)
            {
                /// لاگ خطا

                LogException.Write(ex, "CreateMethodInUserController");

                ///نمایش پیام خطا به کاربر

                ShowMessageToUser(result, "عملیات با خطا مواجه شد.", ResultType.Failure);
            }
           

            return Json(result);

        }

        public ActionResult Edit(string id)
        {
            var model = new ApplicationUserModel();

            if (!_checkingRoleService.HasAccess(PermissionList.UserEdit, CurrentUser.GetCurrentUser))
            {
                return View("Inaccessibility");
            }

            var user = _userService.GetById(id);

        
            ///آماده سازی لیست نقش ها
            PrepareRoleList(model);

            ///آماده سازی پرسنل
            PrepareAllPersonnelsModel(model);

            foreach (var item in user.ApplicationRoles)
            {
                model.RoleId=item.Id;
                model.RoleSelected.Add(item.Id);
            }

          
            model.UserStatus = user.UserStatus;
            model.UserId = user.Id;
            model.PersonnelCode = user.PersonnelCode;
            model.DateExpire = user.DateExpire;
            model.UserName = user.UserName;
            


            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit([Bind(Exclude = "Password")]ApplicationUserModel model)
        {
            var result = new ReturnAjaxForm();

            try
            {
                var user = _userService.GetById(model.UserId);

                /// حذف اجباری بودن گذر واژه

                ModelState.Remove(nameof(model.Password));


                if (ModelState.IsValid)
                {

                    var existingAccount = await _userManager.FindByNameAsync(model.UserName);

                    if (existingAccount != null && existingAccount.Id != user.Id)
                    {
                        ///نمایش پیام به کاربر

                        ShowMessageToUser(result, "نام کاربری تکراری می باشد !", ResultType.Failure);

                        return Json(result);
                    }

                    user.PersonnelCode = model.PersonnelCode;
                    user.UserStatus = model.UserStatus;
                    user.UserName = model.UserName;
                    user.DateExpire = model.DateExpire;

                    if (!String.IsNullOrEmpty(model.NewPassword))
                    {
                        var newPasswordHash = _userManager.PasswordHasher.HashPassword(model.NewPassword);
                        UserStore<ApplicationUser> store = new UserStore<ApplicationUser>();
                        store.SetPasswordHashAsync(user, newPasswordHash);
                    }

                    foreach (var role in user.ApplicationRoles.ToList())
                    {

                        user.ApplicationRoles.Remove(role);
                    }
                    user.ApplicationRoles = new List<ApplicationRole>();
                    //_userService.Update(user);

                    //foreach (var item in model.RoleId.ToList())
                    //{

                    user.ApplicationRoles.Add(_roleService.GetById(model.RoleId));
                    //}

                    _userService.Update(user);

                    ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                    ShowMessageToUser(result, "با موفقیت ویرایش شد .", ResultType.Success);
                }
                else
                {
                    /// show Error Message To User beacuse ModelState Is Invalid
                    StringBuilder builder = AddErrors();
                    ShowMessageToUser(result, builder.ToString(), ResultType.Failure);
                }
            }
            catch (Exception ex)
            {
                /// لاگ خطا

                LogException.Write(ex, "EditMethodInUserController");

                ///نمایش پیام خطا به کاربر

                ShowMessageToUser(result, "عملیات با خطا مواجه شد.", ResultType.Failure);
            }
         
            return Json(result);
        }
        [HttpPost]
        public ActionResult Delete(string id)
        {
            var result = new ReturnAjaxForm();

            if (!_checkingRoleService.HasAccess(PermissionList.UserDelete, CurrentUser.GetCurrentUser))
            {

                ///نمایش پیام عدم دسترسی به کاربر

                ShowMessageToUser(result, " کاربر گرامی،شما  مجوز حذف رکورد را ندارید! ", ResultType.NotAllow);

                return Json(result);
            }


            try
            {
                var entity = _userService.GetById(id);
                _userService.Remove(entity);

                ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                ShowMessageToUser(result, "با موفقیت حذف شد .", ResultType.Success);
            }
            catch (Exception ex)
            {
                /// لاگ خطا

                LogException.Write(ex, "DeleteMethodInUSerController");


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
            var model = new DataTableResponse<ApplicationUserModel>();
            model.draw = request.draw;

            var data = _userService.FilterData(request.start, request.length, filter.Search, filter.SortColumn, filter.SortDirection);

            data.ForEach(x =>
            {
                var user = new ApplicationUserModel();
                user.UserId = x.Id;
                user.UserStatus = x.UserStatus;
                user.UserName = x.UserName;
                user.RoleName = x.ApplicationRoles.Count > 0 ? x.ApplicationRoles.FirstOrDefault().Name : "";
                if (x.DateExpire != null)
                    user.ShamsiDateExpire = ConvertAdToJalali(x.DateExpire.Value);
               
                user.PersonnelCode = x.PersonnelCode;
                model.data.Add(user);
            });

            model.recordsFiltered = _userService.UserCount();

            if (!HttpContext.User.IsInRole("admin"))
            {
                var admin = model.data.FirstOrDefault(x => x.UserName == "admin");
                model.data.Remove(admin);
                model.recordsFiltered = _userService.UserCount() - 1;

            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        #endregion List

    }
}