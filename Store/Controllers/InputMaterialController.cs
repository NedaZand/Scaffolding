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
using Store.WebEssential.Helper;
using Store.Service;
using Store.Essential.Model;
using Store.Core.Domain.StoreTables.StoreRoom;
using Store.Models.Stores.StoreRoom;
using Store.Core.Domain.StoreTables.Work;
using System.Collections.Generic;

namespace Store.Controllers
{
    [Authorize]
    public class InputMaterialController : BaseController
    {
        #region Fields

        private readonly IWorkOrderService _workorderService;
        private readonly IEquipmentService _equipmentService;
        private readonly IInputMaterialService _inputMaterialService;
        private readonly InputMaterialHasEquipmentService _inputMaterialHasEquipmentService;
        private readonly IOutputMaterialService _outputMaterialService;
        private readonly IOutputMaterialHasEquipmentService _outputMaterialHasEquipService;
        private readonly IStockService _stockService;
        private readonly ICheckingRole _checkingRoleService;
        private readonly IUserService _userService;
        private readonly ICompanyService _companyService;
        private readonly IAssignedWorkorderService _assignedWorkorderService;
        private readonly IScaffoldingService _scaffoldingService;
        #endregion
        #region Ctor

        public InputMaterialController(ICompanyService companyService,
            IAssignedWorkorderService assignedWorkorderService,
            IScaffoldingService scaffoldingService,
            IStockService stockService,
            IOutputMaterialService outputMaterialService,
            IOutputMaterialHasEquipmentService outputMaterialHasEquipService,
            InputMaterialHasEquipmentService inputMaterialHasEquipmentService,
            IInputMaterialService inputMaterialService,
            IEquipmentService equipmentService,
            IWorkOrderService workorderService,
            ICheckingRole checkingRoleService,
            IUserService userService)
        {
            _workorderService = workorderService;
            _checkingRoleService = checkingRoleService;
            _equipmentService = equipmentService;
            _userService = userService;
            _inputMaterialService = inputMaterialService;
            _stockService = stockService;
            _outputMaterialService = outputMaterialService;
            _scaffoldingService = scaffoldingService;
            _companyService = companyService;
            _outputMaterialHasEquipService = outputMaterialHasEquipService;
            _assignedWorkorderService = assignedWorkorderService;
            _inputMaterialHasEquipmentService = inputMaterialHasEquipmentService;
        }
        #endregion
        #region Utilities
        [NonAction]
        protected virtual void PrepareAllCompaniesModel(InputMaterialModel model, int? parentId = null)
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
        //[NonAction]
        //protected virtual void PrepareAllWorkordersModel(InputMaterialModel model)
        //{
        //    if (model == null)
        //        throw new ArgumentNullException("model");

        //    model.WorkOrderList.Add(new SelectListItem
        //    {
        //        Text = "انتخاب دستور کار  ",
        //        Value = " ",
        //        Selected = true
        //    });


        //    var workorders = _outputMaterialService.GetAll();

        //    foreach (var c in workorders)
        //    {
        //        model.WorkOrderList.Add(new SelectListItem
        //        {
        //            Text = _workorderService.GetById(c.WorkOrderId).Title,
        //            Value = c.WorkOrderId.ToString()
        //        });
        //    }
        //}

        [NonAction]
        protected virtual void PrepareAllWorkOrderModel(InputMaterialModel model, int? companyID = null)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            var Companies = new List<Company>();

            model.WorkOrderList.Add(new SelectListItem
            {
                Text = "انتخاب دستور کار",
                Value = " "
            });

            Companies = _companyService.GetAllCompaniesByParentCompanyId(companyID);
            if (companyID.HasValue)
                Companies.Add(_companyService.GetById(companyID.Value));


            var works = _workorderService.GetAll(companies: Companies, type: WorkOrderType.Reopening);

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
        protected virtual void PrepareAllScaffoldModel(InputMaterialModel model, int? companyID = null)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            var Companies = new List<Company>();

