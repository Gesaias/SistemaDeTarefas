using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Integracao;
using SistemaDeTarefas.Integracao.Interfaces;

namespace SistemaDeTarefas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CepController : ControllerBase
    {
        private readonly IViaCepIntegracao _viaCepIntegracao;

        public CepController(IViaCepIntegracao viaCepIntegracao)
        {
            _viaCepIntegracao = viaCepIntegracao;
        }

        [HttpGet("{cep}")]
        public async Task<ActionResult<ViaCepIntegracao>> ListarDadosEnderecos(string cep)
        {
            var responseData = await _viaCepIntegracao.obterDadosViaCep(cep);

            if (responseData == null)
            {
                return NotFound("CEP não encontrado");
            }

            return Ok(responseData);
        }
    }
}
