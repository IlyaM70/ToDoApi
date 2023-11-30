using System.Linq.Expressions;

namespace ToDoApi.Data.Repositories.RepositoryInterfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);
        Task<T> GetAsync(Expression<Func<T, bool>>? filter = null);
        Task CreateAsync(T entity);
        Task RemoveAsync(T entity);
        Task SaveAsync();
    }
}
