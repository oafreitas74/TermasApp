using TermasApp.Models;

namespace TermasApp.IRepository
{
    public interface IConsultaRepository
    {
        Task<int> AddNewConsulta(ConsultaModel consulta);
        Task Delete(int id);
        Task<List<ConsultaModel>> GetAllConsultaAquista(int idAquista);
        Task<List<ConsultaModel>> GetAllConsultas();
        Task<List<ConsultaModel>> GetAllConsultasDay();
        Task<List<ConsultaModel>> GetAllConsultaTipo(int? idTipoConsulta);
        Task<List<ConsultaModel>> GetConsultaAquistaDay(int idAquista);
        Task<ConsultaModel> GetConsultaById(int? id);
        Task<List<ConsultaModel>> GetConsultaByMedico(int? idFuncionario);
        Task<List<ConsultaModel>> GetConsultaByMedicoDay(int? idFuncionario);
        Task<int> UpdateConsulta(ConsultaModel consulta);
    }
}