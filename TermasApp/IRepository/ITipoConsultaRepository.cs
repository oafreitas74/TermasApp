using TermasApp.Models;

namespace TermasApp.IRepository
{
    public interface ITipoConsultaRepository
    {
        Task<int> AddNewTConsulta(TipoConsultaModel tipoConsulta);
        Task Delete(int id);
        Task<List<TipoConsultaModel>> GetAllTConsulta();
        Task<string> GetNomeTConsulta(int? id);
        Task<TipoConsultaModel> GetTConsultaById(int? id);
        Task<int> UpdateTConsulta(TipoConsultaModel tipoConsulta);
    }
}