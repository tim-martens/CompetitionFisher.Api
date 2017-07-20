using Breeze.AspNetCore;
using Breeze.Core;
using CompetitionFisher.Api.Infrastructure;
using CompetitionFisher.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;

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

            var connString = Configuration.GetConnectionString("ApplicationDbContext");
            services.AddScoped<ApplicationDbContext>(_ => new ApplicationDbContext(connString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            var options = new JwtBearerOptions
            {
                Audience = Configuration["Auth0:ApiIdentifier"],
                Authority = $"https://{Configuration["Auth0:Domain"]}/"
            };

            app.UseJwtBearerAuthentication(options);
            app.UseMvc();

        }
    }
}
