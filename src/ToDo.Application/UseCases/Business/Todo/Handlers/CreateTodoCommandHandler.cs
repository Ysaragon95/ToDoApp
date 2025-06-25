using Mapster;
using MediatR;
using ToDo.Application.UseCases.Business.Todo.Command;
using ToDo.Domain.Common.Response;
using ToDo.Domain.Enum;
using ToDo.Domain.Interfaces.Repositories;

namespace ToDo.Application.UseCases.Business.Todo.Handlers
{
    public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, BaseResponse<int>>
    {
        private readonly ITodoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateTodoCommandHandler(ITodoRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<int>> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            if (request is null) return BaseResponse<int>.BadRequest("Ha ocurrido un error con los datos enviados, por favor revisar.");

            var existTodo = await _repository.GetTodoAsync(request.Name.Trim());

            if (existTodo is not null) return BaseResponse<int>.BadRequest($"La tarea '{request.Name}' ya se encuentra registrado.");

            var todo = request.Adapt<Domain.Entities.Business.Todo>();

            todo.Status = EnumStateTodo.NotStarted;
            todo.IsCompleted = false;
            todo.OperationRegister = "Creación de tarea";

            await _repository.AddAsync(todo);

            int saveResult = await _unitOfWork.SaveChangesAsync(cancellationToken);

            if (saveResult <= 0) return BaseResponse<int>.Error("No se pudo guardar la tarea en la base de datos.");

            return BaseResponse<int>.Ok(todo.Id, "Tarea creado exitosamente.");
        }
    }
}
