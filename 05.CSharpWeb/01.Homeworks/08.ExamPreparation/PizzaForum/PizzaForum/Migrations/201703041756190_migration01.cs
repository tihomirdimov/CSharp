namespace PizzaForum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        PublishDate = c.DateTime(),
                        Author_Id = c.Int(),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Author_Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Author_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Replies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TopicId = c.Int(nullable: false),
                        Content = c.String(),
                        PublishDate = c.DateTime(),
                        ImageUrl = c.String(),
                        Author_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Author_Id)
                .ForeignKey("dbo.Topics", t => t.TopicId, cascadeDelete: true)
                .Index(t => t.TopicId)
                .Index(t => t.Author_Id);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SessionId = c.String(),
                        isActive = c.Boolean(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Logins", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Replies", "TopicId", "dbo.Topics");
            DropForeignKey("dbo.Replies", "Author_Id", "dbo.Users");
            DropForeignKey("dbo.Topics", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Topics", "Author_Id", "dbo.Users");
            DropIndex("dbo.Logins", new[] { "User_Id" });
            DropIndex("dbo.Replies", new[] { "Author_Id" });
            DropIndex("dbo.Replies", new[] { "TopicId" });
            DropIndex("dbo.Topics", new[] { "Category_Id" });
            DropIndex("dbo.Topics", new[] { "Author_Id" });
            DropTable("dbo.Logins");
            DropTable("dbo.Replies");
            DropTable("dbo.Users");
            DropTable("dbo.Topics");
            DropTable("dbo.Categories");
        }
    }
}
