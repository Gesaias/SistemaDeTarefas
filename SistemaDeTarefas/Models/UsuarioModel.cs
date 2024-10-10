using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeTarefas.Models
{
    [Table("usuario")]
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email{ get; set; }
    }
}
