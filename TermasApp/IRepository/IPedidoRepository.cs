using TermasApp.Models;

namespace TermasApp.IRepository
{
    public interface IPedidoRepository
    {
        Task<int> AddNewPedido(PedidosReparacaoModel pedido);
        Task<bool> CriarPedido();
        Task Delete(int id);
        Task<List<PedidosReparacaoModel>> GetAllPedidos();
        Task<List<PedidosReparacaoModel>> GetAllPedidosAberto();
        Task<List<PedidosReparacaoModel>> GetAllPedidosPreventiva();
        Task<List<PedidosReparacaoModel>> GetAllPedidosPreventivaAberto();
        Task<List<PedidosReparacaoModel>> GetAllPedidosTecnico(int id);
        Task<PedidosReparacaoModel> GetPedidosById(int? id);
        Task<int> UpdatePedido(PedidosReparacaoModel pedido);
    }
}