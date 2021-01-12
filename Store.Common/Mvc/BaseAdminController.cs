using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Store.WebEssential.Mvc
{
  
    public class BaseAdminController : Controller
    {
        private static Random random = new Random();
        public string toEnglishNumber(string input)
        {
            string[] persian = new string[10] { "۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹" };

            for (int j = 0; j < persian.Length; j++)
                input = input.Replace(persian[j], j.ToString());

            return input;
        }
      
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
     
        public DateTime ConvertJalaliToAd(string date)
        {
            var adDate = new DateTime(int.Parse(toEnglishNumber(date.Split('/')[0])), int.Parse(toEnglishNumber(date.Split('/')[1])), int.Parse(toEnglishNumber(date.Split('/')[2])), new PersianCalendar());
            return adDate;
            //return string.Format("{0}/{1}/{2}", jalali.GetYear(ja), shamsi.GetMonth(miladi), shamsi.GetDayOfMonth(miladi));

        }
        public string ConvertAdToJalali(DateTime ad)
        {
            //DateTime miladi = DateTime.Now;
            System.Globalization.PersianCalendar shamsi = new System.Globalization.PersianCalendar();
            var today = string.Format("{0}/{1}/{2}", shamsi.GetYear(ad), shamsi.GetMonth(ad).ToString("00"), shamsi.GetDayOfMonth(ad).ToString("00"));
            return today;
            //var jalali = new DateTime(ad.Year, ad.Month, ad.Day, new PersianCalendar());
            //return string.Format("{0}/{1}/{2}", jalali.Year, jalali.Month, jalali.Day);
        }
    }
}