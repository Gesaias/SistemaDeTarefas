using System.ComponentModel.DataAnnotations.Schema;
using SistemaDeTarefas.Enums;

namespace SistemaDeTarefas.Models
{
    [Table("tarefa")]
    public class TarefaModel : BaseEntity
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("status")]
        public StatusTarefa Status { get; set; }

        [Column("usuario_id")]
        public int? UsuarioId { get; set; }

        public UsuarioModel? Usuario { get; set; }
    }
}

