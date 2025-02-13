using App_Corretora.Models;
using App_Corretora.Data;
using App_Corretora.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;



namespace App_Corretora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorretoraController:ControllerBase
    {
        private readonly ICorretoraRepository _repository;

        public CorretoraController(ICorretoraRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        [Route("Corretoras")]
        public async Task<IActionResult> localizarCorretora()
        {
            var corretoras = await _repository.listarCorretoras();
            return Ok(corretoras);
        }

        [HttpGet]
        [Route("Corretora")]
        public async Task<IActionResult> localizarCorretora(int cnpj)
        {
            var corretora = await _repository.localizarCorretora(cnpj);
            return Ok(corretora);
        }


        [HttpPost]
        [Route("Corretoras")]
        public async Task<IActionResult> cadastrarCorretora(Corretora novaCorretora)
        {
            var corretora = await _repository.cadastrarCorretora(novaCorretora);
            return Ok(corretora);
        }

        [HttpPut]
        [Route("Corretoras")]
        public async Task<IActionResult> atualizarCorretora(Corretora novaCorretora)
        {
            var corretora = await _repository.atualizarCorretora(novaCorretora);
            return Ok(corretora);
        }


        [HttpDelete]
        [Route("Corretoras")]
        public async Task<IActionResult> apagarCorretora(int cnpj)
        {
            var corretora = await _repository.apagarCorretora(cnpj);
            return Ok(corretora);
        }
    }
}
