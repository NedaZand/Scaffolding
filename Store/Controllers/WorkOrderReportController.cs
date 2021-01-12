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

namespace Store.Controllers
{
    [Authorize]
    //[ServerDown]
    public class WorkOrderReportController : BaseController
    {
        #region Fields
        private readonly IWorkOrderService _workorderService;
        private readonly ICheckingRole _checkingRoleService;
        #endregion
        #region Ctor
        public WorkOrderReportController(IWorkOrderService workorderServic, ICheckingRole checkingRoleService)
        {
            _workorderService = workorderServic;
            _checkingRoleService = checkingRoleService;


        }
        #endregion

        #region Utilities


        [NonAction]
        public void PrepareWorkorder(WorkOrderReportModel model)
        {
            var workorders = _workorderService.GetAll();

            model.WorkOrders = (from c in workorders
                               select new SelectListItem
                               {
                                   Text = c.Title,
                                   Value = c.Id.ToString(),
                                   Selected = false
                               }).ToList();
            model.WorkOrders.Add(new SelectListItem
            {
                Text = "انتخاب داربست",
                Value = "",
                Selected = true
            });

        }
       
     
        #endregion
        #region ActionMethod
        public ActionResult Report()
        {
            var model = new WorkOrderReportModel();

            if (!_checkingRoleService.HasAccess(PermissionList.WorkOrderPrint, CurrentUser.GetCurrentUser))
            {
                return View("Inaccessibility");
            }
            PrepareWorkorder(model);

            return View(model);
        }
        [HttpPost]
        public ActionResult Report(WorkOrderReportModel model)
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
            WorkOrderReportModel model = (WorkOrderReportModel)Session["filter"];
            return View();
        }
        public virtual ActionResult StiReport()
        {
            WorkOrderReportModel model = (WorkOrderReportModel)Session["filter"];


            // ایجاد شی جدید
            var mainReport = new Stimulsoft.Report.StiReport();
            try
            {
                mainReport["@workorderId"] = model.WorkOrderId;
                mainReport["@date"] = model.FromDate;
                mainReport["@toDate"] = model.ToDate;
            }
            catch (Exception)
            {

                mainReport["@workOrderId"] = null;
                mainReport["@date"] = null;
                mainReport["@toDate"] = null;

            }

            try
            {
                // فراخوانی فایل استیمول
                mainReport.Load(Server.MapPath("~/ReportFiles/WorkorderFunctionReport.mrt"));
                // 
                mainReport.Compile();
            }
            catch (Exception ex)
            {

                /// لاگ خطا

                LogException.Write(ex, "StiReportMethodInWorkorderReportController");


            }


            return Stimulsoft.Report.Mvc.StiMvcViewer.GetReportSnapshotResult(mainReport);
        }
        public virtual ActionResult ViewerEvent()
        {
            return Stimulsoft.Report.Mvc.StiMvcViewer.ViewerEventResult(HttpContext);
        }

        
        #endregion
    }
}