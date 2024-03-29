namespace Favc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addGenderToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Gender", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Gender");
        }
    }
}
