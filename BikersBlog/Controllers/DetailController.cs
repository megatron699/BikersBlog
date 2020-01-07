using BikersBlog.DAL;
using BikersBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BikersBlog.Controllers
{
    public class DetailController : Controller
    {
        private CarDBContext dBContext = new CarDBContext();
        private static Car car;
        // GET: Detail
        public ActionResult First()
        {
            var car = dBContext.Cars.Where(c => c.MaxSpeed > 90).OrderBy(c=>c.ModelName);
            return View(car);
        }
        public ActionResult Second()
        {
            var car = dBContext.Cars.First();
            return View(car);
        }
        [HttpPost]
        public ActionResult Second(Car myCar)
        {
            var car = dBContext.Cars.First();
            if (ModelState.IsValid)
            {
                dBContext.Cars.Add(myCar);
                dBContext.SaveChanges();
                
             //   return RedirectToAction("First", "Detail");
            }
            return View(car);
        }
    }
}