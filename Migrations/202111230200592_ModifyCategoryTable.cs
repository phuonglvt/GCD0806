namespace GCD0806.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyCategoryTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "Description", c => c.String());
        }
    }
}
