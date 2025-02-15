using App_Corretora.Models;
using App_Corretora.Data;
using App_Corretora.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;



namespace App_Corretora.Controllers
{
    [Route("corretores/")]
    [ApiController]
    public class CorretoraController:ControllerBase
    {
        private readonly ICorretoraRepository _repository;

        public CorretoraController(ICorretoraRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        [Route("Localizar")]
        public async Task<IActionResult> localizarCorretora()
        {
            var corretoras = await _repository.listarCorretoras();
            return Ok(corretoras);
        }

        [HttpGet]
        [Route("Pesquisar")]
        public async Task<IActionResult> localizarCorretora(string cnpj)
        {
            var corretora = await _repository.localizarCorretora(cnpj);
            return Ok(corretora);
        }


        [HttpPost]
        [Route("Gravar")]
        public async Task<IActionResult> cadastrarCorretora(Corretora novaCorretora)
        {
            var corretora = await _repository.cadastrarCorretora(novaCorretora);
            return Ok(corretora);
        }

        [HttpPut]
        [Route("Atualizar")]
        public async Task<IActionResult> atualizarCorretora(Corretora novaCorretora)
        {
            var corretora = await _repository.atualizarCorretora(novaCorretora);
            return Ok(corretora);
        }


        [HttpDelete]
        [Route("Deletar")]
        public async Task<IActionResult> apagarCorretora(string cnpj)
        {
            var corretora = await _repository.apagarCorretora(cnpj);
            return Ok(corretora);
        }
    }
}
