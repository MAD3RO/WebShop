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
            // Categories initializer
            var Categories = new List<CategoryModel>
                {
                    new CategoryModel{Name = "Desktops", Slug="desktops", Sorting=1},
                    new CategoryModel{Name = "Laptops", Slug="laptops", Sorting=1},
                    new CategoryModel{Name = "Processors", Slug="processors", Sorting=1},
                    new CategoryModel{Name = "Graphics Cards", Slug="graphics-cards", Sorting=1},
                    new CategoryModel{Name = "Motherboards", Slug="motherboards", Sorting=1},
                    new CategoryModel{Name = "Storage", Slug="storage", Sorting=1}
                };

            Categories.ForEach(category => context.Categories.AddOrUpdate(s => s.Name, category));
            context.SaveChanges();

            // Products initializer
            var Products = new List<ProductModel>
                {
                    // Desktops
                    new ProductModel{Name = "ASUS - Gaming Desktop PC", CategoryName="Desktops", Description=" Intel Core i5-9400F (6-Core 2.9 GHz), NVIDIA GeForce GTX 1660, 8 GB DDR4, 512 GB SSD, Intel B360, Windows 10 Home 64-bit, GL10CS", DateAdded=DateTime.Parse("2/10/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=1, Image="slika1.jpg", Price=779.98M, Discount=15},
                    new ProductModel{Name = "ABS Mage E", CategoryName="Desktops", Description="Ryzen 5 2600 - B450 Wifi - Radeon RX 5700 - 8GB DDR4 - 512GB SSD ", DateAdded= DateTime.Parse("3/10/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=1, Image="slika1.jpg", Price=849.99M, Discount=25},
                    new ProductModel{Name = "HP Business Desktop ProDesk 400 G4", CategoryName="Desktops", Description="Intel Core i5 (8th Gen) i5-8500T 2.10 GHz - 8 GB DDR4 SDRAM - 256 GB SSD - Windows 10 Pro 64-Bit (English)", DateAdded=DateTime.Parse("4/10/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=1, Image="slika1.jpg", Price=649, Discount=0},
                    new ProductModel{Name = "Lenovo ThinkCentre M910s", CategoryName="Desktops", Description="Intel Core i5-7500 (3.40 GHz) - 8 GB RAM - 256 GB SSD - Windows 10 Pro 64-bit (English) - Small Form Factor - Black", DateAdded=DateTime.Parse("4/10/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=1, Image="slika1.jpg", Price=644.99M, Discount=0},
                    new ProductModel{Name = "iBUYPOWER AlphaB 3660SA", CategoryName="Desktops", Description="AMD Ryzen 5 3600 (3.60 GHz) NVIDIA GeForce RTX 2060 SUPER 16 GB DDR4 480 GB SSD Windows 10 Home 64-bit", DateAdded=DateTime.Parse("4/10/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=1, Image="slika1.jpg", Price=1079.99M, Discount=10},
                    new ProductModel{Name = "Dell Precision T3630 Workstation", CategoryName="Desktops", Description="Intel i7-8700K 6-Core up to 4.7GHz, 32GB DDR4, 2TB HDD + 512GB SSD , Windows 10 Pro 64-bit, 3000 Series Tower NVIDIA Quadro P620", DateAdded=DateTime.Parse("3/10/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=1, Image="slika1.jpg", Price=1672.99M, Discount=30},
                    new ProductModel{Name = "iBUYPOWER Slate 106AV2", CategoryName="Desktops", Description="AMD Ryzen 5 3600 (3.60 GHz) NVIDIA GeForce GTX 1660 8 GB DDR4 500 GB SSD Windows 10 Home 64-bit", DateAdded=DateTime.Parse("2/10/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=1, Image="slika1.jpg", Price=919.99M, Discount=20},
                    new ProductModel{Name = "ABS PC", CategoryName="Desktops", Description="AMD Ryzen 3 3200G - Radeon Vega 8 - 8GB RAM - 240GB SSD - 1TB HDD - Windows 10 Pro", DateAdded= DateTime.Parse("3/10/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=1, Image="slika1.jpg", Price=649.99m, Discount=0},
                    new ProductModel{Name = "ASUS VivoMini UN65U", CategoryName="Desktops", Description="Intel Core i7-7500U Upto 3.5GHz, 16GB DDR4, 256GB SSD, 4K UHD Support, Card Reader, HDMI, Display Port, Dual-Monitor Capable, Wifi, Bluetooth, USB, Windows 10 Pro", DateAdded = DateTime.Parse("4/10/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=1, Image="slika1.jpg", Price=769.99m, Discount=0},
                    new ProductModel{Name = "Acer Veriton Z4660G", CategoryName="Desktops", Description="All-in-One Computer - Intel Core i3 (8th Gen) i3-8100 3.60 GHz - 4 GB DDR4 SDRAM - 500 GB HDD - 21.5 FHD Non-Touch Display - Windows 10 Pro 64-bit", DateAdded= DateTime.Parse("5/5/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=1, Image="slika1.jpg", Price=799.999m, Discount=5},
                    new ProductModel{Name = "Lenovo ThinkCentre M630e", CategoryName="Desktops", Description="Core i5 i5-8265U - 8 GB RAM - 256 GB SSD - Tiny - Black", DateAdded= DateTime.Parse("2/10/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=1, Image="slika1.jpg", Price=639.99m, Discount=0},
                    new ProductModel{Name = "SkyTech Blaze", CategoryName="Desktops", Description="Ryzen 5 1600 6-Core 3.2 GHz, NVIDIA GeForce GTX 1050 Ti 4GB, 1TB HDD, 16GB DDR4, AC WiFi, Windows 10 Home 64-bit", DateAdded= DateTime.Parse("3/10/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=1, Image="slika1.jpg", Price=749.99m, Discount=0},
                    new ProductModel{Name = "ROG Strix GL12", CategoryName="Desktops", Description="9th Gen 8-core Intel Core i7-9700F, NVIDIA GeForce RTX 2060 6 GB, 16 GB DDR4 RAM, 1 TB PCIe SSD, Windows 10 Home", DateAdded= DateTime.Parse("4/10/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=1, Image="slika1.jpg", Price=1499.00m, Discount=5},
                    new ProductModel{Name = "ABS Rogue H", CategoryName="Desktops", Description="Intel i5 9600K - GeForce RTX 2060 Super - 16GB DDR4 3000MHz - 512GB SSD", DateAdded= DateTime.Parse("5/5/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=1, Image="slika1.jpg", Price=1399.99m, Discount=10},
                    new ProductModel{Name = "Skytech Oracle", CategoryName="Desktops", Description="AMD Ryzen 5 2600, NVIDIA GTX 1660 6 GB, 8 GB DDR4, 500 GB SSD, A320M Motherboard, 500 Watt 80 Plus", DateAdded= DateTime.Parse("2/10/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=1, Image="slika1.jpg", Price=849.99m, Discount=0},


                    // Laptops
                    new ProductModel{Name = "GIGABYTE - AERO 15 OLED SA-7US5020SH", CategoryName="Laptops", Description="Gaming Laptop - 15.6' 4K UHD AMOLED - Intel Core i7-9750H - NVIDIA GeForce GTX 1660 Ti - 8 GB Memory 256 GB SSD - Win 10", DateAdded=DateTime.Parse("4/10/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=2, Image="slika1.jpg", Price=1449, Discount=30},
                    new ProductModel{Name = "Lenovo Laptop 100e", CategoryName="Laptops", Description="Intel Celeron N3450 (1.10 GHz) 4 GB LPDDR4 Memory 128 GB eMMC Intel HD Graphics 500 11.6 Windows 10 Pro 64-bit", DateAdded=DateTime.Parse("5/5/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=2, Image="slika1.jpg", Price=259.99m, Discount=0},
                    new ProductModel{Name = "ASUS VivoBook S15 S532", CategoryName="Laptops", Description="Thin & Light 15.6 FHD, Intel Core i7-8565U CPU, 8 GB DDR4 RAM, PCIe NVMe 512 GB SSD, Windows 10 Home, S532FA-SB77, Transparent Silver", DateAdded=DateTime.Parse("2/5/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=2, Image="slika1.jpg", Price=999.99m, Discount=20},
                    new ProductModel{Name = "HP Grade A Laptop ProBook 640 G2", CategoryName="Laptops", Description="Intel Core i5 6th Gen 6300U (2.40 GHz) 8 GB Memory 256 GB SSD Intel HD Graphics 520 14.0 Windows 10 Pro 64-bit", DateAdded=DateTime.Parse("3/5/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=2, Image="slika1.jpg", Price=499.99m, Discount=10},
                    new ProductModel{Name = "HP Chromebook 11-v000nr", CategoryName="Laptops", Description="11.6 Chromebook - 1366 x 768 - Celeron N3060 -2 GB RAM - 16 GB Flash Memory - Ash Silver", DateAdded=DateTime.Parse("4/5/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=2, Image="slika1.jpg", Price=199.99m, Discount=0},
                    new ProductModel{Name = "Acer Spin 5 SP513-53N-56CR", CategoryName="Laptops", Description="Intel Core i5 8th Gen 8265U (1.60 GHz) 8 GB Memory 256 GB SSD Intel UHD Graphics 620 13.3 Touchscreen 1920 x 1080 Convertible 2-in-1 Laptop Windows 10 Home 64-bit", DateAdded=DateTime.Parse("5/5/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=2, Image="slika1.jpg", Price=799.99m, Discount=5},
                    new ProductModel{Name = "Acer Laptop Aspire 5 A515-54-76TA", CategoryName="Laptops", Description="Intel Core i7 10th Gen 10510U (1.80 GHz) 12 GB Memory 512 GB SSD Intel UHD Graphics 15.6 Windows 10 Home 64-bit", DateAdded=DateTime.Parse("2/5/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=2, Image="slika1.jpg", Price=749.99m, Discount=0},
                    new ProductModel{Name = "Lenovo IdeaPad 130", CategoryName="Laptops", Description="15.6 HD Display, AMD A9-9425 Upto 3.70GHz, 8GB RAM, 512GB SSD, DVDRW, HDMI, Card Reader, Wi-Fi, Bluetooth, Windows 10 Pro", DateAdded=DateTime.Parse("3/5/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=2, Image="slika1.jpg", Price=549.00m, Discount=0},
                    new ProductModel{Name = "MSI Laptop Modern 14 A10RAS-884", CategoryName="Laptops", Description="Intel Core i5 10th Gen 10210U (1.60 GHz) 8 GB Memory 512 GB NVMe SSD NVIDIA GeForce MX330 14.0 Windows 10 Home 64-bit", DateAdded=DateTime.Parse("4/5/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=2, Image="slika1.jpg", Price=799.00m, Discount=0},
                    //new ProductModel{Name = "", CategoryName="Laptops", Description="", DateAdded=DateTime.Parse("5/5/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=2, Image="slika1.jpg", Price=m, Discount=0},
                    //new ProductModel{Name = "", CategoryName="Laptops", Description="", DateAdded=DateTime.Parse("5/5/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=2, Image="slika1.jpg", Price=m, Discount=0},


                    // Processors
                    new ProductModel{Name = "Intel Core i9-9900K Coffee Lake", CategoryName="Processors", Description="8-Core, 16-Thread, 3.6 GHz (5.0 GHz Turbo) LGA 1151 (300 Series) 95W BX80684I99900K Desktop Processor Intel UHD Graphics 630", DateAdded=DateTime.Parse("3/5/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=3, Image="slika1.jpg", Price=529.99m, Discount=0},
                    new ProductModel{Name = "Intel Core i7-9700K Coffee Lake", CategoryName="Processors", Description="8-Core 3.6 GHz (4.9 GHz Turbo) LGA 1151 (300 Series) 95W BX80684I79700K Desktop Processor Intel UHD Graphics 630", DateAdded=DateTime.Parse("4/5/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=3, Image="slika1.jpg", Price=379.99m, Discount=0},
                    new ProductModel{Name = "Intel Core i5-9600K Coffee Lake", CategoryName="Processors", Description="6-Core 3.7 GHz (4.6 GHz Turbo) LGA 1151 (300 Series) 95W BX80684I59600K Desktop Processor Intel UHD Graphics 630", DateAdded=DateTime.Parse("5/5/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=3, Image="slika1.jpg", Price=199.99m, Discount=0},
                    new ProductModel{Name = "AMD RYZEN 5 3600", CategoryName="Processors", Description="6-Core 3.6 GHz (4.2 GHz Max Boost) Socket AM4 65W 100-100000031BOX Desktop Processor", DateAdded=DateTime.Parse("3/5/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=3, Image="slika1.jpg", Price=199.99m, Discount=10},
                    new ProductModel{Name = "AMD RYZEN 7 3700X", CategoryName="Processors", Description="8-Core 3.6 GHz (4.4 GHz Max Boost) Socket AM4 65W 100-100000071BOX Desktop Processor", DateAdded=DateTime.Parse("4/5/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=3, Image="slika1.jpg", Price=329.99m, Discount=10},


                    // Graphics cards
                    new ProductModel{Name = "EVGA GeForce RTX 2060 KO", CategoryName="Graphics cards", Description="ULTRA GAMING Video Card, 06G-P4-2068-KR, 6GB GDDR6, Dual Fans, Metal Backplate", DateAdded=DateTime.Parse("3/5/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=4, Image="slika1.jpg", Price=353.22m, Discount=0},
                    new ProductModel{Name = "MSI Radeon RX 5700", CategoryName="Graphics cards", Description="DirectX 12 RX 5700 EVOKE OC 8GB 256-Bit GDDR6 PCI Express 4.0 HDCP Ready CrossFireX Support Video Card", DateAdded=DateTime.Parse("4/5/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=4, Image="slika1.jpg", Price=673.60m, Discount=0},
                    new ProductModel{Name = "EVGA GeForce RTX 2070 SUPER ", CategoryName="Graphics cards", Description="ULTRA GAMING, 08G-P4-3173-KR, 8GB GDDR6, Dual HDB Fans, RGB LED, Metal Backplate", DateAdded=DateTime.Parse("5/5/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=4, Image="slika1.jpg", Price=549.99m, Discount=0},
                    new ProductModel{Name = "ASRock Phantom Gaming D Radeon RX 570", CategoryName="Graphics cards", Description="DirectX 12 RX570 4G 4GB 256-Bit GDDR5 PCI Express 3.0 x16 HDCP Ready Video Card", DateAdded=DateTime.Parse("3/5/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=4, Image="slika1.jpg", Price=119.99m, Discount=0},
                    new ProductModel{Name = "ASRock Radeon RX 5700 XT", CategoryName="Graphics cards", Description="DirectX 12 RX 5700 XT TAICHI X 8G OC+ 8GB 256-Bit GDDR6 PCI Express 4.0 HDCP Ready Video Card", DateAdded=DateTime.Parse("4/5/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=4, Image="slika1.jpg", Price=479.99m, Discount=10},


                    // Motherboards
                    new ProductModel{Name = "ASUS ROG MAXIMUS XII EXTREME", CategoryName="Motherboards", Description="(WiFi 6) LGA 1200 Intel Z490 SATA 6Gb/s Extended ATX Intel Motherboard (16 Power Stages, Quad M.2, 10Gbps & Intel 2.5Gb LAN, Bundled Fan Extension Card II & ThunderboltEX 3-TR Card, 2 Livedash OLED)", DateAdded=DateTime.Parse("3/5/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=5, Image="slika1.jpg", Price=749.99m, Discount=0},
                    new ProductModel{Name = "GIGABYTE Z490 AORUS XTREME WATERFORCE", CategoryName="Motherboards", Description="LGA 1200 Intel Z490 E-ATX Motherboard with Triple M.2, SATA 6Gb/s, USB 3.2 Gen 2, WIFI 6, 10 GbE LAN, Dual Thunderbolt 3, All-In-One Monoblock", DateAdded=DateTime.Parse("4/5/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=5, Image="slika1.jpg", Price=1299.99m, Discount=0},
                    new ProductModel{Name = "ASUS ROG MAXIMUS XII HERO", CategoryName="Motherboards", Description="(WI-FI) LGA 1200 (Intel 10th Gen) Intel Z490 (WiFi 6) SATA 6Gb/s ATX Intel Motherboard (14+2 Power Stages, DDR4 4800+, 5Gbps LAN, Intel LAN, Bluetooth v5.1, Triple M.2, Aura Sync)", DateAdded=DateTime.Parse("5/5/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=5, Image="slika1.jpg", Price=399.99m, Discount=0},
                    new ProductModel{Name = "GIGABYTE Z490 AORUS MASTER", CategoryName="Motherboards", Description="LGA 1200 Intel Z490 ATX Motherboard with Triple M.2, SATA 6Gb/s, USB 3.2 Gen 2, WIFI 6, 2.5 GbE LAN", DateAdded=DateTime.Parse("3/5/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=5, Image="slika1.jpg", Price=389.99m, Discount=0},
                    new ProductModel{Name = "ASUS PRIME B450M-A/CSM", CategoryName="Motherboards", Description="AM4 AMD B450 SATA 6Gb/s USB 3.1 HDMI Micro ATX AMD Motherboard", DateAdded=DateTime.Parse("4/5/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=5, Image="slika1.jpg", Price=79.99m, Discount=0},


                    // Storage
                    new ProductModel{Name = "Crucial MX500 2.5", CategoryName="Storage", Description="1TB SATA III 3D NAND Internal Solid State Drive (SSD) CT1000MX500SSD1", DateAdded=DateTime.Parse("3/5/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=6, Image="slika1.jpg", Price=119.99m, Discount=10},
                    new ProductModel{Name = "Intel 660p Series M.2 2280", CategoryName="Storage", Description="1TB PCIe NVMe 3.0 x4 3D2, QLC Internal Solid State Drive (SSD) SSDPEKNW010T8X1", DateAdded=DateTime.Parse("4/5/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=6, Image="slika1.jpg", Price=118.99m, Discount=0},
                    new ProductModel{Name = "WD Blue 3D NAND 1TB", CategoryName="Storage", Description="Internal SSD - SATA III 6Gb/s 2.5/7mm Solid State Drive - WDS100T2B0A", DateAdded=DateTime.Parse("5/5/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=6, Image="slika1.jpg", Price=159.99m, Discount=25},
                    new ProductModel{Name = "WD Red 4TB", CategoryName="Storage", Description="NAS Hard Disk Drive - 5400 RPM Class SATA 6Gb/s 64MB Cache 3.5 Inch - WD40EFRX", DateAdded=DateTime.Parse("3/3/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=6, Image="slika1.jpg", Price=109.99m, Discount=0},
                    new ProductModel{Name = "Seagate BarraCuda ST2000DM008", CategoryName="Storage", Description="2TB 7200 RPM 256MB Cache SATA 6.0Gb/s 3.5 Hard Drive Bare Drive", DateAdded=DateTime.Parse("4/5/2020 8:30:52AM", CultureInfo.InvariantCulture), CategoryId=6, Image="slika1.jpg", Price=54.99m, Discount=0}
                };

            Products.ForEach(product => context.Products.AddOrUpdate(s => s.Name, product));
            context.SaveChanges();

            // Users initializer
            var Users = new List<UserModel>
                {
                    new UserModel{FirstName = "Admin", LastName="Admin", EmailAddress="admin@gmail.com", Username="admin", Address=null, City=null, Contact=null, ZipCode=null, PasswordHash="5219ED0176D0561BBE7FD004D1FA49ABA5AC18067B9DD27FDA49FBA98E4DD6EB70AC21BE48007A496558B59308074E9E5E08AE278004B3CD991AA44A6BC7CBFE", Salt="gfBE5FYChkI6RvCoLwm0otmY2VTBMVVtXjs4MAnt3Yk=", DateCreated=null, IsGuest=false}
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
