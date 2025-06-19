using Microsoft.AspNetCore.Identity;
using ToDo.Domain.Interfaces.Services;

namespace ToDo.Infrastructure.Services
{
    public class PasswordService : IPasswordService
    {
        private static readonly PasswordHasher<object> _hasher = new();

        public string HashPassword(string password)
        {
            return _hasher.HashPassword(null!, password);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            var result = _hasher.VerifyHashedPassword(null!, hashedPassword, password);
            return result == PasswordVerificationResult.Success;
        }
    }
}
