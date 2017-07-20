using CompetitionFisher.Data.Models;
using CompetitionFisher.Data.Models.Configurations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CompetitionFisher.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base(nameOrConnectionString: "ApplicationDbContext")
        {
            // Disable proxy creation as this messes up the data service.
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public ApplicationDbContext(string connString) : base(connString)
        {
            // Disable proxy creation as this messes up the data service.
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }


        public DbSet<Championship> Championships { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Contestant> Contestants { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Table names match singular entity names by default (don't pluralize)
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Globally disable the convention for cascading deletes
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            // Entity configurations
            modelBuilder.Configurations.Add(new ChampionshipConfiguration());
            modelBuilder.Configurations.Add(new CompetitionConfiguration());
            modelBuilder.Configurations.Add(new ContestantConfiguration());
        }
    }
}
