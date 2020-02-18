namespace WebShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Users : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmailAddress = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Salt = c.String(),
                        DateCreated = c.DateTime()
                    })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.tblUsers");
        }
    }
}
