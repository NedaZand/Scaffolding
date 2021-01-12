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
    
    public class WorkOrderTypeController : BaseController
    {
        #region Fields
        private readonly IWorkOrderTypeService _workOrderTypeService;
        private readonly ICheckingRole _checkingRoleService;
        #endregion
        #region Ctor
        public WorkOrderTypeController(IWorkOrderTypeService workOrderTypeService, ICheckingRole checkingRoleService)
        {
            _workOrderTypeService = workOrderTypeService;
            _checkingRoleService = checkingRoleService;
        }
        #endregion
        #region Utilities

      
        #endregion
        #region ActionMethod
        public ActionResult Index()
        {
            var model = new WorkOrderTypeModel();

            //if (!_checkingRoleService.HasAccess(PermissionList.StoreList, CurrentUser.GetCurrentUser))
            //{

            //    model.NotAllow = true;
            //    return View(model);
            //}

            return View(model);
        }
        public ActionResult Create()
        {
            var model = new WorkOrderTypeModel();

            //if (!_checkingRoleService.HasAccess(PermissionList.StoreCreate, CurrentUser.GetCurrentUser))
            //{

            //    model.NotAllow = true;
            //    return View(model);
            //}
            

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WorkOrderTypeModel model)
        {
            var result = new ReturnAjaxForm();
            var workOrderType = new WorkOrderType();
            

            if (ModelState.IsValid)
            {
                try
                {
                    workOrderType.Title = model.Title;
                    workOrderType.CreatedDate = DateTime.Now;
                    //workOrderStatus.ActionUserId = User.Identity.GetUserId();
                   
                    ///عملیات ثبت در دیتابیس
                    _workOrderTypeService.Insert(workOrderType);

                    result.ResultType = ResultType.Success;
                    result.Message = " با موفقیت ثبت شد";
                }
                catch (Exception e)
                {
                   
                        result.ResultType = ResultType.Failure;
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

            var model =new WorkOrderTypeModel();

            //if (!_checkingRoleService.HasAccess(PermissionList.StoreEdit, CurrentUser.GetCurrentUser))
            //{

            //    model.NotAllow = true;
            //    return View(model);
            //}

            var entity = _workOrderTypeService.GetById(id);
            model.Id = entity.Id;
            model.Title = entity.Title;

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(WorkOrderTypeModel model)
        {
            var result = new ReturnAjaxForm();

            var workOrderType = _workOrderTypeService.GetById(model.Id);
            
            if (ModelState.IsValid)
            {
                try
                {
                    workOrderType.Title = model.Title;
                    workOrderType.ModifiedDate = DateTime.Now;
                    //employeeType.ActionUserId = User.Identity.GetUserId();

                    ///عملیات ویرایش در دیتابیس
                   
                    _workOrderTypeService.Update(workOrderType);

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
                result.ResultType = ResultType.Failure;
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
            var data = _workOrderTypeService.FilterData(request.start, request.length, filter.Search, filter.SortColumn, filter.SortDirection);


            var gridModel = new DataTableResponse<WorkOrderTypeModel>()
            {
                data = data.Select(x =>
                {

                    var m = new WorkOrderTypeModel();
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
                recordsTotal = _workOrderTypeService.Count(filter.Search),
                recordsFiltered = _workOrderTypeService.Count(filter.Search),
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
                var entity = _workOrderTypeService.GetById(id);
                _workOrderTypeService.Remove(entity);

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