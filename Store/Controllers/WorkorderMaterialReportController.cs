using Store.Models;
using Store.Service;
using Store.WebEssential.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
using Microsoft.AspNet.Identity;
using Store.WebEssential.Helper;
using Store.WebEssential.Extensions;
using System.Data.SqlClient;
using Store.Essential.Model;
using Store.Models.Stores.Reports;
using Store.Models.Stores.StoreRoom;
using Store.Models.Stores;

namespace Store.Controllers
{
    [Authorize]
    public class WorkorderMaterialReportController : BaseController
    {
        #region Fields
        private readonly IAssignedWorkorderService _assignedWorkorderService;
        private readonly ICheckingRole _checkingRoleService;
        private readonly IOutputMaterialService _outputMaterialService;
        private readonly IEquipmentService _equipmentService;
        #endregion
        #region Ctor
        public WorkorderMaterialReportController(IOutputMaterialService outputMaterialService,IAssignedWorkorderService assignedWorkorderService,IEquipmentService equipmentService, ICheckingRole checkingRoleService)
        {
            _assignedWorkorderService = assignedWorkorderService;
            _checkingRoleService = checkingRoleService;
            _outputMaterialService = outputMaterialService;
            _equipmentService = equipmentService;



        }
        #endregion
        #region Utilities
        
        [NonAction]
        protected virtual void PrepareAllWorkordersModel(WorkorderMaterialReportModel model)
        {
            var workorders = _assignedWorkorderService.GetAll(null);
            

            model.Workorders.Add(new SelectListItem
            {
                Text = "انتخاب دستور کار ",
                Value = " ",
                Selected = true
            });
            

            foreach (var c in workorders)
            {
              model.Workorders.Add(new SelectListItem
                {
                    Text = c.WorkOrder.Title,
                    Value = c.WorkOrderId.ToString()
                });
            }
            
        }

        [NonAction]
        protected virtual void PrepareAllEquipmentsModel(WorkorderMaterialReportModel model, int workorderId = 0)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            model.Equipments.Add(new SelectListItem
            {
                Text = "انتخاب تجهیزات ",
                Value = " ",
                Selected = true
            });
            if (workorderId > 0)
            {
                var equipments = _outputMaterialService.GetAll(models => models.WorkOrderId == workorderId);

                foreach (var c in equipments)
                {
                    model.Equipments.Add(new SelectListItem
                    {
                        Text = _equipmentService.GetById(c.EquipmentId).Title,
                        Value = c.EquipmentId.ToString()
                    });
                }
            }

        }

        #endregion

        #region ActionMethod
        public ActionResult Report()
        {
            var model = new WorkorderMaterialReportModel();

            if (!_checkingRoleService.HasAccess(PermissionList.WorkOrderPrint, CurrentUser.GetCurrentUser))
            {
                return View("Inaccessibility");
            }
            PrepareAllWorkordersModel(model);
            PrepareAllEquipmentsModel(model, 0);
            return View(model);
        }
        [HttpPost]
        public ActionResult Report(WorkorderMaterialReportModel model)
        {
            if (System.Web.HttpContext.Current.Session["filter"] != null)
            {
                Session.Remove("filter");
                Session.Add("filter", model);
            }
            else
            {
                Session.Add("filter", model);
            }



            return RedirectToAction("Print");
        }
        public virtual ActionResult Print()
        {
           
            return View();
        }
        public virtual ActionResult StiReport()
        {
            WorkorderMaterialReportModel model = (WorkorderMaterialReportModel)Session["filter"];


            // ایجاد شی جدید
            var mainReport = new Stimulsoft.Report.StiReport();
            try
            {
                mainReport["@workorderId"] = model.WorkorderId;
                mainReport["@equipmentId"] = model.EquipmentId;
            }
            catch (Exception)
            {

                mainReport["@workorderId"] = null;
                mainReport["@equipmentId"] = null;

            }
            try
            {
                // فراخوانی فایل استیمول
                mainReport.Load(Server.MapPath("~/ReportFiles/WorkorderMaterialReport.mrt"));
                // 
                mainReport.Compile();
            }
            catch (Exception ex)
            {

                /// لاگ خطا

                LogException.Write(ex, "StiReportMethodInWorkorderMaterialReportController");


            }

      
           

            return Stimulsoft.Report.Mvc.StiMvcViewer.GetReportSnapshotResult(mainReport);
        }
        public virtual ActionResult ViewerEvent()
        {
            return Stimulsoft.Report.Mvc.StiMvcViewer.ViewerEventResult(HttpContext);
        }

        [HttpPost]
        public JsonResult GetEquipmentByWorkOrderID(int workorderId)

        {
            var model = new WorkorderMaterialReportModel();

            ///بدست آوردن  تجهیزات 
            PrepareAllEquipmentsModel(model, workorderId);

            return Json(model.Equipments);
        }

        #endregion
    }
}