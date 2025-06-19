using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities.Security;
using ToDo.Domain.Interfaces.Repositories;
using ToDo.Infrastructure.Persistence.Context;

namespace ToDo.Infrastructure.Repositories
{
    public class UserRepository(ApplicationDbContext context) : BaseRepository<User>(context), IUserRepository
    {
        /// <summary>
        /// Obtiene un usuario de la base de datos por su email.
        /// </summary>
        /// <param name="email">Parametro de busqueda para usuario</param>
        /// <returns></returns>
        public async Task<User?> GetUserAsync(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
