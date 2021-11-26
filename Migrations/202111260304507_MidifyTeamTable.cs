namespace GCD0806.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MidifyTeamTable : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Teams", "Name", unique: true, name: "UniqueName");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Teams", "UniqueName");
        }
    }
}
