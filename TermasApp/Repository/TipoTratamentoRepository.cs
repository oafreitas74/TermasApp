using Microsoft.EntityFrameworkCore;
using TermasApp.Data;
using TermasApp.IRepository;
using TermasApp.Models;

namespace TermasApp.Repository
{

    public class TipoTratamentoRepository : ITipoTratamentoRepository
    {
        private readonly TermasAppContext _db;

        public TipoTratamentoRepository(TermasAppContext db)
        {
            _db = db;
        }

        public async Task<List<TipoTratamentoModel>> GetAllTTratamento()
        {
            return await _db.TipoTratamento.OrderBy(o => o.Nome)
                .Select(tipoTramento => new TipoTratamentoModel()
                {
                    Id = tipoTramento.Id,
                    Preco = tipoTramento.Preco,
                    Nome = tipoTramento.Nome,
                    Descricao = tipoTramento.Descricao,
                    Duracao = tipoTramento.Duracao,
                    ImagemPublicitaria = tipoTramento.ImagemPublicitaria,

                }).ToListAsync();
        }

        public async Task<TipoTratamentoModel> GetTTratamentoById(int? id)
        {
            return await _db.TipoTratamento.Where(x => x.Id == id)
                .Select(tipoTramento => new TipoTratamentoModel()
                {
                    Id = tipoTramento.Id,
                    Preco = tipoTramento.Preco,
                    Nome = tipoTramento.Nome,
                    Descricao = tipoTramento.Descricao,
                    Duracao = tipoTramento.Duracao,
                    ImagemPublicitaria = tipoTramento.ImagemPublicitaria,

                }).FirstAsync();
        }

        public async Task<int> AddNewTTratamento(TipoTratamentoModel tipoTramento)
        {
            var newtipoConsulta = new TipoTratamento()
            {

                Preco = tipoTramento.Preco,
                Nome = tipoTramento.Nome,
                Descricao = tipoTramento.Descricao,
                Duracao = tipoTramento.Duracao,
                ImagemPublicitaria = tipoTramento.ImagemPublicitaria,
            };
            await _db.TipoTratamento.AddAsync(newtipoConsulta);
            await _db.SaveChangesAsync();
            return newtipoConsulta.Id;
        }

        public async Task<int> UpdateTTratamento(TipoTratamentoModel tipoTramento)
        {
            var tipoTramentoId = _db.TipoTratamento.Find(tipoTramento.Id);

            tipoTramentoId.Preco = tipoTramento.Preco;
            tipoTramentoId.Nome = tipoTramento.Nome;
            tipoTramentoId.Descricao = tipoTramento.Descricao;
            tipoTramentoId.Duracao = tipoTramento.Duracao;
            tipoTramentoId.ImagemPublicitaria = tipoTramento.ImagemPublicitaria;

            _db.TipoTratamento.Update(tipoTramentoId);
            await _db.SaveChangesAsync();
            return tipoTramentoId.Id;
        }

        public Task<string> GetNomeTTratamento(int? id)
        {
            var tipoTramentoId = _db.TipoTratamento.Find(id);
            return Task.FromResult(tipoTramentoId.Nome);
        }

        public async Task Delete(int id)
        {
            var tipoTramentoId = await _db.TipoTratamento.FindAsync(id);
            if (tipoTramentoId != null)
            {
                _db.TipoTratamento.Remove(tipoTramentoId);
            }
            await _db.SaveChangesAsync();

        }
    }
}
