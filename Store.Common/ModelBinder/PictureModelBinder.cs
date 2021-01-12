using Store.WebEssential.Model.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.WebEssential.ModelBinder
{
    public class PictureModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;
            Stream stream = null;
            string fileName = "";
            string contentType = "";
            if (string.IsNullOrEmpty(request["qqfile"]))
            {
                HttpPostedFileBase file = request.Files[0];
                if (file == null)
                {
                    throw new ArgumentException("No File Uploaded");
                }
                stream = file.InputStream;
                fileName = Path.GetFileName(file.FileName);
                contentType = file.ContentType;
            }
            else
            {
                stream = request.InputStream;
                fileName = request["qqfile"];
            }
            var fileBinary = new byte[stream.Length];
            stream.Read(fileBinary, 0, fileBinary.Length);
            var fileExtension = Path.GetExtension(fileName);
            if (string.IsNullOrEmpty(fileExtension))
            {
                fileExtension = fileExtension.ToLowerInvariant();
            }
            if (string.IsNullOrEmpty(contentType))
            {
                switch (fileExtension)
                {
                    case ".bmp":
                        contentType = "image/bmp";
                        break;
                    case ".gif":
                        contentType = "image/gif";
                        break;
                    case ".jpeg":
                    case ".jpg":
                    case ".jpe":
                    case ".jfif":
                    case ".pjpeg":
                    case ".pjp":
                        contentType = "image/jpeg";
                        break;
                    case ".png":
                        contentType = "image/png";
                        break;
                    case ".tiff":
                    case ".tif":
                        contentType = "image/tiff";
                        break;
                    default:
                        break;

                }
            }
            return new UploadPictureModel
            {
                ContentType = contentType,
                FileBinary = fileBinary
            };
        }
    }
}