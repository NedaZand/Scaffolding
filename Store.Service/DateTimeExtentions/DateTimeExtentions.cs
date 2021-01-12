using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.DateTimeExtentions
{
    public static class DateTimeExtentions
    {
        #region Fields
        private static PersianCalendar _persianCalendar = new PersianCalendar();
        #endregion Fields

        #region Convert DateTime to persian date
        /// <summary>
        /// Convert Datetime to perisan date as string
        /// </summary>
        /// <param name="dateTime">DateTime</param>
        /// <returns>Persian date as string  yyyy/mm/dd</returns>
        public static string PersianDate(this DateTime? dateTime)
        {
            return string.Format("{0}/{1}/{2}", _persianCalendar.GetYear(dateTime.Value), _persianCalendar.GetMonth(dateTime.Value), _persianCalendar.GetDayOfMonth(dateTime.Value));
        }
        #endregion Convert DateTime to persian date

        #region Convert DateTime to persian Time
        /// <summary>
        /// Convert Datetime and return time
        /// </summary>
        /// <param name="dateTime">time HH:MM</param>
        /// <returns></returns>
        public static string PersianTime(this DateTime dateTime)
        {
            return string.Format("ساعت{0} و {1} دقیقه", _persianCalendar.GetHour(dateTime), _persianCalendar.GetMinute(dateTime));
        }
        #endregion Convert DateTime to persian date
    }
}
