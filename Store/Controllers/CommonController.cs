using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

using System.Globalization;
using Store.WebEssential.Mvc;

namespace Store.Controllers
{
    public partial class CommonController : Controller
    {
        #region Fields

     
        //private readonly HttpContextBase _httpContext;
      
        #endregion

        #region Constructors

        public CommonController( )
        {
           
            //this._httpContext = httpContext;
          
        }

        #endregion

        #region Methods
        public string ConvertAdToJalali(string date)
        {
            var miladi = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var shamsi = new System.Globalization.PersianCalendar();

            return string.Format("{0}/{1}/{2}", shamsi.GetYear(miladi), shamsi.GetMonth(miladi), shamsi.GetDayOfMonth(miladi));

        }
        public string ConvertJalaliToAd(string date)
        {
            DateTime jalali = new DateTime();
            try
            {
                jalali = new DateTime(int.Parse(date.Substring(0, 4)), int.Parse(date.Substring(5, 2)), int.Parse(date.Substring(8, 2)), new PersianCalendar());


                return string.Format("{0}/{1}/{2}", jalali.Year, jalali.Month, jalali.Day);
            }
            catch (Exception e)
            {

                return null;
            }
          
           
        }
        #endregion Methods
    }
}
