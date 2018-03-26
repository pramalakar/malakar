namespace malakar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWidget : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Widgets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Order = c.Int(nullable: false),
                        Key = c.String(),
                        Data = c.String(),
                        Image = c.String(),
                        WidgetRowId = c.Int(nullable: false),
                        StatusID = c.Int(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WidgetRows", t => t.WidgetRowId, cascadeDelete: true)
                .Index(t => t.WidgetRowId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Widgets", "WidgetRowId", "dbo.WidgetRows");
            DropIndex("dbo.Widgets", new[] { "WidgetRowId" });
            DropTable("dbo.Widgets");
        }
    }
}
