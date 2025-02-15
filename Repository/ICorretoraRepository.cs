using App_Corretora.Data;
using App_Corretora.Models;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace App_Corretora.Repository
{
    public interface ICorretoraRepository
    {
        Task<List<Corretora>> listarCorretoras();
        Task<string> localizarCorretora(string cnpj);
        Task<string> apagarCorretora(string cnpj);
        Task<int> cadastrarCorretora(Corretora corretores);

        Task<string> atualizarCorretora(Corretora corretores);




    }
}
