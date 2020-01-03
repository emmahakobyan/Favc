namespace Favc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addsubcribenewsletter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsSubcribeToNewsLetter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "IsSubcribeToNewsLetter");
        }
    }
}
