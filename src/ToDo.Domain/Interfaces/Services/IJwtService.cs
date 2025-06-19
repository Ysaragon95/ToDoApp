using ToDo.Domain.Entities.Security;

namespace ToDo.Domain.Interfaces.Services
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
