using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Web.Models;

namespace Web.DataAccess
{
    public class BusinessContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
    }
}