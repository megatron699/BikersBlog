using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace RealBlog.Helpers
{
    public class ImageSaveHelper
    {   /// <summary>
        /// Сохраняет изображение и возвращает путь до него.
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static string SaveImage(HttpPostedFileBase image)
        {
            var ext = Path.GetExtension(image.FileName);
            var newimagename = Guid.NewGuid().ToString();
            var result = newimagename + ext;
            //if (image == null) return null;
          
            var filePathOriginal = HostingEnvironment.MapPath("/Content/Images/Uploads/");
            string savedFileName = Path.Combine(filePathOriginal ?? throw new InvalidOperationException(), result);
           

            //~Content/Images/Uploads
            image.SaveAs(savedFileName);
            return $"/Content/Images/Uploads/{result}";
        }
    }
}