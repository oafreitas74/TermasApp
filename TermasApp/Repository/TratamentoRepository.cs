using Microsoft.EntityFrameworkCore;
using TermasApp.Data;
using TermasApp.IRepository;
using TermasApp.Models;

namespace TermasApp.Repository
{
    public class TratamentoRepository : ITratamentoRepository
    {
        private readonly TermasAppContext _db;
        private readonly ITriagemRepository _triagemRepository;
        public TratamentoRepository(TermasAppContext db, ITriagemRepository triagemRepository)
        {
            _db = db;
            _triagemRepository = triagemRepository;
        }

        public async Task<List<TratamentoModel>> GetAllTratamento()
        {
            return await _db.Tratamento.OrderBy(o => o.Data).Select(tratamento => new TratamentoModel()
            {
                Id = tratamento.Id,
                IdPrescricao = tratamento.IdPrescricao,
                IdTipoTratamento = tratamento.IdTipoTratamento,
                IdAquista = tratamento.IdAquista,
                IdTerapeuta = tratamento.IdTerapeuta,
                IdTriagem = tratamento.IdTriagem,
                Hora = tratamento.Hora,
                Data = tratamento.Data,
                Observacoes = tratamento.Observacoes,
            }).ToListAsync();
        }

        public async Task<List<TratamentoModel>> GetAllTratamentoDay()
        {
            DateTime date = DateTime.Now.Date;
            string now = String.Format("{0:yyyy-MM-dd}", date);
            return await _db.Tratamento.Where(x => x.Data == now).OrderBy(o => o.Hora).Select(tratamento => new TratamentoModel()
            {
                Id = tratamento.Id,
                IdPrescricao = tratamento.IdPrescricao,
                IdTipoTratamento = tratamento.IdTipoTratamento,
                IdAquista = tratamento.IdAquista,
                IdTerapeuta = tratamento.IdTerapeuta,
                IdTriagem = tratamento.IdTriagem,
                Hora = tratamento.Hora,
                Data = tratamento.Data,
                Observacoes = tratamento.Observacoes,
            }).ToListAsync();
        }

