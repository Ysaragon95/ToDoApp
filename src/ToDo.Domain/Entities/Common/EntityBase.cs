using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDo.Domain.Entities.Common
{
    public class EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime? UpdateDate { get; set; } = null;
        public string OperationRegister { get; set; } = "Registro del sistema";
        public bool StatusRegister { get; set; } = true;

        protected EntityBase()
        {
            CreateDate = DateTime.Now;
        }
    }
}
