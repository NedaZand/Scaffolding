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
using Store.Service.Stores;
using Store.Core.Domain.StoreTables;
using Store.Service;
using Store.Essential.Model;
using Store.Core.Domain.StoreTables.StoreRoom;
using Store.Models.Stores.StoreRoom;
using Store.Core.Domain.StoreTables.Work;
using System.Collections.Generic;

namespace Store.Controllers
{
    [Authorize]
    public class OutputMaterialController : BaseController
    {
        #region Fields

        private readonly IWorkOrderService _workorderService;
        private readonly IEquipmentService _equipmentService;
        private readonly IOutputMaterialService _outputMaterialService;
        private readonly IStockService _stockService;
        private readonly ICheckingRole _checkingRoleService;
        private readonly IAssignedWorkorderService _assignedWorkorderService;
        private readonly IAssignedWorkorderDetailService _assignedWorkorderDetailService;
        private readonly IUserService _userService;
        private readonly IStockService _stockservice;
        private readonly ICompanyService _companyService;
        private readonly IScaffoldingService _scaffoldingService;
        private readonly IOutputMaterialHasEquipmentService _outputHasequipService;
        #endregion
        #region Ctor

        public OutputMaterialController(IScaffoldingService scaffoldingService,
            ICompanyService companyService,
            IAssignedWorkorderDetailService assignedWorkorderDetailService,
            IAssignedWorkorderService assignedWorkorderService,
            IStockService stockService, IStockService stockservice,
            IOutputMaterialService outputMaterialService,
            IEquipmentService equipmentService,
            IWorkOrderService workorderService,
            ICheckingRole checkingRoleService,
            IUserService userService,
            IOutputMaterialHasEquipmentService outputHasequip)
        {
            _workorderService = workorderService;
            _checkingRoleService = checkingRoleService;
            _equipmentService = equipmentService;
            _userService = userService;
            _outputMaterialService = outputMaterialService;
            _stockService = stockService;
            _stockservice = stockService;
            _assignedWorkorderService = assignedWorkorderService;
            _companyService = companyService;
            _scaffoldingService = scaffoldingService;
            _assignedWorkorderDetailService = assignedWorkorderDetailService;
            _outputHasequipService = outputHasequip;
        }
        #endregion
        #region Utilities
        [NonAction]
        protected virtual void PrepareAllCompaniesModel(OutputMaterialModel model, int? parentId = null)
        {
            if (model == null)
                throw new ArgumentNullException("model");

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

        [NonAction]
        protected virtual void PrepareAllWorkOrderModel(OutputMaterialModel model, int? companyID = null)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            var Companies = new List<Company>();
            var statuses = new List<WorkOrderStatus>();

            statuses.Add(WorkOrderStatus.InProcess);
            statuses.Add(WorkOrderStatus.Unassigned);

            model.WorkOrderList.Add(new SelectListItem
            {
                Text = "انتخاب دستور کار",
                Value = " "
            });

            Companies = _companyService.GetAllCompaniesByParentCompanyId(companyID);
            if (companyID.HasValue)
                Companies.Add(_companyService.GetById(companyID.Value));


            var works = _workorderService.GetAll(companies: Companies, type: WorkOrderType.Installation).Where(x => x.ScaffoldingId.HasValue);
            works = works.Where(d => d.Scaffolding.ScaffoldStates == Core.Domain.StoreTables.StoreRoom.ScaffoldStates.Submited).ToList();
            foreach (var c in works)
            {
                model.WorkOrderList.Add(new SelectListItem
                {
                    Text = c.Title,
                    Value = c.Id.ToString()
                });
            }


        }

