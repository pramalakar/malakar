namespace malakar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "StatusID", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "AddedByUID", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "UserID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UserID");
            DropColumn("dbo.Users", "AddedByUID");
            DropColumn("dbo.Users", "DateAdded");
            DropColumn("dbo.Users", "StatusID");
        }
    }
}
