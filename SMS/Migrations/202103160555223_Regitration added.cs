namespace SMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Regitrationadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Registrations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastNamme = c.String(),
                        CourseId = c.String(),
                        BatchId = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Registrations");
        }
    }
}
