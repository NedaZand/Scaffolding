using Store.Core.CommonHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.WebEssential.ModelBinder
{
    public class DataTableModelBinder : DefaultModelBinder
    {
        public override object BindModel( ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
           

            var request = controllerContext.HttpContext.Request;


            var model = new DataTableRequestFilter();
            model.Search = request.QueryString["search[value]"];
            model.SortDirection = "asc";

            if (request.QueryString["order[0][column]"] != null)
            {
                model.SortColumn = int.Parse(request.QueryString["order[0][column]"]);
            }
            if (request.QueryString["order[0][dir]"] != null)
            {
                model.SortDirection = request.QueryString["order[0][dir]"];
            }
            return model;
        }
    }
}