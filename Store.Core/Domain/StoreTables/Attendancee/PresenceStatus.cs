using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Domain.StoreTables.Attendancee
{
    public enum PresenceStatus
    {
        [Display(Name = "انتخاب")]
        Unknown = 0,

        [Display(Name ="ورود")]
        Entry=1,

        [Display(Name = "خروج")]
        Exit =2,

        [Display(Name = "مرخصی روزانه یا استحقاقی")]
        DayOff =3,

        [Display(Name = "مرخصی استعلاجی")]
        SickLeave =5,

        [Display(Name = "استراحت")]
        Rest =6,

        [Display(Name = "ماموریت")]
        Mission =7,

        [Display(Name = "شیفت عصر کار ۸ ساعته")]
        EveningShiftWork8Hours = 8,

        [Display(Name = "مرخصی شیفت عصر کار ۸ ساعته")]
        EveningShiftWork8HoursLeave = 9,

        [Display(Name = "شیفت شب کار ۸ ساعته")]
        NightShiftWork8Hours = 10,

        [Display(Name = "مرخصی شیفت شب کار ۸ ساعته")]
        NightShiftWork8HoursLeave = 11,

        [Display(Name = "تعطیلی پنجشنبه")]
        Closed = 12,

    }
}
