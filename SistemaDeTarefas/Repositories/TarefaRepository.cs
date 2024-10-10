using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositories.Interfaces;

namespace SistemaDeTarefas.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly SistemaTarefasDBContext _dbContext;

        public TarefaRepository(SistemaTarefasDBContext sistemaTarefasDBContext)
        {
            _dbContext = sistemaTarefasDBContext;
        }

        public async Task<TarefaModel> BuscarPorId(int id)
        {
            return await _dbContext.Tarefas
            .Include(x => x.Usuario)
            .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TarefaModel>> BuscarTodasTarefas() => await _dbContext.Tarefas.ToListAsync();

        public async Task<TarefaModel> Adicionar(TarefaModel tarefa)
        {
            await _dbContext.Tarefas.AddAsync(tarefa);
            await _dbContext.SaveChangesAsync();

            return tarefa;
        }

        public async Task<bool> Apagar(int id)
        {
            TarefaModel tarefa = await BuscarPorId(id) ?? throw new Exception($"Tarefa para o ID({id}) não foi encontrado no banco de dados!");

            _dbContext.Tarefas.Remove(tarefa);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<TarefaModel> Atualizar(TarefaModel tarefa, int id)
        {
            TarefaModel tarefaPorId = await BuscarPorId(id) ?? throw new Exception($"Tarefa para o ID({id}) não foi encontrado no banco de dados!");

            tarefaPorId.Name = tarefa.Name;
            tarefaPorId.Description = tarefa.Description;
            tarefaPorId.Status = tarefa.Status;
            tarefaPorId.UsuarioId = tarefa.UsuarioId;

            _dbContext.Tarefas.Update(tarefaPorId);
            await _dbContext.SaveChangesAsync();

            return tarefaPorId;
        }
    }
}
