namespace Coursework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditDatabase1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "IssueId", "dbo.Issues");
            DropIndex("dbo.Tickets", new[] { "IssueId" });
            AddColumn("dbo.Issues", "TicketId", c => c.Int());
            CreateIndex("dbo.Issues", "TicketId");
            AddForeignKey("dbo.Issues", "TicketId", "dbo.Tickets", "Id");
            DropColumn("dbo.Tickets", "IssueId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "IssueId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Issues", "TicketId", "dbo.Tickets");
            DropIndex("dbo.Issues", new[] { "TicketId" });
            DropColumn("dbo.Issues", "TicketId");
            CreateIndex("dbo.Tickets", "IssueId");
            AddForeignKey("dbo.Tickets", "IssueId", "dbo.Issues", "Id", cascadeDelete: true);
        }
    }
}
