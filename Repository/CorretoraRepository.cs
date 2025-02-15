using App_Corretora.Data;
using App_Corretora.Models;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace App_Corretora.Repository
{
    public class CorretoraRepository : ICorretoraRepository
    {
         private SessaoDB _sessaoDB;

        public CorretoraRepository(SessaoDB sessaoDB)
        {
            _sessaoDB = sessaoDB;
        }

        public async Task<List<Corretora>> listarCorretoras()
        {
            using(var conn = _sessaoDB.Connection)
            {
                string consulta = "Select *from Corretores";
                List<Corretora> corretoras = (await conn.QueryAsync<Corretora>(sql: consulta)).ToList();
                return corretoras;
            }
        }



        public async Task<string> localizarCorretora(string cnpj)
        {
            using (var conn = _sessaoDB.Connection)
            {
                string consulta = "Select *from Corretores where cnpj = @cnpj";
                var corretora =  await conn.ExecuteAsync(sql: consulta, param: new { cnpj });
                return corretora.ToString();
            }
        }


        public async Task<int> cadastrarCorretora(Corretora novaCorretora)
        {

            using (var conn = _sessaoDB.Connection)
            {
                string cadastraCorretoa = @"Insert into Corretores(cnpj,corretora,logradouro,cep,nomeSocial) values(@cnpj,@corretora,@logradouro,@cep,@nomeSocial)";
                var corretoras = await conn.ExecuteAsync(sql: cadastraCorretoa, param: novaCorretora);
                return corretoras;
            }

        }



        public async Task<string> atualizarCorretora(Corretora novaCorretora)
        {

            using (var conn = _sessaoDB.Connection)
            {
                string atualizaCorretoa = @"Update Corretores set corretora=@corretora,logradouro=@logradouro,cep=@cep,nomeSocial=@nomeSocial where = cnpj=@cnpj";
                var corretoras = await conn.ExecuteAsync(sql: atualizaCorretoa, param: novaCorretora);
                return corretoras.ToString();
            }

        }

        public async Task<string> apagarCorretora(string idCnpj)
        {
            using (var conn = _sessaoDB.Connection)
            {
                string consulta = @"Delete from Corretores where cnpj = @idCnpj";
                var corretoras = await conn.ExecuteAsync(sql: consulta, param: new { idCnpj });
                return corretoras.ToString();
            }
        }



    }
}
