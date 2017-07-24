using System.Linq;

namespace CompetitionFisher.Data.UOW
{
    public interface IRepository<out T>
    {
        IQueryable<T> All();
    }
}
