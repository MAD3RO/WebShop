namespace WebShop.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.Linq;
    using WebShop.Models.Data;

    internal sealed class Configuration : DbMigrationsConfiguration<WebShop.Models.Data.Db>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WebShop.Models.Data.Db context)
        {
            // Page initializer
            var Pages = new List<PageModel>
                {
                    new PageModel{Title="Home", Body="<p>This is Home page.</p>", Slug="home", Sorting=0},
                };

            Pages.ForEach(page => context.Pages.AddOrUpdate(s => s.Title, page));
            context.SaveChanges();

            // Categories initializer
            var Categories = new List<CategoryModel>
                {
                    new CategoryModel{Name = "Desktops", Slug="desktops", Sorting=1},
                    new CategoryModel{Name = "Laptops", Slug="laptops", Sorting=1},
                    new CategoryModel{Name = " SmartPhones", Slug="smart-phones", Sorting=1},
                    new CategoryModel{Name = "Smart Watches", Slug="smart-watches", Sorting=1},
                    new CategoryModel{Name = "Tablets", Slug="tablets", Sorting=1},
                    new CategoryModel{Name = "TVs", Slug="tvs", Sorting=1},
                    new CategoryModel{Name = "Peripherals", Slug="peripherals", Sorting=1},
                    new CategoryModel{Name = "Accessories", Slug="accessories", Sorting=1}
                };

            Categories.ForEach(category => context.Categories.AddOrUpdate(s => s.Name, category));
            context.SaveChanges();

            // Products initializer
            var Products = new List<ProductModel>
                {
                    new ProductModel{Name = "ASUS - Gaming Desktop PC", Slug="asus-gaming-desktop-pc", CategoryName="Desktops", Description=" Intel Core i5-9400F (6-Core 2.9 GHz), NVIDIA GeForce GTX 1660, 8 GB DDR4, 512 GB SSD, Intel B360, Windows 10 Home 64-bit, GL10CS", DateAdded=DateTime.Parse("2/10/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=1, Image="slika1.jpg", Price=779.98M, Discount=15},
                    new ProductModel{Name = "ABS Mage E", Slug="abs-mage-e", CategoryName="Desktops", Description="Ryzen 5 2600 - B450 Wifi - Radeon RX 5700 - 8GB DDR4 - 512GB SSD ", DateAdded= DateTime.Parse("3/10/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=1, Image="slika1.jpg", Price=849.99M, Discount=25},
                    new ProductModel{Name = "HP Business Desktop ProDesk 400 G4", Slug="hp-business-desktop-prodesk-400-G4", CategoryName="Desktops", Description="Intel Core i5 (8th Gen) i5-8500T 2.10 GHz - 8 GB DDR4 SDRAM - 256 GB SSD - Windows 10 Pro 64-Bit (English)", DateAdded=DateTime.Parse("4/10/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=1, Image="slika1.jpg", Price=649, Discount=0},
                    new ProductModel{Name = "Lenovo ThinkCentre M910s", Slug="lenovo-thinkcentre-m910s", CategoryName="Desktops", Description="Intel Core i5-7500 (3.40 GHz) - 8 GB RAM - 256 GB SSD - Windows 10 Pro 64-bit (English) - Small Form Factor - Black", DateAdded=DateTime.Parse("4/10/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=1, Image="slika1.jpg", Price=644.99M, Discount=0},
                    new ProductModel{Name = "iBUYPOWER AlphaB 3660SA", Slug="ibuypower-alphab-3660sa", CategoryName="Desktops", Description="AMD Ryzen 5 3600 (3.60 GHz) NVIDIA GeForce RTX 2060 SUPER 16 GB DDR4 480 GB SSD Windows 10 Home 64-bit", DateAdded=DateTime.Parse("4/10/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=1, Image="slika1.jpg", Price=1079.99M, Discount=10},
                    new ProductModel{Name = "Dell Precision T3630 Workstation", Slug="dell-precision-t3630-workstation", CategoryName="Desktops", Description="Intel i7-8700K 6-Core up to 4.7GHz, 32GB DDR4, 2TB HDD + 512GB SSD , Windows 10 Pro 64-bit, 3000 Series Tower NVIDIA Quadro P620", DateAdded=DateTime.Parse("3/10/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=1, Image="slika1.jpg", Price=1672.99M, Discount=30},
                    new ProductModel{Name = "iBUYPOWER Slate 106AV2", Slug="IBUYPOWER-SLATE-106AV2", CategoryName="Desktops", Description="AMD Ryzen 5 3600 (3.60 GHz) NVIDIA GeForce GTX 1660 8 GB DDR4 500 GB SSD Windows 10 Home 64-bit", DateAdded=DateTime.Parse("2/10/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=1, Image="slika1.jpg", Price=919.99M, Discount=20},
                    //new ProductModel{Name = "Produkt", Slug="produkt", CategoryName="Voće", Description="opis", CategoryId=2, ImageName="slika1.jpg", Price=12},
                    //new ProductModel{Name = "Produkt", Slug="produkt", CategoryName="Voće", Description="opis", CategoryId=2, ImageName="slika1.jpg", Price=12},
                    //new ProductModel{Name = "Produkt", Slug="produkt", CategoryName="Voće", Description="opis", CategoryId=2, ImageName="slika1.jpg", Price=12},
                    //new ProductModel{Name = "Produkt", Slug="produkt", CategoryName="Voće", Description="opis", CategoryId=2, ImageName="slika1.jpg", Price=12},
                    new ProductModel{Name = "GIGABYTE - AERO 15 OLED SA-7US5020SH", Slug="gigabyte-aero-15", CategoryName="Laptops", Description="Gaming Laptop - 15.6' 4K UHD AMOLED - Intel Core i7-9750H - NVIDIA GeForce GTX 1660 Ti - 8 GB Memory 256 GB SSD - Win 10", DateAdded=DateTime.Parse("4/10/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=2, Image="slika1.jpg", Price=1449, Discount=30}
                };

            Products.ForEach(product => context.Products.AddOrUpdate(s => s.Name, product));
            context.SaveChanges();

            // Users initializer
            var Users = new List<UserModel>
                {
                    new UserModel{FirstName = "Admin", LastName="Admin", EmailAddress="admin@gmail.com", Username="admin", Address=null, City=null, Contact=null, ZipCode=null, PasswordHash="1AA2693838747090005ED77F132B6CE68C15AB7E", Salt="4ok+P6YyPBl9EqGs/dFvtcZAXWMrJVyG6KQGYpWvfVc=", DateCreated=null, IsGuest=false}
                };

            Users.ForEach(user => context.Users.AddOrUpdate(s => s.Username, user));
            context.SaveChanges();

            // Roles initializer
            var Roles = new List<RoleModel>
                {
                    new RoleModel{Name="Admin"},
                    new RoleModel{Name="User"},
                    new RoleModel{Name="Guest"}
                };

            Roles.ForEach(role => context.Roles.AddOrUpdate(s => s.Name, role));
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
