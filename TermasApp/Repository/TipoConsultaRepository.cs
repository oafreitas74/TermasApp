using Microsoft.EntityFrameworkCore;
using TermasApp.Data;
using TermasApp.IRepository;
using TermasApp.Models;

namespace TermasApp.Repository
{


    public class TipoConsultaRepository : ITipoConsultaRepository
    {
        private readonly TermasAppContext _db;

        public TipoConsultaRepository(TermasAppContext db)
        {
            _db = db;
        }

        public async Task<List<TipoConsultaModel>> GetAllTConsulta()
        {
            return await _db.TipoConsulta.OrderBy(o => o.Nome)
                .Select(tipoConsulta => new TipoConsultaModel()
                {
                    Id = tipoConsulta.Id,
                    Preco = tipoConsulta.Preco,
                    Nome = tipoConsulta.Nome,
                    Descricao = tipoConsulta.Descricao,
                    Duracao = tipoConsulta.Duracao,
                    ImagemPublicitaria = tipoConsulta.ImagemPublicitaria,
                }).ToListAsync();
        }

        public async Task<TipoConsultaModel> GetTConsultaById(int? id)
        {
            return await _db.TipoConsulta.Where(x => x.Id == id)
                .Select(tipoConsulta => new TipoConsultaModel()
                {
                    Id = tipoConsulta.Id,
                    Preco = tipoConsulta.Preco,
                    Nome = tipoConsulta.Nome,
                    Descricao = tipoConsulta.Descricao,
                    Duracao = tipoConsulta.Duracao,
                    ImagemPublicitaria = tipoConsulta.ImagemPublicitaria,
                }).FirstAsync();
        }

        public async Task<int> AddNewTConsulta(TipoConsultaModel tipoConsulta)
        {
            var newtipoConsulta = new TipoConsulta()
            {

                Preco = tipoConsulta.Preco,
                Nome = tipoConsulta.Nome,
                Descricao = tipoConsulta.Descricao,
                Duracao = tipoConsulta.Duracao,
                ImagemPublicitaria = tipoConsulta.ImagemPublicitaria,
            };
            await _db.TipoConsulta.AddAsync(newtipoConsulta);
            await _db.SaveChangesAsync();
            return newtipoConsulta.Id;
        }

        public async Task<int> UpdateTConsulta(TipoConsultaModel tipoConsulta)
        {
            var tipoConsultaId = _db.TipoConsulta.Find(tipoConsulta.Id);

            tipoConsultaId.Preco = tipoConsulta.Preco;
            tipoConsultaId.Nome = tipoConsulta.Nome;
            tipoConsultaId.Descricao = tipoConsulta.Descricao;
            tipoConsultaId.Duracao = tipoConsulta.Duracao;
            tipoConsultaId.ImagemPublicitaria = tipoConsulta.ImagemPublicitaria;

            _db.TipoConsulta.Update(tipoConsultaId);
            await _db.SaveChangesAsync();
            return tipoConsultaId.Id;
        }

        public Task<string> GetNomeTConsulta(int? id)
        {
            var tipoConsultaId = _db.TipoConsulta.Find(id);
            return Task.FromResult(tipoConsultaId.Nome);
        }

        public async Task Delete(int id)
        {
            var tipoConsulta = await _db.TipoConsulta.FindAsync(id);
            if (tipoConsulta != null)
            {
                _db.TipoConsulta.Remove(tipoConsulta);
            }
            await _db.SaveChangesAsync();

        }
    }
}
