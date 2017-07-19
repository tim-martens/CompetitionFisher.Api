using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Breeze.Core;
using Newtonsoft.Json.Serialization;
using Breeze.AspNetCore;
using CompetitionFisher.Data.Context;
using CompetitionFisher.Api.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;
using System.Linq;
using System.Threading.Tasks;

namespace CompetitionFisher.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            var mvcBuilder = services.AddMvc();

            //Auth0
            string domain = $"https://{Configuration["Auth0:Domain"]}/";
            services.AddAuthorization(options =>
            {
                options.AddPolicy("read:messages",
                    policy => policy.Requirements.Add(new HasScopeRequirement("read:messages", domain)));
                options.AddPolicy("create:messages",
                    policy => policy.Requirements.Add(new HasScopeRequirement("create:messages", domain)));
            });

            //Breeze
            mvcBuilder.AddJsonOptions(opt => {
                var ss = JsonSerializationFns.UpdateWithDefaults(opt.SerializerSettings);
                var resolver = ss.ContractResolver;
                if (resolver != null)
                {
                    var res = resolver as DefaultContractResolver;
                    res.NamingStrategy = null;  // <<!-- this removes the camelcasing
                }

            });

            mvcBuilder.AddMvcOptions(o => { o.Filters.Add(new GlobalExceptionFilter()); });

            var connString = Configuration.GetConnectionString("SchoolContext");
            services.AddScoped<SchoolContext>(_ => new SchoolContext(connString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            var options = new JwtBearerOptions
            {
                Audience = Configuration["Auth0:ApiIdentifier"],
                Authority = $"https://{Configuration["Auth0:Domain"]}/",
                Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        // If you need the user's information for any reason at this point, you can get it by looking at the Claims property
                        // of context.Ticket.Principal.Identity
                        var claimsIdentity = context.Ticket.Principal.Identity as ClaimsIdentity;
                        if (claimsIdentity != null)
                        {
                            // Get the user's ID
                            string userId = claimsIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

                            if (!string.IsNullOrEmpty(userId) && userId.Contains("|"))
                            {
                                userId = userId.Substring(userId.IndexOf("|") + 1);
                            }
                            claimsIdentity.AddClaim(new Claim("auth0userId", userId));

                            // Get the name
                            string name = claimsIdentity.Claims.FirstOrDefault(c => c.Type == "name")?.Value;
                        }

                        return Task.FromResult(0);
                    }
                }
            };
            app.UseJwtBearerAuthentication(options);

            app.UseMvc();
        }
    }
}
