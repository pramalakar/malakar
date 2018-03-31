namespace malakar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddArticleCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArticleCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Content = c.String(),
                        Banner = c.String(),
                        StatusID = c.Int(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ArticleCategories");
        }
    }
}
