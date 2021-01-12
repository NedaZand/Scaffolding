using Store.Service;
using Store.WebEssential.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Configuration;
using System.IO;
using System.Web.Security;
using Store.Service.Stores;
using Store.WebEssential.Helper;
using Store.Models.Stores;
using Store.Core.CommonHelper;
using Store.WebEssential.ModelBinder;
using Store.Core.Domain.StoreTables.StoreRoom;
using Store.Models.Stores.StoreRoom;
using Store.Service.Media;
using Rotativa;

namespace Store.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        #region Fields
        private readonly IStockService _stockService;
        private readonly IEquipmentService _equipmentService;
        private readonly ICompanyService _companyService;
        private readonly IUserService _userService;
        private readonly IWorkOrderService _workOrderService;
        private readonly IScaffoldingService _scaffoldingService;
        private readonly IPictureService _pictureService;

        #endregion

        #region Utilities


        #endregion

        #region Ctor
        public HomeController(IPictureService pictureService, IScaffoldingService scaffoldingService, IStockService stockService, ICompanyService companyService, IUserService userService, IEquipmentService equipmentService, IWorkOrderService workOrderService)
        {
            this._stockService = stockService;
            this._companyService = companyService;
            this._userService = userService;
            this._equipmentService = equipmentService;
            this._workOrderService = workOrderService;
            this._scaffoldingService = scaffoldingService;
            this._pictureService = pictureService;
        }
        #endregion
        public ActionResult Index()
        {
            var d = DateTime.Now.Date;

            var d2 = DateTime.Now.AddDays(-15);

            var f = d2.Subtract(d).Days;

            return View();
        }
        public ActionResult Test()
        {
            return View();
        }
        [HttpGet]
        public JsonResult StockList(DataTableRequest request, [ModelBinder(typeof(DataTableModelBinder))]DataTableRequestFilter filter)

        {
            if (request.length == -1)
            {
                request.length = int.MaxValue;
            }
            var data = _stockService.FilterData(request.start, request.length, filter.Search, filter.SortColumn, filter.SortDirection);


            var gridModel = new DataTableResponse<Stock>()
            {
                data = data.Select(x =>
                {

                    var getEquipment = _equipmentService.GetById(x.EquipmentId);
                    var m = new Stock();


                    if (getEquipment.MinimumInventory != 0 && x.StockReady <= getEquipment.MinimumInventory)
                    {
                        m.DefectiveNumberStock = x.DefectiveNumberStock;
                        m.EquipmentTitle = _equipmentService.GetById(x.EquipmentId).Title;
                        m.MissingNumberStock = x.MissingNumberStock;
                        m.StockReady = x.StockReady;
                        m.TotalStock = x.TotalStock;
                        m.EquipmentId = x.EquipmentId;

                    }
                    else if (((x.TotalStock * getEquipment.MinimumInventoryPercentage) / 100) == x.StockReady)
                    {
                        m.DefectiveNumberStock = x.DefectiveNumberStock;
                        m.EquipmentTitle = _equipmentService.GetById(x.EquipmentId).Title;
                        m.MissingNumberStock = x.MissingNumberStock;
                        m.StockReady = x.StockReady;
                        m.TotalStock = x.TotalStock;
                        m.EquipmentId = x.EquipmentId;
                    }

                    else
                    {
                        m = null;
                    }


                    return m;
                }).ToList(),
                recordsTotal = _stockService.Count(filter.Search),
                recordsFiltered = _stockService.Count(filter.Search),
                draw = request.draw
            };

            gridModel.data = gridModel.data.Where(x => x != null).ToList();

            return Json(gridModel, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ScaffoldExpirList(DataTableRequest request, [ModelBinder(typeof(DataTableModelBinder))]DataTableRequestFilter filter)

        {
            if (request.length == -1)
            {
                request.length = int.MaxValue;
            }
            var data = _scaffoldingService.FilterData(request.start, request.length, filter.Search, filter.SortColumn, filter.SortDirection, alertExpire: true);

            var gridModel = new DataTableResponse<ScaffoldModel>()
            {
                data = data.Select(x =>
                {

                    var m = new ScaffoldModel();
                    int diffExpireDate = 0;
                    int diffTagDate = 0;

                    if (x.ExpireDate.HasValue)
                    {
                        diffExpireDate = x.ExpireDate.Value.Subtract(DateTime.Now).Days;

                        if (diffExpireDate <= 0)
                        {
                            m.AlertExpireDate = "تاریخ انقضا داربست به پایان رسیده است.";

                        }


                    }

                    if (x.RegistrationDate.HasValue)
                    {
                        diffTagDate = DateTime.Now.Subtract(x.RegistrationDate.Value).Days;

                        if (diffTagDate >= 0)
                        {

                            m.AlertRegisterTagDate = "تگ ایمنی منقضی شده است";
                            //m.AlertRegisterTagDate = diffTagDate + " روز تا منقضی شدن تگ ایمنی";

                        }
                        //else if (diffTagDate == 0)
                        //{
                        //    m.AlertRegisterTagDate = "تگ ایمنی منقضی شده است";

                        //}


                    }

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
                    m.EarthTitle = x.Earth != null ? x.Earth.Title : "";
                    m.BuildingTitle = x.Building != null ? x.Building.Title : "";
                    m.ScaffoldTypeTitle = x.ScaffoldType != null ? x.ScaffoldType.Title : "";

                    var des = _workOrderService.GetAll(scaffoldingId: x.Id, type: Core.Domain.StoreTables.Work.WorkOrderType.Installation).FirstOrDefault();
                    if (des != null)
                    {
                        string desc = des.Description;
                        m.Description = desc.Length > 40 ? "<a style='text-align:left;direction:ltr;' title='" + desc + "'>" + desc.Substring(0, 40) + " ..." + "</a>" : desc;
                    }


                    m.ShamsiCreateDate = ConvertAdToJalaliDateTime(x.CreatedDate.Value);
                    m.ActionUserName = _userService.GetById(x.ActionUserId).UserName;
                    m.Id = x.Id;

                    if (x.ModifiedDate.HasValue)
                        m.ShamsiEditDate = ConvertAdToJalaliDateTime(x.ModifiedDate.Value);
                    if (x.LastActionUserId != null)
                        m.EditUserName = _userService.GetById(x.ActionUserId).UserName;

                    return m;
                }).ToList(),
                recordsTotal = _scaffoldingService.Count(filter.Search, alertExpire: true),
                recordsFiltered = _scaffoldingService.Count(filter.Search, alertExpire: true),
                draw = request.draw
            };
            //gridModel.data = gridModel.data.Where(x => x != null).ToList();


            return Json(gridModel, JsonRequestBehavior.AllowGet);
        }


        public ActionResult PrintScaffoldingExpired()
        {
            var model = new List<ScaffoldModel>();

            var data = _scaffoldingService.FilterData(0, int.MaxValue, null, 0, null, alertExpire: true);


            data.ForEach(x =>
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
                m.EarthTitle = x.Earth != null ? x.Earth.Title : "";
                m.BuildingTitle = x.Building != null ? x.Building.Title : "";
                m.ScaffoldTypeTitle = x.ScaffoldType != null ? x.ScaffoldType.Title : "";
                m.ShamsiCreateDate = ConvertAdToJalaliDateTime(x.CreatedDate.Value);

                model.Add(m);
            });


            return new ViewAsPdf("PrintExpiredScaffoldList", model);
        }

    }
}