using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class AppContext : DbContext
    {
        public AppContext(): base("StudentConnection")
        {

        }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}