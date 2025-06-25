using ToDo.Domain.Entities.Business;

namespace ToDo.Domain.Interfaces.Repositories
{
    public interface ITodoRepository : IBaseRepository<Todo>
    {
        Task<Todo?> GetTodoAsync(string name);
    }
}
