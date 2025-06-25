using ToDo.Domain.Entities.Common;
using ToDo.Domain.Enum;

namespace ToDo.Domain.Entities.Business
{
    public class Todo : EntityBase
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public EnumStateTodo Status { get; set; }
        public bool IsCompleted { get; set; } = false;
        public int IdUserCreate { get; set; }
    }
}
