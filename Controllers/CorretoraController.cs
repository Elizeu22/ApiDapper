using App_Corretora.Models;
using App_Corretora.Data;
using App_Corretora.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using Newtonsoft.Json;
using StackExchange.Redis;



namespace App_Corretora.Controllers
{
    [Route("corretores/")]
    [ApiController]
    public class CorretoraController:ControllerBase
    {
        private readonly ICorretoraRepository _repository;
        private readonly IDistributedCache _distributedCache;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="distributedCache"></param>
        public CorretoraController(ICorretoraRepository repository, IDistributedCache distributedCache)
        {
            _repository = repository;
            _distributedCache = distributedCache;
        }




        /// <summary>
        /// /
        /// </summary>
        /// <returns>ADICIONADO REDIS</returns>
        [HttpGet]
        [Route("Localizar")]
        public async Task<IActionResult> localizarCorretoras()
       {
            var chave = "listarCorretoras";
            var serializarObjeto = "";
            var listarCorretora = new List<Corretora>();

            var listRedis = await _distributedCache.GetAsync(chave);

            if(listRedis != null)
            {
                serializarObjeto = Encoding.UTF8.GetString(listRedis);
                listarCorretora = JsonConvert.DeserializeObject<List<Corretora>>(serializarObjeto);
            }

            else
            {
                listarCorretora = await _repository.listarCorretoras();

                serializarObjeto = JsonConvert.SerializeObject(listarCorretora);

                listRedis = Encoding.UTF8.GetBytes(serializarObjeto);

                var options = new DistributedCacheEntryOptions()
                      .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                      .SetSlidingExpiration(TimeSpan.FromMinutes(20));

                await _distributedCache.SetAsync(chave, listRedis, options);

            }

            return listarCorretora == null ? NotFound() : Ok(listarCorretora);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="cnpj"></param>
        /// <returns>ADICIONADO REDIS </returns>
        [HttpGet]
        [Route("Pesquisar")]
        public async Task<IActionResult> localizarCorretora(string cnpj)
        {
            var chave = "localizarCorretoras";
            var serializarObjeto = "";
            var localizarCorretora = new Corretora();

            var listRedis = await _distributedCache.GetAsync(chave);

            if (listRedis != null)
            {
                serializarObjeto = Encoding.UTF8.GetString(listRedis);
                localizarCorretora = JsonConvert.DeserializeObject<Corretora>(serializarObjeto);
            }


            else
            {
                localizarCorretora = await _repository.localizarCorretora(cnpj);

                serializarObjeto = JsonConvert.SerializeObject(localizarCorretora);

                listRedis = Encoding.UTF8.GetBytes(serializarObjeto);

                var options = new DistributedCacheEntryOptions()
                      .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                      .SetSlidingExpiration(TimeSpan.FromMinutes(20));

                await _distributedCache.SetAsync(chave, listRedis, options);
                

            }

               
                return localizarCorretora == null ? NotFound() : Ok(localizarCorretora);
       
  
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="novaCorretora"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Gravar")]
        public async Task<IActionResult> cadastrarCorretora(Corretora novaCorretora)
        {
           var corretora =  await _repository.cadastrarCorretora(novaCorretora);
           return corretora == null ? NotFound("Cadastro ja existe") : Ok(corretora);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="novaCorretora"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Atualizar")]
        public async Task<IActionResult> atualizarCorretora(Corretora novaCorretora)
        {
            var corretora = await _repository.atualizarCorretora(novaCorretora);
            return corretora == null ? NotFound() : Ok(corretora);
        }





        /// <summary>
        /// 
        /// </summary>
        /// <param name="cnpj"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Deletar")]
        public async Task<IActionResult> apagarCorretora(string cnpj)
        {
            var corretora = await _repository.apagarCorretora(cnpj);

            return corretora == null ? NotFound() : Ok(corretora);



        }
    }
}
