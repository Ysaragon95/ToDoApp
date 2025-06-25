using MediatR;
using ToDo.Domain.Common.Response;
using ToDo.Domain.Enum;

namespace ToDo.Application.UseCases.Business.Todo.Command
{
    public record DeleteTodoCommand(int IdTodo) : IRequest<BaseResponse<int>>;
}