        [NonAction]
        protected virtual void PrepareAllEquipmentsModel(OutputMaterialModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            //model.EquipmentList.Add(new SelectListItem
            //{
            //    Text = "انتخاب تجهیزات ",
            //    Value = " ",
            //    Selected = true
            //});

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
        public ActionResult Index()
        {
            var model = new OutputMaterialModel();

            if (!_checkingRoleService.HasAccess(PermissionList.OutputMaterialList, CurrentUser.GetCurrentUser))
            {
                return View("Inaccessibility");
            }

            ///آماده سازی دستور کار ها
            // PrepareAllWorkOrderModel(model);
            //model.SearchModel.CompanyList = model.CompanyList;

            ///آماده سازی تجهیزات
            //PrepareAllEquipmentsModel(model);
            //model.SearchModel.EquipmentList = model.EquipmentList;


            return View(model);
        }
        public ActionResult Create()
        {
            var model = new OutputMaterialModel();

            if (!_checkingRoleService.HasAccess(PermissionList.OutputMaterialCreate, CurrentUser.GetCurrentUser))
            {

                return View("Inaccessibility");
            }

            ///بدست آوردن زیر مجموعه های شرکت
            PrepareAllCompaniesModel(model);
            /////آماده سازی دستورکار ها
            //PrepareAllWorkordersModel(model);
            ///آماده سازی تجهیزات
            PrepareAllEquipmentsModel(model);

            return View(model);
        }
        [HttpPost]
        public ActionResult Create(OutputMaterialModel model)
        {
            var result = new ReturnAjaxForm();


            if (model.Id2 == " ")
                ModelState.AddModelError("WorkOrderId", " دستور کار الزامی است");


            if (model.Count == null)
                ModelState.AddModelError("Count", " تعداد الزامی است");
            else
            {
                foreach (var item in model.Count)
                {
                    if (item == 0)
                    {
                        ModelState.AddModelError("Count", " وارد کردن تعداد الزامی است");
                        break;
                    }
                }
            }
            if (model.EquipmentId == null)
                ModelState.AddModelError("Count", " انتخاب تجهیزات الزامی است");


            if (ModelState.IsValid)
            {
                try
                {
                    //string[] ids = model.Id2.Split(',');
                    // model.AssignedWorkorderId = Convert.ToInt32(ids[0]);
                    model.WorkOrderId = model.WorkOrderId;

                    var outputMaterial = new OutputMaterial();
                    List<int> NewCount = new List<int>();
                    string NewEquimpent = "";
                    for (int equip = 0; equip < model.EquipmentId.Count; equip++)
                    {
                        var stock = _stockService.GetById(model.EquipmentId[equip]);
                        if (stock != null)
                        {
                            if (stock.StockReady < model.Count[equip])
                            {
                                var equipTitle = _equipmentService.GetById(model.EquipmentId[equip]).Title;
                                if (NewEquimpent == "")
                                    NewEquimpent = " موجودی " + (equipTitle) + " کافی نیست. ";
                                else
                                    NewEquimpent += " موجودی " + (equipTitle) + " کافی نیست. ";
                            }

                        }
                        else
                        {
                            var equipTitle = _equipmentService.GetById(model.EquipmentId[equip]).Title;
                            if (NewEquimpent == "")
                                NewEquimpent = " موجودی " + (equipTitle) + " کافی نیست. ";
                            else
                                NewEquimpent += " موجودی " + (equipTitle) + " کافی نیست. ";
                        }
                    }
                    if (NewEquimpent != "") // موجودی کافی نیست
                    {
                        ShowMessageToUser(result, NewEquimpent, ResultType.Failure);
                        return Json(result);

                    }
                    outputMaterial.Count = model.Count[0];
                    outputMaterial.Date = model.Date;
                    outputMaterial.WorkOrderId = model.WorkOrderId;
                    outputMaterial.ScaffoldingId = _workorderService.GetById(model.WorkOrderId).ScaffoldingId.Value;
                    //outputMaterial.WorkorderId = model.AssignedWorkorderId;
                    outputMaterial.EquipmentId = model.EquipmentId[0];
                    outputMaterial.ActionUserId = User.Identity.GetUserId();
                    ///عملیات ثبت در دیتابیس
                    if (_outputMaterialService.Insert(outputMaterial))
                    {
                        for (int equip = 0; equip < model.EquipmentId.Count; equip++)
                        {

                            var outputHasequipment = new outputMaterialHasEquipment()
                            {
                                EquipmentId = model.EquipmentId[equip],
                                OutputMaterialId = outputMaterial.Id,
                                Count = model.Count[equip],
                                ActionUserId = User.Identity.GetUserId()
                            };
                            if (!_outputHasequipService.Insert(outputHasequipment))
                            {
                                ShowMessageToUser(result, "عملیات با خطا مواجه شد.", ResultType.Failure);
                                return Json(result);
                            }
                            
                        }
                        ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر
                        var scaffold = _scaffoldingService.GetById(outputMaterial.ScaffoldingId);
                        if (scaffold == null)
                        {
                            ShowMessageToUser(result, "فراخوانی داربست انتخاب شده جهت تغییر وضعیت پیگیری، با خطا مواجه شد.", ResultType.Failure);
                            return Json(result);
                        }
                        scaffold.ScaffoldStates = ScaffoldStates.Material;
                        _scaffoldingService.Update(scaffold);

                    }
                    else
                    {
                        ShowMessageToUser(result, "عملیات با خطا مواجه شد.", ResultType.Failure);
                    }

                }
                catch (Exception ex)
                {
                    /// لاگ خطا

                    LogException.Write(ex, "CreateMethodInOutputMaterialController");

                    ///نمایش پیام خطا به کاربر

                    if (ex.InnerException.InnerException != null && ex.InnerException.InnerException.Message.Contains("duplicate key"))
                        ShowMessageToUser(result, " برای این تجهیز قبلا خروجی ثبت شده است در صورت نیاز اقدام به ویرایش نمایید ", ResultType.Failure);
                    else

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

            var model = new OutputMaterialModel();

            if (!_checkingRoleService.HasAccess(PermissionList.OutputMaterialEdit, CurrentUser.GetCurrentUser))
            {
                return PartialView("_Inaccessibility");
            }

            ///آماده سازی دستورکار ها
            //PrepareAllWorkOrderModel(model);
            ///آماده سازی تجهیزات

            var outputMaterial = _outputMaterialService.GetById(id);
            var outPutHasEquipment = _outputHasequipService.GetAllById(outputMaterial.Id);
            PrepareAllEquipmentsModel(model);

            for (int i = 0; i < outPutHasEquipment.Count; i++)
            {
                model.Count.Add(outPutHasEquipment[i].Count);
                model.EquipmentId.Add(outPutHasEquipment[i].EquipmentId);
            }
            model.Date = outputMaterial.Date;
            //model.Id2 = $"{outputMaterial.WorkorderId.ToString()} ,{outputMaterial.WorkOrderId.ToString()}";
            model.Id = outputMaterial.Id;
            model.WorkOrderId = outputMaterial.WorkOrderId;

            return View(model);
        }

        [HttpGet]
        public ActionResult ShowEquipments(int id)
        {



            var outputMaterial = _outputHasequipService.GetAllById(id);

            List<OutputHasEquipmentModel> list = new List<OutputHasEquipmentModel>();
            foreach (var item in outputMaterial)
            {
                var model = new OutputHasEquipmentModel();
                model.Id = item.Id;
                model.ActionUserName = item.ActionUserId != null ? _userService.GetById(item.ActionUserId).UserName : "";
                model.ShamsiCreateDate = item.CreatedDate.HasValue ? ConvertAdToJalaliDateTime(item.CreatedDate.Value) : "";
                model.EditUserName = item.LastActionUserId != null ? _userService.GetById(item.LastActionUserId).UserName : "";
                model.ShamsiEditDate = item.ModifiedDate.HasValue ? ConvertAdToJalaliDateTime(item.ModifiedDate.Value) : "";
                model.Count = item.Count;
                model.Title = _equipmentService.GetById(item.EquipmentId).Title;
                var ExitDate = _outputMaterialService.GetById(item.OutputMaterialId).Date;
                model.ExitDate = ExitDate.HasValue ? ConvertAdToJalali((DateTime)ExitDate.Value) : "";
                list.Add(model);
            }

            return PartialView(list);
        }

        [HttpPost]
        public ActionResult Edit(OutputMaterialModel model)
        {
            var result = new ReturnAjaxForm();

            if (model.Count == null)
                ModelState.AddModelError("Count", " تعداد الزامی است");

            if (model.EquipmentId == null)
                ModelState.AddModelError("Count", " انتخاب تجهیزات الزامی است");


            if (ModelState.IsValid)
            {
                try
                {

                    List<int> NewCount = new List<int>();
                    string NewEquimpent = "";
                    for (int equip = 0; equip < model.EquipmentId.Count; equip++)
                    {
                        var stock = _stockService.GetById(model.EquipmentId[equip]);
                        if (stock != null)
                        {
                            if (stock.StockReady < model.Count[equip])
                            {
                                var equipTitle = _equipmentService.GetById(model.EquipmentId[equip]).Title;
                                if (NewEquimpent == "")
                                    NewEquimpent = " موجودی " + (equipTitle) + " کافی نیست. ";
                                else
                                    NewEquimpent += " موجودی " + (equipTitle) + " کافی نیست. ";
                            }

                        }
                        else
                        {
                            var equipTitle = _equipmentService.GetById(model.EquipmentId[equip]).Title;
                            if (NewEquimpent == "")
                                NewEquimpent = " موجودی " + (equipTitle) + " کافی نیست. ";
                            else
                                NewEquimpent += " موجودی " + (equipTitle) + " کافی نیست. ";
                        }
                    }
                    if (NewEquimpent != "") // موجودی کافی نیست
                    {
                        ShowMessageToUser(result, NewEquimpent, ResultType.Failure);
                        return Json(result);

                    }

                    var outputMaterial = _outputMaterialService.GetById(model.Id);

                    outputMaterial.Date = model.Date;
                    outputMaterial.LastActionUserId = User.Identity.GetUserId();
                    ///عملیات ثبت در دیتابیس
                    if (_outputMaterialService.Update(outputMaterial))
                    {
                        var outputHasEquip = _outputHasequipService.GetAllById(outputMaterial.Id);

                        foreach (var item in outputHasEquip)
                        {
                            _outputHasequipService.Remove(item); // ابتدا تمامی رکورد های تجهیزات و تعداد تجهیزات برای خروجی انبار جاری حذف می شوند
                        }

                        for (int equip = 0; equip < model.EquipmentId.Count; equip++)
                        {

                            var outputHasequipment = new outputMaterialHasEquipment()
                            {
                                EquipmentId = model.EquipmentId[equip],
                                OutputMaterialId = outputMaterial.Id,
                                Count = model.Count[equip],
                                ActionUserId = User.Identity.GetUserId()
                            };
                            if (_outputHasequipService.Insert(outputHasequipment))
                            {
                                ShowMessageToUser(result, "با موفقیت ویرایش شد", ResultType.Success);
                            }
                            else
                                ShowMessageToUser(result, "عملیات با خطا مواجه شد.", ResultType.Failure);
                        }

                    }
                    else
                    {
                        ShowMessageToUser(result, "عملیات با خطا مواجه شد.", ResultType.Failure);
                    }

                }
                catch (Exception ex)
                {
                    /// لاگ خطا

                    LogException.Write(ex, "CreateMethodInOutputMaterialController");

                    ///نمایش پیام خطا به کاربر

                    if (ex.InnerException.InnerException != null && ex.InnerException.InnerException.Message.Contains("duplicate key"))
                        ShowMessageToUser(result, " برای این تجهیز قبلا خروجی ثبت شده است در صورت نیاز اقدام به ویرایش نمایید ", ResultType.Failure);
                    else

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
        public JsonResult List(DataTableRequest request, [ModelBinder(typeof(DataTableModelBinder))]DataTableRequestFilter filter)

        {
            if (request.length == -1)
            {
                request.length = int.MaxValue;
            }
            var data = _outputMaterialService.FilterData(request.start, request.length, filter.Search, filter.SortColumn, filter.SortDirection);


            var gridModel = new DataTableResponse<OutputMaterialModel>()
            {
                data = data.Select(x =>
                {

                    var m = new OutputMaterialModel();
                    m.WorkOrderTitle = _workorderService.GetById(x.WorkOrderId).Title;
                    m.ShamsiDate = ConvertAdToJalali(x.Date.Value);
                    m.ShamsiCreateDate = ConvertAdToJalaliDateTime(x.CreatedDate.Value);
                    m.ActionUserName = _userService.GetById(x.ActionUserId).UserName;
                    if (x.ModifiedDate.HasValue)
                        m.ShamsiCreateDate = ConvertAdToJalaliDateTime(x.ModifiedDate.Value);
                    if (x.LastActionUserId != null)
                        m.EditUserName = _userService.GetById(x.ActionUserId).UserName;

                    m.Id = x.Id;

                    if (x.ModifiedDate != null)
                    {
                        m.ShamsiEditDate = ConvertAdToJalaliDateTime(x.ModifiedDate.Value);
                    }


                    return m;
                }).ToList(),
                recordsTotal = _outputMaterialService.Count(),
                recordsFiltered = _outputMaterialService.Count(),
                draw = request.draw
            };



            return Json(gridModel, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var result = new ReturnAjaxForm();

            if (!_checkingRoleService.HasAccess(PermissionList.OutputMaterialDelete, CurrentUser.GetCurrentUser))
            {
                ///نمایش پیام عدم دسترسی  به کاربر

                ShowMessageToUser(result, "کاربر گرامی،شما  مجوز حذف رکورد را ندارید! ", ResultType.NotAllow);


                return Json(result, JsonRequestBehavior.AllowGet);
            }

            try
            {
                var entity = _outputMaterialService.GetById(id);
                
                var outputHasEquip = _outputHasequipService.GetAllById(entity.Id);
                foreach (var item in outputHasEquip)
                {
                    _outputHasequipService.Remove(item);
                }

                _outputMaterialService.Remove(entity);
                ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                ShowMessageToUser(result, "با موفقیت حذف شد", ResultType.Success);

            }
            catch (Exception ex)
            {
                /// لاگ خطا

                LogException.Write(ex, "DeleteMethodInOutputMaterialController");

                ///نمایش پیام خطا به کاربر

                ShowMessageToUser(result, "امکان حذف  رکورد وجود ندارد.", ResultType.Failure);
            }

            return Json(result);

        }
        [HttpPost]
        public JsonResult GetWorkOrderByCompanyID(int companyID)

        {
            var model = new OutputMaterialModel();

            ///بدست آوردن درستور ک 
            PrepareAllWorkOrderModel(model, companyID);

            return Json(model.WorkOrderList);
        }
        [HttpPost]
        public JsonResult GetCompaniesByParentId(int parentId)

        {
            var model = new OutputMaterialModel();


            PrepareAllCompaniesModel(model, parentId);

            return Json(model.Companies);
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