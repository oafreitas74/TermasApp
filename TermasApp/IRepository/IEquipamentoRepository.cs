using TermasApp.Models;

namespace TermasApp.IRepository
{
    public interface IEquipamentoRepository
    {
        Task<int> AddNewEquipamento(EquipamentoModel equipamento);
        Task Delete(int id);
        Task<List<EquipamentoModel>> GetAllEquipamento();
        Task<List<EquipamentoPreventivaModel>> GetAllEquipamentoPreventiva();
        Task<EquipamentoModel> GetEquipamentoById(int? id);
        Task<EquipamentoPreventivaModel> GetEquipamentoPreventivaById(int? id);
        Task<List<int>> GetIdAllEquipamentoPreventivaAbr();
        Task<List<int>> GetIdAllEquipamentoPreventivaAgo();
        Task<List<int>> GetIdAllEquipamentoPreventivaDez();
        Task<List<int>> GetIdAllEquipamentoPreventivaFev();
        Task<List<int>> GetIdAllEquipamentoPreventivaJan();
        Task<List<int>> GetIdAllEquipamentoPreventivaJul();
        Task<List<int>> GetIdAllEquipamentoPreventivaJun();
        Task<List<int>> GetIdAllEquipamentoPreventivaMai();
        Task<List<int>> GetIdAllEquipamentoPreventivaMar();
        Task<List<int>> GetIdAllEquipamentoPreventivaNov();
        Task<List<int>> GetIdAllEquipamentoPreventivaOut();
        Task<List<int>> GetIdAllEquipamentoPreventivaSet();
        Task<List<int>> GetListEQuipamentoPreventiva();
        Task<string> GetNomeEquipamento(int? id);
        Task<int> UpdateEquipamento(EquipamentoModel equipamento);
        Task<int> UpdateEquipamentoPreventiva(EquipamentoPreventivaModel equipamento);
        Task<bool> UpdateListEquipamentoPreventiva(List<EquipamentoPreventivaModel> ListEquipamento);
    }
}