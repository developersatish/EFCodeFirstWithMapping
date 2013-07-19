using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace EFCodeFirstWithMapping.Utilities
{
    public class MyContext : DbContext
    {
        public MyContext()
            : base("MyConnection")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}