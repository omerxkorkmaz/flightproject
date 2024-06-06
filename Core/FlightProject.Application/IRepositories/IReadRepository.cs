using System.Linq.Expressions;

namespace FlightProject.Application.IRepositories
{
    public interface IReadRepository<T> where T : class, new()
    {
        IQueryable<T> GetFlight(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetNewFlight(Expression<Func<T, bool>> predicate);
    }
}
