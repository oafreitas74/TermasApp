using TermasApp.Models;

namespace TermasApp.IRepository
{
    public interface ITipoTratamentoRepository
    {
        Task<int> AddNewTTratamento(TipoTratamentoModel tipoTramento);
        Task Delete(int id);
        Task<List<TipoTratamentoModel>> GetAllTTratamento();
        Task<string> GetNomeTTratamento(int? id);
        Task<TipoTratamentoModel> GetTTratamentoById(int? id);
        Task<int> UpdateTTratamento(TipoTratamentoModel tipoTramento);
    }
}