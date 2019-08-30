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
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<RoleModel> Roles { get; set; }
        public DbSet<UserRoleModel> UserRoles { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<OrderDetailsModel> OrderDetails { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<OrderModel>().HasRequired(m => m.Users).WithMany().HasForeignKey(m => m.UserId).WillCascadeOnDelete(true);
            // modelBuilder.Entity<OrderModel>().HasOptional(t => t.Users).WithMany().HasForeignKey(d => d.UserId).WillCascadeOnDelete(true);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // modelBuilder.Entity<OrderModel>().HasKey(m => m.OrderId);
            //        modelBuilder
            //.Entity<OrderModel>()
            //    .HasOptional(e => e.)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);
            
        }
    }
}