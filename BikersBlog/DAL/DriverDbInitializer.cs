using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BikersBlog.DAL
{
    public class DriverDbInitializer : DropCreateDatabaseAlways<DriverDBContext>
    {
        protected override void Seed(DriverDBContext context)
        {
            var driver1 = new Models.Driver { Name = "Александр", LastName = "Петров", Age = 30 };
            var driver2 = new Models.Driver { Name = "Иван", LastName = "Кондратьев", Age = 25 };
            context.Drivers.Add(driver1);
            context.Drivers.Add(driver2);
       
            context.SaveChanges();
            //base.Seed(context);
        }
    }
}