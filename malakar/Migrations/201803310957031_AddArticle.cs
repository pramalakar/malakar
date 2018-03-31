namespace malakar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddArticle : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 100),
                        Brief = c.String(maxLength: 255),
                        Content = c.String(),
                        Published = c.Boolean(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Banner = c.String(),
                        OwnerId = c.Int(nullable: false),
                        StatusID = c.Int(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.ArticleCategories", "Name", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ArticleCategories", "Name", c => c.String());
            DropTable("dbo.Articles");
        }
    }
}
