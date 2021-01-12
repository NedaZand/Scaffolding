using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Domain.Media
{
    public class Picture : BaseEntity
    {
        public byte[] PictureBinary { get; set; }
        public string MimeType { get; set; }
        public string SeoFilename { get; set; }
        public bool IsNew { get; set; }
        public string AltAttribute { get; set; }
         public string TitleAttribute { get; set; }
         
    }
}
