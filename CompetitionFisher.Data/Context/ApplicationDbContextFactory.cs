using System.Data.Entity.Infrastructure;

namespace CompetitionFisher.Data.Context
{
    public class ApplicationDbContextFactory : IDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext Create()
        {
            return new ApplicationDbContext("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CompetitionFisher;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
