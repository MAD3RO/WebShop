using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WebShop.Models.Data
{
    public class Db : DbContext
    {
        public Db() : base("Db") { Database.SetInitializer(new WebShopInitializer()); }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<RoleModel> Roles { get; set; }
        public DbSet<UserRoleModel> UserRoles { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<OrderDetailsModel> OrderDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}