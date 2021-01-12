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

namespace Store.Controllers
{
    [Authorize]
    public class BuyMaterialReportController : BaseController
    {
        #region Fields
        private readonly IEquipmentService _equipmentService;
        private readonly ICheckingRole _checkingRoleService;
        #endregion
        #region Ctor
        public BuyMaterialReportController(IEquipmentService equipmentService, ICheckingRole checkingRoleService)
        {
            _equipmentService = equipmentService;
            _checkingRoleService = checkingRoleService;


        }
        #endregion
        #region Utilities
        
        [NonAction]
        protected virtual void PrepareAllEquipmentsModel(BuyMaterialModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            model.EquipmentList.Add(new SelectListItem
            {
                Text = "انتخاب تجهیزات ",
                Value = " ",
                Selected = true
            });

            var equipments = _equipmentService.GetAll();

            foreach (var c in equipments)
            {
                model.EquipmentList.Add(new SelectListItem
                {
                    Text = c.Title,
                    Value = c.Id.ToString()
                });
            }
        }


        #endregion

        #region ActionMethod
        public ActionResult BuyMaterialReport()
        {
            var model = new BuyMaterialModel();

            if (!_checkingRoleService.HasAccess(PermissionList.WorkOrderPrint, CurrentUser.GetCurrentUser))
            {
                return View("Inaccessibility");
            }
            PrepareAllEquipmentsModel(model);

            return View(model);
        }
        [HttpPost]
        public ActionResult Report(BuyMaterialModel model)
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
            BuyMaterialModel model = (BuyMaterialModel)Session["filter"];


            // ایجاد شی جدید
            var mainReport = new Stimulsoft.Report.StiReport();
            try
            {
                mainReport["@equipmentId"] = model.EquipmentId;
                mainReport["@fromDate"] = model.FromBuyDate;
                mainReport["@toDate"] = model.ToBuyDate;
            }
            catch (Exception ex)
            {
                /// لاگ خطا

                LogException.Write(ex, "StiReportMethodInBuyMaterialReportController");


                mainReport["@equipmentId"] = null;
                mainReport["@fromDate"] = null;
                mainReport["@toDate"] = null;

            }

            try
            {
                // فراخوانی فایل استیمول
                mainReport.Load(Server.MapPath("~/ReportFiles/BuyMaterialReport.mrt"));
                // 
                mainReport.Compile();


            }
            catch (Exception ex)
            {

                /// لاگ خطا

                LogException.Write(ex, "StiReportMethodInBuyMaterialReportController");


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