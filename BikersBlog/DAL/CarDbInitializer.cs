using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BikersBlog.Models;

namespace BikersBlog.DAL
{
    public class CarDbInitializer : DropCreateDatabaseAlways<CarDBContext> //CreateDatabesIfNotExist
    {
        protected override void Seed(CarDBContext context)
        {
            var car1 = new Models.Car { ModelName = "Honda", MaxSpeed = 300 };
            var car2 = new Models.Car { ModelName = "Toyota", MaxSpeed = 320 };
            var driver3 = new Models.Driver { Name = "Stig", LastName = "Sir", Age = 28, Car = car1 };
            var driver4 = new Models.Driver { Name = "Andrew", LastName = "Andrew", Age = 28 };
          

            context.Cars.Add(car1);
            context.Cars.Add(car2);
            context.Drivers.Add(driver3);
            context.Drivers.Add(driver4);
            context.SaveChanges();
            //context.Cars.Remove(car2);
            //base.Seed(context);
            //car1.ModelName = "Mitsubishi";
            //var selectResult = context.Cars.Where(c => c.MaxSpeed > 90);

        }
    }
}