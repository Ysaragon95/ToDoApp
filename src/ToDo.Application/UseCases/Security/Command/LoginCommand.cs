using MediatR;
using ToDo.Application.DTOs.Security;
using ToDo.Domain.Common.Response;

namespace ToDo.Application.UseCases.Security.Command
{
    public record LoginCommand(string Email, string Password) : IRequest<BaseResponse<AuthResponse>>;
}
