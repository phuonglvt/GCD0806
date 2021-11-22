namespace GCD0806.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TodoTableModification1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Todoes", "Description", c => c.String());
            AddColumn("dbo.Todoes", "DueDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Todoes", "DueDate");
            DropColumn("dbo.Todoes", "Description");
        }
    }
}
