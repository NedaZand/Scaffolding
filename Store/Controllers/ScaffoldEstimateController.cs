using Store.Service.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Controllers
{
    public class ScaffoldEstimateController : Controller
    {
        #region Fields
        private readonly IStockService _stockService;
        private readonly IEquipmentService _equipmentService;

        #endregion
        #region Ctor

        public ScaffoldEstimateController(IStockService stockService, IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
            _stockService = stockService;
        }
        #endregion
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Drowing()
        {
            return View();
        }
        public ActionResult EstimateMaterial()
        {
            var equipments = _equipmentService.GetAll();

            var systemNameList = new List<string>() { "fourFoot", "fiveFeet", "sixFeet", "eightFeet", "tenFeet", "TwelveFeet", "fourteenFeet", "SixteenFeet", "EighteenFeet", "twentyFeet" };

            var list = new List<int>();

             foreach(var systemName in systemNameList)
            {

                foreach (var equipment in equipments)
                {
                    if(equipment.SystemName!=null)
                    {
                        if (equipment.SystemName.Contains(systemName))
                        {
                            list.Add(_stockService.GetById(equipment.Id) != null ? _stockService.GetById(equipment.Id).StockReady : 0);
                        }
                    }
                   
                }
                
            }

            ViewBag.EquipmentList = list;
            return View();
        }
    }
}