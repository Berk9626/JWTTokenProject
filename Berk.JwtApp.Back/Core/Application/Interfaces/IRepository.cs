using System.Linq.Expressions;

namespace Berk.JwtApp.Back.Core.Application.Interfaces
{
    public interface IRepository<T> where T : class, new()
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(object id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);

        Task<T?> GetByFilter(Expression<Func<T, bool>> filter);

    }
}
