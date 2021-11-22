namespace GCD0806.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TodoTableModification : DbMigration
    {
        public override void Up()
        {
        //  DropColumn("dbo.Todoes", "Description");
           DropColumn("dbo.Todoes", "DueDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Todoes", "DueDate", c => c.DateTime(nullable: false));
         //   AddColumn("dbo.Todoes", "Description", c => c.String());
        }
    }
}
