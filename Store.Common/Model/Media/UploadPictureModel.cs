using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.WebEssential.Model.Media
{
    public class UploadPictureModel
    {
        public byte[] FileBinary { get; set; }
        public string ContentType { get; set; }
    }
}