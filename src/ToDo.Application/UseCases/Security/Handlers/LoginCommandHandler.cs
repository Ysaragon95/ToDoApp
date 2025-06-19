using MediatR;
using ToDo.Application.DTOs.Security;
using ToDo.Application.UseCases.Security.Command;
using ToDo.Domain.Common.Response;
using ToDo.Domain.Interfaces.Repositories;
using ToDo.Domain.Interfaces.Services;

namespace ToDo.Application.UseCases.Security.Handlers
{
    public class LoginCommandHandler(IUserRepository userRepository, IJwtService jwtService, IPasswordService passwordService) : IRequestHandler<LoginCommand, BaseResponse<AuthResponse>>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IJwtService _jwtService = jwtService;
        private readonly IPasswordService _passwordService = passwordService;

        public async Task<BaseResponse<AuthResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserAsync(request.Email);

            if (user == null)
                return BaseResponse<AuthResponse>.NotFound($"Correo {request.Email} no registrado en el sistema.");

            if (!VerifyPassword(request.Password, user.PasswordHash))
                return BaseResponse<AuthResponse>.BadRequest("Contraseña incorrecta.");

            var token = _jwtService.GenerateToken(user);

            var authResponse = new AuthResponse
            {
                IdUser = user.Id,
                UserName = $"{user.Name} {user.LastName}",
                Token = token,
                Expiration = DateTime.Now.AddMinutes(60)
            };

            return BaseResponse<AuthResponse>.Ok(authResponse, "Acceso correcto.");
        }

        private bool VerifyPassword(string password, string salt)
        {
            return _passwordService.VerifyPassword(password, salt);
        }
    }
}
