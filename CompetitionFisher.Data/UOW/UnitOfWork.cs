using Breeze.Persistence;
using Breeze.Persistence.EF6;
using CompetitionFisher.Data.Context;
using CompetitionFisher.Data.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionFisher.Data.UOW
{
    public class UnitOfWork : EFPersistenceManager<ApplicationDbContext>
    {
        private readonly EFPersistenceManager<ApplicationDbContext> _persistenceManager;

        public UnitOfWork(ApplicationDbContext context) : base(context)
        {
            _persistenceManager = new EFPersistenceManager<ApplicationDbContext>();

            Championships = new Repository<Championship>(_persistenceManager.Context);
            Competitions = new Repository<Competition>(_persistenceManager.Context);
            Contestants = new Repository<Contestant>(_persistenceManager.Context);
            Results = new Repository<Result>(_persistenceManager.Context);
        }


        public IRepository<Championship> Championships { get; private set; }
        public IRepository<Competition> Competitions { get; private set; }
        public IRepository<Contestant> Contestants { get; private set; }
        public IRepository<Result> Results { get; private set; }

        public SaveResult Commit(JObject changeSet)
        {
            return _persistenceManager.SaveChanges(changeSet);
        }

        // additional stuff goes here. Checkout the NorthwindIBModelController of the Breeze.AspNetCore.InternalTest.sln in the breeze.server.net repo
        // https://github.com/Breeze/breeze.server.net/blob/master/Tests/Test.AspNetCore/Controllers/NorthwindIBModelController.cs
    }
}
