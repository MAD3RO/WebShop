namespace WebShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userRoles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblUserRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.tblRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.tblUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblUserRoles", "UserId", "dbo.tblUsers");
            DropForeignKey("dbo.tblUserRoles", "RoleId", "dbo.tblRoles");
            DropIndex("dbo.tblUserRoles", new[] { "RoleId" });
            DropIndex("dbo.tblUserRoles", new[] { "UserId" });
            DropTable("dbo.tblUserRoles");
        }
    }
}
