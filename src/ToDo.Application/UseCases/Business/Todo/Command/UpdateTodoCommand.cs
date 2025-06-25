using MediatR;
using ToDo.Domain.Common.Response;
using ToDo.Domain.Enum;

namespace ToDo.Application.UseCases.Business.Todo.Command
{
    public record UpdateTodoCommand(int IdTodo,
        string Name,
        string Description,
        EnumStateTodo Status,
        bool IsCompleted,
        int IdUserCreate) : IRequest<BaseResponse<int>>;
}
