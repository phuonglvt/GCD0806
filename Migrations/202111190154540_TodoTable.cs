namespace GCD0806.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TodoTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Todoes", "Descripition");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Todoes", "Descripition", c => c.String());
        }
    }
}
