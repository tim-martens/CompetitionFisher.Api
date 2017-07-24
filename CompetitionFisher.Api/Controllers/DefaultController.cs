using Breeze.AspNetCore;
using Breeze.Persistence;
using CompetitionFisher.Data.Context;
using CompetitionFisher.Data.UOW;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace CompetitionFisher.Api.Controllers
{
    [Authorize]
    [BreezeQueryFilter]
    public class DefaultController : BaseController
    {
        private readonly UnitOfWork _uow;

        // called via DI 
        public DefaultController(ApplicationDbContext context)
        {
            _uow = new UnitOfWork(context);
        }

        [HttpGet]
        // ~/breeze/metadata
        public IActionResult Metadata()
        {
            return Ok(_uow.Metadata());
        }

        [HttpPost]
        public SaveResult SaveChanges([FromBody] JObject saveBundle)
        {
            return _uow.SaveChanges(saveBundle);
        }

    }
}
