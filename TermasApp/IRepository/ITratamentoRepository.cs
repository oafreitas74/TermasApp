using TermasApp.Models;

namespace TermasApp.IRepository
{
    public interface ITratamentoRepository
    {
        Task<int> AddNewTratamento(TratamentoModel tratamento);
        Task Delete(int id);
        Task<List<TratamentoModel>> GetAllTratamento();
        Task<List<TratamentoModel>> GetAllTratamentoAquista(int idAquista);
        Task<List<TratamentoModel>> GetAllTratamentoDay();
        Task<List<TratamentoModel>> GetAllTratamentoTipo(int? idTipoTratamento);
        Task<List<TratamentoModel>> GetTratamentoAquistaDay(int idAquista);
        Task<TratamentoModel> GetTratamentoById(int? id);
        Task<List<TratamentoModel>> GetTratamentoByTerapeutaDay(int idTerapeuta);
        Task<int> TratamentosMarcados(int idPrescricao);
        Task<int> UpdateTratamento(TratamentoModel tratamento);
    }
}