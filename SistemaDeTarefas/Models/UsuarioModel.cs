using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeTarefas.Models
{
    [Table("usuario")]
    public class UsuarioModel : BaseEntity
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string? Name { get; set; }
        [Column("email")]
        public string? Email{ get; set; }

        // public ICollection<TarefaModel>? Tarefas { get; set; }
    }
}
