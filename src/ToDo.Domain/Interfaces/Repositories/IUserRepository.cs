using ToDo.Domain.Entities.Security;

namespace ToDo.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetUserAsync(string email);
    }
}
