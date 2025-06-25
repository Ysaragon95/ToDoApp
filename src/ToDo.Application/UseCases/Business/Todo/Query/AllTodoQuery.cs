using MediatR;
using ToDo.Application.DTOs.Business.Todo;
using ToDo.Domain.Common.Response;
using ToDo.Domain.Enum;

namespace ToDo.Application.UseCases.Business.Todo.Query
{
    public record AllTodoQuery(int IdUser, EnumStateTodo? StateTodo, string? Name) : IRequest<BaseResponse<List<AllTodoQueryResponse>>>;
}
