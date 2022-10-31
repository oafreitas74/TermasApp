using Microsoft.EntityFrameworkCore;
using TermasApp.Data;
using TermasApp.IRepository;
using TermasApp.Models;

namespace TermasApp.Repository
{
    public class TriagemRepository : ITriagemRepository
    {
        private readonly TermasAppContext _db;
        public TriagemRepository(TermasAppContext db)
        {
            _db = db;
        }

        public async Task<List<TriagemModel>> GetAllTriagemDay()
        {
            DateTime date = DateTime.Now.Date;
            string now = String.Format("{0:yyyy-MM-dd}", date);

            return await _db.Triagem.Where(x => x.Data == now).OrderBy(o => o.Hora)
                .Select(triagem => new TriagemModel()
                {
                    Id = triagem.Id,
                    IdEnfermeiro = triagem.IdEnfermeiro,
                    IdAquista = triagem.IdAquista,
                    Hora = triagem.Hora,
                    Data = triagem.Data,
                }).ToListAsync();
        }
        public async Task<List<TriagemModel>> GetAllTriagemEnfermeiro(int idEnfermeiro)
        {
            return await _db.Triagem.Where(x => x.IdEnfermeiro == idEnfermeiro).OrderByDescending(o => o.Data)
                .Select(triagem => new TriagemModel()
                {
                    Id = triagem.Id,
                    IdEnfermeiro = triagem.IdEnfermeiro,
                    IdAquista = triagem.IdAquista,
                    Hora = triagem.Hora,
                    Data = triagem.Data,
                }).ToListAsync();
        }

        public async Task<List<TriagemModel>> GetAllTriagemAquista(int idAquista)
        {
            return await _db.Triagem.Where(x => x.IdAquista == idAquista).OrderByDescending(o => o.Data)
                .Select(triagem => new TriagemModel()
                {
                    Id = triagem.Id,
                    IdEnfermeiro = triagem.IdEnfermeiro,
                    IdAquista = triagem.IdAquista,
                    Hora = triagem.Hora,
                    Data = triagem.Data,
                }).ToListAsync();
        }

        public async Task<List<TriagemModel>> GetAllTriagem()
        {
            return await _db.Triagem.OrderBy(o => o.Id)
                .Select(triagem => new TriagemModel()
                {
                    Id = triagem.Id,
                    IdEnfermeiro = triagem.IdEnfermeiro,
                    IdAquista = triagem.IdAquista,
                    Hora = triagem.Hora,
                    Data = triagem.Data,
                }).ToListAsync();
        }
        public async Task<TriagemModel> GetTriagemById(int? id)
        {
            return await _db.Triagem.Where(x => x.Id == id).OrderBy(o => o.Id)
                .Select(triagem => new TriagemModel()
                {
                    Id = triagem.Id,
                    IdEnfermeiro = triagem.IdEnfermeiro,
                    IdAquista = triagem.IdAquista,
                    Hora = triagem.Hora,
                    Data = triagem.Data,
                }).FirstAsync();
        }

        public async Task<int> AddNewTriagem(TriagemModel triagem)
        {
            var newTriagem = new Triagem()
            {
                IdEnfermeiro = triagem.IdEnfermeiro,
                IdAquista = triagem.IdAquista,
                Hora = triagem.Hora,
                Data = triagem.Data,
            };

            await _db.Triagem.AddAsync(newTriagem);
            await _db.SaveChangesAsync();
            return newTriagem.Id;
        }

        public async Task<int> CreatedTriagemConsulta(int id)
        {
            var consulta = _db.Consulta.Find(id);
            DateTime hora = Convert.ToDateTime(consulta.Hora);
            DateTime horaT = hora.AddMinutes(-15);
            var newTriagem = new Triagem()
            {
                IdAquista = consulta.IdAquista,
                Hora = horaT.ToString("%H:%m"),
                Data = consulta.Data,
            };

            await _db.Triagem.AddAsync(newTriagem);
            await _db.SaveChangesAsync();
            return newTriagem.Id;
        }

        public async Task<int> CreatedTriagemTratamento(int id)
        {
            var tratamento = _db.Tratamento.Find(id);
            DateTime hora = Convert.ToDateTime(tratamento.Hora);
            DateTime horaT = hora.AddMinutes(-15);
            var newTriagem = new Triagem()
            {
                IdAquista = tratamento.IdAquista,
                Hora = horaT.ToString("%H:%m"),
                Data = tratamento.Data,
            };

            await _db.Triagem.AddAsync(newTriagem);
            await _db.SaveChangesAsync();
            return newTriagem.Id;
        }

        public async Task<int> UpdateTriagem(TriagemModel triagem)
        {
            var triagemId = _db.Triagem.Find(triagem.Id);

            triagemId.IdEnfermeiro = triagem.IdEnfermeiro;
            triagemId.Hora = triagem.Hora;
            triagemId.Data = triagem.Data;


            _db.Triagem.Update(triagemId);
            await _db.SaveChangesAsync();
            return triagemId.Id;
        }
        public async Task Delete(int id)
        {
            var triagem = await _db.Triagem.FindAsync(id);
            if (triagem != null)
            {
                _db.Triagem.Remove(triagem);
            }
            await _db.SaveChangesAsync();

        }

        public Task<string> GetNomeEnfermeiro(int? id)
        {
            var triagemId = _db.Triagem.Find(id);
            if (triagemId.IdEnfermeiro > 0)
            {
                var enfermeiro = _db.Funcionario.Find(triagemId.IdEnfermeiro);

                return Task.FromResult(enfermeiro.Nome);
            }

            return Task.FromResult("");
        }
        public async Task<EnfermeiroModel> GetEnfermeiro(int? id)
        {
            var enfermeiro = new EnfermeiroModel()
            {
                Id = 0,
                Nome = "",
            };
            var triagemId = _db.Triagem.Find(id);
            if (triagemId.IdEnfermeiro > 0)
            {
                var enfermeiroId = await _db.Funcionario.FindAsync(triagemId.IdEnfermeiro);
                enfermeiro.Id = enfermeiroId.Id;
                enfermeiro.Nome = enfermeiro.Nome;
            }

            return enfermeiro;
        }
    }
}
