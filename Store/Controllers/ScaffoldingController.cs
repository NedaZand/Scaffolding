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
using Store.Service.Stores;
using Store.Models.Stores;
using Store.Core.Domain.StoreTables.Work;
using Store.Service;
using Store.Essential.Model;
using Store.Models.Stores.StoreRoom;
using Store.Core.Domain.StoreTables.StoreRoom;
using Store.Service.Media;
using Rotativa;
using System.Collections.Generic;
using Store.Core.Domain.StoreTables;

namespace Store.Controllers
{
    [Authorize]
    public class ScaffoldingController : BaseController
    {
        private readonly IWorkOrderService _workorderService;
        private readonly IWorkgroupService _workgroupService;
        private readonly ICheckingRole _checkingRoleService;
        private readonly ICompanyService _companyService;
        private readonly IUserService _userService;
        private readonly IScaffoldingService _scaffoldingService;
        private readonly IInputMaterialService _inputMaterialService;
        private readonly IOutputMaterialService _outputMaterialService;
        private readonly IScaffoldTypeService _scaffoldTypeService;
        private readonly IBuildingService _buildingService;
        private readonly IEarthService _earthService;
        private readonly IEquipmentService _equipmentService;
        private readonly IWorkorderAssignedUsersService _workorderAssignedUsers;
        private readonly IPictureService _pictureService;
        private readonly IStockService _stockService;
        private readonly IOutputMaterialHasEquipmentService _outMaterialHasEquiService;
        private readonly IInputMaterialHasEquipmentService _inputMaterialHasEquipmentService;
        #region Fields

        #endregion
        #region Ctor
        public ScaffoldingController(IWorkOrderService workOrderService,
            IWorkgroupService workgroupService,
            ICheckingRole checkingRole,
            ICompanyService companyService,
            IUserService userService,
            IScaffoldingService scaffoldingService,
            IInputMaterialService inputMaterialService,
            IOutputMaterialService outputMaterialService,
            IScaffoldTypeService scaffoldTypeService,
            IBuildingService buildingService,
            IEarthService earthService,
            IEquipmentService equipmentService,
            IWorkorderAssignedUsersService workorderAssignedUsersService,
            IPictureService pictureService,
            IStockService stockService,
            IOutputMaterialHasEquipmentService outputMaterialHasEquipmentService,
            IInputMaterialHasEquipmentService inputMaterialHasEquipmentService)
        {
            _workorderService = workOrderService;
            _workgroupService = workgroupService;
            _checkingRoleService = checkingRole;
            _companyService = companyService;
            _userService = userService;
            _scaffoldingService = scaffoldingService;
            _inputMaterialService = inputMaterialService;
            _outputMaterialService = outputMaterialService;
            _scaffoldTypeService = scaffoldTypeService;
            _buildingService = buildingService;
            _earthService = earthService;
            _equipmentService = equipmentService;
            _workorderAssignedUsers = workorderAssignedUsersService;
            _pictureService = pictureService;
            _stockService = stockService;
            _outMaterialHasEquiService = outputMaterialHasEquipmentService;
            _inputMaterialHasEquipmentService = inputMaterialHasEquipmentService;
        }
        #endregion
        #region Utilities

        [NonAction]
        protected virtual void PrepareAllCompaniesModel(ScaffoldModel model, int? parentId = null, int type = 0)
        {
            if (model == null)
                throw new ArgumentNullException("model");
            if (type == 0)
            {
                model.Companies.Add(new SelectListItem
                {
                    Text = "انتخاب ",
                    Value = " "
                });

                //var companies = SelectListHelper.GetCompanyList(_companyService);
                var companies = _companyService.GetAll(parentId: parentId);
                foreach (var c in companies)
                {
                    model.Companies.Add(new SelectListItem
                    {
                        Text = c.Title,
                        Value = c.Id.ToString()
                    });
                }
            }
            else if (type == 1)
            {
                var companies = _companyService.GetAll(parentId: parentId);
                foreach (var c in companies)
                {
                    model.UnitList.Add(new SelectListItem
                    {
                        Text = c.Title,
                        Value = c.Id.ToString()
                    });
                }
            }
            else
            {
                var companies = _companyService.GetAll(parentId: parentId);
                foreach (var c in companies)
                {
                    model.SectionList.Add(new SelectListItem
                    {
                        Text = c.Title,
                        Value = c.Id.ToString()
                    });
                }
            }

        }

        [NonAction]
        protected virtual void PrepareAllWorkOrderModel(ScaffoldModel model, int? companyID = null)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            var Companies = new List<Company>();
            var statuses = new List<WorkOrderStatus>();
            var works = new List<WorkOrder>();

            statuses.Add(WorkOrderStatus.InProcess);
            statuses.Add(WorkOrderStatus.Unassigned);

            model.WorkOrders.Add(new SelectListItem
            {
                Text = "انتخاب دستور کار",
                Value = " "
            });

            Companies = _companyService.GetAllCompaniesByParentCompanyId(companyID);
            if (companyID.HasValue)
                Companies.Add(_companyService.GetById(companyID.Value));

            if (model.WorkOrderId != 0)

                works = _workorderService.GetAll(companies: Companies, type: WorkOrderType.Installation).Where(x => x.ScaffoldingId.HasValue).ToList();
            else
                works = _workorderService.GetAll(companies: Companies, type: WorkOrderType.Installation).Where(x => !x.ScaffoldingId.HasValue).ToList();

            foreach (var c in works)
            {
                model.WorkOrders.Add(new SelectListItem
                {
                    Text = c.Title,
                    Value = c.Id.ToString()
                });
            }


        }

