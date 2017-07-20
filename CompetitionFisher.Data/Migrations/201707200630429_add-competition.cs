namespace CompetitionFisher.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcompetition : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Enrollment", "CourseId", "dbo.Course");
            DropForeignKey("dbo.Enrollment", "StudentId", "dbo.Student");
            CreateTable(
                "dbo.Championship",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Auth0UserId = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Auth0UserId);
            
            CreateTable(
                "dbo.Competition",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Auth0UserId = c.String(nullable: false, maxLength: 50),
                        ChampionshipId = c.Guid(),
                        Name = c.String(nullable: false, maxLength: 50),
                        Date = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Championship", t => t.ChampionshipId)
                .Index(t => t.Auth0UserId)
                .Index(t => t.ChampionshipId);
            
            AddForeignKey("dbo.Enrollment", "CourseId", "dbo.Course", "Id");
            AddForeignKey("dbo.Enrollment", "StudentId", "dbo.Student", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrollment", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Enrollment", "CourseId", "dbo.Course");
            DropForeignKey("dbo.Competition", "ChampionshipId", "dbo.Championship");
            DropIndex("dbo.Competition", new[] { "ChampionshipId" });
            DropIndex("dbo.Competition", new[] { "Auth0UserId" });
            DropIndex("dbo.Championship", new[] { "Auth0UserId" });
            DropTable("dbo.Competition");
            DropTable("dbo.Championship");
            AddForeignKey("dbo.Enrollment", "StudentId", "dbo.Student", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Enrollment", "CourseId", "dbo.Course", "Id", cascadeDelete: true);
        }
    }
}
