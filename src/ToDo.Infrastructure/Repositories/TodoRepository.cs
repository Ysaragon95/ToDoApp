using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities.Business;
using ToDo.Domain.Interfaces.Repositories;
using ToDo.Infrastructure.Persistence.Context;

namespace ToDo.Infrastructure.Repositories
{
    public class TodoRepository(ApplicationDbContext context) : BaseRepository<Todo>(context), ITodoRepository
    {
        public async Task<Todo?> GetTodoAsync(string name)
        {
            return await _context.Todos
                .FirstOrDefaultAsync(u => u.Name == name);
        }
    }
}
