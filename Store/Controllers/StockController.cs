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

namespace Store.Controllers
{
    [Authorize]
    public class StockController : BaseController
    {
        #region Fields
        private readonly IStockService _stockService;
        private readonly IEquipmentService _equipmentService;
        private readonly ICompanyService _companyService;
        private readonly IUserService _userService;
        private readonly IWorkOrderService _workOrderService;
        private readonly IScaffoldingService _scaffoldingService;

        #endregion

        #region Utilities


        #endregion

        #region Ctor
        public StockController(IScaffoldingService scaffoldingService, IStockService stockService, ICompanyService companyService, IUserService userService, IEquipmentService equipmentService, IWorkOrderService workOrderService)
        {
            this._stockService = stockService;
            this._companyService = companyService;
            this._userService = userService;
            this._equipmentService = equipmentService;
            this._workOrderService = workOrderService;
            this._scaffoldingService = scaffoldingService;
        }
        #endregion
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult List(DataTableRequest request, [ModelBinder(typeof(DataTableModelBinder))]DataTableRequestFilter filter)

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

                    m.DefectiveNumberStock = x.DefectiveNumberStock;
                    m.EquipmentTitle = _equipmentService.GetById(x.EquipmentId).Title;
                    m.MissingNumberStock = x.MissingNumberStock;
                    m.StockReady = x.StockReady;
                    m.TotalStock = x.TotalStock;
                    m.MainStock = x.MainStock;
                    m.EquipmentId = x.EquipmentId;


                    return m;
                }).ToList(),
                recordsTotal = _stockService.Count(filter.Search),
                recordsFiltered = _stockService.Count(filter.Search),
                draw = request.draw
            };

            return Json(gridModel, JsonRequestBehavior.AllowGet);
        }


    }
}