        public async Task<TratamentoModel> GetTratamentoById(int? id)
        {
            return await _db.Tratamento.Where(x => x.Id == id).Select(tratamento => new TratamentoModel()
            {
                Id = tratamento.Id,
                IdPrescricao = tratamento.IdPrescricao,
                IdTipoTratamento = tratamento.IdTipoTratamento,
                IdAquista = tratamento.IdAquista,
                IdTerapeuta = tratamento.IdTerapeuta,
                IdTriagem = tratamento.IdTriagem,
                Hora = tratamento.Hora,
                Data = tratamento.Data,
                Observacoes = tratamento.Observacoes,
            }).FirstAsync();
        }
        public async Task<List<TratamentoModel>> GetAllTratamentoAquista(int idAquista)
        {
            return await _db.Tratamento.Where(x => x.IdAquista == idAquista).OrderBy(o => o.Data).Select(tratamento => new TratamentoModel()
            {
                Id = tratamento.Id,
                IdPrescricao = tratamento.IdPrescricao,
                IdTipoTratamento = tratamento.IdTipoTratamento,
                IdAquista = tratamento.IdAquista,
                IdTerapeuta = tratamento.IdTerapeuta,
                IdTriagem = tratamento.IdTriagem,
                Hora = tratamento.Hora,
                Data = tratamento.Data,
                Observacoes = tratamento.Observacoes,
            }).ToListAsync();
        }
        public async Task<List<TratamentoModel>> GetAllTratamentoTipo(int? idTipoTratamento)
        {
            return await _db.Tratamento.Where(x => x.IdTipoTratamento == idTipoTratamento).OrderBy(o => o.Data).Select(tratamento => new TratamentoModel()
            {
                Id = tratamento.Id,
                IdPrescricao = tratamento.IdPrescricao,
                IdTipoTratamento = tratamento.IdTipoTratamento,
                IdAquista = tratamento.IdAquista,
                IdTerapeuta = tratamento.IdTerapeuta,
                IdTriagem = tratamento.IdTriagem,
                Hora = tratamento.Hora,
                Data = tratamento.Data,
                Observacoes = tratamento.Observacoes,
            }).ToListAsync();
        }
        public async Task<List<TratamentoModel>> GetTratamentoAquistaDay(int idAquista)
        {
            DateTime date = DateTime.Now.Date;
            string now = String.Format("{0:yyyy-MM-dd}", date);
            return await _db.Tratamento.Where(x => x.IdAquista == idAquista && x.Data == now).OrderBy(o => o.Hora).Select(tratamento => new TratamentoModel()
            {
                Id = tratamento.Id,
                IdPrescricao = tratamento.IdPrescricao,
                IdTipoTratamento = tratamento.IdTipoTratamento,
                IdAquista = tratamento.IdAquista,
                IdTerapeuta = tratamento.IdTerapeuta,
                IdTriagem = tratamento.IdTriagem,
                Hora = tratamento.Hora,
                Data = tratamento.Data,
                Observacoes = tratamento.Observacoes,
            }).ToListAsync();
        }
        public async Task<List<TratamentoModel>> GetTratamentoByTerapeutaDay(int idTerapeuta)
        {
            DateTime date = DateTime.Now.Date;
            string now = String.Format("{0:yyyy-MM-dd}", date);
            return await _db.Tratamento.Where(x => x.IdTerapeuta == idTerapeuta && x.Data == now).OrderBy(o => o.Hora).Select(tratamento => new TratamentoModel()
            {
                Id = tratamento.Id,
                IdPrescricao = tratamento.IdPrescricao,
                IdTipoTratamento = tratamento.IdTipoTratamento,
                IdAquista = tratamento.IdAquista,
                IdTerapeuta = tratamento.IdTerapeuta,
                IdTriagem = tratamento.IdTriagem,
                Hora = tratamento.Hora,
                Data = tratamento.Data,
                Observacoes = tratamento.Observacoes,
            }).ToListAsync();
        }
        public async Task<int> AddNewTratamento(TratamentoModel tratamento)
        {
            var newTratamento = new Tratamento()
            {
                Id = tratamento.Id,
                IdPrescricao = tratamento.IdPrescricao,
                IdTipoTratamento = tratamento.IdTipoTratamento,
                IdAquista = tratamento.IdAquista,
                IdTerapeuta = tratamento.IdTerapeuta,
                IdTriagem = tratamento.IdTriagem,
                Hora = tratamento.Hora,
                Data = tratamento.Data,
                Observacoes = tratamento.Observacoes,
            };

            await _db.Tratamento.AddAsync(newTratamento);
            await _db.SaveChangesAsync();

            int idTriagem = await _triagemRepository.CreatedTriagemTratamento(newTratamento.Id);

            var tratamentoId = _db.Tratamento.Find(newTratamento.Id);
            tratamentoId.IdTriagem = idTriagem;
            _db.Tratamento.Update(tratamentoId);
            await _db.SaveChangesAsync();

            return tratamentoId.Id;
        }

        public async Task<int> UpdateTratamento(TratamentoModel tratamento)
        {
            var tratamentoId = _db.Tratamento.Find(tratamento.Id);

            tratamentoId.IdTipoTratamento = tratamento.IdTipoTratamento;
            tratamentoId.IdPrescricao = tratamento.IdPrescricao;
            tratamentoId.IdAquista = tratamento.IdAquista;
            tratamentoId.IdTerapeuta = tratamento.IdTerapeuta;
            tratamentoId.IdTriagem = tratamento.IdTriagem;
            tratamentoId.Hora = tratamento.Hora;
            tratamentoId.Data = tratamento.Data;
            tratamentoId.Observacoes = tratamento.Observacoes;


            _db.Tratamento.Update(tratamentoId);
            await _db.SaveChangesAsync();
            return tratamentoId.Id;
        }
        public async Task Delete(int id)
        {
            var tratamento = await _db.Tratamento.FindAsync(id);
            if (tratamento != null)
            {
                _db.Tratamento.Remove(tratamento);
            }
            await _db.SaveChangesAsync();

        }

        public Task<int> TratamentosMarcados(int idPrescricao)
        {
            return Task.FromResult(_db.Tratamento.Where(x => x.IdPrescricao == idPrescricao).Count());
        }


    }
}