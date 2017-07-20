namespace CompetitionFisher.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delschoolcontext : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Enrollment", "CourseId", "dbo.Course");
            DropForeignKey("dbo.Enrollment", "StudentId", "dbo.Student");
            DropIndex("dbo.Enrollment", new[] { "CourseId" });
            DropIndex("dbo.Enrollment", new[] { "StudentId" });
            DropTable("dbo.Course");
            DropTable("dbo.Enrollment");
            DropTable("dbo.Student");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        LastName = c.String(),
                        FirstName = c.String(),
                        EnrollmentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Enrollment",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        Grade = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Title = c.String(),
                        Credits = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Enrollment", "StudentId");
            CreateIndex("dbo.Enrollment", "CourseId");
            AddForeignKey("dbo.Enrollment", "StudentId", "dbo.Student", "Id");
            AddForeignKey("dbo.Enrollment", "CourseId", "dbo.Course", "Id");
        }
    }
}
