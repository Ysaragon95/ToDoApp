using MediatR;
using ToDo.Application.DTOs.Business.Todo;
using ToDo.Application.UseCases.Business.Todo.Query;
using ToDo.Domain.Common.Response;
using ToDo.Domain.Interfaces.Repositories;

namespace ToDo.Application.UseCases.Business.Todo.Handlers
{
    public class AllTodoQueryHandler : IRequestHandler<AllTodoQuery, BaseResponse<List<AllTodoQueryResponse>>>
    {
        private readonly ITodoRepository _todoRepository;

        public AllTodoQueryHandler(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<BaseResponse<List<AllTodoQueryResponse>>> Handle(AllTodoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var todoList = await _todoRepository.GetAllByAsync(x =>
                    x.IdUserCreate == request.IdUser &&
                    (!request.StateTodo.HasValue || x.Status == request.StateTodo.Value) &&
                    (string.IsNullOrWhiteSpace(request.Name) || x.Name.Contains(request.Name))
                );

                if (todoList == null || !todoList.Any())
                {
                    return BaseResponse<List<AllTodoQueryResponse>>.BadRequest("No se encontraron tareas.");
                }

                var response = todoList.Select(todo => new AllTodoQueryResponse
                {
                    Id = todo.Id,
                    Name = todo.Name,
                    Description = todo.Description,
                    Status = todo.Status
                }).ToList();

                return BaseResponse<List<AllTodoQueryResponse>>.Ok(response, "Tareas consutladas exitosamente");
            }
            catch (Exception ex)
            {
                return BaseResponse<List<AllTodoQueryResponse>>.Error(ex.Message);
            }
        }
    }
}
