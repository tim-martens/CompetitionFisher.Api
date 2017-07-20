using Breeze.AspNetCore;
using Breeze.Persistence;
using Breeze.Persistence.EF6;
using CompetitionFisher.Data.Context;
using CompetitionFisher.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace CompetitionFisher.Api.Controllers
{
    [Authorize]
    [Route("breeze/[controller]/[action]")]
    [BreezeQueryFilter]
    public class ModelController : BaseController
    {
        private CompetitionFisherPersistenceManager PersistenceManager;

        // called via DI 
        public ModelController(ApplicationDbContext context)
        {
            PersistenceManager = new CompetitionFisherPersistenceManager(context);
        }

        //[Authorize("read:messages")]
        //[HttpGet]
        //public string Auth0Id()
        //{
        //    return $"{Auth0UserId}";
        //}

        [HttpGet]
        public IActionResult Metadata()
        {
            return Ok(PersistenceManager.Metadata());
        }

        [HttpPost]
        public SaveResult SaveChanges([FromBody] JObject saveBundle)
        {
            return PersistenceManager.SaveChanges(saveBundle);
        }

        [HttpGet]
        public IQueryable<Championship> Championships()
        {
            return PersistenceManager.Context.Championships;
        }

        [HttpGet]
        public IQueryable<Competition> Competitions()
        {
            return PersistenceManager.Context.Competitions;
        }

        [HttpGet]
        public IQueryable<Contestant> Contestants()
        {
            return PersistenceManager.Context.Contestants;
        }

        [HttpGet]
        public IQueryable<Result> Results()
        {
            return PersistenceManager.Context.Results;
        }
    }

    internal class CompetitionFisherPersistenceManager : EFPersistenceManager<ApplicationDbContext>
    {
        public CompetitionFisherPersistenceManager(ApplicationDbContext context) : base(context) { }

        // additional stuff goes here. Checkout the NorthwindIBModelController of the Breeze.AspNetCore.InternalTest.sln in the breeze.server.net repo
        // https://github.com/Breeze/breeze.server.net/blob/master/Tests/Test.AspNetCore/Controllers/NorthwindIBModelController.cs
    }
}
