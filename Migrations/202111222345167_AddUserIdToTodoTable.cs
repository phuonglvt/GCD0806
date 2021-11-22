namespace GCD0806.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserIdToTodoTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Todoes", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Todoes", "UserId");
            AddForeignKey("dbo.Todoes", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Todoes", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Todoes", new[] { "UserId" });
            DropColumn("dbo.Todoes", "UserId");
        }
    }
}
