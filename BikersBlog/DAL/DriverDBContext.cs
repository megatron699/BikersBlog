using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BikersBlog.Models;

namespace BikersBlog.DAL
{
    public class DriverDBContext: DbContext
    {
        public DriverDBContext() : base("DriverDbContext")
        { }
        public DbSet<Driver> Drivers { get; set; }
    }
}