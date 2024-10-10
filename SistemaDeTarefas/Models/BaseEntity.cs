using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeTarefas.Models
{
    public class BaseEntity
    {
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
