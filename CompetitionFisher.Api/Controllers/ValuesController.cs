﻿using CompetitionFisher.Data.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CompetitionFisher.Api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : BaseController
    {
        private readonly SchoolContext _context;

        public ValuesController(SchoolContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        [Authorize("read:messages")]
        public IEnumerable<string> Get()
        {
            //return _context.Courses.Select(el => el.Title);
            return new string[] { $"{Auth0UserId}", "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}