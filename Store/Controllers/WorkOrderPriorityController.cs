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
using Store.Essential.Model;

namespace Store.Controllers
{
   [Authorize]
    public class WorkOrderPriorityController : BaseController
    {
        #region Fields
        private readonly IWorkOrderPriorityService _workOrderPriorityService;
        private readonly ICheckingRole _checkingRoleService;
        #endregion
        #region Ctor
        public WorkOrderPriorityController(IWorkOrderPriorityService workOrderPriorityService, ICheckingRole checkingRoleService)
        {
           this._workOrderPriorityService = workOrderPriorityService;
            this._checkingRoleService = checkingRoleService;
        }
        #endregion
        #region Utilities

      
        #endregion
        #region ActionMethod
        public ActionResult Index()
        {
            var model = new WorkOrderPriorityModel();

            //if (!_checkingRoleService.HasAccess(PermissionList.StoreList, CurrentUser.GetCurrentUser))
            //{

            //    model.NotAllow = true;
            //    return View(model);
            //}

            return View(model);
        }
        public ActionResult Create()
        {
            var model = new WorkOrderPriorityModel();

            //if (!_checkingRoleService.HasAccess(PermissionList.StoreCreate, CurrentUser.GetCurrentUser))
            //{

            //    model.NotAllow = true;
            //    return View(model);
            //}
            

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WorkOrderPriorityModel model)
        {
            var result = new ReturnAjaxForm();
            var workOrderPriority = new WorkOrderPriority();
            

            if (ModelState.IsValid)
            {
                try
                {
                    workOrderPriority.Title = model.Title;
                    workOrderPriority.CreatedDate = DateTime.Now;
                    //workOrderStatus.ActionUserId = User.Identity.GetUserId();
                   
                    ///عملیات ثبت در دیتابیس
                    _workOrderPriorityService.Insert(workOrderPriority);

                    result.ResultType = ResultType.Success;
                    result.Message = " با موفقیت ثبت شد";
                }
                catch (Exception e)
                {
                   
                        result.ResultType =ResultType.Failure;
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
                result.ResultType = ResultType.Failure;
                result.Message = builder.ToString();
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            var model =new WorkOrderPriorityModel();

            //if (!_checkingRoleService.HasAccess(PermissionList.StoreEdit, CurrentUser.GetCurrentUser))
            //{

            //    model.NotAllow = true;
            //    return View(model);
            //}

            var entity = _workOrderPriorityService.GetById(id);
            model.Id = entity.Id;
            model.Title = entity.Title;

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(WorkOrderPriorityModel model)
        {
            var result = new ReturnAjaxForm();

            var workOrderType = _workOrderPriorityService.GetById(model.Id);
            
            if (ModelState.IsValid)
            {
                try
                {
                    workOrderType.Title = model.Title;
                    workOrderType.ModifiedDate = DateTime.Now;
                    //employeeType.ActionUserId = User.Identity.GetUserId();

                    ///عملیات ویرایش در دیتابیس
                   
                    _workOrderPriorityService.Update(workOrderType);

                    result.ResultType = ResultType.Success;
                    result.Message = " با موفقیت ویرایش شد";
                }
                catch (Exception e)
                {
                    result.ResultType = ResultType.Failure;
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
                result.ResultType =ResultType.Failure;
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
            var data = _workOrderPriorityService.FilterData(request.start, request.length, filter.Search, filter.SortColumn, filter.SortDirection);


            var gridModel = new DataTableResponse<WorkOrderPriorityModel>()
            {
                data = data.Select(x =>
                {

                    var m = new WorkOrderPriorityModel();
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
                recordsTotal = _workOrderPriorityService.Count(filter.Search),
                recordsFiltered = _workOrderPriorityService.Count(filter.Search),
                draw = request.draw
            };



            return Json(gridModel, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var result = new ReturnAjaxForm();

            if (!_checkingRoleService.HasAccess(PermissionList.StoreDetaileDelete, CurrentUser.GetCurrentUser))
            {
                result.ResultType = ResultType.NotAllow;
                result.Message = " کاربر گرامی،شما  مجوز حذف رکورد را ندارید!  ";
                return Json(result, JsonRequestBehavior.AllowGet);
            }



            try
            {
                var entity = _workOrderPriorityService.GetById(id);
                _workOrderPriorityService.Remove(entity);

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