using MediatR;
using ToDo.Application.UseCases.Business.Todo.Command;
using ToDo.Domain.Common.Response;
using ToDo.Domain.Interfaces.Repositories;

namespace ToDo.Application.UseCases.Business.Todo.Handlers
{
    public class UpdateTodoCommandHandler(ITodoRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateTodoCommand, BaseResponse<int>>
    {
        private readonly ITodoRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<BaseResponse<int>> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
        {
            if (request is null) return BaseResponse<int>.BadRequest("Ha ocurrido un error con los datos enviados, por favor revisar.");

            var existTodo = await _repository.FindOneOrDefaultAsync(x => x.Id == request.IdTodo);

            if (existTodo is null) return BaseResponse<int>.BadRequest("Lo sentimos la tarea no se encuentra en nuestros registros.");

            existTodo.Name = request.Name.Trim();
            existTodo.Description = request.Description.Trim();
            existTodo.Status = request.Status;
            existTodo.IsCompleted = request.IsCompleted;
            existTodo.OperationRegister = "Actualización de tarea";
            existTodo.IdUserCreate = request.IdUserCreate;
            existTodo.UpdateDate = DateTime.Now;

            _repository.Update(existTodo);

            int saveResult = await _unitOfWork.SaveChangesAsync(cancellationToken);

            if (saveResult <= 0) return BaseResponse<int>.Error("No se pudo guardar la tarea en la base de datos.");

            return BaseResponse<int>.Ok(existTodo.Id, "Tarea actualizada exitosamente.");
        }
    }
}
