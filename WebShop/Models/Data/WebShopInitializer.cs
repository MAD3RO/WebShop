using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebShop.Models.ViewModels.Pages;

namespace WebShop.Models.Data
{
    // public class WebShopInitializer : System.Data.Entity.DropCreateDatabaseAlways<Db>

    public class WebShopInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<Db>
    {
        protected override void Seed(Db context)
        {
            // Page initializer
            var Pages = new List<PageModel>
            {
                new PageModel{Title="Home", Body="home page", Slug="home", Sorting=0},
            };

            Pages.ForEach(s => context.Pages.Add(s));
            context.SaveChanges();

            // Categories initializer
            var Categories = new List<CategoryModel>
            {
                new CategoryModel{Name = "Kategorija", Slug="kategorija", Sorting=1}
            };

            Categories.ForEach(s => context.Categories.Add(s));
            context.SaveChanges();

            // Products initializer
            var Products = new List<ProductModel>
            {
                new ProductModel{Name = "Produkt", Slug="produkt", CategoryName="Voće", Description="opis", CategoryId=1, ImageName="slika", Price=12}
            };

            Products.ForEach(s => context.Products.Add(s));
            context.SaveChanges();

            // Users initializer
            var Users = new List<UserModel>
            {
                new UserModel{FirstName = "Admin", LastName="Admin", EmailAddress="admin@gmail.com", Password="password123", Username="admin"}
            };

            Users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();

            // Roles initializer
            var Roles = new List<RoleModel>
            {
                new RoleModel{Name="Admin"},
                new RoleModel{Name="User"}
            };

            Roles.ForEach(s => context.Roles.Add(s));
            context.SaveChanges();

            // User roles initializer
            var UserRoles = new List<UserRoleModel>
            {
                new UserRoleModel{UserId = 1, RoleId = 1}
            };

            UserRoles.ForEach(s => context.UserRoles.Add(s));
            context.SaveChanges();

            // Orders initializer
            //var Orders = new List<OrderModel>
            //{
            //    new OrderModel{OrderId = 1}
            //};

            //Orders.ForEach(s => context.Orders.Add(s));
            //context.SaveChanges();

            // Order details initializer
            //var OrderDetails = new List<OrderDetailsModel>
            //{
            //    new OrderDetailsModel{OrderId = 1, UserId = 1, ProductId = 1, Quantity = 2}
            //};

            //OrderDetails.ForEach(s => context.OrderDetails.Add(s));
            //context.SaveChanges();
        }
    }
}