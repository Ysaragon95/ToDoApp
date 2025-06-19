using System.Linq.Expressions;

namespace ToDo.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetByIdsAsync(IEnumerable<int> ids, bool includeOnlyActive = true);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task<T?> FindOneOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
