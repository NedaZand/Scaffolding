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

namespace Store.Controllers
{
    [Authorize]
    public class BuyMaterialController : BaseController
    {
        #region Fields

        private readonly ICompanyStoreRoomService _companyService;
        private readonly IEquipmentService _equipmentService;
        private readonly IBuyMaterialService _buyMaterialService;
        private readonly IStockService _stockService;
        private readonly ICheckingRole _checkingRoleService;
        private readonly IUserService _userService;
        private readonly IUnitService _unitService;
        #endregion
        #region Ctor

        public BuyMaterialController(IUnitService unitService, IStockService stockService, IBuyMaterialService buyMaterialService, IEquipmentService equipmentService, ICompanyStoreRoomService companyService, ICheckingRole checkingRoleService, IUserService userService)
        {
            _companyService = companyService;
            _checkingRoleService = checkingRoleService;
            _equipmentService = equipmentService;
            _userService = userService;
            _buyMaterialService = buyMaterialService;
            _stockService = stockService;
            _unitService = unitService;
        }
        #endregion
        #region Utilities

        [NonAction]
        protected virtual void PrepareAllCompaniesModel(BuyMaterialModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            model.CompanyList.Add(new SelectListItem
            {
                Text = "انتخاب شرکت فروشنده ",
                Value = " ",
                Selected = true
            });

            var companies = _companyService.GetAll();

            foreach (var c in companies)
            {
                model.CompanyList.Add(new SelectListItem
                {
                    Text = c.Title,
                    Value = c.Id.ToString()
                });
            }
        }

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

