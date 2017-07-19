using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CompetitionFisher.Api.Controllers
{
    public class BaseController : Controller
    {
        public string Auth0UserId
        {
            get
            {
                var claim = User.Claims.FirstOrDefault(x => x.Type == "auth0userId"); // TODO: remove magic string. see https://stackoverflow.com/questions/41046879/asp-mvc-ef6-multi-tenant-based-on-host
                if (claim == null)
                    return string.Empty;

                return claim.Value;
            }
        }
    }
}
