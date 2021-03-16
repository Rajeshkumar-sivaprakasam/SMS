namespace SMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yearsAddedinstring : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Batches", "Year", c => c.String());
            AddColumn("dbo.Courses", "Year", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "Year");
            DropColumn("dbo.Batches", "Year");
        }
    }
}
