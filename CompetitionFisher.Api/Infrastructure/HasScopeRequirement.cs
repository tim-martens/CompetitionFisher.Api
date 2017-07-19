using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompetitionFisher.Api.Infrastructure
{
    public class HasScopeRequirement : AuthorizationHandler<HasScopeRequirement>, IAuthorizationRequirement
    {
        private readonly string issuer;
        private readonly string scope;

        public HasScopeRequirement(string scope, string issuer)
        {
            this.scope = scope;
            this.issuer = issuer;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HasScopeRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == "scope" && c.Issuer == issuer))
                //return Task.CompletedTask;
                return Task.FromResult(true);

            var scopes = context.User.FindFirst(c => c.Type == "scope" && c.Issuer == issuer).Value.Split(' ');

            if (scopes.Any(s => s == scope))
                context.Succeed(requirement);

            return Task.FromResult(true);
            //return Task.CompletedTask;
        }
    }
}