            model.ScaffoldList.Add(new SelectListItem
            {
                Text = "انتخاب داربست ",
                Value = " "
            });

            Companies = _companyService.GetAllCompaniesByParentCompanyId(companyID);

            if (companyID.HasValue)
                Companies.Add(_companyService.GetById(companyID.Value));


            var works = _workorderService.GetAll(companies: Companies, type: WorkOrderType.Installation).Where(x => x.ScaffoldingId.HasValue);

            foreach (var c in works)
            {

                model.ScaffoldList.Add(new SelectListItem
                {
                    Text = _scaffoldingService.GetById(c.ScaffoldingId.Value).Title,
                    Value = c.ScaffoldingId.ToString()
                });
            }


        }


        [NonAction]
        protected virtual void PrepareAllEquipmentsModel(InputMaterialModel model, int scaffoldingId = 0)
        {
            if (model == null)
                throw new ArgumentNullException("model");


            if (scaffoldingId > 0)
            {
                var outPutMaterial = _outputMaterialService.GetAll(models => models.ScaffoldingId == scaffoldingId).FirstOrDefault();
                var inPutMaterial = _inputMaterialService.GetAll(models => models.ScaffoldingId == scaffoldingId).FirstOrDefault();
                if (outPutMaterial != null)
                {
                    List<int> equipmentsInOutput = new List<int>();
                    var outputMaterials = _outputMaterialHasEquipService.GetAllById(outPutMaterial.Id).Select(d => new inputMaterialHasEquipment { EquipmentId = d.EquipmentId });
                    foreach (var item in outputMaterials)
                    {
                        equipmentsInOutput.Add(item.EquipmentId);
                    }
                    if (inPutMaterial != null)
                    {
                        var inputMaterialsHasEquipment = _inputMaterialHasEquipmentService.GetAllById(inPutMaterial.Id).Select(d => new inputMaterialHasEquipment { EquipmentId = d.EquipmentId }).ToList();
                        foreach (var item in inputMaterialsHasEquipment)
                        {
                            equipmentsInOutput.Remove(item.EquipmentId);
                        }

                    }
                    ViewData["outPutMaterialID"] = outPutMaterial.Id;

                    foreach (var equipId in equipmentsInOutput)
                    {

                        model.EquipmentList.Add(new SelectListItem
                        {
                            Text = _equipmentService.GetById(equipId).Title,
                            //Value = $"{c.Id.ToString()} ,{c.EquipmentId.ToString()}"
                            Value = equipId.ToString()
                        });
                    }
                }


            }

        }

