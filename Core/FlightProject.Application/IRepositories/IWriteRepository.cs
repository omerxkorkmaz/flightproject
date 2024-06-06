using System.Linq.Expressions;

namespace FlightProject.Application.IRepositories
{
    public interface IWriteRepository<T> where T : class , new()
    {
        Task Add(T entity);
        Task Update(T entity);
     
    }
}
