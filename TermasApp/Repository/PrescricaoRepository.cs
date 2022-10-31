using Microsoft.EntityFrameworkCore;
using TermasApp.Data;
using TermasApp.IRepository;
using TermasApp.Models;

namespace TermasApp.Repository
{

    public class PrescricaoRepository : IPrescricaoRepository
    {
        private readonly TermasAppContext _db;
        public PrescricaoRepository(TermasAppContext db)
        {
            _db = db;
        }

        public async Task<List<PrescricaoModel>> GetAllPrecricao()
        {
            return await _db.Precricao.OrderBy(o => o.Id)
                .Select(prescricao => new PrescricaoModel()
                {
                    Id = prescricao.Id,
                    IdConsulta = prescricao.IdConsulta,
                    IdAquista = prescricao.IdAquista,
                    IdTipoTratamento = prescricao.IdTipoTratamento,
                    NTratamentos = prescricao.NTratamentos,
                    Data = prescricao.Data,
                }).ToListAsync();
        }
        public async Task<List<PrescricaoModel>> GetAllPrecricaoAquista(int idAquista)
        {
            return await _db.Precricao.Where(x => x.IdAquista == idAquista).OrderBy(o => o.Data)
                .Select(prescricao => new PrescricaoModel()
                {
                    Id = prescricao.Id,
                    IdConsulta = prescricao.IdConsulta,
                    IdAquista = prescricao.IdAquista,
                    IdTipoTratamento = prescricao.IdTipoTratamento,
                    NTratamentos = prescricao.NTratamentos,
                    Data = prescricao.Data,
                }).ToListAsync();
        }
        public async Task<PrescricaoModel> GetPrecricaoById(int? id)
        {
            return await _db.Precricao.Where(x => x.Id == id)
                .Select(prescricao => new PrescricaoModel()
                {
                    Id = prescricao.Id,
                    IdConsulta = prescricao.IdConsulta,
                    IdAquista = prescricao.IdAquista,
                    IdTipoTratamento = prescricao.IdTipoTratamento,
                    NTratamentos = prescricao.NTratamentos,
                    Data = prescricao.Data,
                }).FirstAsync();
        }

        public async Task<int> AddNewPrecricao(PrescricaoModel prescricao)
        {
            var newPrescricao = new Precricao()
            {
                IdConsulta = prescricao.IdConsulta,
                IdAquista = prescricao.IdAquista,
                IdTipoTratamento = prescricao.IdTipoTratamento,
                NTratamentos = prescricao.NTratamentos,
                Data = DateTime.Now.Date.ToString(),
            };

            await _db.Precricao.AddAsync(newPrescricao);
            await _db.SaveChangesAsync();

            var consulta = _db.Consulta.Find(newPrescricao.IdConsulta);
            consulta.PrescricaoTrue = true;
            _db.Consulta.Update(consulta);
            await _db.SaveChangesAsync();

            return newPrescricao.Id;
        }

        public async Task<int> UpdatePrecricao(PrescricaoModel prescricao)
        {
            var prescricaoId = _db.Precricao.Find(prescricao.Id);

            prescricaoId.IdAquista = prescricao.IdAquista;
            prescricaoId.IdConsulta = prescricao.IdConsulta;
            prescricaoId.IdTipoTratamento = prescricao.IdTipoTratamento;
            prescricaoId.NTratamentos = prescricao.NTratamentos;
            prescricaoId.Data = prescricao.Data;


            _db.Precricao.Update(prescricaoId);
            await _db.SaveChangesAsync();
            return prescricaoId.Id;
        }
        public async Task Delete(int id)
        {
            var prescricao = await _db.Precricao.FindAsync(id);
            if (prescricao != null)
            {
                _db.Precricao.Remove(prescricao);
            }
            await _db.SaveChangesAsync();

        }
    }
}
