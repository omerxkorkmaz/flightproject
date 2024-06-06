using FlightProject.Application.IRepositories;
using FlightProject.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FlightProject.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : class, new()
    {   
        private readonly FlightDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public ReadRepository(FlightDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
 

        public IQueryable<T> GetFlight(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).AsQueryable();
        }

        public IQueryable<T> GetNewFlight(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).AsQueryable();
        }
    }
}
