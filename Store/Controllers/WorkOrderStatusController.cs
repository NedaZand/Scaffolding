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
using Store.Core.Domain.StoreTables.Work;

namespace Store.Controllers
{
    [Authorize]
    public class WorkOrderStatusController : BaseController
    {
        #region Fields
        private readonly IWorkOrderStatusService _workOrderStatusService;
        private readonly ICheckingRole _checkingRoleService;
        #endregion
        #region Ctor
        public WorkOrderStatusController(IWorkOrderStatusService workOrderStatusService, ICheckingRole checkingRoleService)
        {
            _workOrderStatusService = workOrderStatusService;
            _checkingRoleService = checkingRoleService;
        }
        #endregion
        #region Utilities

      
        #endregion
        #region ActionMethod
        public ActionResult Index()
        {
            var model = new WorkOrderStatusModel();

            //if (!_checkingRoleService.HasAccess(PermissionList.StoreList, CurrentUser.GetCurrentUser))
            //{

            //    model.NotAllow = true;
            //    return View(model);
            //}

            return View(model);
        }
        public ActionResult Create()
        {
            var model = new WorkOrderStatusModel();

            //if (!_checkingRoleService.HasAccess(PermissionList.StoreCreate, CurrentUser.GetCurrentUser))
            //{

            //    model.NotAllow = true;
            //    return View(model);
            //}
            

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WorkOrderStatusModel model)
        {
            var result = new Models.ReturnAjaxForm();
            var workOrderStatus = new WorkOrderStatus();
            

            if (ModelState.IsValid)
            {
                try
                {
                    workOrderStatus.Title = model.Title;
                    workOrderStatus.CreatedDate = DateTime.Now;
                    //workOrderStatus.ActionUserId = User.Identity.GetUserId();
                   
                    ///عملیات ثبت در دیتابیس
                    _workOrderStatusService.Insert(workOrderStatus);

                    result.ResultType = Models.ResultType.Success;
                    result.Message = " با موفقیت ثبت شد";
                }
                catch (Exception e)
                {
                   
                        result.ResultType = Models.ResultType.Failure;
                        result.Message = e.InnerException.InnerException.Message;
                    

                }

            }
            else
            {
                StringBuilder builder = new StringBuilder();
                // Append to StringBuilder.
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
                result.ResultType = Models.ResultType.Failure;
                result.Message = builder.ToString();
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            var model =new WorkOrderStatusModel();

            //if (!_checkingRoleService.HasAccess(PermissionList.StoreEdit, CurrentUser.GetCurrentUser))
            //{

            //    model.NotAllow = true;
            //    return View(model);
            //}

            var entity = _workOrderStatusService.GetById(id);
            model.Id = entity.Id;
            model.Title = entity.Title;

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(WorkOrderStatusModel model)
        {
            var result = new Models.ReturnAjaxForm();

            var employeeType = _workOrderStatusService.GetById(model.Id);
            
            if (ModelState.IsValid)
            {
                try
                {
                    employeeType.Title = model.Title;
                    employeeType.ModifiedDate = DateTime.Now;
                    //employeeType.ActionUserId = User.Identity.GetUserId();

                    ///عملیات ویرایش در دیتابیس
                   
                    _workOrderStatusService.Update(employeeType);

                    result.ResultType = Models.ResultType.Success;
                    result.Message = " با موفقیت ویرایش شد";
                }
                catch (Exception e)
                {
                    result.ResultType = Models.ResultType.Failure;
                    result.Message = e.Message;
                }

            }
            else
            {
                StringBuilder builder = new StringBuilder();
                // Append to StringBuilder.
                foreach (var e in ModelState.Values)
                {
                    if (e.Errors.Count() > 0)
                    {
                        foreach(var error in e.Errors.ToList())
                        {
                            builder.Append(error.ErrorMessage).Append("\n");
                        }
                    }
                       
                }
                result.ResultType = Models.ResultType.Failure;
                result.Message = builder.ToString();
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult List(DataTableRequest request, [ModelBinder(typeof(DataTableModelBinder))]DataTableRequestFilter filter)

        {
            if (request.length == -1)
            {
                request.length = int.MaxValue;
            }
            var data = _workOrderStatusService.FilterData(request.start, request.length, filter.Search, filter.SortColumn, filter.SortDirection);


            var gridModel = new DataTableResponse<WorkOrderStatusModel>()
            {
                data = data.Select(x =>
                {

                    var m = new WorkOrderStatusModel();
                    m.Title = x.Title;
                    m.ShamsiCreateDate = ConvertAdToJalaliDateTime(x.CreatedDate.Value);
                    //m.ActionUserName = x.ActionUser.UserName;
                    m.Id = x.Id;

                    if (x.ModifiedDate != null)
                    {
                        m.ShamsiEditDate = ConvertAdToJalaliDateTime(x.ModifiedDate.Value);
                    }


                    return m;
                }).ToList(),
                recordsTotal = _workOrderStatusService.Count(filter.Search),
                recordsFiltered = _workOrderStatusService.Count(filter.Search),
                draw = request.draw
            };



            return Json(gridModel, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var result = new Models.ReturnAjaxForm();

            if (!_checkingRoleService.HasAccess(PermissionList.StoreDetaileDelete, CurrentUser.GetCurrentUser))
            {
                result.ResultType = ResultType.NotAllow;
                result.Message = " کاربر گرامی،شما  مجوز حذف رکورد را ندارید!  ";
                return Json(result, JsonRequestBehavior.AllowGet);
            }



            try
            {
                var entity = _workOrderStatusService.GetById(id);
                _workOrderStatusService.Remove(entity);

                result.ResultType = ResultType.Success;
                result.Message = " با موفقیت حذف شد";
            }
            catch (Exception e)
            {
                result.ResultType = ResultType.Failure;
                result.Message = e.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);

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