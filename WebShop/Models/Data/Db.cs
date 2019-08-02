using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace WebShop.Models.Data
{
    public class Db : DbContext
    {
        public Db() : base("Db") { }
        public DbSet<PageModel> Pages { get; set; }
        public DbSet<SidebarModel> Sidebar { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}