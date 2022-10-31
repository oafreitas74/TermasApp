using TermasApp.Models;

namespace TermasApp.IRepository
{
    public interface IFuncionarioRepository
    {
        Task<int> AddNewFuncionario(FuncionarioModel funcionario);
        Task Delete(int id);
        int FuncionarioCount();
        bool FuncionarioExists(int id);
        Task<bool> FuncionarioLoginTrue(int? id);
        Task<List<FuncionarioModel>> GetAllFuncionario();
        Task<List<FuncionarioModel>> GetAllFuncionarioTipo(string tipo);
        Task<string> GetFotoUrlFuncionario(int? id);
        Task<FuncionarioModel> GetFuncionarioById(int? id);
        Task<string> GetNomeFuncionario(int? id);
        Task<string> GetPostolFuncionario(int? id);
        Task<string> GetTipolFuncionario(int? id);
        Task<int> UpdateFuncionario(FuncionarioModel funcionario);
    }
}