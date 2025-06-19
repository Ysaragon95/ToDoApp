using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ToDo.Domain.Interfaces.Repositories;
using ToDo.Infrastructure.Persistence.Context;

namespace ToDo.Infrastructure.Repositories
{
    /// <summary>
    /// Author: Yedsi Aragon
    /// Description: Implementación genérica del patrón repositorio para realizar operaciones CRUD básicas
    /// </summary>
    /// <typeparam name="T">Tipo de entidad gestionada por el repositorio. Debe ser una clase</typeparam>
    /// <param name="context">Instancia de <see cref="DbContext"/> utilizada para acceder a la base de datos.</param>
    public class BaseRepository<T>(ApplicationDbContext context) : IBaseRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context = context;
        protected readonly DbSet<T> _dbSet = context.Set<T>();

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetByIdsAsync(IEnumerable<int> ids, bool includeOnlyActive = true)
        {
            IQueryable<T> query = _dbSet.Where(entity => ids.Contains(EF.Property<int>(entity, "Id")));

            if (includeOnlyActive)
            {
                query = query.Where(entity => EF.Property<bool>(entity, "StatusRegister") == true);
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<T?> FindOneOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
