using MediatR;
using ToDo.Application.DTOs.Security;
using ToDo.Domain.Common.Response;

namespace ToDo.Application.UseCases.Security.Command
{
    public record CreateUserCommand(string Name,
        string LastName,
        string Email,
        string Password,
        string OperationRegister) : IRequest<BaseResponse<CreateUserResponse>>;
}
