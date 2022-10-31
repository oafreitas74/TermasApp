using TermasApp.Models;

namespace TermasApp.IRepository
{
    public interface IAquistaRepository
    {
        Task<int> AddNewAquista(AquistaModel aquista);
        bool AquistaExists(int id);
        Task<bool> AquistaLoginTrue(int? id);
        Task Delete(int id);
        Task<List<AquistaModel>> GetAllAquista();
        Task<AquistaModel> GetAquistaById(int? id);
        Task<string> GetFotoUrlAquista(int? id);
        Task<string> GetNomeAquista(int? id);
        Task<int> UpdateAquista(AquistaModel aquista);
    }
}