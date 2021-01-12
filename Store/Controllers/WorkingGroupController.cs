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
using Store.Models.User;
using System.Collections.Generic;

namespace Store.Controllers
{
    [Authorize]
    public class WorkingGroupController : BaseController
    {
        #region Fields
        private readonly IWorkgroupService _workgroupService;
        private readonly ICheckingRole _checkingRoleService;
        private readonly IPersonnelService _personnelService;
        private readonly IUserService _userService;
        private readonly IWorkgroupPersonnelService _workgroupPersonnelService;
        #endregion
        #region Ctor

        public WorkingGroupController(IWorkgroupPersonnelService workgroupPersonnelService, IWorkgroupService workgroupService, IPersonnelService personnelService, ICheckingRole checkingRoleService, IUserService userService)
        {
            _workgroupService = workgroupService;
            _checkingRoleService = checkingRoleService;
            _userService = userService;
            _personnelService = personnelService;
            _workgroupPersonnelService = workgroupPersonnelService;
        }
        #endregion
        #region Utilities


        [NonAction]
        protected virtual void PrepareAllPersonnelsModel(WorkgroupModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            model.PersonnelList.Add(new SelectListItem
            {
                Text = "[None]",
                Value = " "
            });
            var personnels = _personnelService.GetAll();
            foreach (var c in personnels)
            {
                StringBuilder groupName = new StringBuilder();

                foreach(var group in c.WorkingGroupPersonnels)
                {
                    groupName.Append(" - ");
                    groupName.Append(group.Workgroup.Title);
                   
                }
               
                model.PersonnelList.Add(new SelectListItem
                {

                    Text = c.PositionType != null ? $"{c.UserNameFmaily} - {c.PositionType.Title}" : c.UserNameFmaily
                     + " "+groupName,
                    Value = c.PersonnelCode.ToString()
                });
            }
        }


