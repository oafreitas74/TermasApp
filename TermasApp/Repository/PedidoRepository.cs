using Microsoft.EntityFrameworkCore;
using TermasApp.Data;
using TermasApp.IRepository;
using TermasApp.Models;

namespace TermasApp.Repository
{

    public class PedidoRepository : IPedidoRepository
    {
        private readonly TermasAppContext _db;
        private readonly IEquipamentoRepository _equipamentoRepository;
        public PedidoRepository(TermasAppContext db,
                                IEquipamentoRepository equipamentoRepository)
        {
            _db = db;
            _equipamentoRepository = equipamentoRepository;
        }

        public async Task<List<PedidosReparacaoModel>> GetAllPedidosAberto()
        {
            return await _db.PedidosReparacao.Where(x => x.Estado == "Aberto").OrderBy(o => o.DataPedido)
                    .Select(pedido => new PedidosReparacaoModel()
                    {
                        Id = pedido.Id,
                        IdEquipamento = pedido.IdEquipamento,
                        IdTecnico = pedido.IdTecnico,
                        DataConclusao = pedido.DataConclusao,
                        DataPedido = pedido.DataPedido,
                        Avaria = pedido.Avaria,
                        Observacoes = pedido.Observacoes,
                        Valor = pedido.Valor,
                        Estado = pedido.Estado,
                        Preventiva = pedido.Preventiva,
                    }).ToListAsync();
        }
        public async Task<List<PedidosReparacaoModel>> GetAllPedidosTecnico(int id)
        {
            return await _db.PedidosReparacao.Where(x => x.IdTecnico == id).OrderBy(o => o.DataPedido)
                    .Select(pedido => new PedidosReparacaoModel()
                    {
                        Id = pedido.Id,
                        IdEquipamento = pedido.IdEquipamento,
                        IdTecnico = pedido.IdTecnico,
                        DataConclusao = pedido.DataConclusao,
                        DataPedido = pedido.DataPedido,
                        Avaria = pedido.Avaria,
                        Observacoes = pedido.Observacoes,
                        Valor = pedido.Valor,
                        Estado = pedido.Estado,
                        Preventiva = pedido.Preventiva,
                    }).ToListAsync();
        }

        public async Task<List<PedidosReparacaoModel>> GetAllPedidos()
        {
            return await _db.PedidosReparacao.OrderBy(o => o.DataPedido)
                    .Select(pedido => new PedidosReparacaoModel()
                    {
                        Id = pedido.Id,
                        IdEquipamento = pedido.IdEquipamento,
                        IdTecnico = pedido.IdTecnico,
                        DataConclusao = pedido.DataConclusao,
                        DataPedido = pedido.DataPedido,
                        Avaria = pedido.Avaria,
                        Observacoes = pedido.Observacoes,
                        Valor = pedido.Valor,
                        Estado = pedido.Estado,
                        Preventiva = pedido.Preventiva,
                    }).ToListAsync();
        }
        public async Task<List<PedidosReparacaoModel>> GetAllPedidosPreventiva()
        {
            return await _db.PedidosReparacao.Where(x => x.Preventiva == true).OrderBy(o => o.DataPedido)
                    .Select(pedido => new PedidosReparacaoModel()
                    {
                        Id = pedido.Id,
                        IdEquipamento = pedido.IdEquipamento,
                        IdTecnico = pedido.IdTecnico,
                        DataConclusao = pedido.DataConclusao,
                        DataPedido = pedido.DataPedido,
                        Avaria = pedido.Avaria,
                        Observacoes = pedido.Observacoes,
                        Valor = pedido.Valor,
                        Estado = pedido.Estado,
                        Preventiva = pedido.Preventiva,
                    }).ToListAsync();
        }
        public async Task<List<PedidosReparacaoModel>> GetAllPedidosPreventivaAberto()
        {
            return await _db.PedidosReparacao.Where(x => x.Preventiva == true && x.Estado == "Aberto").OrderBy(o => o.DataPedido)
                    .Select(pedido => new PedidosReparacaoModel()
                    {
                        Id = pedido.Id,
                        IdEquipamento = pedido.IdEquipamento,
                        IdTecnico = pedido.IdTecnico,
                        DataConclusao = pedido.DataConclusao,
                        DataPedido = pedido.DataPedido,
                        Avaria = pedido.Avaria,
                        Observacoes = pedido.Observacoes,
                        Valor = pedido.Valor,
                        Estado = pedido.Estado,
                        Preventiva = pedido.Preventiva,
                    }).ToListAsync();
        }
        public async Task<PedidosReparacaoModel> GetPedidosById(int? id)
        {
            return await _db.PedidosReparacao.Where(x => x.Id == id)
                .Select(pedido => new PedidosReparacaoModel()
                {
                    Id = pedido.Id,
                    IdEquipamento = pedido.IdEquipamento,
                    IdTecnico = pedido.IdTecnico,
                    DataConclusao = pedido.DataConclusao,
                    DataPedido = pedido.DataPedido,
                    Avaria = pedido.Avaria,
                    Observacoes = pedido.Observacoes,
                    Valor = pedido.Valor,
                    Estado = pedido.Estado,
                    Preventiva = pedido.Preventiva,

                }).FirstAsync();
        }
        public async Task<int> AddNewPedido(PedidosReparacaoModel pedido)
        {
            var newPedido = new PedidosReparacao()
            {
                IdEquipamento = pedido.IdEquipamento,
                IdTecnico = pedido.IdTecnico,
                DataConclusao = pedido.DataConclusao,
                DataPedido = DateTime.Now.ToString(),
                Avaria = pedido.Avaria,
                Observacoes = pedido.Observacoes,
                Valor = pedido.Valor,
                Estado = "Aberto",
                Preventiva = pedido.Preventiva,

            };
            await _db.PedidosReparacao.AddAsync(newPedido);
            await _db.SaveChangesAsync();
            return newPedido.Id;
        }

        public async Task<int> UpdatePedido(PedidosReparacaoModel pedido)
        {
            var pedidoId = _db.PedidosReparacao.Find(pedido.Id);
            pedidoId.IdEquipamento = pedido.IdEquipamento;
            pedidoId.IdTecnico = pedido.IdTecnico;
            pedidoId.DataConclusao = DateTime.Now.ToString();
            pedidoId.DataPedido = pedido.DataPedido;
            pedidoId.Avaria = pedido.Avaria;
            pedidoId.Observacoes = pedido.Observacoes;
            pedidoId.Valor = pedido.Valor;
            pedidoId.Estado = pedido.Estado;
            pedidoId.Preventiva = pedido.Preventiva;

            _db.PedidosReparacao.Update(pedidoId);
            await _db.SaveChangesAsync();
            return pedidoId.Id;
        }

        public async Task Delete(int id)
        {
            var pedido = await _db.PedidosReparacao.FindAsync(id);
            if (pedido != null)
            {
                _db.PedidosReparacao.Remove(pedido);
            }
            await _db.SaveChangesAsync();
        }

        public async Task<bool> CriarPedido()
        {
            List<int> list = await _equipamentoRepository.GetListEQuipamentoPreventiva();
            var pedido = new PedidosReparacaoModel()
            {
                Avaria = "Manutenção Preventiva",
                Preventiva = true,
            };
            for (int i = 0; i < list.Count(); i++)
            {
                pedido.IdEquipamento = list[i];

                await AddNewPedido(pedido);
            }
            return true;
        }
    }
}
