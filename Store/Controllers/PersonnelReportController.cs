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


namespace Store.Controllers
{
    [Authorize]
    //[ServerDown]
    public class PersonnelReportController : BaseController
    {
        #region Fields
        private readonly IPersonnelService _personnelService;
        private readonly IPositionTypeService _positionService;
        private readonly IEmployeeTypeService _employeeService;
        private readonly ICheckingRole _checkingRoleService;
        #endregion
        #region Ctor
        public PersonnelReportController(IPersonnelService personnelService, ICheckingRole checkingRoleService, IPositionTypeService positionService,
      IEmployeeTypeService employeeService)
        {
            _personnelService = personnelService;
            _checkingRoleService = checkingRoleService;
            _positionService = positionService;
            _employeeService = employeeService;


        }
        #endregion

        #region Utilities

        
        [NonAction]
        protected virtual void PreparePersonnels(PersonnelReportModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            model.Personnels.Add(new SelectListItem
            {
                Text = "[None]",
                Value = " "
            });
            var personnels = _personnelService.GetAll();
            foreach (var c in personnels)
                model.Personnels.Add(new SelectListItem
                {
                    Text = $"{c.UserNameFmaily}-{c.PersonnelCode}",
                    Value = c.PersonnelCode.ToString()
                });
        }
        #endregion
        #region ActionMethod
        public ActionResult Report()
        {
            var model = new PersonnelReportModel();

            if (!_checkingRoleService.HasAccess(PermissionList.PersonnelPrint, CurrentUser.GetCurrentUser))
            {
                return View("Inaccessibility");
            }

            PreparePersonnels(model);

            return View(model);
        }

        [HttpPost]
        public ActionResult PersonnelFunction(PersonnelReportModel model)
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



            return RedirectToAction("PersonnelFunctionPrint");
        }
        public virtual ActionResult PersonnelFunctionPrint()
        {
            PersonnelReportModel model = (PersonnelReportModel)Session["filter"];
            return View();
        }
        public virtual ActionResult PersonnelFunctionStiReport()
        {
            PersonnelReportModel model = (PersonnelReportModel)Session["filter"];


            // ایجاد شی جدید
            var mainReport = new Stimulsoft.Report.StiReport();
            try
            {
                mainReport["@fromDate"] = model.FromDate;
                mainReport["@toDate"] = model.ToDate;
                mainReport["@personnelCode"] = model.PersonnelCode;
            }
            catch (Exception)
            {


                mainReport["@fromDate"] = null;
                mainReport["@toDate"] = null;
                mainReport["@personnelCode"] = null;



            }

            try
            {
                // فراخوانی فایل استیمول
                mainReport.Load(Server.MapPath("~/ReportFiles/PersonnelFunctionReport.mrt"));
                // 
                mainReport.Compile();
            }
            catch (Exception ex)
            {
                /// لاگ خطا

                LogException.Write(ex, "PersonnelFunctionStiReportMethodInPersonnelReportController");


            }
          

            return Stimulsoft.Report.Mvc.StiMvcViewer.GetReportSnapshotResult(mainReport);
        }
        public virtual ActionResult PersonnelFunctionViewerEvent()
        {
            return Stimulsoft.Report.Mvc.StiMvcViewer.ViewerEventResult(HttpContext);
        }
        #endregion
    }
}