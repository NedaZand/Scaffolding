using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Essential.Model
{
    public class ReturnAjaxForm
    {
        public string html { get; set; }
        public ResultType ResultType { get; set; }
        public string Message { get; set; }
        public int EntityId { get; set; }


    }
    public enum ResultType
    {
        Success,
        Failure,
        NotAllow,
        Update,
        Redirect,
        Warning
    }
}