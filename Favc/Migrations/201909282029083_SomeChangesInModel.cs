namespace Favc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeChangesInModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Gender", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Gender", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