        #endregion
        #region ActionMethod
        public ActionResult Index()
        {
            var model = new InputMaterialModel();

            if (!_checkingRoleService.HasAccess(PermissionList.InputMateriaList, CurrentUser.GetCurrentUser))
            {
                return View("Inaccessibility");
            }

            ///آماده سازی دستور کار ها
            ///PrepareAllWorkordersModel(model);
            //model.SearchModel.CompanyList = model.CompanyList;

            ///آماده سازی تجهیزات
            //PrepareAllEquipmentsModel(model);
            //model.SearchModel.EquipmentList = model.EquipmentList;

            return View(model);
        }
        public ActionResult Create()
        {
            var model = new InputMaterialModel();

            if (!_checkingRoleService.HasAccess(PermissionList.InputMaterialCreate, CurrentUser.GetCurrentUser))
            {

                return View("_Inaccessibility");
            }
            ///بدست آوردن زیر مجموعه های شرکت
            PrepareAllCompaniesModel(model);
            ///آماده سازی دستورکار ها
           // PrepareAllWorkordersModel(model);
            ///آماده سازی تجهیزات
            PrepareAllEquipmentsModel(model, 0);

            return View(model);
        }
        [HttpPost]
        public ActionResult Create(InputMaterialModel model)
        {
            var result = new ReturnAjaxForm();

            var inputMaterial = new InputMaterial();

            //if (model.Id2 == " " || model.Id2 == null)

            //    ModelState.AddModelError("Id2", " انتخاب تجهیز الزامی است");

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


            if (!model.ScaffoldingId.HasValue)
                ModelState.AddModelError("ScaffoldingId", " داربست الزامی است");

            if (model.EquipmentId == null)
                ModelState.AddModelError("ScaffoldingId", " انتخاب تجهیز الزامی است");


            if (model.DefectiveNumber == null)
                ModelState.AddModelError("Count", " تعداد الزامی است");
            else
            {
                foreach (var item in model.DefectiveNumber)
                {
                    if (item == 0)
                    {
                        ModelState.AddModelError("ScaffoldingId", " وارد کردن تعداد معیوب الزامی است");
                        break;
                    }
                }
            }

            if (ModelState.IsValid)
            {
                try
                {

                    //model.EquipmentId = Convert.ToInt32(ids[1]);

                    var getOutput = _outputMaterialService.GetById(model.OutputMaterialId);
                    var existinPutmaterial = _inputMaterialService.GetAll(d => d.ScaffoldingId == model.ScaffoldingId).FirstOrDefault();
                    inputMaterial.Count = model.Count[0];
                    inputMaterial.Date = model.Date;
                    inputMaterial.OutputMaterialId = model.OutputMaterialId;
                    inputMaterial.WorkOrderId = model.WorkOrderId;
                    inputMaterial.EquipmentId = model.EquipmentId[0];
                    inputMaterial.ScaffoldingId = getOutput.ScaffoldingId;
                    inputMaterial.ActionUserId = User.Identity.GetUserId();
                    if (existinPutmaterial == null)
                    {
                        ///عملیات ثبت در دیتابیس
                        if (_inputMaterialService.Insert(inputMaterial))
                        {
                            var outPutMaterial = _outputMaterialHasEquipService.GetAllById(model.OutputMaterialId);
                            ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر
                            for (int i = 0; i < model.EquipmentId.Count; i++)
                            {
                                var inputHasEquip = new inputMaterialHasEquipment();
                                var equipmentCount = outPutMaterial.FirstOrDefault(d => d.EquipmentId == model.EquipmentId[i]).Count;
                                inputHasEquip.InputMaterialId = inputMaterial.Id;
                                inputHasEquip.Count = model.Count[i];
                                inputHasEquip.EquipmentId = model.EquipmentId[i];
                                inputHasEquip.DefectiveNumber = model.DefectiveNumber[i];
                                inputHasEquip.HealthyNumber = model.Count[i] - model.DefectiveNumber[i];
                                inputHasEquip.MissingNumber = equipmentCount - model.Count[i];
                                inputHasEquip.ActionUserId = User.Identity.GetUserId();
                                if (!_inputMaterialHasEquipmentService.Insert(inputHasEquip, inputMaterial))
                                {
                                    ShowMessageToUser(result, "عملیات با خطا مواجه شد.", ResultType.Failure);
                                    return Json(result);
                                }
                            }
                            ShowMessageToUser(result, "با موفقیت ثبت شد", ResultType.Success);
                        }

                        else
                        {
                            ///نمایش پیام خطا  به کاربر

                            ShowMessageToUser(result, "عملیات با خطا مواجه شد.", ResultType.Failure);
                        }
                    }
                    else
                    {
                        var outPutMaterial = _outputMaterialHasEquipService.GetAllById(model.OutputMaterialId);
                        ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر
                        for (int i = 0; i < model.EquipmentId.Count; i++)
                        {
                            var inputHasEquip = new inputMaterialHasEquipment();
                            var equipmentCount = outPutMaterial.FirstOrDefault(d => d.EquipmentId == model.EquipmentId[i]).Count;
                            inputHasEquip.InputMaterialId = existinPutmaterial.Id;
                            inputHasEquip.Count = model.Count[i];
                            inputHasEquip.EquipmentId = model.EquipmentId[i];
                            inputHasEquip.DefectiveNumber = model.DefectiveNumber[i];
                            inputHasEquip.HealthyNumber = model.Count[i] - model.DefectiveNumber[i];
                            inputHasEquip.MissingNumber = equipmentCount - model.Count[i];
                            inputHasEquip.ActionUserId = User.Identity.GetUserId();
                            if (!_inputMaterialHasEquipmentService.Insert(inputHasEquip, existinPutmaterial))
                            {
                                ShowMessageToUser(result, "عملیات با خطا مواجه شد.", ResultType.Failure);
                                return Json(result);
                            }
                        }
                        ShowMessageToUser(result, "با موفقیت ثبت شد", ResultType.Success);
                    }
                    

                }
                catch (Exception ex)
                {
                    /// لاگ خطا

                    LogException.Write(ex, "EditMethodInInputMaterialController");

                    ///نمایش پیام خطا به کاربر
                    if (ex.InnerException != null && ex.InnerException.InnerException != null && ex.InnerException.InnerException.Message.Contains("duplicate key"))
                        ShowMessageToUser(result, " برای این تجهیز قبلا ورودی ثبت شده است در صورت نیاز اقدام به ویرایش نمایید ", ResultType.Failure);
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

            var model = new InputMaterialModel();

            if (!_checkingRoleService.HasAccess(PermissionList.InputMaterialEdit, CurrentUser.GetCurrentUser))
            {
                return PartialView("_Inaccessibility");
            }

            var inPutMaterial = _inputMaterialService.GetById(id);
            var iPutHasEquipment = _inputMaterialHasEquipmentService.GetAllById(inPutMaterial.Id);
            

            for (int i = 0; i < iPutHasEquipment.Count; i++)
            {
                model.Count.Add(iPutHasEquipment[i].Count);
                model.EquipmentId.Add(iPutHasEquipment[i].EquipmentId);

                model.DefectiveNumber.Add(iPutHasEquipment[i].DefectiveNumber);
            }
            foreach (var equipId in model.EquipmentId)
            {

                model.EquipmentList.Add(new SelectListItem
                {
                    Text = _equipmentService.GetById(equipId).Title,
                    Value = equipId.ToString()
                });
            }

            model.Date = (DateTime)inPutMaterial.Date;
            model.Id = inPutMaterial.Id;
            model.WorkOrderId = inPutMaterial.WorkOrderId;

            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(InputMaterialModel model)
        {
            var result = new ReturnAjaxForm();

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
                ModelState.AddModelError("EquipmentId", " انتخاب تجهیز الزامی است");


            if (model.DefectiveNumber == null)
                ModelState.AddModelError("DefectiveNumber", " تعداد الزامی است");
            else
            {
                foreach (var item in model.DefectiveNumber)
                {
                    if (item == 0)
                    {
                        ModelState.AddModelError("DefectiveNumber", " وارد کردن تعداد معیوب الزامی است");
                        break;
                    }
                }
            }



            if (ModelState.IsValid)
            {
                try
                {
                    //string[] ids = model.Id2.Split(',');
                    //model.OutputMaterialId = Convert.ToInt32(ids[0]);
                    //model.EquipmentId = Convert.ToInt32(ids[1]);

                    var inputMaterial = _inputMaterialService.GetById(model.Id);
                    var outPutMaterials = _outputMaterialService.GetAll(models => models.ScaffoldingId == inputMaterial.ScaffoldingId).FirstOrDefault();
                    var inputMaterailHasEquip = _inputMaterialHasEquipmentService.GetAllById(inputMaterial.Id);
                    inputMaterial.Date = model.Date;
                    //inputMaterial.Count = model.Count;
                    //inputMaterial.WorkOrderId = model.WorkOrderId;
                    //inputMaterial.EquipmentId = model.EquipmentId;
                    //inputMaterial.DefectiveNumber = model.DefectiveNumber;
                    //inputMaterial.HealthyNumber = model.Count - model.DefectiveNumber;
                    //inputMaterial.MissingNumber = _outputMaterialService.GetById(inputMaterial.OutputMaterialId).Count - model.Count;
                    inputMaterial.ModifiedDate = DateTime.Now;
                    inputMaterial.LastActionUserId = User.Identity.GetUserId();

                    ///عملیات ویرایش در دیتابیس

                    if (_inputMaterialService.Update(inputMaterial))
                    {
                        foreach (var item in inputMaterailHasEquip)
                        {
                            _inputMaterialHasEquipmentService.Remove(item);
                        }
                        var outPutMaterial = _outputMaterialHasEquipService.GetAllById(outPutMaterials.Id);

                        for (int i = 0; i < model.EquipmentId.Count; i++)
                        {
                            var inputHasEquip = new inputMaterialHasEquipment();
                            var equipmentCount = outPutMaterial.FirstOrDefault(d => d.EquipmentId == model.EquipmentId[i]).Count;
                            inputHasEquip.InputMaterialId = inputMaterial.Id;
                            inputHasEquip.Count = model.Count[i];
                            inputHasEquip.EquipmentId = model.EquipmentId[i];
                            inputHasEquip.DefectiveNumber = model.DefectiveNumber[i];
                            inputHasEquip.HealthyNumber = model.Count[i] - model.DefectiveNumber[i];
                            inputHasEquip.MissingNumber = equipmentCount - model.Count[i];
                            inputHasEquip.ActionUserId = User.Identity.GetUserId();
                            if (!_inputMaterialHasEquipmentService.Insert(inputHasEquip, inputMaterial))
                            {
                                ShowMessageToUser(result, "عملیات با خطا مواجه شد.", ResultType.Failure);
                                return Json(result);
                            }
                        }
                        ShowMessageToUser(result, "با موفقیت ویرایش شد", ResultType.Success);
                    }
                    else
                    {
                        ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                        ShowMessageToUser(result, "عملیات با خطا مواجه شد.", ResultType.Failure);
                    }

                }
                catch (Exception ex)
                {
                    /// لاگ خطا

                    LogException.Write(ex, "EditMethodInInputMaterialController");

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
        public JsonResult List(DataTableRequest request, [ModelBinder(typeof(DataTableModelBinder))]DataTableRequestFilter filter, BuySearchModel model)

        {
            if (request.length == -1)
            {
                request.length = int.MaxValue;
            }
            var data = _inputMaterialService.FilterData(request.start, request.length, filter.Search, filter.SortColumn, filter.SortDirection, null, null, model.EquipmentId, model.CompanyStoreRoomId, model.Price, model.BuyDate, model.ToBuyDate);


            var gridModel = new DataTableResponse<InputMaterialModel>()
            {
                data = data.Select(x =>
                {


                    var m = new InputMaterialModel();
                    //m.Count = x.Count;
                    m.EquipmentName = _equipmentService.GetById(x.EquipmentId).Title;
                    m.WorkOrderTitle = _workorderService.GetById(x.WorkOrderId).Title;
                    //m.DefectiveNumber = x.DefectiveNumber;
                    m.HealthyNumber = x.HealthyNumber;
                    m.MissingNumber = x.MissingNumber;
                    if (x.Date != null)
                        m.ShamsiDate = ConvertAdToJalali(x.Date.Value);
                    if (x.CreatedDate != null)
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
                recordsTotal = _inputMaterialService.Count(filter.Search),
                recordsFiltered = _inputMaterialService.Count(filter.Search),
                draw = request.draw
            };



            return Json(gridModel, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ShowEquipments(int id)
        {



            var inPutMaterial = _inputMaterialHasEquipmentService.GetAllById(id);

            List<InputHasEquipmentModel> list = new List<InputHasEquipmentModel>();
            foreach (var item in inPutMaterial)
            {
                var model = new InputHasEquipmentModel();
                model.Id = item.Id;
                model.ActionUserName = item.ActionUserId != null ? _userService.GetById(item.ActionUserId).UserName : "";
                model.ShamsiCreateDate = item.CreatedDate.HasValue ? ConvertAdToJalaliDateTime(item.CreatedDate.Value) : "";
                model.EditUserName = item.LastActionUserId != null ? _userService.GetById(item.LastActionUserId).UserName : "";
                model.ShamsiEditDate = item.ModifiedDate.HasValue ? ConvertAdToJalaliDateTime(item.ModifiedDate.Value) : "";
                model.Count = item.Count;
                model.MissingNumber = item.MissingNumber;
                model.HealthyNumber = item.HealthyNumber;
                model.DefectiveNumber = item.DefectiveNumber;
                model.Title = _equipmentService.GetById(item.EquipmentId).Title;
                var EntryDate = _inputMaterialService.GetById(item.InputMaterialId).Date;
                model.EntryDate = EntryDate.HasValue ? ConvertAdToJalali((DateTime)EntryDate.Value) : "";
                list.Add(model);
            }

            return PartialView(list);
        }


        [HttpPost]
        public JsonResult GetEquipmentByWorkOrderID(int scaffoldingId)

        {
            var model = new InputMaterialModel();

            ///بدست آوردن  تجهیزات 
            PrepareAllEquipmentsModel(model, scaffoldingId);
            var OutputMaterialID = (int)ViewData["outPutMaterialID"];
            return Json(new InputMaterialModel { EquipmentList = model.EquipmentList, OutputMaterialId = OutputMaterialID }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var result = new ReturnAjaxForm();

            if (!_checkingRoleService.HasAccess(PermissionList.InputMaterialDelete, CurrentUser.GetCurrentUser))
            {
                ///نمایش پیام عدم دسترسی  به کاربر

                ShowMessageToUser(result, "کاربر گرامی،شما  مجوز حذف رکورد را ندارید! ", ResultType.NotAllow);


                return Json(result, JsonRequestBehavior.AllowGet);
            }

            try
            {
                var entity = _inputMaterialService.GetById(id);

                var inPutHasEquip = _inputMaterialHasEquipmentService.GetAllById(entity.Id);
                foreach (var item in inPutHasEquip)
                {
                    _inputMaterialHasEquipmentService.Remove(item);
                }

                _inputMaterialService.Remove(entity);
                ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                ShowMessageToUser(result, "با موفقیت حذف شد", ResultType.Success);

            }
            catch (Exception ex)
            {
                /// لاگ خطا

                LogException.Write(ex, "DeleteMethodInInPutMaterialController");

                ///نمایش پیام خطا به کاربر

                ShowMessageToUser(result, "امکان حذف  رکورد وجود ندارد.", ResultType.Failure);
            }

            return Json(result);

        }
        [HttpPost]
        public JsonResult GetWorkOrderByCompanyID(int companyID)

        {
            var model = new InputMaterialModel();

            ///بدست آوردن درستور ک 
            PrepareAllWorkOrderModel(model, companyID);

            return Json(model.WorkOrderList);
        }
        [HttpPost]
        public JsonResult GetCompaniesByParentId(int parentId)

        {
            var model = new InputMaterialModel();


            PrepareAllCompaniesModel(model, parentId);

            return Json(model.Companies);
        }

        public JsonResult GetScaffoldByWorkorderId(int workorderId)
        {
            var model = new InputMaterialModel();

            var getWorkorder = _workorderService.GetById(workorderId);

            PrepareAllScaffoldModel(model, getWorkorder.CompanyId);

            model.ScaffoldingId = getWorkorder.ScaffoldingId;

            return Json(model.ScaffoldList, JsonRequestBehavior.AllowGet);
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