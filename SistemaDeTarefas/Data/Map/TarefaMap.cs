using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Data.Map
{
    public class TarefaMap : IEntityTypeConfiguration<TarefaModel>
    {
        public void Configure(EntityTypeBuilder<TarefaModel> builder)
        {
            builder.HasKey(task => task.Id);
            builder.Property(task => task.Name).IsRequired().HasMaxLength(255);
            builder.Property(task => task.Description).HasMaxLength(1000);
            builder.Property(task => task.Status).IsRequired();
            builder.Property(task => task.UsuarioId).IsRequired(false);

            builder.Property(task => task.CreatedAt).IsRequired();
            builder.Property(task => task.UpdatedAt).IsRequired();

            builder.HasOne(task => task.Usuario);
        }
    }
}
