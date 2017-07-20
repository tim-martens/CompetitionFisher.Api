namespace CompetitionFisher.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addresult : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Result",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ContestantId = c.Guid(nullable: false),
                        CompetitionId = c.Guid(nullable: false),
                        TotalNumber = c.Int(nullable: false),
                        TotalWeight = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contestant", t => t.ContestantId)
                .ForeignKey("dbo.Competition", t => t.CompetitionId)
                .Index(t => t.ContestantId)
                .Index(t => t.CompetitionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Result", "CompetitionId", "dbo.Competition");
            DropForeignKey("dbo.Result", "ContestantId", "dbo.Contestant");
            DropIndex("dbo.Result", new[] { "CompetitionId" });
            DropIndex("dbo.Result", new[] { "ContestantId" });
            DropTable("dbo.Result");
        }
    }
}
