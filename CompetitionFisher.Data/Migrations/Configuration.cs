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

            #region Results

            if (!context.Results.Any())
            {
                // 2016 - 1
                var result1_1_1 = new Result { Id = Guid.NewGuid(), Competition = competition1_1, Contestant = contestant1, TotalNumber = 10, TotalWeight = 1220 };
                var result1_1_2 = new Result { Id = Guid.NewGuid(), Competition = competition1_1, Contestant = contestant2, TotalNumber = 0, TotalWeight = 0 };
                var result1_1_3 = new Result { Id = Guid.NewGuid(), Competition = competition1_1, Contestant = contestant3, TotalNumber = 14, TotalWeight = 2100 };
                var result1_1_4 = new Result { Id = Guid.NewGuid(), Competition = competition1_1, Contestant = contestant4, TotalNumber = 12, TotalWeight = 1860 };
                var result1_1_5 = new Result { Id = Guid.NewGuid(), Competition = competition1_1, Contestant = contestant5, TotalNumber = 15, TotalWeight = 2110 };
                var result1_1_6 = new Result { Id = Guid.NewGuid(), Competition = competition1_1, Contestant = contestant6, TotalNumber = 27, TotalWeight = 4560 };
                var result1_1_7 = new Result { Id = Guid.NewGuid(), Competition = competition1_1, Contestant = contestant7, TotalNumber = 2, TotalWeight = 270 };
                var result1_1_8 = new Result { Id = Guid.NewGuid(), Competition = competition1_1, Contestant = contestant8, TotalNumber = 9, TotalWeight = 1300 };

                // 2016 - 2
                var result1_2_2 = new Result { Id = Guid.NewGuid(), Competition = competition1_2, Contestant = contestant2, TotalNumber = 10, TotalWeight = 1120 };
                var result1_2_3 = new Result { Id = Guid.NewGuid(), Competition = competition1_2, Contestant = contestant3, TotalNumber = 11, TotalWeight = 1450 };
                var result1_2_4 = new Result { Id = Guid.NewGuid(), Competition = competition1_2, Contestant = contestant4, TotalNumber = 18, TotalWeight = 2140 };
                var result1_2_5 = new Result { Id = Guid.NewGuid(), Competition = competition1_2, Contestant = contestant5, TotalNumber = 5, TotalWeight = 660 };
                var result1_2_6 = new Result { Id = Guid.NewGuid(), Competition = competition1_2, Contestant = contestant6, TotalNumber = 7, TotalWeight = 870 };
                var result1_2_7 = new Result { Id = Guid.NewGuid(), Competition = competition1_2, Contestant = contestant7, TotalNumber = 12, TotalWeight = 1350 };
                var result1_2_8 = new Result { Id = Guid.NewGuid(), Competition = competition1_2, Contestant = contestant8, TotalNumber = 19, TotalWeight = 1820 };

                // 2016 - 3
                var result1_3_1 = new Result { Id = Guid.NewGuid(), Competition = competition1_3, Contestant = contestant1, TotalNumber = 10, TotalWeight = 1120 };
                var result1_3_2 = new Result { Id = Guid.NewGuid(), Competition = competition1_3, Contestant = contestant2, TotalNumber = 10, TotalWeight = 1120 };
                var result1_3_3 = new Result { Id = Guid.NewGuid(), Competition = competition1_3, Contestant = contestant3, TotalNumber = 11, TotalWeight = 1450 };
                var result1_3_4 = new Result { Id = Guid.NewGuid(), Competition = competition1_3, Contestant = contestant4, TotalNumber = 18, TotalWeight = 2140 };
                var result1_3_5 = new Result { Id = Guid.NewGuid(), Competition = competition1_3, Contestant = contestant5, TotalNumber = 5, TotalWeight = 660 };
                var result1_3_6 = new Result { Id = Guid.NewGuid(), Competition = competition1_3, Contestant = contestant6, TotalNumber = 7, TotalWeight = 870 };
                var result1_3_8 = new Result { Id = Guid.NewGuid(), Competition = competition1_3, Contestant = contestant8, TotalNumber = 19, TotalWeight = 1820 };

                // 2016 - 4 contestant1, contestant2, contestant3, contestant5, contestant6, contestant7, contestant8
                var result1_4_1 = new Result { Id = Guid.NewGuid(), Competition = competition1_4, Contestant = contestant1, TotalNumber = 10, TotalWeight = 1220 };
                var result1_4_2 = new Result { Id = Guid.NewGuid(), Competition = competition1_4, Contestant = contestant2, TotalNumber = 0, TotalWeight = 0 };
                var result1_4_3 = new Result { Id = Guid.NewGuid(), Competition = competition1_4, Contestant = contestant3, TotalNumber = 14, TotalWeight = 2100 };
                var result1_4_5 = new Result { Id = Guid.NewGuid(), Competition = competition1_4, Contestant = contestant5, TotalNumber = 15, TotalWeight = 2110 };
                var result1_4_6 = new Result { Id = Guid.NewGuid(), Competition = competition1_4, Contestant = contestant6, TotalNumber = 27, TotalWeight = 4560 };
                var result1_4_7 = new Result { Id = Guid.NewGuid(), Competition = competition1_4, Contestant = contestant7, TotalNumber = 2, TotalWeight = 270 };
                var result1_4_8 = new Result { Id = Guid.NewGuid(), Competition = competition1_4, Contestant = contestant8, TotalNumber = 9, TotalWeight = 1300 };

                // 2016 - 5 contestant1, contestant2, contestant3, contestant4, contestant5, contestant6, contestant7
                var result1_5_1 = new Result { Id = Guid.NewGuid(), Competition = competition1_5, Contestant = contestant1, TotalNumber = 10, TotalWeight = 1220 };
                var result1_5_2 = new Result { Id = Guid.NewGuid(), Competition = competition1_5, Contestant = contestant2, TotalNumber = 0, TotalWeight = 0 };
                var result1_5_3 = new Result { Id = Guid.NewGuid(), Competition = competition1_5, Contestant = contestant3, TotalNumber = 14, TotalWeight = 2100 };
                var result1_5_4 = new Result { Id = Guid.NewGuid(), Competition = competition1_5, Contestant = contestant4, TotalNumber = 12, TotalWeight = 1860 };
                var result1_5_5 = new Result { Id = Guid.NewGuid(), Competition = competition1_5, Contestant = contestant5, TotalNumber = 15, TotalWeight = 2110 };
                var result1_5_6 = new Result { Id = Guid.NewGuid(), Competition = competition1_5, Contestant = contestant6, TotalNumber = 27, TotalWeight = 4560 };
                var result1_5_7 = new Result { Id = Guid.NewGuid(), Competition = competition1_5, Contestant = contestant7, TotalNumber = 2, TotalWeight = 270 };

                // 2016 - 6 contestant1, contestant4, contestant5, contestant6, contestant7, contestant8
                var result1_6_1 = new Result { Id = Guid.NewGuid(), Competition = competition1_6, Contestant = contestant1, TotalNumber = 10, TotalWeight = 1220 };
                var result1_6_4 = new Result { Id = Guid.NewGuid(), Competition = competition1_6, Contestant = contestant4, TotalNumber = 12, TotalWeight = 1860 };
                var result1_6_5 = new Result { Id = Guid.NewGuid(), Competition = competition1_6, Contestant = contestant5, TotalNumber = 15, TotalWeight = 2110 };
                var result1_6_6 = new Result { Id = Guid.NewGuid(), Competition = competition1_6, Contestant = contestant6, TotalNumber = 27, TotalWeight = 4560 };
                var result1_6_7 = new Result { Id = Guid.NewGuid(), Competition = competition1_6, Contestant = contestant7, TotalNumber = 2, TotalWeight = 270 };
                var result1_6_8 = new Result { Id = Guid.NewGuid(), Competition = competition1_6, Contestant = contestant8, TotalNumber = 9, TotalWeight = 1300 };

                // 2017 - 1 contestant1, contestant2, contestant3, contestant4, contestant5, contestant6, contestant7, contestant8
                var result2_1_1 = new Result { Id = Guid.NewGuid(), Competition = competition2_1, Contestant = contestant1, TotalNumber = 10, TotalWeight = 1220 };
                var result2_1_2 = new Result { Id = Guid.NewGuid(), Competition = competition2_1, Contestant = contestant2, TotalNumber = 0, TotalWeight = 0 };
                var result2_1_3 = new Result { Id = Guid.NewGuid(), Competition = competition2_1, Contestant = contestant3, TotalNumber = 14, TotalWeight = 2100 };
                var result2_1_4 = new Result { Id = Guid.NewGuid(), Competition = competition2_1, Contestant = contestant4, TotalNumber = 12, TotalWeight = 1860 };
                var result2_1_5 = new Result { Id = Guid.NewGuid(), Competition = competition2_1, Contestant = contestant5, TotalNumber = 15, TotalWeight = 2110 };
                var result2_1_6 = new Result { Id = Guid.NewGuid(), Competition = competition2_1, Contestant = contestant6, TotalNumber = 27, TotalWeight = 4560 };
                var result2_1_7 = new Result { Id = Guid.NewGuid(), Competition = competition2_1, Contestant = contestant7, TotalNumber = 2, TotalWeight = 270 };
                var result2_1_8 = new Result { Id = Guid.NewGuid(), Competition = competition2_1, Contestant = contestant8, TotalNumber = 9, TotalWeight = 1300 };

                // 2017 - 2 contestant1, contestant2, contestant4, contestant5, contestant6, contestant7, contestant8
                var result2_2_1 = new Result { Id = Guid.NewGuid(), Competition = competition2_2, Contestant = contestant1, TotalNumber = 10, TotalWeight = 1220 };
                var result2_2_2 = new Result { Id = Guid.NewGuid(), Competition = competition2_2, Contestant = contestant2, TotalNumber = 0, TotalWeight = 0 };
                var result2_2_4 = new Result { Id = Guid.NewGuid(), Competition = competition2_2, Contestant = contestant4, TotalNumber = 12, TotalWeight = 1860 };
                var result2_2_5 = new Result { Id = Guid.NewGuid(), Competition = competition2_2, Contestant = contestant5, TotalNumber = 15, TotalWeight = 2110 };
                var result2_2_6 = new Result { Id = Guid.NewGuid(), Competition = competition2_2, Contestant = contestant6, TotalNumber = 27, TotalWeight = 4560 };
                var result2_2_7 = new Result { Id = Guid.NewGuid(), Competition = competition2_2, Contestant = contestant7, TotalNumber = 2, TotalWeight = 270 };
                var result2_2_8 = new Result { Id = Guid.NewGuid(), Competition = competition2_2, Contestant = contestant8, TotalNumber = 9, TotalWeight = 1300 };

                // 2017 - 3 contestant1, contestant2, contestant3, contestant5, contestant6, contestant7, contestant8
                var result2_3_1 = new Result { Id = Guid.NewGuid(), Competition = competition2_3, Contestant = contestant1, TotalNumber = 10, TotalWeight = 1220 };
                var result2_3_2 = new Result { Id = Guid.NewGuid(), Competition = competition2_3, Contestant = contestant2, TotalNumber = 0, TotalWeight = 0 };
                var result2_3_3 = new Result { Id = Guid.NewGuid(), Competition = competition2_3, Contestant = contestant3, TotalNumber = 14, TotalWeight = 2100 };
                var result2_3_5 = new Result { Id = Guid.NewGuid(), Competition = competition2_3, Contestant = contestant5, TotalNumber = 15, TotalWeight = 2110 };
                var result2_3_6 = new Result { Id = Guid.NewGuid(), Competition = competition2_3, Contestant = contestant6, TotalNumber = 27, TotalWeight = 4560 };
                var result2_3_7 = new Result { Id = Guid.NewGuid(), Competition = competition2_3, Contestant = contestant7, TotalNumber = 2, TotalWeight = 270 };
                var result2_3_8 = new Result { Id = Guid.NewGuid(), Competition = competition2_3, Contestant = contestant8, TotalNumber = 9, TotalWeight = 1300 };

                // Wedstrijd Zeevisserforum contestant1, contestant2, contestant3, contestant4, contestant5, contestant6, contestant8
                var result3_1 = new Result { Id = Guid.NewGuid(), Competition = competition3, Contestant = contestant1, TotalNumber = 10, TotalWeight = 1220 };
                var result3_2 = new Result { Id = Guid.NewGuid(), Competition = competition3, Contestant = contestant2, TotalNumber = 0, TotalWeight = 0 };
                var result3_3 = new Result { Id = Guid.NewGuid(), Competition = competition3, Contestant = contestant3, TotalNumber = 14, TotalWeight = 2100 };
                var result3_4 = new Result { Id = Guid.NewGuid(), Competition = competition3, Contestant = contestant4, TotalNumber = 12, TotalWeight = 1860 };
                var result3_5 = new Result { Id = Guid.NewGuid(), Competition = competition3, Contestant = contestant5, TotalNumber = 15, TotalWeight = 2110 };
                var result3_6 = new Result { Id = Guid.NewGuid(), Competition = competition3, Contestant = contestant6, TotalNumber = 27, TotalWeight = 4560 };
                var result3_7 = new Result { Id = Guid.NewGuid(), Competition = competition3, Contestant = contestant7, TotalNumber = 2, TotalWeight = 270 };
                var result3_8 = new Result { Id = Guid.NewGuid(), Competition = competition3, Contestant = contestant8, TotalNumber = 9, TotalWeight = 1300 };

                context.Results.Add(result1_1_1);
                context.Results.Add(result1_1_2);
                context.Results.Add(result1_1_3);
                context.Results.Add(result1_1_4);
                context.Results.Add(result1_1_5);
                context.Results.Add(result1_1_6);
                context.Results.Add(result1_1_7);
                context.Results.Add(result1_1_8);

                context.Results.Add(result1_2_2);
                context.Results.Add(result1_2_3);
                context.Results.Add(result1_2_4);
                context.Results.Add(result1_2_5);
                context.Results.Add(result1_2_6);
                context.Results.Add(result1_2_7);
                context.Results.Add(result1_2_8);

                context.Results.Add(result1_3_1);
                context.Results.Add(result1_3_2);
                context.Results.Add(result1_3_3);
                context.Results.Add(result1_3_4);
                context.Results.Add(result1_3_5);
                context.Results.Add(result1_3_6);
                context.Results.Add(result1_3_8);

                context.Results.Add(result1_4_1);
                context.Results.Add(result1_4_2);
                context.Results.Add(result1_4_3);
                context.Results.Add(result1_4_5);
                context.Results.Add(result1_4_6);
                context.Results.Add(result1_4_7);
                context.Results.Add(result1_4_8);

                context.Results.Add(result1_5_1);
                context.Results.Add(result1_5_2);
                context.Results.Add(result1_5_3);
                context.Results.Add(result1_5_4);
                context.Results.Add(result1_5_5);
                context.Results.Add(result1_5_6);
                context.Results.Add(result1_5_7);

                context.Results.Add(result1_6_1);
                context.Results.Add(result1_6_4);
                context.Results.Add(result1_6_5);
                context.Results.Add(result1_6_6);
                context.Results.Add(result1_6_7);
                context.Results.Add(result1_6_8);

                context.Results.Add(result2_1_1);
                context.Results.Add(result2_1_2);
                context.Results.Add(result2_1_3);
                context.Results.Add(result2_1_4);
                context.Results.Add(result2_1_5);
                context.Results.Add(result2_1_6);
                context.Results.Add(result2_1_7);
                context.Results.Add(result2_1_8);

                context.Results.Add(result2_2_1);
                context.Results.Add(result2_2_2);
                context.Results.Add(result2_2_4);
                context.Results.Add(result2_2_5);
                context.Results.Add(result2_2_6);
                context.Results.Add(result2_2_7);
                context.Results.Add(result2_2_8);

                context.Results.Add(result2_3_1);
                context.Results.Add(result2_3_2);
                context.Results.Add(result2_3_3);
                context.Results.Add(result2_3_5);
                context.Results.Add(result2_3_6);
                context.Results.Add(result2_3_7);
                context.Results.Add(result2_3_8);

                context.Results.Add(result3_1);
                context.Results.Add(result3_2);
                context.Results.Add(result3_3);
                context.Results.Add(result3_4);
                context.Results.Add(result3_5);
                context.Results.Add(result3_6);
                context.Results.Add(result3_7);
                context.Results.Add(result3_8);
            }

            #endregion

        }

    }
}
