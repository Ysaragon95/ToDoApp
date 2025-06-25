using ToDo.Domain.Enum;

namespace ToDo.Application.DTOs.Business.Todo
{
    public class AllTodoQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public EnumStateTodo Status { get; set; }
    }
}