        [NonAction]
        protected virtual void PrepareAllBuildings(ScaffoldModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            var buildings = _buildingService.GetAll();

            model.Buildings.Add(new SelectListItem
            {
                Text = "انتخاب نوع ساختمان",
                Value = " "
            });

            foreach (var c in buildings)
            {

                model.Buildings.Add(new SelectListItem
                {
                    Text = c.Title,
                    Value = c.Id.ToString(),
                    Selected = false
                });
            }

            //model.Types.Add(new SelectListItem
            //{
            //    Text = "[None]",
            //    Value = " "
            //});
            //var types = _workorderTypeService.GetAll();
            //foreach (var c in types)
            //    model.Types.Add(new SelectListItem
            //    {
            //        Text = c.Title,
            //        Value = c.Id.ToString()
            //    });
        }

        [NonAction]
        protected virtual void PrepareAllEarths(ScaffoldModel model)
        {

            var earths = _earthService.GetAll();

            model.Earths.Add(new SelectListItem
            {
                Text = "انتخاب نوع زمین",
                Value = " "
            });

            foreach (var c in earths)
            {

                model.Earths.Add(new SelectListItem
                {
                    Text = c.Title,
                    Value = c.Id.ToString(),
                    Selected = false
                });
            }
        }

        [NonAction]
        protected virtual void PrepareAllScaffoldTypes(ScaffoldModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            var scaffoldTypes = _scaffoldTypeService.GetAll();

            model.ScaffoldTypes.Add(new SelectListItem
            {
                Text = "انتخاب نوع داربست",
                Value = " "
            });

            foreach (var c in scaffoldTypes)
            {

                model.ScaffoldTypes.Add(new SelectListItem
                {
                    Text = c.Title,
                    Value = c.Id.ToString(),
                    Selected = false
                });
            }
        }

        protected virtual void GetWorkOrderInfo(ScaffoldModel model, Scaffolding scaffold)
        {

            var getWorkOrder = _workorderService.GetAll(type: WorkOrderType.Installation, scaffoldingId: scaffold.Id);
            if (getWorkOrder.Count > 0)
            {
                model.WorkOrderModel.Title = getWorkOrder.FirstOrDefault()?.Title;
                model.WorkOrderModel.CompanyName = _companyService.GetById(getWorkOrder.FirstOrDefault().CompanyId)?.Title;
                if (getWorkOrder.FirstOrDefault().UnitId.HasValue)
                    model.WorkOrderModel.UnitName = _companyService.GetById(getWorkOrder.FirstOrDefault().UnitId.Value)?.Title;
                if (getWorkOrder.FirstOrDefault().SectionId.HasValue)
                    model.WorkOrderModel.SectionName = _companyService.GetById(getWorkOrder.FirstOrDefault().SectionId.Value)?.Title;
                model.WorkOrderModel.Tag = getWorkOrder.FirstOrDefault()?.Tag;
                model.WorkOrderModel.ShamsiDate = ConvertAdToJalali(getWorkOrder.FirstOrDefault().Date);

                model.WorkOrderTitle = getWorkOrder.FirstOrDefault().Title;

                if (scaffold.RegistrationDate.HasValue)
                    model.ShamsiRegistrationDate = ConvertAdToJalali(scaffold.RegistrationDate.Value);
                model.Tag = getWorkOrder.FirstOrDefault().Tag;
                model.Title = scaffold.Title;
                model.Tag = scaffold.Tag;
                model.EarthTitle = scaffold.Earth.Title;
                model.BuildingTitle = scaffold.Building.Title;
                model.ScaffoldTypeTitle = scaffold.ScaffoldType.Title;
                if (scaffold.SafetyTagExpire.HasValue)
                    model.ShamsiSafetyTagExpire = ConvertAdToJalali(scaffold.SafetyTagExpire.Value);
                if (scaffold.ExpireDate.HasValue)
                    model.ShamsiExpireDate = ConvertAdToJalali(scaffold.ExpireDate.Value);
                model.ShamsiDate = ConvertAdToJalali(scaffold.Date);
                model.Height = scaffold.Height;
                model.Width = scaffold.Width;
                model.Length = scaffold.Length;

                model.WorkOrderModel.CompanyName = _companyService.GetById(getWorkOrder.FirstOrDefault().CompanyId)?.Title;
                model.WorkOrderModel.SectionName = _companyService.GetById(getWorkOrder.FirstOrDefault().SectionId.Value)?.Title;
                model.WorkOrderModel.UnitName = _companyService.GetById(getWorkOrder.FirstOrDefault().UnitId.Value)?.Title;
                model.WorkOrderTitle = getWorkOrder.FirstOrDefault().Title;
                model.Tag = getWorkOrder.FirstOrDefault().Tag;
                model.ShamsiCreateDate = ConvertAdToJalali(getWorkOrder.FirstOrDefault().Date);

            }


        }

        #endregion
        #region ActionMethod
        public ActionResult Index()
        {
            var model = new ScaffoldModel();

            if (!_checkingRoleService.HasAccess(PermissionList.ScaffoldingList, CurrentUser.GetCurrentUser))
            {
                return View("Inaccessibility");
            }
            ///آماده سازی لیست ساختمان
            //PrepareAllBuildings(model);
            ///آماده سازی لیست نوع زمین
            //PrepareAllEarths(model);
            ///آماده سازی لیست نوع داربست
            //PrepareAllScaffoldTypes(model);
            ///آماده سازی لیست دستور کار
           //PrepareAllWorkOrderModel(model);

            return View(model);
        }

