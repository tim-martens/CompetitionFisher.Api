namespace CompetitionFisher.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcontestant : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contestant",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Auth0UserId = c.String(maxLength: 50),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContestantCompetition",
                c => new
                    {
                        CompetitionId = c.Guid(nullable: false),
                        ContestantId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompetitionId, t.ContestantId })
                .ForeignKey("dbo.Competition", t => t.CompetitionId, cascadeDelete: true)
                .ForeignKey("dbo.Contestant", t => t.ContestantId, cascadeDelete: true)
                .Index(t => t.CompetitionId)
                .Index(t => t.ContestantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContestantCompetition", "ContestantId", "dbo.Contestant");
            DropForeignKey("dbo.ContestantCompetition", "CompetitionId", "dbo.Competition");
            DropIndex("dbo.ContestantCompetition", new[] { "ContestantId" });
            DropIndex("dbo.ContestantCompetition", new[] { "CompetitionId" });
            DropTable("dbo.ContestantCompetition");
            DropTable("dbo.Contestant");
        }
    }
}
