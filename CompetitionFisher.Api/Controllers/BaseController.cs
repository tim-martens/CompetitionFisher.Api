using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace CompetitionFisher.Api.Controllers
{
    public class BaseController : Controller
    {
        
        public string Auth0UserId
        {
            get
            {
                string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

                // remove auth0| or facebook| from auth0_userId
                // TODO: check out if auth0 uses this when different accounts are joined
                //
                //if (!string.IsNullOrEmpty(userId) && userId.Contains("|"))
                //{
                //    userId = userId.Substring(userId.IndexOf("|") + 1);
                //}

                return userId;
            }
        }
    }
}
