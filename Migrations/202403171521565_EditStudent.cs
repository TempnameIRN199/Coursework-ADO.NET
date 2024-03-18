namespace Coursework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditStudent : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Patronymic", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Patronymic", c => c.String(nullable: false));
        }
    }
}
