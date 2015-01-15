namespace Dylan.AlgorithmTech.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArticleImageInfoes",
                c => new
                    {
                        ArticleImageId = c.Guid(nullable: false, identity: true),
                        Path = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ArticleImageId);
            
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        ArticleId = c.Guid(nullable: false, identity: true),
                        Content = c.String(),
                        Title = c.String(maxLength: 100),
                        TitleImageId = c.Guid(nullable: false),
                        CommiteTime = c.DateTime(nullable: false),
                        ModifyTime = c.DateTime(nullable: false),
                        TagId = c.Guid(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ArticleId)
                .ForeignKey("dbo.ArticleImageInfoes", t => t.TitleImageId, cascadeDelete: true)
                .ForeignKey("dbo.TagInfoes", t => t.TagId)
                .Index(t => t.TitleImageId)
                .Index(t => t.TagId);
            
            CreateTable(
                "dbo.CommentInfoes",
                c => new
                    {
                        CommentId = c.Guid(nullable: false, identity: true),
                        Content = c.String(),
                        CommitTime = c.DateTime(nullable: false),
                        ArticleId = c.Guid(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Articles", t => t.ArticleId)
                .Index(t => t.ArticleId);
            
            CreateTable(
                "dbo.TagInfoes",
                c => new
                    {
                        TagId = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TagId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "TagId", "dbo.TagInfoes");
            DropForeignKey("dbo.CommentInfoes", "ArticleId", "dbo.Articles");
            DropForeignKey("dbo.Articles", "TitleImageId", "dbo.ArticleImageInfoes");
            DropIndex("dbo.CommentInfoes", new[] { "ArticleId" });
            DropIndex("dbo.Articles", new[] { "TagId" });
            DropIndex("dbo.Articles", new[] { "TitleImageId" });
            DropTable("dbo.TagInfoes");
            DropTable("dbo.CommentInfoes");
            DropTable("dbo.Articles");
            DropTable("dbo.ArticleImageInfoes");
        }
    }
}
