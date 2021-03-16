namespace SMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeyAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Registrations", "LastName", c => c.String());
            AlterColumn("dbo.Registrations", "CourseId", c => c.Int());
            AlterColumn("dbo.Registrations", "BatchId", c => c.Int());
            CreateIndex("dbo.Registrations", "CourseId");
            CreateIndex("dbo.Registrations", "BatchId");
            AddForeignKey("dbo.Registrations", "BatchId", "dbo.Batches", "Id");
            AddForeignKey("dbo.Registrations", "CourseId", "dbo.Courses", "Id");
            DropColumn("dbo.Registrations", "LastNamme");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Registrations", "LastNamme", c => c.String());
            DropForeignKey("dbo.Registrations", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Registrations", "BatchId", "dbo.Batches");
            DropIndex("dbo.Registrations", new[] { "BatchId" });
            DropIndex("dbo.Registrations", new[] { "CourseId" });
            AlterColumn("dbo.Registrations", "BatchId", c => c.String());
            AlterColumn("dbo.Registrations", "CourseId", c => c.String());
            DropColumn("dbo.Registrations", "LastName");
        }
    }
}
