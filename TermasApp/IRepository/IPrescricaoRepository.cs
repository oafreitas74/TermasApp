using TermasApp.Models;

namespace TermasApp.IRepository
{
    public interface IPrescricaoRepository
    {
        Task<int> AddNewPrecricao(PrescricaoModel prescricao);
        Task Delete(int id);
        Task<List<PrescricaoModel>> GetAllPrecricao();
        Task<List<PrescricaoModel>> GetAllPrecricaoAquista(int idAquista);
        Task<PrescricaoModel> GetPrecricaoById(int? id);
        Task<int> UpdatePrecricao(PrescricaoModel prescricao);
    }
}