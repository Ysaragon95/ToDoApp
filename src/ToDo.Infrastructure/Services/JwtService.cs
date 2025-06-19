using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ToDo.Domain.Common.Configuration;
using ToDo.Domain.Entities.Security;
using ToDo.Domain.Interfaces.Services;

namespace ToDo.Infrastructure.Services
{
    public class JwtService(IOptions<JwtOption> jwtOption) : IJwtService
    {
        private readonly JwtOption _jwtOption = jwtOption.Value;

        public string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOption.SecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, user.Email),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Email, user.Email),
            };

            var token = new JwtSecurityToken(
                issuer: _jwtOption.ValidIssuer,
                audience: _jwtOption.ValidAudience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
