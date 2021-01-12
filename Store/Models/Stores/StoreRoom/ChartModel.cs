using Store.Core.Domain.StoreTables.Work;
using Store.Essential;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Models.Stores.StoreRoom
{
    public class ChartModel : BaseModel
    {

        public ChartModel()
        {
            AccessLevelHeight = new List<double>();
            AccessLevelWidth = new List<double>();
            AccessLevelMode = new List<int>();
            Widths = new List<double>();

            AccessLevelHeight2 = new List<double>();
            AccessLevelWidth2 = new List<double>();
            AccessLevelMode2 = new List<int>();
            Widths2 = new List<double>();


        }
    

        [Display(Name = "عرض")]
        public double Width { get; set; }

        

        [Display(Name = "ارتفاع")]

        [RegularExpression(@"^\d+(.\d{1,2})?$")]
        public double Height { get; set; }

        [Display(Name = "طول")]
        public double Length { get; set; }

        [Display(Name = "محیط مخزن")]
        public double Environment { get; set; }

        [Display(Name = "قطر مخزن")]
        public double Diameter { get; set; }

        [Display(Name = "فاصله مخزن")]
        public double Distance { get; set; }

        [Display(Name = "تعداد عرض")]
        public int WidthCount { get; set; }

        [Display(Name = "تعداد ارتفاع سطح دسترسی")]
        public int HeightCount { get; set; }

        [Display(Name = "تعداد دهنه")]
        public int Line { get; set; }
        
        [Display(Name = "ارتفاع سطح دسترسی")]
        public IList<double> AccessLevelHeight { get; set; }

        [Display(Name = "عرض سطوح دسترسی")]
        public IList<double> AccessLevelWidth { get; set; }

        [Display(Name = "حالت سطوح دسترسی")]
        public IList<int> AccessLevelMode { get; set; }

        [Display(Name = "تعداد عرض")]
        public IList<double> Widths { get; set; }


        [Display(Name = "عرض دیوار 2")]
        public double Width2 { get; set; }

        [Display(Name = "ارتفاع دیوار 2")]
        public double Height2 { get; set; }

        [Display(Name = "طول دیوار 2")]
        public double Length2 { get; set; }

        [Display(Name = "تعداد عرض دیوار 2")]
        public int WidthCount2 { get; set; }

        [Display(Name = "تعداد ارتفاع سطح دسترسی دیوار 2")]
        public int HeightCount2 { get; set; }

        [Display(Name = "ارتفاع سطح دسترسی دیوار 2")]
        public IList<double> AccessLevelHeight2 { get; set; }

        [Display(Name = "عرض سطوح دسترسی دیوار 2")]
        public IList<double> AccessLevelWidth2 { get; set; }

        [Display(Name = "حالت سطوح دسترسی دیوار 2")]
        public IList<int> AccessLevelMode2 { get; set; }

        [Display(Name = "تعداد عرض دیوار 2")]
        public IList<double> Widths2 { get; set; }

    }
}