using MediatR;
using ToDo.Application.UseCases.Business.Todo.Command;
using ToDo.Domain.Common.Response;
using ToDo.Domain.Enum;
using ToDo.Domain.Interfaces.Repositories;

namespace ToDo.Application.UseCases.Business.Todo.Handlers
{
    public class DeleteTodoCommandHandler : IRequestHandler<DeleteTodoCommand, BaseResponse<int>>
    {
        private readonly ITodoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTodoCommandHandler(ITodoRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse<int>> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
        {
            if (request is null) return BaseResponse<int>.BadRequest("Ha ocurrido un error con los datos enviados, por favor revisar.");

            var existTodo = await _repository.FindOneOrDefaultAsync(x => x.Id == request.IdTodo);

            if (existTodo is null || !existTodo.StatusRegister) return BaseResponse<int>.BadRequest("Lo sentimos la tarea no se encuentra en nuestros registros.");

            existTodo.Status = EnumStateTodo.Cancelled;
            existTodo.OperationRegister = "Eliminación de tarea";
            existTodo.UpdateDate = DateTime.Now;
            existTodo.StatusRegister = false;

            _repository.Update(existTodo);

            int saveResult = await _unitOfWork.SaveChangesAsync(cancellationToken);

            if (saveResult <= 0) return BaseResponse<int>.Error("No se pudo eliminar la tarea en la base de datos.");

            return BaseResponse<int>.Ok(existTodo.Id, "Tarea eliminada.");
        }
}
}