        public ActionResult NoSafetyTag()
        {
            var model = new ScaffoldModel();

            if (!_checkingRoleService.HasAccess(PermissionList.ScaffoldingList, CurrentUser.GetCurrentUser))
            {
                return View("Inaccessibility");
            }
            ///آماده سازی لیست ساختمان
            //PrepareAllBuildings(model);
            ///آماده سازی لیست نوع زمین
            //PrepareAllEarths(model);
            ///آماده سازی لیست نوع داربست
            //PrepareAllScaffoldTypes(model);
            ///آماده سازی لیست دستور کار
           //PrepareAllWorkOrderModel(model);

            return View(model);
        }
        public ActionResult Create()
        {
            var model = new ScaffoldModel();

            if (!_checkingRoleService.HasAccess(PermissionList.ScaffoldingCreate, CurrentUser.GetCurrentUser))
            {

                return View("Inaccessibility");
            }
            ///آماده سازی لیست ساختمان
            PrepareAllBuildings(model);
            ///آماده سازی لیست نوع زمین
            PrepareAllEarths(model);
            ///آماده سازی لیست نوع داربست
            PrepareAllScaffoldTypes(model);

            ///بدست آوردن زیر مجموعه های شرکت
            PrepareAllCompaniesModel(model);

            return View(model);
        }
        [HttpPost]
        public ActionResult Create(ScaffoldModel model)
        {
            var result = new ReturnAjaxForm();
            var scaffold = new Scaffolding();

            if (model.WorkOrderId == 0)

                ModelState.AddModelError("WorkOrderId", "دستور کار الزامی است.");

            if (Request["print"] != null)
            {
                ModelState.Clear();

                TempData["model"] = model;

                if (model.WorkOrderId != 0)
                {
                    result.ResultType = ResultType.Redirect;
                    result.Message = "/Scaffolding/CreateFormPrint?workorderId=" + model.WorkOrderId;
                    return Json(result);
                }

                //return RedirectToAction("CreateFormPrint", new { workorderId =model.WorkOrderId});
                else
                    ModelState.AddModelError("WorkOrderId", "دستور کار الزامی است.");

            }
            else
            {

                if (model.Date.HasValue && model.ExpireDate.HasValue && model.ExpireDate.Value.Date < model.Date.Value.Date)
                    ModelState.AddModelError("ExpireDate", "تاریخ انقضا نمی تواند از تاریخ شروع کوچکتر باشد.");

            }


            if (ModelState.IsValid)
            {
                try
                {

                    scaffold.Title = model.Title;
                    scaffold.Tag = model.Tag;
                    scaffold.Width = model.Width;
                    scaffold.ScaffoldTypeId = model.ScaffoldTypeId;
                    scaffold.ExpireDate = model.ExpireDate;
                    scaffold.Date = model.Date.Value;
                    scaffold.SafetyTagExpire = model.SafetyTagExpire;
                    scaffold.Description = model.Description;
                    scaffold.Length = model.Length;
                    scaffold.Height = model.Height;
                    scaffold.EarthId = model.EarthId;
                    scaffold.BuildingId = model.BuildingId;
                    scaffold.WorkOrderId = model.WorkOrderId;
                    scaffold.ScaffoldStates = ScaffoldStates.Submited;
                    if (model.Image > 0)
                        scaffold.Image = model.Image;
                    scaffold.ActionUserId = User.Identity.GetUserId();
                    int scaffoldId;

                    ///عملیات ثبت در دیتابیس

                    if (_scaffoldingService.Insert(scaffold, out scaffoldId))
                    {
                        ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                        ShowMessageToUser(result, "با موفقیت ثبت شد. ", ResultType.Success, scaffoldId);
                    }
                    else
                    {
                        ///نمایش پیام خطا  به کاربر

                        ShowMessageToUser(result, "عملیات با خطا مواجه شد.", ResultType.Failure);
                    }



                }
                catch (Exception ex)
                {

                    /// لاگ خطا

                    LogException.Write(ex, "CreateMethodInScaffoldingController");

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

            var model = new ScaffoldModel();

            if (!_checkingRoleService.HasAccess(PermissionList.ScaffoldingEdit, CurrentUser.GetCurrentUser))
            {

                return View("Inaccessibility");
            }

            /// پر کردن مدل و ارسال به ویو جهت ویرایش

            #region FillModelWithDatabase

            var entity = _scaffoldingService.GetById(id);
            var getWorkorder = _workorderService.GetAll(type: WorkOrderType.Installation, scaffoldingId: entity.Id);
            model.Id = entity.Id;
            model.Title = entity.Title;
            model.Tag = entity.Tag;
            model.Width = entity.Width;
            model.ScaffoldTypeId = entity.ScaffoldTypeId;
            if (entity.ExpireDate.HasValue)
                model.ExpireDate = entity.ExpireDate.Value;
            model.Date = entity.Date;
            if (entity.RegistrationDate.HasValue)
                model.SafetyTagExpire = entity.RegistrationDate.Value;
            model.Description = entity.Description;
            model.Length = entity.Length;
            model.Height = entity.Height;
            model.EarthId = entity.EarthId;
            model.BuildingId = entity.BuildingId;
            if (entity.Image.HasValue)
                model.Image = entity.Image.Value;

            if (getWorkorder.Count > 0)
            {
                ///بدست آوردن زیر مجموعه های شرکت
                //PrepareAllCompaniesModel(model, 0);
                model.Companies.Add(new SelectListItem
                {
                    Value = getWorkorder.FirstOrDefault().CompanyId.ToString(),
                    Text = _companyService.GetById(getWorkorder.FirstOrDefault().CompanyId)?.Title
                });
                model.WorkOrderId = getWorkorder.FirstOrDefault().Id;
                model.CompanyId = getWorkorder.FirstOrDefault().CompanyId;
                model.UnitId = getWorkorder.FirstOrDefault()?.UnitId;
                ///آماده سازی لیست دستور کار
                // PrepareAllWorkOrderModel(model,model.CompanyId.Value);

                model.WorkOrders.Add(new SelectListItem
                {
                    Value = getWorkorder.FirstOrDefault().Id.ToString(),
                    Text = getWorkorder.FirstOrDefault()?.Title
                });

                if (model.UnitId.HasValue)
                {
                    //PrepareAllCompaniesModel(model, model.CompanyId.Value, 1);
                    model.UnitList.Add(new SelectListItem
                    {
                        Value = getWorkorder.FirstOrDefault().UnitId.ToString(),
                        Text = _companyService.GetById(getWorkorder.FirstOrDefault().UnitId.Value)?.Title
                    });
                    ///آماده سازی لیست دستور کار
                    //PrepareAllWorkOrderModel(model,model.UnitId.Value);

                }
                model.SectionId = getWorkorder.FirstOrDefault()?.SectionId;
                if (model.SectionId.HasValue)
                {

                    model.SectionList.Add(new SelectListItem
                    {
                        Value = getWorkorder.FirstOrDefault().SectionId.ToString(),
                        Text = _companyService.GetById(getWorkorder.FirstOrDefault().SectionId.Value)?.Title
                    });


                }

            }

            ///آماده سازی لیست ساختمان
            PrepareAllBuildings(model);
            ///آماده سازی لیست نوع زمین
            PrepareAllEarths(model);
            ///آماده سازی لیست نوع داربست
            PrepareAllScaffoldTypes(model);



            #endregion FillModelWithDatabase

            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(ScaffoldModel model)
        {
            var result = new ReturnAjaxForm();

            if (model.Date.HasValue && model.ExpireDate.HasValue && model.ExpireDate.Value.Date < model.Date.Value.Date)
                ModelState.AddModelError("ExpireDate", "تاریخ انقضا نمی تواند از تاریخ شروع کوچکتر باشد.");


            if (ModelState.IsValid)
            {
                try
                {
                    var scaffold = _scaffoldingService.GetById(model.Id);

                    scaffold.Title = model.Title;
                    scaffold.Tag = model.Tag;
                    scaffold.Width = model.Width;
                    scaffold.ScaffoldTypeId = model.ScaffoldTypeId;
                    scaffold.ExpireDate = model.ExpireDate;
                    scaffold.Date = model.Date.Value;
                    scaffold.RegistrationDate = model.SafetyTagExpire;
                    scaffold.Description = model.Description;
                    scaffold.Length = model.Length;
                    scaffold.Height = model.Height;
                    scaffold.EarthId = model.EarthId;
                    scaffold.Image = model.Image;
                    scaffold.BuildingId = model.BuildingId;
                    scaffold.confirmed = model.confirmed;
                    scaffold.TotalPoints = model.TotalPoints;
                    scaffold.WorkOrderId = model.WorkOrderId;
                    scaffold.LastActionUserId = User.Identity.GetUserId();
                    scaffold.ModifiedDate = DateTime.Now;
                    ///عملیات ثبت در دیتابیس
                    _scaffoldingService.Update(scaffold);

                    ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                    ShowMessageToUser(result, "با موفقیت ویرایش شد. ", ResultType.Success);
                }
                catch (Exception ex)
                {

                    /// لاگ خطا

                    LogException.Write(ex, "EditMethodInScaffoldingController");

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
        public JsonResult List(DataTableRequest request, [ModelBinder(typeof(DataTableModelBinder))]DataTableRequestFilter filter, ScaffoldSearchModel model)

        {
            if (request.length == -1)
            {
                request.length = int.MaxValue;
            }
            var data = _scaffoldingService.FilterData(request.start, request.length, filter.Search, filter.SortColumn, filter.SortDirection, model.FromDate, model.ToDate, model.FromExpireDate, model.ToExpireDate, model.Width, model.Height, model.Lengthh, model.FromSafetyTagExpire, model.ToSafetyTagExpire, model.BuildingId, model.EarthId, model.WorkOrderId, model.ScaffoldTypeId, model.Title, model.Tag, notTag: model.NotTag);


            var gridModel = new DataTableResponse<ScaffoldModel>()
            {
                data = data.Select(x =>
                {

                    var m = new ScaffoldModel();
                    m.Title = x.Title;
                    m.Tag = x.Tag;
                    if (x.Image.HasValue)
                        m.ImageUrl = _pictureService.GetPictureUrl(x.Image.Value);
                    m.ShamsiDate = ConvertAdToJalali(x.Date);
                    if (x.ExpireDate.HasValue)
                        m.ShamsiExpireDate = ConvertAdToJalali(x.ExpireDate.Value);
                    if (x.RegistrationDate.HasValue)
                        m.ShamsiSafetyTagExpire = ConvertAdToJalali(x.RegistrationDate.Value);
                    m.Width = x.Width;
                    m.Height = x.Height;
                    m.Length = x.Length;
                    m.confirmed = x.confirmed;
                    m.TotalPoints = x.TotalPoints;
                    m.EarthTitle = x.Earth != null ? x.Earth.Title : "";
                    m.BuildingTitle = x.Building != null ? x.Building.Title : "";
                    m.ScaffoldTypeTitle = x.ScaffoldType != null ? x.ScaffoldType.Title : "";
                    m.ShamsiCreateDate = ConvertAdToJalaliDateTime(x.CreatedDate.Value);
                    m.ActionUserName = _userService.GetById(x.ActionUserId).UserName;
                    m.Id = x.Id;

                    if (x.ModifiedDate.HasValue)
                        m.ShamsiEditDate = ConvertAdToJalaliDateTime(x.ModifiedDate.Value);
                    if (x.LastActionUserId != null)
                        m.EditUserName = _userService.GetById(x.ActionUserId).UserName;
                    m.ScaffoldStates = x.ScaffoldStates.GetDisplayName();

                    return m;
                }).ToList(),
                recordsTotal = _scaffoldingService.Count(filter.Search, model.FromDate, model.ToDate, model.FromExpireDate, model.ToExpireDate, model.Width, model.Height, model.Lengthh, model.FromSafetyTagExpire, model.ToSafetyTagExpire, model.BuildingId, model.EarthId, model.WorkOrderId, model.ScaffoldTypeId, model.Title, model.Tag, notTag: model.NotTag),
                recordsFiltered = _scaffoldingService.Count(filter.Search, model.FromDate, model.ToDate, model.FromExpireDate, model.ToExpireDate, model.Width, model.Height, model.Lengthh, model.FromSafetyTagExpire, model.ToSafetyTagExpire, model.BuildingId, model.EarthId, model.WorkOrderId, model.ScaffoldTypeId, model.Title, model.Tag, notTag: model.NotTag),
                draw = request.draw
            };



            return Json(gridModel, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {
            var result = new ReturnAjaxForm();

            if (!_checkingRoleService.HasAccess(PermissionList.ScaffoldingDelete, CurrentUser.GetCurrentUser))
            {

                ///نمایش پیام عدم دسترسی به کاربر

                ShowMessageToUser(result, "کاربر گرامی،شما  مجوز حذف رکورد را ندارید! ", ResultType.NotAllow);

                //return Json(result, JsonRequestBehavior.AllowGet);
            }



            try
            {
                var entity = _scaffoldingService.GetById(id);
                _scaffoldingService.Remove(entity);

                ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                ShowMessageToUser(result, "با موفقیت حذف شد.", ResultType.Failure);
            }
            catch (Exception ex)
            {
                /// لاگ خطا

                LogException.Write(ex, "DeleteMethodInScaffoldingController");


                ///نمایش پیام خطا به کاربر

                ShowMessageToUser(result, "امکان حذف  رکورد وجود ندارد.", ResultType.Failure);

            }

            return Json(result, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult GetWorkOrderByScaffoldId(int id)
        {
            var model = new WorkOrderModel();
            var scaffold = new Scaffolding();


            try
            {
                //scaffold = _scaffoldingService.GetById(id);
                //var getWorkOrder = _workorderService.GetAll(type: WorkOrderType.Installation, scaffoldingId: scaffold.Id);
                //if (getWorkOrder.Count>0)
                //{

                //    model.Title =getWorkOrder.FirstOrDefault().Title;
                //    model.TypeTitle = getWorkOrder.FirstOrDefault().TypeId.GetDisplayName();
                //    model.Tag =getWorkOrder.FirstOrDefault().Tag;
                //    model.ShamsiDate =ConvertAdToJalali(getWorkOrder.FirstOrDefault().Date);
                //    model.CompanyName =_companyService.GetById(getWorkOrder.FirstOrDefault().CompanyId)?.Title;
                //    model.SectionName = _companyService.GetById(getWorkOrder.FirstOrDefault().SectionId.Value)?.Title;
                //    model.UnitName = _companyService.GetById(getWorkOrder.FirstOrDefault().UnitId.Value)?.Title;
                //}
                model.ScaffoldingId = id;
            }
            catch (Exception ex)
            {
                /// لاگ خطا

                LogException.Write(ex, "GetWorkOrderByScaffoldIdMethodInScaffoldingController");



            }

            return PartialView("ShowWorkOrder", model);

        }

        [HttpPost]
        public ActionResult GetSafetyTagByScaffoldId(int id)
        {
            var model = new ScaffoldModel();
            var scaffold = new Scaffolding();

            try
            {
                scaffold = _scaffoldingService.GetById(id);
                model.ExpertName = scaffold.ExpertName;
                model.PermitNumber = scaffold.PermitNumber;
                model.TotalPoints = scaffold.TotalPoints;
                model.confirmed = scaffold.confirmed;
                if (scaffold.RegistrationDate.HasValue)
                    model.ShamsiRegistrationDate = ConvertAdToJalali(scaffold.RegistrationDate.Value);


            }
            catch (Exception ex)
            {
                /// لاگ خطا

                LogException.Write(ex, "GetSafetyTagByScaffoldIdMethodInScaffoldingController");



            }

            return PartialView("ShowSafetyTag", model);

        }

        [HttpPost]
        public ActionResult GetPersonnelByScaffoldId(int id)
        {

            var scaffold = new Scaffolding();


            try
            {
                //scaffold = _scaffoldingService.GetById(id);

                var workorder = _workorderService.GetAll(scaffoldingId: id, type: WorkOrderType.Installation);
                if (workorder.Count > 0)
                    scaffold.WorkOrderId = scaffold.WorkOrderId = workorder.FirstOrDefault().Id;

            }
            catch (Exception ex)
            {
                /// لاگ خطا

                LogException.Write(ex, "GetPersonnelByScaffoldIdMethodInScaffoldingController");



            }

            return PartialView("ShowPersonnel", scaffold);

        }
        [HttpPost]
        public ActionResult GetEquipmentByScaffoldId(int id)
        {


            try
            {
                ShowEquipments equipments = new ShowEquipments();
                var outPutMaterial = _outputMaterialService.GetAll(model => model.ScaffoldingId == id).FirstOrDefault();
                if (outPutMaterial != null)
                {
                    List<OutputHasEquipmentModel> outPutList = new List<OutputHasEquipmentModel>();
                    var outPutHasEquip = _outMaterialHasEquiService.GetAllById(outPutMaterial.Id);
                    foreach (var item in outPutHasEquip)
                    {
                        var outPutEquip = new OutputHasEquipmentModel();
                        outPutEquip.Title = _equipmentService.GetById(item.EquipmentId).Title;
                        outPutEquip.Count = item.Count;
                        outPutEquip.ExitDate = ConvertAdToJalaliDateTime((DateTime)outPutMaterial.Date);
                        outPutList.Add(outPutEquip);
                    }
                    equipments.OutOutMaterial = outPutList;
                }
                var inPutMaterial = _inputMaterialService.GetAll(model => model.ScaffoldingId == id).FirstOrDefault();
                if (inPutMaterial != null)
                {
                    List<InputHasEquipmentModel> inPutList = new List<InputHasEquipmentModel>();

                    var inPutHasEquip = _inputMaterialHasEquipmentService.GetAllById(inPutMaterial.Id);
                    foreach (var item in inPutHasEquip)
                    {
                        var inPutEquip = new InputHasEquipmentModel();
                        inPutEquip.Title = _equipmentService.GetById(item.EquipmentId).Title;
                        inPutEquip.Count = item.Count;
                        inPutEquip.HealthyNumber = item.HealthyNumber;
                        inPutEquip.MissingNumber = item.MissingNumber;
                        inPutEquip.DefectiveNumber = item.DefectiveNumber;
                        inPutEquip.EntryDate = ConvertAdToJalaliDateTime((DateTime)inPutMaterial.Date);
                        inPutList.Add(inPutEquip);
                    }
                    equipments.InPutMaterial = inPutList;
                }
                return PartialView("ShowEquipment", equipments);

            }
            catch (Exception ex)
            {
                /// لاگ خطا

                LogException.Write(ex, "GetEquipmentByScaffoldIdMethodInScaffoldingController");

            }
            return PartialView();


        }

        [HttpGet]
        public JsonResult PersonnelList(DataTableRequest request, [ModelBinder(typeof(DataTableModelBinder))]DataTableRequestFilter filter, int workorderId = 0)

        {
            if (request.length == -1)
            {
                request.length = int.MaxValue;
            }
            var data = _workorderAssignedUsers.FilterData(request.start, request.length, filter.Search, filter.SortColumn, filter.SortDirection, 0, workorderId);


            var gridModel = new DataTableResponse<WorkorderAssignedUsersModel>()
            {
                data = data.Select(x =>
                {

                    var m = new WorkorderAssignedUsersModel();
                    m.PersonnelCode = x.PersonnelCode;
                    m.NameFamily = x.Personnel.UserNameFmaily;
                    m.Area = x.Area;
                    m.WorkorderTitle = _workorderService.GetById(x.WorkorderId).Title;
                    m.WorkgroupTitle = x.WorkgroupId != 0 ? _workgroupService.GetById(x.WorkgroupId).Title : "";
                    m.Id = x.Id;
                    return m;
                }).ToList(),
                recordsTotal = _workorderAssignedUsers.Count(0, workorderId),
                recordsFiltered = _workorderAssignedUsers.Count(0, workorderId),
                draw = request.draw
            };



            return Json(gridModel, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult EquipmentList(DataTableRequest request, [ModelBinder(typeof(DataTableModelBinder))]DataTableRequestFilter filter, int workorderId = 0)

        {
            if (request.length == -1)
            {
                request.length = int.MaxValue;
            }
            var data = _outputMaterialService.FilterData(request.start, request.length, filter.Search, filter.SortColumn, filter.SortDirection, workorderId);


            var gridModel = new DataTableResponse<OutputMaterialModel>()
            {
                data = data.Select(x =>
                {

                    var m = new OutputMaterialModel();
                    m.EquipmentName = _equipmentService.GetById(x.EquipmentId).Title;
                    //m.Count = x.Count;
                    m.ShamsiDate = ConvertAdToJalali(x.Date.Value);
                    if (_workorderService.GetById(x.WorkOrderId) != null)
                        m.WorkOrderTitle = _workorderService.GetById(x.WorkOrderId).Title;

                    if (_inputMaterialService.GetAll(models => models.Id == x.Id).Count() > 0)
                    {
                        var getInput = _inputMaterialService.GetAll(models => models.Id == x.Id).FirstOrDefault();
                        //m.InputMaterialModel.Count = getInput.Count;
                        m.InputMaterialModel.ShamsiDate = ConvertAdToJalali(getInput.Date.Value);
                        //m.InputMaterialModel.DefectiveNumber = getInput.DefectiveNumber;
                        m.InputMaterialModel.HealthyNumber = getInput.HealthyNumber;
                        m.InputMaterialModel.MissingNumber = getInput.MissingNumber;
                    }

                    m.Id = x.Id;
                    return m;
                }).ToList(),
                recordsTotal = _workorderAssignedUsers.Count(0, workorderId),
                recordsFiltered = _workorderAssignedUsers.Count(0, workorderId),
                draw = request.draw
            };



            return Json(gridModel, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CreateFormPrint(int workorderId = 0)
        {
            var getWorkorder = _workorderService.GetById(workorderId);
            var model = new ScaffoldModel();
            model.WorkOrderModel.Title = getWorkorder.Title;
            model.WorkOrderModel.Tag = getWorkorder.Tag;
            model.WorkOrderModel.ShamsiDate = ConvertAdToJalali(getWorkorder.Date);
            model.WorkOrderModel.CompanyName = _companyService.GetById(getWorkorder.CompanyId).Title;

            if (getWorkorder.UnitId.HasValue)
                model.WorkOrderModel.UnitName = _companyService.GetById(getWorkorder.UnitId.Value).Title;

            if (getWorkorder.SectionId.HasValue)
                model.WorkOrderModel.SectionName = _companyService.GetById(getWorkorder.SectionId.Value).Title;

            return new ViewAsPdf("_CreateFormPrint", model);

        }
        [HttpPost]
        public ActionResult CreateForm(int scaffoldingId = 0)
        {
            var model = new ScaffoldModel();
            string viewName = "";

            if (scaffoldingId != 0)

            {
                var getScaffold = _scaffoldingService.GetById(scaffoldingId);
                var getScaffoldType = _scaffoldTypeService.GetById(getScaffold.ScaffoldTypeId);

                var equipments = _equipmentService.GetAll();

                var systemNameList = new List<string>() { "fourFoot", "fiveFeet", "sixFeet", "eightFeet", "tenFeet", "TwelveFeet", "fourteenFeet", "SixteenFeet", "EighteenFeet", "twentyFeet" };
                var baseList = new List<string>() { "baseFour", "baseThree", "baseTwo", "baseOne", "baseHalf" };
                var keshabi = new List<string>() { "keshabiThree", "keshabitwoHalf", "keshabiOneThirty", "keshabiOne", "keshabiSeventyFive" };
                var plate = new List<string>() { "plateThree", "plateTwoHalf", "plateOneThirty", "plateOne", "plateSeventyFive" };

                foreach (var systemName in systemNameList)
                {

                    foreach (var equipment in equipments)
                    {
                        if (equipment.SystemName != null)
                        {
                            if (equipment.SystemName == systemName)
                            {
                                model.EquipmentList.Add(_stockService.GetById(equipment.Id) != null ? _stockService.GetById(equipment.Id).StockReady : 0);
                            }
                        }

                    }

                }
                foreach (var basename in baseList)
                {

                    foreach (var equipment in equipments)
                    {
                        if (equipment.SystemName != null)
                        {
                            if (equipment.SystemName == basename)
                            {
                                model.BaseEquipmentList.Add(_stockService.GetById(equipment.Id) != null ? _stockService.GetById(equipment.Id).StockReady : 0);
                            }
                        }

                    }

                }

                foreach (var keshabiname in keshabi)
                {

                    foreach (var equipment in equipments)
                    {
                        if (equipment.SystemName != null)
                        {
                            if (equipment.SystemName == keshabiname)
                            {
                                model.KeshabiEquipmentList.Add(_stockService.GetById(equipment.Id) != null ? _stockService.GetById(equipment.Id).StockReady : 0);
                            }
                        }

                    }

                }
                foreach (var platename in plate)
                {
                    // لیست متریال هارو میگیره 

                    foreach (var equipment in equipments)
                    {
                        // لیست کلی رو میگیره
                        if (equipment.SystemName != null)
                        {
                            // اگر متریال جزئی از لیست باشه به لیست اضافه میشه اگر نباشه میره بالا  بحث اینه چرا دوباره تکرار کرده 
                            if (equipment.SystemName == platename)
                            {
                                model.PlateEquipmentList.Add(_stockService.GetById(equipment.Id) != null ? _stockService.GetById(equipment.Id).StockReady : 0);
                            }
                        }

                    }

                }
                if (getScaffoldType.SystemName.Contains("SingleWallIndependentBlockingScaffold"))
                {
                    viewName = "_CreateFormSingleWall";
                }
                else if (getScaffoldType.SystemName.Contains("IndependentAngularScaffolding"))
                {
                    viewName = "_CreateFormAngularWall";
                }
                else if (getScaffoldType.SystemName.Contains("PolyScaffolding"))
                {
                    viewName = "_CreateFormPolyScaffolding";
                }
                else if (getScaffoldType.SystemName.Contains("MovableScaffold"))
                {
                    viewName = "_CreateFormMovableScaffold";
                }
                else if (getScaffoldType.SystemName.Contains("CylinderTankScaffold"))
                {
                    viewName = "_CreateFormCylinderTank";
                }
                else if (getScaffoldType.SystemName.Contains("SphericalTankScaffold"))
                {
                    viewName = "_CreateFormCircularTank";
                }
                else if (getScaffoldType.SystemName.Contains("CageScaffold"))
                {
                    viewName = "_CreateFormCageScaffold";
                }

                model.ScaffoldTypeId = getScaffold.ScaffoldTypeId;
                model.BuildingId = getScaffold.BuildingId;
                model.EarthId = getScaffold.EarthId;
                model.Height = getScaffold.Height;
                model.Width = getScaffold.Width;
                model.Title = getScaffold.Title;
                model.Length = getScaffold.Length;
                model.Id = scaffoldingId;

                GetWorkOrderInfo(model, getScaffold);

            }


            return PartialView(viewName, model);

        }
        [HttpPost]
        public JsonResult GetWorkOrderByCompanyID(int companyID)

        {
            var model = new ScaffoldModel();

            ///بدست آوردن درستور ک 
            PrepareAllWorkOrderModel(model, companyID);

            return Json(model.WorkOrders);
        }
        [HttpPost]
        public JsonResult GetCompaniesByParentId(int parentId)

        {
            var model = new ScaffoldModel();


            PrepareAllCompaniesModel(model, parentId);

            return Json(model.Companies);
        }

        [HttpPost]
        public JsonResult ExtendedDateScaffold(int scaffoldId, bool extendedExpiryDate)
        {
            var result = new ReturnAjaxForm();
            var scaffold = _scaffoldingService.GetById(scaffoldId);

            if (scaffold != null)
            {
                try
                {
                    if (extendedExpiryDate)
                    {
                        if (scaffold.ExpireDate.HasValue)
                        {
                            if (scaffold.ExpireDate.Value.Date < DateTime.Now.Date)
                                scaffold.ExpireDate = DateTime.Now;
                            scaffold.ExpireDate = scaffold.ExpireDate.Value.AddDays(15);
                        }


                        else
                        {
                            scaffold.ExpireDate = DateTime.Now;
                            scaffold.ExpireDate = scaffold.ExpireDate.Value.AddDays(15);
                        }

                    }


                    else
                    {
                        if (scaffold.RegistrationDate.HasValue)
                        {
                            if (scaffold.RegistrationDate.Value.Date < DateTime.Now.Date)
                                scaffold.RegistrationDate = DateTime.Now;

                            scaffold.RegistrationDate = scaffold.RegistrationDate.Value.AddDays(15);
                        }

                        else

                            ShowMessageToUser(result, "در حال حاضر برای این داربست تگ ایمنی ثبت نشده است ", ResultType.Failure, scaffoldId);


                    }

                    _scaffoldingService.Update(scaffold);

                    ShowMessageToUser(result, "تمدید انقضا داربست با موفقیت انجام شد. ", ResultType.Success, scaffoldId);
                }
                catch (Exception ex)
                {

                    /// لاگ خطا

                    LogException.Write(ex, "ExtendedExpiryDateScaffoldMethodInScaffoldingController");

                    ///نمایش پیام خطا به کاربر
                    ShowMessageToUser(result, "عملیات با خطا مواجه شد. ", ResultType.Failure, scaffoldId);
                }



            }

            else
            {

                ShowMessageToUser(result, "داربست حذف شده است. ", ResultType.Warning, scaffoldId);

            }


            return Json(result);
        }



        #endregion

        #region Chart

        public ActionResult CreateSingleWallChart(ChartModel model)
        {
            return View("SingleWallChart", model);
        }
        public ActionResult CreateAngularWallChart(ChartModel model)
        {
            return View("AngularWallChart", model);
        }
        public ActionResult CreateMovableChart(ChartModel model)
        {
            return View("MovableChart", model);
        }
        public ActionResult CreateCageChart(ChartModel model)
        {
            return View("CageChart", model);
        }
        public ActionResult CreatePolyChart(ChartModel model)
        {
            return View("PolyChart", model);
        }
        public ActionResult CreateCylinderTankChart(ChartModel model)
        {
            return View("CylinderTankChart", model);
        }
        public ActionResult CreateCircularTankChart(ChartModel model)
        {
            return View("CircularTankChart", model);
        }
        public ActionResult CreateFormSingleWall()
        {
            var model = new ScaffoldModel();
            return PartialView("_CreateFormSingleWall", model);
        }
        public ActionResult Help()
        {
            return View();
        }

        #endregion
        #region Report
        [HttpPost]
        public ActionResult Report(WorkOrderModel model)
        {
            ModelState.Remove(nameof(model.Title));
            ModelState.Remove(nameof(model.Tag));
            ModelState.Remove(nameof(model.Date));
            ModelState.Remove(nameof(model.ExpireDate));
            ModelState.Remove(nameof(model.TypeId));
            ModelState.Remove(nameof(model.Status));
            ModelState.Remove(nameof(model.PriorityId));
            ModelState.Remove(nameof(model.CompanyId));

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
            WorkOrderModel model = (WorkOrderModel)Session["filter"];
            return View();
        }
        public virtual ActionResult StiReport()
        {
            WorkOrderModel model = (WorkOrderModel)Session["filter"];


            // ایجاد شی جدید
            var mainReport = new Stimulsoft.Report.StiReport();
            try
            {
                mainReport["@priority"] = model.PriorityId == WorkOrderPriority.Unassigned ? null : model.PriorityId;
                mainReport["@type"] = model.TypeId == WorkOrderType.Unassigned ? null : model.TypeId;
                mainReport["@companyId"] = model.CompanyId == 0 ? null : model.CompanyId;
                mainReport["@status"] = model.Status == WorkOrderStatus.Select ? null : model.Status;
                mainReport["@title"] = model.TitleSearch;
                mainReport["@tag"] = model.TagSearch;
                mainReport["@date"] = model.FromDate;
                mainReport["@toDate"] = model.ToDate;
                mainReport["@expireDate"] = model.FromExpireDate;
                mainReport["@toExpireDate"] = model.ToExpireDate;
            }
            catch (Exception)
            {

                mainReport["@priority"] = null;
                mainReport["@type"] = null;
                mainReport["@companyId"] = null;
                mainReport["@status"] = null;
                mainReport["@title"] = null;
                mainReport["@tag"] = null;
                mainReport["@date"] = null;
                mainReport["@toDate"] = null;
                mainReport["@expireDate"] = null;
                mainReport["@toExpireDate"] = null;

            }

            // فراخوانی فایل استیمول
            mainReport.Load(Server.MapPath("~/ReportFiles/WorkorderReportFilter.mrt"));
            // 
            mainReport.Compile();

            //if (model.FromDate.HasValue)
            //    mainReport["FromDate"] = ConvertAdToJalali(model.FromDate.Value);
            //if (model.ToDate.HasValue)
            //    mainReport["ToDate"] = ConvertAdToJalali(model.ToDate.Value);
            //mainReport["DateAndTime"] = ConvertAdToJalaliDateTime(DateTime.Now);
            //mainReport["PersonelId"] =model.IDPersonel;
            //mainReport["AgencyId"] = _agencyService.GetById(model.AgencyId).IDAgent;
            //mainReport["MelliCode"] = model.MelliCode;

            return Stimulsoft.Report.Mvc.StiMvcViewer.GetReportSnapshotResult(mainReport);
        }
        public virtual ActionResult ViewerEvent()
        {
            return Stimulsoft.Report.Mvc.StiMvcViewer.ViewerEventResult(HttpContext);
        }

        #endregion

    }
}