namespace WebShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tblUsers", "ZipCode", c => c.Long());
            AlterColumn("dbo.tblUsers", "Contact", c => c.Long());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblUsers", "Contact", c => c.Long(nullable: false));
            AlterColumn("dbo.tblUsers", "ZipCode", c => c.Long(nullable: false));
        }
    }
}
