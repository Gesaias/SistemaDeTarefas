using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaDeTarefas.Integracao.Response;

namespace SistemaDeTarefas.Integracao.Interfaces
{
    public interface IViaCepIntegracao
    {
        Task<ViaCepResponse> obterDadosViaCep(string cep);
    }
}
