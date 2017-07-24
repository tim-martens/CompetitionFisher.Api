using System.Data.Entity;
using System.Linq;

namespace CompetitionFisher.Data.UOW
{
    internal class Repository<T> : IRepository<T> where T : class
    {
        public Repository(DbContext context)
        {
            Context = context;
        }

        public DbContext Context { get; private set; }
        
        public IQueryable<T> All()
        {
            return Context.Set<T>();
        }
    }
}