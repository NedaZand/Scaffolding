using Store.Service;
using Store.WebEssential.Mvc;
using System;
using System.Linq;
using System.Web.Mvc;
using Store.Service.Stores;
using Store.WebEssential.Helper;
using Store.Models.Stores;
using Microsoft.AspNet.Identity;
using Store.Core.Domain.StoreTables.Attendancee;
using System.Collections.Generic;
using System.Text;
using Store.Core.CommonHelper;
using Store.WebEssential.ModelBinder;
using Store.Core.Domain.StoreTables.Work;
using Store.Essential.Model;
using Store.WebEssential.UserControl;
namespace Store.Controllers
{
    [Authorize]
    public class BrowseDailyController : BaseController
    {
        #region Fields
        private readonly IAssignedWorkorderService _assignedWorkService;
        private readonly IAttendanceService _attendanceService;
        private readonly ICompanyService _companyService;
        private readonly IUserService _userService;
        private readonly IWorkOrderService _workOrderService;
        private readonly IPersonnelService _personnelService;
        private readonly IRoutinService _routinService;
        private readonly IWorkorderAssignedUsersService _workorderAssignedUsersService;
        private readonly IAssignedWorkorderDetailService _workorderAssignedDetailService;
        private readonly IAssignedTaskService _assignedTaskService;
        private readonly IAssignedTaskUserService _assignedTaskUserService;
        private readonly ICheckingRole _checkingRoleService;
        #endregion


        #region Utilities


        [NonAction]
        protected virtual void PrepareAllCompaniesModel(AssignedWorkorderModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            model.Companies.Add(new SelectListItem
            {
                Text = "[None]",
                Value = " "
            });
            var companies = SelectListHelper.GetCompanyList(_companyService);
            foreach (var c in companies)
                model.Companies.Add(c);
        }

        [NonAction]
        protected virtual List<SelectListItem> PrepareAllPersonnelsModel()
        {
            var personnelList = new List<SelectListItem>();
            //if (model == null)
            //    throw new ArgumentNullException("model");

            personnelList.Add(new SelectListItem
            {
                Text = "[None]",
                Value = " "
            });
            var personnels = _personnelService.GetAll();
            foreach (var c in personnels)
            {
                personnelList.Add(new SelectListItem
                {
                    Text = c.UserNameFmaily,
                    Value = c.PersonnelCode.ToString()
                });
            }

            return personnelList;
        }


        [NonAction]
        protected virtual void PrepareAllRoutinsModel(AssignedRoutineModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            model.Routines.Add(new SelectListItem
            {
                Text = "[None]",
                Value = " "
            });
            var routins = _routinService.GetAll();
            foreach (var c in routins)
            {
                model.Routines.Add(new SelectListItem
                {
                    Text = c.Title,
                    Value = c.Id.ToString()
                });
            }
        }

        [NonAction]
        protected virtual void PrepareAllWorkOrderModel(AssignedWorkorderModel model, int companyID = 0)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            model.Works.Add(new SelectListItem
            {
                Text = "[None]",
                Value = " "
            });

            var works = _workOrderService.GetAll(companyId: companyID, date: DateTime.Now);

            foreach (var c in works)
            {
                model.Works.Add(new SelectListItem
                {
                    Text = c.Title,
                    Value = c.Id.ToString()
                });
            }
        }



        #endregion
        

        #region Ctor
        public BrowseDailyController(ICheckingRole checkingRoleService,IAssignedTaskUserService assignedTaskUserService,IAssignedTaskService assignedTaskService,IWorkorderAssignedUsersService workorderAssignedUsersService, IAssignedWorkorderService assignedWorkService, ICompanyService companyService, IUserService userService, IAttendanceService attendanceService, IWorkOrderService workOrderService, IPersonnelService personnelService, IRoutinService routinService, IAssignedWorkorderDetailService workorderAssignedDetailService)
        {
            this._assignedWorkService = assignedWorkService;
            this._companyService = companyService;
            this._userService = userService;
            this._attendanceService = attendanceService;
            this._workOrderService = workOrderService;
            this._personnelService = personnelService;
            this._routinService = routinService;
            this._workorderAssignedUsersService = workorderAssignedUsersService;
            this._workorderAssignedDetailService = workorderAssignedDetailService;
            this._assignedTaskUserService = assignedTaskUserService;
            this._assignedTaskService = assignedTaskService;
            this._checkingRoleService = checkingRoleService;
        }
        #endregion


        public ActionResult WorkorderList()
        {
            if (!_checkingRoleService.HasAccess(PermissionList.BrowseDailyList, Service.User.CurrentUser.GetCurrentUser))
            {
                return View("Inaccessibility");
            }


            var works = _workorderAssignedDetailService.GetAll(null,DateTime.Now.Date);
           
            return View(works);
        }
        public ActionResult RoutinList()
        {
            if (!_checkingRoleService.HasAccess(PermissionList.BrowseDailyList, Service.User.CurrentUser.GetCurrentUser))
            {
                return View("Inaccessibility");
            }


            var routins = _assignedTaskService.GetAll(date:DateTime.Now.Date);

            return View(routins);
        }

    }
}