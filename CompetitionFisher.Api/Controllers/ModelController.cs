using Breeze.AspNetCore;
using Breeze.Persistence;
using Breeze.Persistence.EF6;
using CompetitionFisher.Data.Context;
using CompetitionFisher.Data.Models;
using CompetitionFisher.Data.UOW;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Data.Entity;
using System.Linq;

namespace CompetitionFisher.Api.Controllers
{
    [Authorize]
    [BreezeQueryFilter]
    public class ModelController : BaseController
    {
        private readonly UnitOfWork _uow;

        // called via DI 
        public ModelController(ApplicationDbContext context)
        {
            _uow = new UnitOfWork(context);
        }

        //[Authorize("read:messages")]
        //[HttpGet]
        //public string Auth0Id()
        //{
        //    return $"{Auth0UserId}";
        //}

        [HttpGet]
        // ~breeze/model/championships
        public IQueryable<Championship> Championships()
        {
            return _uow.Championships.All();
        }

        [HttpGet]
        // ~breeze/model/competitions
        public IQueryable<Competition> Competitions()
        {
            return _uow.Competitions.All()
                .Include(el => el.Championship);
        }

        [HttpGet]
        // ~breeze/model/contestants
        public IQueryable<Contestant> Contestants()
        {
            return _uow.Contestants.All();
        }

        [HttpGet]
        // ~breeze/model/results
        public IQueryable<Result> Results()
        {
            return _uow.Results.All();
        }
    }
}
