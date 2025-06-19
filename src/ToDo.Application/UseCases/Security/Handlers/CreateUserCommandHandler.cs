using Mapster;
using MediatR;
using ToDo.Application.DTOs.Security;
using ToDo.Application.UseCases.Security.Command;
using ToDo.Domain.Common.Response;
using ToDo.Domain.Entities.Security;
using ToDo.Domain.Interfaces.Repositories;
using ToDo.Domain.Interfaces.Services;

namespace ToDo.Application.UseCases.Security.Handlers
{
    public class CreateUserCommandHandler(IUserRepository repository,
        IPasswordService passwordService,
        IUnitOfWork unitOfWork) : IRequestHandler<CreateUserCommand, BaseResponse<CreateUserResponse>>
    {
        private readonly IUserRepository _repository = repository;
        private readonly IPasswordService _passwordService = passwordService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<BaseResponse<CreateUserResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (request is null) return BaseResponse<CreateUserResponse>.BadRequest("Ha ocurrido un error con los datos enviados, por favor revisar.");

            User? existUser = await _repository.GetUserAsync(request.Email);

            if (existUser is not null) return BaseResponse<CreateUserResponse>.BadRequest($"{request.Email} ya se encuentra registrado");

            User user = request.Adapt<User>();
            user.PasswordHash = _passwordService.HashPassword(request.Password);

            await _repository.AddAsync(user);

            int saveResult = await _unitOfWork.SaveChangesAsync(cancellationToken);

            if (saveResult <= 0) return BaseResponse<CreateUserResponse>.Error("No se pudo guardar el usuario en la base de datos.");

            var response = new CreateUserResponse() { FullName = $"{request.Name}, {request.LastName}", Email = request.Email };

            return BaseResponse<CreateUserResponse>.Ok(response, "Usuario creado exitosamente.");
        }
    }
}
