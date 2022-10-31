using TermasApp.Models;

namespace TermasApp.IRepository
{
    public interface ITriagemRepository
    {
        Task<int> AddNewTriagem(TriagemModel triagem);
        Task<int> CreatedTriagemConsulta(int id);
        Task<int> CreatedTriagemTratamento(int id);
        Task Delete(int id);
        Task<List<TriagemModel>> GetAllTriagem();
        Task<List<TriagemModel>> GetAllTriagemAquista(int idAquista);
        Task<List<TriagemModel>> GetAllTriagemDay();
        Task<List<TriagemModel>> GetAllTriagemEnfermeiro(int idEnfermeiro);
        Task<EnfermeiroModel> GetEnfermeiro(int? id);
        Task<string> GetNomeEnfermeiro(int? id);
        Task<TriagemModel> GetTriagemById(int? id);
        Task<int> UpdateTriagem(TriagemModel triagem);
    }
}