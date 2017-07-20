namespace CompetitionFisher.Data.Migrations
{
    using CompetitionFisher.Data.Context;
    using CompetitionFisher.Data.Models;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            const string auth0UserId1 = "auth0|59671de5a9cbf525f7b23185"; // tim.martens@gmail.com: username/password
            const string auth0UserId2 = "facebook|1305531819521683"; // tim.martens@gmail.com: Facebook

            Guid championshipId1 = Guid.NewGuid();
            Guid championshipId2 = Guid.NewGuid();

            Guid competitionId1_1 = Guid.NewGuid();
            Guid competitionId1_2 = Guid.NewGuid();
            Guid competitionId1_3 = Guid.NewGuid();
            Guid competitionId1_4 = Guid.NewGuid();
            Guid competitionId1_5 = Guid.NewGuid();
            Guid competitionId1_6 = Guid.NewGuid();

            Guid competitionId2_1 = Guid.NewGuid();
            Guid competitionId2_2 = Guid.NewGuid();
            Guid competitionId2_3 = Guid.NewGuid();
            Guid competitionId2_4 = Guid.NewGuid();
            Guid competitionId2_5 = Guid.NewGuid();
            Guid competitionId2_6 = Guid.NewGuid();

            Guid competitionId3 = Guid.NewGuid(); // For competition without championship

            context.Championships.AddOrUpdate(
                el => el.Name,
                new Championship { Id = championshipId1, Auth0UserId = auth0UserId1, Name = "Umicore 2016" },
                new Championship { Id = championshipId2, Auth0UserId = auth0UserId2, Name = "Umicore 2017" }
                );

            context.Competitions.AddOrUpdate(
                el => el.Date,
                new Competition { Id = competitionId1_1, Auth0UserId = auth0UserId1, Name = "Wedstrijd 1", Date = new DateTime(2016, 02, 10), ChampionshipId = championshipId1 },
                new Competition { Id = competitionId1_2, Auth0UserId = auth0UserId1, Name = "Wedstrijd 2", Date = new DateTime(2016, 04, 7), ChampionshipId = championshipId1 },
                new Competition { Id = competitionId1_3, Auth0UserId = auth0UserId1, Name = "Wedstrijd 3", Date = new DateTime(2016, 05, 23), ChampionshipId = championshipId1 },
                new Competition { Id = competitionId1_4, Auth0UserId = auth0UserId1, Name = "Wedstrijd 4", Date = new DateTime(2016, 10, 11), ChampionshipId = championshipId1 },
                new Competition { Id = competitionId1_5, Auth0UserId = auth0UserId1, Name = "Wedstrijd 5", Date = new DateTime(2016, 11, 22), ChampionshipId = championshipId1 },
                new Competition { Id = competitionId1_6, Auth0UserId = auth0UserId1, Name = "Wedstrijd 6", Date = new DateTime(2016, 12, 7), ChampionshipId = championshipId1 },

                new Competition { Id = competitionId2_1, Auth0UserId = auth0UserId2, Name = "Wedstrijd 1", Date = new DateTime(2017, 03, 11), ChampionshipId = championshipId2 },
                new Competition { Id = competitionId2_2, Auth0UserId = auth0UserId2, Name = "Wedstrijd 2", Date = new DateTime(2017, 04, 18), ChampionshipId = championshipId2 },
                new Competition { Id = competitionId2_3, Auth0UserId = auth0UserId2, Name = "Wedstrijd 3", Date = new DateTime(2017, 05, 1), ChampionshipId = championshipId2 },
                new Competition { Id = competitionId2_4, Auth0UserId = auth0UserId2, Name = "Wedstrijd 4", Date = new DateTime(2017, 9, 15), ChampionshipId = championshipId2 },
                new Competition { Id = competitionId2_5, Auth0UserId = auth0UserId2, Name = "Wedstrijd 5", Date = new DateTime(2017, 10, 2), ChampionshipId = championshipId2 },
                new Competition { Id = competitionId2_6, Auth0UserId = auth0UserId2, Name = "Wedstrijd 6", Date = new DateTime(2017, 11, 17), ChampionshipId = championshipId2 },

                new Competition { Id = competitionId3, Auth0UserId = auth0UserId1, Name = "Zeevisserforum", Date = new DateTime(2017, 6, 10) }
            );




            //context.Students.AddOrUpdate(
            //    el => el.Id,
            //    new Student { Id = 1, FirstName = "Dick", LastName = "Tator", EnrollmentDate = DateTime.Now.AddDays(-20) },
            //    new Student { Id = 2, FirstName = "Miss", LastName = "Tress", EnrollmentDate = DateTime.Now.AddDays(-10) });

            //context.Courses.AddOrUpdate(
            //    el => el.Id,
            //    new Course { Id = 1, Credits = 8, Title = "Using Breeze with ASP.NET Core" },
            //    new Course { Id = 2, Credits = 9, Title = "Intro EF 6" });

            //context.Enrollments.AddOrUpdate(
            //    el => el.Id,
            //    new Enrollment { Id = 1, CourseId = 1, StudentId = 1, Grade = Grade.B },
            //    new Enrollment { Id = 2, CourseId = 1, StudentId = 2, Grade = Grade.A },
            //    new Enrollment { Id = 3, CourseId = 2, StudentId = 2, Grade = Grade.A }
            //    );
        }
    }
}
