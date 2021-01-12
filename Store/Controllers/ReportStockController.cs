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
    public class ReportStockController : BaseController
    {
        #region Fields
        private readonly IEquipmentService _equipmentService;
        private readonly ICheckingRole _checkingRoleService;
        #endregion
        #region Ctor
        public ReportStockController(IEquipmentService equipmentService, ICheckingRole checkingRoleService)
        {
            _equipmentService = equipmentService;
            _checkingRoleService = checkingRoleService;


        }
        #endregion

        #region Utilities


        [NonAction]
        public void PrepareEquipment()
        {
            var equipments = _equipmentService.GetAll();

            var equipmentList = new List<SelectListItem>();

            equipmentList.Add(new SelectListItem
            {
                Text = "انتخاب تجهیز",
                Value = " "
            });

            foreach (var c in equipments)
            {

                equipmentList.Add(new SelectListItem
                {
                    Text = c.Title,
                    Value = c.Id.ToString(),
                    Selected = false
                });
            }
            ViewBag.Equipments = equipmentList;

        }
       
     
        #endregion
        #region ActionMethod
        public ActionResult StockMaterialReport()
        {
         

            if (!_checkingRoleService.HasAccess(PermissionList.WorkOrderPrint, CurrentUser.GetCurrentUser))
            {
                return View("Inaccessibility");
            }
            PrepareEquipment();

            return View();
        }
        [HttpPost]
        public ActionResult Report(int? equipmentId)
        {
            if (System.Web.HttpContext.Current.Session["filter"] != null)
            {
                Session.Remove("filter");
                Session.Add("filter", equipmentId);
            }
            else
            {
                Session.Add("filter", equipmentId);
            }



            return RedirectToAction("Print");
        }
        public virtual ActionResult Print()
        {
            int? equipmentId = (int?)Session["filter"];
            return View();
        }
        public virtual ActionResult StiReport()
        {
            int? equipmentId = (int?)Session["filter"];


            // ایجاد شی جدید
            var mainReport = new Stimulsoft.Report.StiReport();
            try
            {
                mainReport["@equipmentId"] = equipmentId;
            }
            catch (Exception)
            {

                mainReport["@equipmentId"] = null;
               

            }

            try
            {
                // فراخوانی فایل استیمول
                mainReport.Load(Server.MapPath("~/ReportFiles/StockMaterialReport.mrt"));
                // 
                mainReport.Compile();
            }
            catch (Exception ex)
            {

                /// لاگ خطا

                LogException.Write(ex, "StiReportMethodInReportStockController");

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