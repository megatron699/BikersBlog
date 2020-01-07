using BikersBlog.DAL;
using BikersBlog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BikersBlog.Controllers
{
    public class DriverController : Controller
    {
        // GET: Driver
        public DriverDBContext dBContext = new DriverDBContext();
        public ActionResult DriverView(int Id)
        {
            var myDriver = dBContext.Drivers.FirstOrDefault(c => c.Id == Id);
            if (myDriver != null)
                return View(myDriver);
            else return HttpNotFound();
        }
        public ActionResult DriverEd(int Id)
        {

            var myDriver = dBContext.Drivers.First(c => c.Id == Id);
            if (myDriver != null)
                return View(myDriver);
            else return HttpNotFound();
        }
        [HttpPost]
        public ActionResult DriverEd(Driver myDriver)
        {
            var Driver = dBContext.Drivers.First();
            if (ModelState.IsValid)
            {
               
                 
                dBContext.Entry(myDriver).State = EntityState.Modified;
               
                dBContext.SaveChanges();

                return RedirectToAction("List");
            }
            return View(myDriver);
        }
        public ActionResult List()
        {
            var allDrivers = dBContext.Drivers.OrderByDescending(c => c.LastName);
            ViewBag.Drivers = allDrivers;

            return View();
        }
        public ActionResult Create(Driver driver)
        {
            if(ModelState.IsValid)
            {
                dBContext.Drivers.Add(driver);
                dBContext.SaveChanges();
                return RedirectToAction("List");   
            }
            return View(driver);
        }
    }
}