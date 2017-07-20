namespace CompetitionFisher.Data.Migrations
{
    using CompetitionFisher.Data.Context;
    using CompetitionFisher.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            // uncomment to debug
            //if (System.Diagnostics.Debugger.IsAttached == false)
            //{
            //    System.Diagnostics.Debugger.Launch();
            //}

            #region Constants

            const string auth0UserId1 = "auth0|59671de5a9cbf525f7b23185"; // tim.martens@gmail.com: username/password
            const string auth0UserId2 = "facebook|1305531819521683"; // tim.martens@gmail.com: Facebook

            #endregion

            #region Championships

            var championship1 = new Championship { Id = Guid.NewGuid(), Auth0UserId = auth0UserId1, Name = "Umicore 2016" };
            var championship2 = new Championship { Id = Guid.NewGuid(), Auth0UserId = auth0UserId2, Name = "Umicore 2017" };

            context.Championships.AddOrUpdate(el => el.Name, championship1, championship2);

            #endregion

            #region Contestants

            var contestant1 = new Contestant { Id = Guid.NewGuid(), Auth0UserId = auth0UserId1, FirstName = "Tim", LastName = "Martens" };
            var contestant2 = new Contestant { Id = Guid.NewGuid(), FirstName = "Peter", LastName = "Martens" };
            var contestant3 = new Contestant { Id = Guid.NewGuid(), FirstName = "Johan", LastName = "Van Ginderen" };
            var contestant4 = new Contestant { Id = Guid.NewGuid(), FirstName = "Quinten", LastName = "Van Ginderen" };
            var contestant5 = new Contestant { Id = Guid.NewGuid(), FirstName = "Werner", LastName = "Janssens" };
            var contestant6 = new Contestant { Id = Guid.NewGuid(), FirstName = "Jurgen", LastName = "Verkerken" };
            var contestant7 = new Contestant { Id = Guid.NewGuid(), FirstName = "Eddy", LastName = "Pauwels" };
            var contestant8 = new Contestant { Id = Guid.NewGuid(), FirstName = "Patrick", LastName = "Vanotterdyck" };

            context.Contestants.AddOrUpdate(el => new { el.FirstName, el.LastName },
                contestant1, contestant2, contestant3, contestant4, contestant5, contestant6, contestant7, contestant8);

            #endregion

            #region Competitions

            // championship 2016
            var competition1_1 = new Competition
            {
                Id = Guid.NewGuid(),
                Auth0UserId = auth0UserId1,
                Name = "Wedstrijd 1",
                Date = new DateTime(2016, 02, 10),
                ChampionshipId = championship1.Id,
                Contestants = new List<Contestant> {
                        contestant1, contestant2, contestant3, contestant4, contestant5, contestant6, contestant7, contestant8
                    }
            };
            var competition1_2 = new Competition
            {
                Id = Guid.NewGuid(),
                Auth0UserId = auth0UserId1,
                Name = "Wedstrijd 2",
                Date = new DateTime(2016, 04, 7),
                ChampionshipId = championship1.Id,
                Contestants = new List<Contestant> {
                        contestant2, contestant3, contestant4, contestant5, contestant6, contestant7, contestant8
                    }
            };
            var competition1_3 = new Competition
            {
                Id = Guid.NewGuid(),
                Auth0UserId = auth0UserId1,
                Name = "Wedstrijd 3",
                Date = new DateTime(2016, 05, 23),
                ChampionshipId = championship1.Id,
                Contestants = new List<Contestant> {
                        contestant1, contestant2, contestant3, contestant4, contestant5, contestant6, contestant8
                    }
            };
            var competition1_4 = new Competition
            {
                Id = Guid.NewGuid(),
                Auth0UserId = auth0UserId1,
                Name = "Wedstrijd 4",
                Date = new DateTime(2016, 10, 11),
                ChampionshipId = championship1.Id,
                Contestants = new List<Contestant> {
                        contestant1, contestant2, contestant3, contestant5, contestant6, contestant7, contestant8
                    }
            };
            var competition1_5 = new Competition
            {
                Id = Guid.NewGuid(),
                Auth0UserId = auth0UserId1,
                Name = "Wedstrijd 5",
                Date = new DateTime(2016, 11, 22),
                ChampionshipId = championship1.Id,
                Contestants = new List<Contestant> {
                        contestant1, contestant2, contestant3, contestant4, contestant5, contestant6, contestant7
                    }
            };
            var competition1_6 = new Competition
            {
                Id = Guid.NewGuid(),
                Auth0UserId = auth0UserId1,
                Name = "Wedstrijd 6",
                Date = new DateTime(2016, 12, 7),
                ChampionshipId = championship1.Id,
                Contestants = new List<Contestant> {
                        contestant1, contestant4, contestant5, contestant6, contestant7, contestant8
                    }
            };

            // championship 2017
            var competition2_1 = new Competition
            {
                Id = Guid.NewGuid(),
                Auth0UserId = auth0UserId2,
                Name = "Wedstrijd 1",
                Date = new DateTime(2017, 03, 11),
                ChampionshipId = championship2.Id,
                Contestants = new List<Contestant> {
                        contestant1, contestant2, contestant3, contestant4, contestant5, contestant6, contestant7, contestant8
                    }
            };
            var competition2_2 = new Competition
            {
                Id = Guid.NewGuid(),
                Auth0UserId = auth0UserId2,
                Name = "Wedstrijd 2",
                Date = new DateTime(2017, 04, 18),
                ChampionshipId = championship2.Id,
                Contestants = new List<Contestant> {
                        contestant1, contestant2, contestant4, contestant5, contestant6, contestant7, contestant8
                    }
            };
            var competition2_3 = new Competition
            {
                Id = Guid.NewGuid(),
                Auth0UserId = auth0UserId2,
                Name = "Wedstrijd 3",
                Date = new DateTime(2017, 05, 1),
                ChampionshipId = championship2.Id,
                Contestants = new List<Contestant> {
                        contestant1, contestant2, contestant3, contestant5, contestant6, contestant7, contestant8
                    }
            };
            var competition2_4 = new Competition
            {
                Id = Guid.NewGuid(),
                Auth0UserId = auth0UserId2,
                Name = "Wedstrijd 4",
                Date = new DateTime(2017, 9, 15),
                ChampionshipId = championship2.Id
            };
            var competition2_5 = new Competition
            {
                Id = Guid.NewGuid(),
                Auth0UserId = auth0UserId2,
                Name = "Wedstrijd 5",
                Date = new DateTime(2017, 10, 2),
                ChampionshipId = championship2.Id
            };
            var competition2_6 = new Competition
            {
                Id = Guid.NewGuid(),
                Auth0UserId = auth0UserId2,
                Name = "Wedstrijd 6",
                Date = new DateTime(2017, 11, 17),
                ChampionshipId = championship2.Id
            };

            // competition without championship
            var competition3 = new Competition
            {
                Id = Guid.NewGuid(),
                Auth0UserId = auth0UserId1,
                Name = "Zeevisserforum",
                Date = new DateTime(2017, 6, 10),
                Contestants = new List<Contestant> {
                        contestant1, contestant2, contestant3, contestant4, contestant5, contestant6, contestant8
                    }
            };

            context.Competitions.AddOrUpdate(el => el.Date,
                competition1_1, competition1_2, competition1_3, competition1_4, competition1_5, competition1_6,
                competition2_1, competition2_2, competition2_3, competition2_4, competition2_5, competition2_6,
                competition3
            );

            #endregion

        }

    }
}
