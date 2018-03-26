namespace malakar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWidgetRow : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WidgetRows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Order = c.Int(nullable: false),
                        LayoutId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Layouts", t => t.LayoutId, cascadeDelete: true)
                .Index(t => t.LayoutId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WidgetRows", "LayoutId", "dbo.Layouts");
            DropIndex("dbo.WidgetRows", new[] { "LayoutId" });
            DropTable("dbo.WidgetRows");
        }
    }
}
