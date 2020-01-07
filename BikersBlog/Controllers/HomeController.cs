using BikersBlog.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace BikersBlog.Controllers
{
    /// <summary>
    /// Хелпер класс для работы с изображениями.
    /// </summary>
    public class ImageSaveHelper
    {
        /// <summary>
        /// Сохраняет изображение и возвращает путь до него.
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static string SaveImage(HttpPostedFileBase image)
        {
            //var ext = path.getextension(image.filename);
            //var newimagename = image.filename;
            //var result = newimagename + ext;
            //if (image == null) return null;
            var result = image.FileName;
            var filePathOriginal = HostingEnvironment.MapPath("/Content/Images/Uploads/");
            string savedFileName = Path.Combine(filePathOriginal ?? throw new InvalidOperationException(), result);
            image.SaveAs(savedFileName);
            return $"/Content/Images/Uploads/{result}";
        }

    }
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Practice()
        {
            
            Student student = new Student
            {
                Name = "Егор",
                Age = 18,
                Birthday = new DateTime(1998,08,12),
                Group = "6301",
                IsSendDown = true,
                PhotoUrl = "/Content/Images/Uploads/w-brand.png",
                Univercity = new Univercity
                {
                    Name = "Самарский университет",
                    City = "Самара"
                }
            };         
            ViewBag.Username = "Борис Бритва";
            return View(student);
        }
        [HttpPost]
        public ActionResult Practice(Student student, HttpPostedFileBase imageData)
        {
            if (ModelState.IsValid)
            {
                var filename = ImageSaveHelper.SaveImage(imageData);

                student.PhotoUrl = filename;
            }
            //опред. действие
            return View(student);
        }
    }
}