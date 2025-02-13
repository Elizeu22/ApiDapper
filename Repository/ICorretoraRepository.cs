using App_Corretora.Data;
using App_Corretora.Models;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace App_Corretora.Repository
{
    public interface ICorretoraRepository
    {
        Task<List<Corretora>> listarCorretoras();
        Task<int> localizarCorretora(int cnpj);
        Task<int> apagarCorretora(int cnpj);
        Task<int> cadastrarCorretora(Corretora corretores);

        Task<int> atualizarCorretora(Corretora corretores);




    }
}
