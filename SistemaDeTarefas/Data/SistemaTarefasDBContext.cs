using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data.Map;
using SistemaDeTarefas.Models;
using System;
using System.Linq;

namespace SistemaDeTarefas.Data
{
    public class SistemaTarefasDBContext : DbContext
    {
        public SistemaTarefasDBContext(DbContextOptions<SistemaTarefasDBContext> options)
            : base(options)
        {
        }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TarefaModel> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                var now = DateTime.UtcNow; // current datetime

                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).CreatedAt = now;
                }
                ((BaseEntity)entity.Entity).UpdatedAt = now;
            }
        }

        // public override int SaveChanges()
        // {
        //     var entries = ChangeTracker.Entries()
        //         .Where(e => e.Entity is BaseEntity &&
        //                     (e.State == EntityState.Added || e.State == EntityState.Modified));

        //     foreach (var entityEntry in entries)
        //     {
        //         ((BaseEntity)entityEntry.Entity).UpdatedAt = DateTime.UtcNow;

        //         if (entityEntry.State == EntityState.Added)
        //         {
        //             ((BaseEntity)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
        //         }
        //     }

        //     return base.SaveChanges();
        // }
    }
}
