namespace WebShop.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebShop.Models.Data;

    internal sealed class Configuration : DbMigrationsConfiguration<WebShop.Models.Data.Db>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebShop.Models.Data.Db context)
        {
            // Page initializer
            var Pages = new List<PageModel>
            {
                new PageModel{Title="Home", Body="<p>This is Home page.</p>", Slug="home", Sorting=0},
            };

            Pages.ForEach(s => context.Pages.AddOrUpdate(s));
            context.SaveChanges();

            // Categories initializer
            var Categories = new List<CategoryModel>
            {
                new CategoryModel{Name = "Hot Deals", Slug="hot-deals", Sorting=1},
                new CategoryModel{Name = "Desktops", Slug="desktops", Sorting=1},
                new CategoryModel{Name = "Laptops", Slug="laptops", Sorting=1},
                new CategoryModel{Name = " SmartPhones", Slug="smart-phones", Sorting=1},
                new CategoryModel{Name = "Smart Watches", Slug="smart-watches", Sorting=1},
                new CategoryModel{Name = "Tablets", Slug="tablets", Sorting=1},
                new CategoryModel{Name = "TVs", Slug="tvs", Sorting=1},
                new CategoryModel{Name = "Peripherals", Slug="peripherals", Sorting=1},
                new CategoryModel{Name = "Accessories", Slug="accessories", Sorting=1}
            };

            Categories.ForEach(s => context.Categories.AddOrUpdate(s));
            context.SaveChanges();

            // Products initializer
            var Products = new List<ProductModel>
            {
                new ProductModel{Name = "ASUS - Gaming Desktop PC", Slug="asus-gaming-desktop-pc", CategoryName="Desktops", Description=" Intel Core i5-9400F (6-Core 2.9 GHz), NVIDIA GeForce GTX 1660, 8 GB DDR4, 512 GB SSD, Intel B360, Windows 10 Home 64-bit, GL10CS", CategoryId=2, ImageName="slika1", Price=779.98M},
                new ProductModel{Name = "GIGABYTE - AERO 15 OLED SA-7US5020SH", Slug="gigabyte-aero-15", Description="Gaming Laptop - 15.6' 4K UHD AMOLED - Intel Core i7-9750H - NVIDIA GeForce GTX 1660 Ti - 8 GB Memory 256 GB SSD - Win 10", CategoryId=3, ImageName="slika1", Price=1449}
                //new ProductModel{Name = "Produkt", Slug="produkt", CategoryName="Voće", Description="opis", CategoryId=1, ImageName="slika", Price=12},
                //new ProductModel{Name = "Produkt", Slug="produkt", CategoryName="Voće", Description="opis", CategoryId=1, ImageName="slika", Price=12},
                //new ProductModel{Name = "Produkt", Slug="produkt", CategoryName="Voće", Description="opis", CategoryId=1, ImageName="slika", Price=12},
                //new ProductModel{Name = "Produkt", Slug="produkt", CategoryName="Voće", Description="opis", CategoryId=1, ImageName="slika", Price=12},
                //new ProductModel{Name = "Produkt", Slug="produkt", CategoryName="Voće", Description="opis", CategoryId=1, ImageName="slika", Price=12},
                //new ProductModel{Name = "Produkt", Slug="produkt", CategoryName="Voće", Description="opis", CategoryId=1, ImageName="slika", Price=12},
                //new ProductModel{Name = "Produkt", Slug="produkt", CategoryName="Voće", Description="opis", CategoryId=1, ImageName="slika", Price=12},
                //new ProductModel{Name = "Produkt", Slug="produkt", CategoryName="Voće", Description="opis", CategoryId=1, ImageName="slika", Price=12},
                //new ProductModel{Name = "Produkt", Slug="produkt", CategoryName="Voće", Description="opis", CategoryId=1, ImageName="slika", Price=12},
                //new ProductModel{Name = "Produkt", Slug="produkt", CategoryName="Voće", Description="opis", CategoryId=1, ImageName="slika", Price=12},
                //new ProductModel{Name = "Produkt", Slug="produkt", CategoryName="Voće", Description="opis", CategoryId=1, ImageName="slika", Price=12},
                //new ProductModel{Name = "Produkt", Slug="produkt", CategoryName="Voće", Description="opis", CategoryId=1, ImageName="slika", Price=12},
                //new ProductModel{Name = "Produkt", Slug="produkt", CategoryName="Voće", Description="opis", CategoryId=1, ImageName="slika", Price=12},
                //new ProductModel{Name = "Produkt", Slug="produkt", CategoryName="Voće", Description="opis", CategoryId=1, ImageName="slika", Price=12},
                //new ProductModel{Name = "Produkt", Slug="produkt", CategoryName="Voće", Description="opis", CategoryId=1, ImageName="slika", Price=12},
                //new ProductModel{Name = "Produkt", Slug="produkt", CategoryName="Voće", Description="opis", CategoryId=1, ImageName="slika", Price=12},
                //new ProductModel{Name = "Produkt", Slug="produkt", CategoryName="Voće", Description="opis", CategoryId=1, ImageName="slika", Price=12},
                //new ProductModel{Name = "Produkt", Slug="produkt", CategoryName="Voće", Description="opis", CategoryId=1, ImageName="slika", Price=12},
            };

            Products.ForEach(s => context.Products.AddOrUpdate(s));
            context.SaveChanges();

            // Users initializer
            var Users = new List<UserModel>
            {
                new UserModel{FirstName = "Admin", LastName="Admin", EmailAddress="admin@gmail.com", Username="admin", StreetAddress=null, City=null, Contact=null, ZipCode=null, PasswordHash="1AA2693838747090005ED77F132B6CE68C15AB7E", Salt="4ok+P6YyPBl9EqGs/dFvtcZAXWMrJVyG6KQGYpWvfVc=", DateCreated=null}
            };

            Users.ForEach(s => context.Users.AddOrUpdate(s));
            context.SaveChanges();

            // Roles initializer
            var Roles = new List<RoleModel>
            {
                new RoleModel{Name="Admin"},
                new RoleModel{Name="User"}
            };

            Roles.ForEach(s => context.Roles.AddOrUpdate(s));
            context.SaveChanges();

            // User roles initializer
            var UserRoles = new List<UserRoleModel>
            {
                new UserRoleModel{UserId = 1, RoleId = 1}
            };

            UserRoles.ForEach(s => context.UserRoles.AddOrUpdate(s));
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
