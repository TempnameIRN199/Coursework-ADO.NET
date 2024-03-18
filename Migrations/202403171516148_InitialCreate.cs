namespace Coursework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Disciplines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Issues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EssenceOfIssue = c.String(nullable: false),
                        DisciplineId = c.Int(nullable: false),
                        TypeId = c.Int(nullable: false),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Disciplines", t => t.DisciplineId, cascadeDelete: true)
                .ForeignKey("dbo.Types", t => t.TypeId, cascadeDelete: true)
                .Index(t => t.DisciplineId)
                .Index(t => t.TypeId);
            
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mark = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        StudentId = c.Int(nullable: false),
                        TicketId = c.Int(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Tickets", t => t.TicketId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.TicketId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Surname = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Patronymic = c.String(nullable: false),
                        GroupId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        IssueId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Issues", t => t.IssueId, cascadeDelete: true)
                .Index(t => t.IssueId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Results", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.Tickets", "IssueId", "dbo.Issues");
            DropForeignKey("dbo.Results", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Students", "UserId", "dbo.Users");
            DropForeignKey("dbo.Students", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Issues", "TypeId", "dbo.Types");
            DropForeignKey("dbo.Issues", "DisciplineId", "dbo.Disciplines");
            DropIndex("dbo.Tickets", new[] { "IssueId" });
            DropIndex("dbo.Students", new[] { "UserId" });
            DropIndex("dbo.Students", new[] { "GroupId" });
            DropIndex("dbo.Results", new[] { "TicketId" });
            DropIndex("dbo.Results", new[] { "StudentId" });
            DropIndex("dbo.Issues", new[] { "TypeId" });
            DropIndex("dbo.Issues", new[] { "DisciplineId" });
            DropTable("dbo.Tickets");
            DropTable("dbo.Users");
            DropTable("dbo.Students");
            DropTable("dbo.Results");
            DropTable("dbo.Types");
            DropTable("dbo.Issues");
            DropTable("dbo.Groups");
            DropTable("dbo.Disciplines");
        }
    }
}