        [NonAction]
        protected virtual void PrepareAllWorkgroupModel(WorkgroupModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            model.WorkgroupList.Add(new SelectListItem
            {
                Text = " گروه کاری  ",
                Value = "0"
            });
            //var companies = SelectListHelper.GetCompanyList(_companyService);
            var workgroups = _workgroupService.GetAll();

            foreach (var c in workgroups)
            {
                model.WorkgroupList.Add(new SelectListItem
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
            var model = new WorkgroupModel();

            if (!_checkingRoleService.HasAccess(PermissionList.WorkingGroupList, CurrentUser.GetCurrentUser))
            {
                return View("Inaccessibility");
            }

            return View(model);
        }
        public ActionResult Create()
        {
            var model = new WorkgroupModel();

            if (!_checkingRoleService.HasAccess(PermissionList.WorkingGroupCreate, CurrentUser.GetCurrentUser))
            {

                return View("Inaccessibility");
            }

            PrepareAllPersonnelsModel(model);
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(WorkgroupModel model)
        {
            var result = new ReturnAjaxForm();
            var workgroup = new Workgroup();

            bool IsTitleExist = false;

            /// کد پایین چک می کند عنوان تکرای وارد نشود

            if (_workgroupService.GetAll(title: model.Title.Trim()).Count > 0)
            {
                IsTitleExist = true;
            }


            if (IsTitleExist)
            {
                ModelState.AddModelError("Title", "عنوان گروه  تکراری است!");
            }


            if (ModelState.IsValid)
            {
                try
                {
                    workgroup.Title = model.Title;

                    workgroup.ActionUserId = User.Identity.GetUserId();

                    foreach (var personnelId in model.PersonnelIds)
                    {
                        var workingGroupPersonnel = new WorkingGroupPersonnel()
                        {
                            PersonnelCode = personnelId
                        };

                        workgroup.WorkingGroupPersonnels.Add(workingGroupPersonnel);
                    }


                    ///عملیات ثبت در دیتابیس
                    _workgroupService.Insert(workgroup);

                    ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                    ShowMessageToUser(result, "با موفقیت ثبت شد", ResultType.Success);

                }
                catch (Exception ex)
                {
                    /// لاگ خطا

                    LogException.Write(ex, "CreateMethodInWorkingGroupController");


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

            var model = new WorkgroupModel();

            if (!_checkingRoleService.HasAccess(PermissionList.WorkingGroupEdit, CurrentUser.GetCurrentUser))
            {
                return View("Inaccessibility");
            }

            var workgroup = _workgroupService.GetById(id);
            model.Title = workgroup.Title;
            model.Id = workgroup.Id;
            PrepareAllPersonnelsModel(model);

            foreach (var personnel in workgroup.WorkingGroupPersonnels)
            {
                model.PersonnelIds.Add(personnel.PersonnelCode);
            }


            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(WorkgroupModel model)
        {
            var result = new ReturnAjaxForm();

            bool IsTitleExist = false;

            var workgroup = _workgroupService.GetById(model.Id);


            var exist = _workgroupService.GetAll(title: model.Title.Trim());


            if (exist.Count > 0 && exist.FirstOrDefault().Id != workgroup.Id)
            {
                IsTitleExist = true;
            }

            if (IsTitleExist)
            {
                ModelState.AddModelError("title", "عنوان گروه تکراری است!");
            }


            if (ModelState.IsValid)
            {
                try
                {

                    

                    workgroup.Title = model.Title;
                    workgroup.ModifiedDate = DateTime.Now;
                    workgroup.LastActionUserId = User.Identity.GetUserId();
                    var h = new List<WorkingGroupPersonnel>();
                    foreach (var personnelId in workgroup.WorkingGroupPersonnels)
                    {
                        h.Add(_workgroupPersonnelService.GetById(personnelId.Id));
                    }

                        _workgroupPersonnelService.Remove(h);

                    workgroup.WorkingGroupPersonnels = null;
                    workgroup.WorkingGroupPersonnels = new List<WorkingGroupPersonnel>();
                    ///عملیات ویرایش در دیتابیس

                    foreach (var personnelId in model.PersonnelIds)
                    {
                        var workingGroupPersonnel = new WorkingGroupPersonnel()
                        {
                            PersonnelCode = personnelId,
                            WorkgroupId=workgroup.Id
                        };

                        workgroup.WorkingGroupPersonnels.Add(workingGroupPersonnel);
                    }

                    ///عملیات ویرایش در دیتابیس

                    _workgroupService.Update(workgroup);

                    ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                    ShowMessageToUser(result, "با موفقیت ویرایش شد", ResultType.Success);

                }
                catch (Exception ex)
                {
                    /// لاگ خطا

                    LogException.Write(ex, "EditMethodInWorkingGroupController");


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

        public ActionResult CreatePartial()
        {
            var model = new WorkgroupModel();

            if (!_checkingRoleService.HasAccess(PermissionList.WorkingGroupCreate, CurrentUser.GetCurrentUser))
            {

                return PartialView("_Inaccessibility");
            }


            return PartialView("_CreatePartial", model);
        }
        [HttpGet]
        public JsonResult List(DataTableRequest request, [ModelBinder(typeof(DataTableModelBinder))]DataTableRequestFilter filter)

        {
            if (request.length == -1)
            {
                request.length = int.MaxValue;
            }
            var data = _workgroupService.FilterData(request.start, request.length, filter.Search, filter.SortColumn, filter.SortDirection);


            var gridModel = new DataTableResponse<WorkgroupModel>()
            {
                data = data.Select(x =>
                {

                    var m = new WorkgroupModel();
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
                recordsTotal = _workgroupService.Count(filter.Search),
                recordsFiltered = _workgroupService.Count(filter.Search),
                draw = request.draw
            };



            return Json(gridModel, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var result = new ReturnAjaxForm();

            if (!_checkingRoleService.HasAccess(PermissionList.WorkingGroupDelete, CurrentUser.GetCurrentUser))
            {
                ///نمایش پیام عدم دسترسی  به کاربر

                ShowMessageToUser(result, "کاربر گرامی،شما  مجوز حذف رکورد را ندارید! ", ResultType.NotAllow);


                //return Json(result, JsonRequestBehavior.AllowGet);
            }

            try
            {
                var entity = _workgroupService.GetById(id);
                _workgroupService.Remove(entity);

                ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                ShowMessageToUser(result, "با موفقیت حذف شد", ResultType.Success);

            }
            catch (Exception ex)
            {
                /// لاگ خطا

                LogException.Write(ex, "DeleteMethodInWorkingGroupController");


                ///نمایش پیام خطا به کاربر

                ShowMessageToUser(result, "امکان حذف  رکورد وجود ندارد.", ResultType.Failure);
            }

            return Json(result);

        }


        public JsonResult GetAllWorkingGroup()
        {
            var model = new WorkgroupModel();

            PrepareAllWorkgroupModel(model);

            return Json(model.WorkgroupList, JsonRequestBehavior.AllowGet);

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