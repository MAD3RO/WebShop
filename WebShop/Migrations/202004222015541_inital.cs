﻿namespace WebShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inital : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblCartDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CartId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblCarts", t => t.CartId)
                .ForeignKey("dbo.tblProducts", t => t.ProductId)
                .Index(t => t.CartId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.tblCarts",
                c => new
                    {
                        CartId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CartId)
                .ForeignKey("dbo.tblUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.tblUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Username = c.String(),
                        EmailAddress = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        ZipCode = c.Long(),
                        Contact = c.Long(),
                        PasswordHash = c.String(),
                        Salt = c.String(),
                        DateCreated = c.DateTime(),
                        IsGuest = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Slug = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategoryName = c.String(),
                        CategoryId = c.Int(nullable: false),
                        ImageName = c.String(),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblCategories", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.tblCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Slug = c.String(),
                        Sorting = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblOrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblOrders", t => t.OrderId)
                .ForeignKey("dbo.tblProducts", t => t.ProductId)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.tblOrders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Status = c.String(),
                        PaymentMethod = c.String(),
                        CreatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.tblUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.tblPages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Slug = c.String(),
                        Body = c.String(),
                        Sorting = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblUserRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.tblRoles", t => t.RoleId)
                .ForeignKey("dbo.tblUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblUserRoles", "UserId", "dbo.tblUsers");
            DropForeignKey("dbo.tblUserRoles", "RoleId", "dbo.tblRoles");
            DropForeignKey("dbo.tblOrderDetails", "ProductId", "dbo.tblProducts");
            DropForeignKey("dbo.tblOrderDetails", "OrderId", "dbo.tblOrders");
            DropForeignKey("dbo.tblOrders", "UserId", "dbo.tblUsers");
            DropForeignKey("dbo.tblCartDetails", "ProductId", "dbo.tblProducts");
            DropForeignKey("dbo.tblProducts", "CategoryId", "dbo.tblCategories");
            DropForeignKey("dbo.tblCartDetails", "CartId", "dbo.tblCarts");
            DropForeignKey("dbo.tblCarts", "UserId", "dbo.tblUsers");
            DropIndex("dbo.tblUserRoles", new[] { "RoleId" });
            DropIndex("dbo.tblUserRoles", new[] { "UserId" });
            DropIndex("dbo.tblOrders", new[] { "UserId" });
            DropIndex("dbo.tblOrderDetails", new[] { "ProductId" });
            DropIndex("dbo.tblOrderDetails", new[] { "OrderId" });
            DropIndex("dbo.tblProducts", new[] { "CategoryId" });
            DropIndex("dbo.tblCarts", new[] { "UserId" });
            DropIndex("dbo.tblCartDetails", new[] { "ProductId" });
            DropIndex("dbo.tblCartDetails", new[] { "CartId" });
            DropTable("dbo.tblUserRoles");
            DropTable("dbo.tblRoles");
            DropTable("dbo.tblPages");
            DropTable("dbo.tblOrders");
            DropTable("dbo.tblOrderDetails");
            DropTable("dbo.tblCategories");
            DropTable("dbo.tblProducts");
            DropTable("dbo.tblUsers");
            DropTable("dbo.tblCarts");
            DropTable("dbo.tblCartDetails");
        }
    }
}
