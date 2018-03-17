namespace malakar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateRoles : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Roles(Name) VALUES('superadmin')");
            Sql("INSERT INTO Roles(Name) VALUES('admin')");
            Sql("INSERT INTO Roles(Name) VALUES('user')");
        }
        
        public override void Down()
        {
        }
    }
}
