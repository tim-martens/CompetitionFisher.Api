using CompetitionFisher.Data.Context;
using CompetitionFisher.Data.Models;
using Breeze.AspNetCore;
using Breeze.Persistence;
using Breeze.Persistence.EF6;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace CompetitionFisher.Api.Controllers
{
    [Route("breeze/[controller]/[action]")]
    [BreezeQueryFilter]
    public class SchoolModelController : BaseController
    {
        private SchoolPersistenceManager PersistenceManager;

        // called via DI 
        public SchoolModelController(ApplicationDbContext context)
        {
            PersistenceManager = new SchoolPersistenceManager(context);
        }

        [Authorize("read:messages")]
        [HttpGet]
        public string Auth0Id()
        {
            //return _context.Courses.Select(el => el.Title);
            return $"{Auth0UserId}";
        }

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
        public IQueryable<Student> Students()
        {
            return PersistenceManager.Context.Students.Include("Enrollments");
        }
    }

    internal class SchoolPersistenceManager : EFPersistenceManager<ApplicationDbContext>
    {
        public SchoolPersistenceManager(ApplicationDbContext context) : base(context) { }

        // additional stuff goes here. Checkout the NorthwindIBModelController of the Breeze.AspNetCore.InternalTest.sln in the breeze.server.net repo
        // https://github.com/Breeze/breeze.server.net/blob/master/Tests/Test.AspNetCore/Controllers/NorthwindIBModelController.cs
    }
}
