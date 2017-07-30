namespace malakar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateRoleTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO AspNetRoles(Id, Name) VALUES(1, 'superadmin')");
            Sql("INSERT INTO AspNetRoles(Id, Name) VALUES(2, 'admin')");
            Sql("INSERT INTO AspNetRoles(Id, Name) VALUES(3, 'user')");

        }
        
        public override void Down()
        {
        }
    }
}
