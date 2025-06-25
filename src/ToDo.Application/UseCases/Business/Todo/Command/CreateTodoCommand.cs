using MediatR;
using ToDo.Domain.Common.Response;

namespace ToDo.Application.UseCases.Business.Todo.Command
{
    public record CreateTodoCommand(
        string Name,
        string Description,
        int IdUserCreate
    ) : IRequest<BaseResponse<int>>;
}
