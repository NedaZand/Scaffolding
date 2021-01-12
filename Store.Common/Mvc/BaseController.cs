using Store.Essential.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Store.WebEssential.Mvc
{
    public class BaseController : Controller
    {
        private static Random random = new Random();
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
        public DateTime NewConvertJalaliToAd(string date)
        {
            //var adDate = new DateTime(int.Parse(toEnglishNumber(date.Split('/')[0])), int.Parse(toEnglishNumber(date.Split('/')[1])), int.Parse(toEnglishNumber(date.Split('/')[2])), new PersianCalendar());
            //return adDate;
            PersianCalendar pc = new PersianCalendar();
            int day = int.Parse(date.Split('/')[0]);
            int month = int.Parse(date.Split('/')[1]);
            int year = int.Parse(date.Split('/')[2]);

            DateTime dt = new DateTime(year, month, day, pc);
            return dt;
        }
        public string ConvertAdToJalali(DateTime ad)
        {
            //DateTime miladi = DateTime.Now;
            System.Globalization.PersianCalendar shamsi = new System.Globalization.PersianCalendar();
            var today = string.Format("{0}/{1}/{2}", shamsi.GetYear(ad).ToString("00"), shamsi.GetMonth(ad), shamsi.GetDayOfMonth(ad).ToString("00"));
            return today;
                 
}
        public string ConvertAdToJalaliDateTime(DateTime ad)
        {
            //DateTime miladi = DateTime.Now;
            System.Globalization.PersianCalendar shamsi = new System.Globalization.PersianCalendar();
            var today = string.Format("{0}:{1} {2}/{3}/{4}",shamsi.GetHour(ad).ToString("00"), shamsi.GetMinute(ad).ToString("00"), shamsi.GetYear(ad), shamsi.GetMonth(ad).ToString("00"), shamsi.GetDayOfMonth(ad).ToString("00"));
            return today;

        }

        string MonthName(int month)
    {
        switch (month)
        {
            case 1:
                return "فروردین";
            case 2:
                return "اردیبهشت";
            case 3:
                return "خرداد";
            case 4:
                return "تیر";
            case 5:
                return "مرداد";
            case 6:
                return "شهریور";
            case 7:
                return "مهر";
            case 8:
                return "آبان";
            case 9:
                return "آذر";
            case 10:
                return "دی";
            case 11:
                return "بهمن";
            case 12:
                return "اسفند";
            default:
                return "";


        

    }
            //var jalali = new DateTime(ad.Year, ad.Month, ad.Day, new PersianCalendar());
            //return string.Format("{0}/{1}/{2}", jalali.Year, jalali.Month, jalali.Day);
        }
        //public string ConvertJalaliToAd(string date)
        //{
        //    DateTime dt = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        //    //var jalali = date;
        //    var jalali = new DateTime(dt.Year, dt.Month, dt.Day, new PersianCalendar());
        //    //var ad = new System.Globalization.PersianCalendar();
        //    return string.Format("{0}/{1}/{2}", jalali.Year, jalali.Month, jalali.Day);

        //}
        public string toEnglishNumber(string input)
        {
            string[] persian = new string[10] { "۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹" };

            for (int j = 0; j < persian.Length; j++)
                input = input.Replace(persian[j], j.ToString());

            return input;
        }

        public StringBuilder AddErrors()
        {
            StringBuilder builder = new StringBuilder();
            // Append to StringBuilder.
            foreach (var e in ModelState.Values)
            {
                if (e.Errors.Count() > 0)
                {
                    foreach (var error in e.Errors.ToList())
                    {
                        builder.Append(error.ErrorMessage).Append("\n");
                    }
                }

            }

            return builder;
        }

        public void ShowMessageToUser(ReturnAjaxForm result, string message, ResultType resultType,int entityId=0)
        {
            result.ResultType = resultType;
            result.Message = message;
            result.EntityId = entityId;
        }

    }
}