        [NonAction]
        protected virtual void PrepareAllUnits(BuyMaterialModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            model.Units.Add(new SelectListItem
            {
                Text = "انتخاب واحد ",
                Value = " ",
                Selected = true
            });
            var units = _unitService.GetAll();

            foreach (var c in units)
            {
                model.Units.Add(new SelectListItem
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
            var model = new BuyMaterialModel();

            if (!_checkingRoleService.HasAccess(PermissionList.BuyMaterialList, CurrentUser.GetCurrentUser))
            {
                return View("Inaccessibility");
            }

            ///آماده سازی شرکت ها
            PrepareAllCompaniesModel(model);
            model.SearchModel.CompanyList = model.CompanyList;

            ///آماده سازی تجهیزات
            PrepareAllEquipmentsModel(model);
            model.SearchModel.EquipmentList = model.EquipmentList;

            return View(model);
        }
        public ActionResult Create()
        {
            var model = new BuyMaterialModel();

            if (!_checkingRoleService.HasAccess(PermissionList.BuyMaterialCreate, CurrentUser.GetCurrentUser))
            {

                return View("Inaccessibility");
            }

            ///آماده سازی شرکت ها
            PrepareAllCompaniesModel(model);
            ///آماده سازی تجهیزات
            PrepareAllEquipmentsModel(model);
            ///آماده سازی واحد
            PrepareAllUnits(model);

            return View(model);
        }
        [HttpPost]
        public ActionResult Create(BuyMaterialModel model)
        {
            var result = new ReturnAjaxForm();
            if (model.Count <= 0)
                ModelState.AddModelError("Count", "تعداد خریداری شده الزامی است");

            var buyMaterial = new BuyMaterial();
            if (model.EquipmentId == null)
                model.EquipmentId = 0;
            var stock = _stockService.GetById(model.EquipmentId.Value);

            if (ModelState.IsValid)
            {
                try
                {
                    buyMaterial.Count = model.Count;
                    buyMaterial.Date = model.BuyDate;
                    buyMaterial.CompanyStoreRoomId = model.CompanyStoreRoomId;
                    buyMaterial.EquipmentId = model.EquipmentId.Value;
                    buyMaterial.Price = model.Price;
                    buyMaterial.UnitId = model.UnitId;
                    buyMaterial.ActionUserId = User.Identity.GetUserId();

                    ///عملیات ثبت در دیتابیس
                    if (_buyMaterialService.Insert(buyMaterial))
                    {
                        ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                        ShowMessageToUser(result, "با موفقیت ثبت شد", ResultType.Success);
                    }

                    else
                    {

                        ///نمایش پیام خطا  به کاربر

                        ShowMessageToUser(result, "عملیات با خطا مواجه شد.", ResultType.Failure);
                    }

                }
                catch (Exception ex)
                {

                    ///نمایش پیام خطا به کاربر

                    ShowMessageToUser(result, ex.Message, ResultType.Failure);

                    LogException.Write(ex, "CreateActionInBuyMaterialController");

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

            var model = new BuyMaterialModel();

            if (!_checkingRoleService.HasAccess(PermissionList.BuyMaterialEdit, CurrentUser.GetCurrentUser))
            {
                return PartialView("_Inaccessibility");
            }

            ///آماده سازی شرکت ها
            PrepareAllCompaniesModel(model);
            ///آماده سازی تجهیزات
            PrepareAllEquipmentsModel(model);
            ///آماده سازی واحد
            PrepareAllUnits(model);


            var buyMaterial = _buyMaterialService.GetById(id);

            model.Count = buyMaterial.Count;
            model.BuyDate = buyMaterial.Date;
            model.CompanyStoreRoomId = buyMaterial.CompanyStoreRoomId;
            model.EquipmentId = buyMaterial.EquipmentId;
            model.Price = buyMaterial.Price;
            model.UnitId = buyMaterial.UnitId;
            model.Id = buyMaterial.Id;

            return PartialView(model);
        }
        [HttpPost]
        public ActionResult Edit(BuyMaterialModel model)
        {
            var result = new ReturnAjaxForm();

            ModelState.Remove("EquipmentId");
            if (model.Count <= 0)
                ModelState.AddModelError("Count", "تعداد خریداری شده الزامی است");

            if (ModelState.IsValid)
            {
                try
                {
                    var buyMaterial = _buyMaterialService.GetById(model.Id);

                    buyMaterial.Count = model.Count;
                    buyMaterial.Date = model.BuyDate;
                    buyMaterial.CompanyStoreRoomId = model.CompanyStoreRoomId;
                    buyMaterial.Price = model.Price;
                    buyMaterial.UnitId = model.UnitId;
                    buyMaterial.ModifiedDate = DateTime.Now;
                    buyMaterial.LastActionUserId = User.Identity.GetUserId();

                    ///عملیات ثبت در دیتابیس

                    if (_buyMaterialService.Update(buyMaterial))
                    {
                        ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                        ShowMessageToUser(result, "با موفقیت ویرایش شد", ResultType.Success);
                    }

                    else
                    {
                        ///نمایش پیام خطا  به کاربر

                        ShowMessageToUser(result, "عملیات با خطا مواجه شد.", ResultType.Failure);
                    }

                }
                catch (Exception ex)
                {
                    LogException.Write(ex, "EditActionInBuyMaterialController");
                    ///نمایش پیام خطا به کاربر

                    ShowMessageToUser(result, ex.Message, ResultType.Failure);

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
            var data = _buyMaterialService.FilterData(request.start, request.length, filter.Search, filter.SortColumn, filter.SortDirection, null, null, model.EquipmentId, model.CompanyStoreRoomId, model.Price, model.BuyDate, model.ToBuyDate);


            var gridModel = new DataTableResponse<BuyMaterialModel>()
            {
                data = data.Select(x =>
                {

                    var m = new BuyMaterialModel();
                    m.PriceToString = x.Price.ToString("N0");
                    m.Count = x.Count;
                    if (x.UnitId.HasValue)
                    {
                        var getUnit = _unitService.GetById(x.UnitId.Value);

                        if (getUnit != null)
                            m.UnitTitle = getUnit.Title;
                    }

                    m.EquipmentName = _equipmentService.GetById(x.EquipmentId).Title;
                    if(x.CompanyStoreRoomId.HasValue)
                    m.CompanyName = _companyService.GetById(x.CompanyStoreRoomId.Value).Title;
                    m.ShamsiBuyDate = ConvertAdToJalali(x.Date.Value);
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
                recordsTotal = _buyMaterialService.Count(filter.Search,equipmentId:model.EquipmentId,companyId:model.CompanyStoreRoomId,fromdate:model.BuyDate,todate:model.ToBuyDate),
                recordsFiltered = _buyMaterialService.Count(filter.Search, equipmentId: model.EquipmentId, companyId: model.CompanyStoreRoomId, fromdate: model.BuyDate, todate: model.ToBuyDate),
                draw = request.draw
            };



            return Json(gridModel, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var result = new ReturnAjaxForm();

            if (!_checkingRoleService.HasAccess(PermissionList.BuyMaterialDelete, CurrentUser.GetCurrentUser))
            {
                ///نمایش پیام عدم دسترسی  به کاربر

                ShowMessageToUser(result, "کاربر گرامی،شما  مجوز حذف رکورد را ندارید! ", ResultType.NotAllow);


                //return Json(result, JsonRequestBehavior.AllowGet);
            }

            try
            {
                var entity = _buyMaterialService.GetById(id);
                if (_buyMaterialService.Remove(entity))
                {
                    ///نمایش پیام موفقیت آمیز بودن عملیات به کاربر

                    ShowMessageToUser(result, "با موفقیت حذف شد", ResultType.Success);
                }
                else
                {
                    ///نمایش پیام خطا  به کاربر

                    ShowMessageToUser(result, "عملیات با خطا مواجه شد.", ResultType.Failure);
                }


            }
            catch (Exception ex)
            {
                ///نمایش پیام خطا به کاربر

                ShowMessageToUser(result, ex.Message, ResultType.Failure);

                LogException.Write(ex, "DeleteActionInBuyMaterialController");
            }

            return Json(result);

        }

        #endregion


        #region Report
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
            BuyMaterialModel model = (BuyMaterialModel)Session["filter"];
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

                if (model.CompanyStoreRoomId != 0)
                    mainReport["@companyStoreRoomId"] = model.CompanyStoreRoomId;
                else
                    mainReport["@companyStoreRoomId"] = null;

                mainReport["@fromDate"] = model.FromBuyDate;
                mainReport["@toDate"] = model.ToBuyDate;
            }
            catch (Exception)
            {

                mainReport["@equipmentId"] = null;
                mainReport["@companyStoreRoomId"] = null;
                mainReport["@fromDate"] = null;
                mainReport["@toDate"] = null;

            }

            // فراخوانی فایل استیمول
            mainReport.Load(Server.MapPath("~/ReportFiles/BuyMaterialReport.mrt"));
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