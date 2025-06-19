using ToDo.Domain.Entities.Common;

namespace ToDo.Domain.Entities.Security
{
    public sealed class User : EntityBase
    {
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
    }
}
