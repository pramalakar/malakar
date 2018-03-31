namespace malakar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddArticleCategoryToArticle : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArticleCategoryToArticles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArticleCategoryId = c.Int(nullable: false),
                        ArticleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .ForeignKey("dbo.ArticleCategories", t => t.ArticleCategoryId, cascadeDelete: true)
                .Index(t => t.ArticleCategoryId)
                .Index(t => t.ArticleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArticleCategoryToArticles", "ArticleCategoryId", "dbo.ArticleCategories");
            DropForeignKey("dbo.ArticleCategoryToArticles", "ArticleId", "dbo.Articles");
            DropIndex("dbo.ArticleCategoryToArticles", new[] { "ArticleId" });
            DropIndex("dbo.ArticleCategoryToArticles", new[] { "ArticleCategoryId" });
            DropTable("dbo.ArticleCategoryToArticles");
        }
    }
}
