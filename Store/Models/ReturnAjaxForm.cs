using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Models
{
    public class ReturnAjaxForm
    {
        public string html { get; set; }
        public ResultType ResultType { get; set; }
        public string Message { get; set; }
        public string Refrence { get; set; }
        public string Vacher { get; set; }


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