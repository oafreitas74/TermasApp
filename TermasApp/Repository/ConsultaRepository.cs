using Microsoft.EntityFrameworkCore;
using TermasApp.Data;
using TermasApp.IRepository;
using TermasApp.Models;

namespace TermasApp.Repository
{

    public class ConsultaRepository : IConsultaRepository
    {
        private readonly TermasAppContext _db;
        private readonly ITriagemRepository _triagemRepository;
        public ConsultaRepository(TermasAppContext db, ITriagemRepository triagemRepository)
        {
            _db = db;
            _triagemRepository = triagemRepository;
        }

        public async Task<List<ConsultaModel>> GetAllConsultas()
        {
            return await _db.Consulta.OrderBy(o => o.Data).Select(consulta => new ConsultaModel()
            {
                Id = consulta.Id,
                IdMedico = consulta.IdMedico,
                IdTipoConsulta = consulta.IdTipoConsulta,
                IdAquista = consulta.IdAquista,
                IdTriagem = consulta.IdTriagem,
                Hora = consulta.Hora,
                Data = consulta.Data,
                Observacoes = consulta.Observacoes,
                PrescricaoTrue = consulta.PrescricaoTrue,
            }).ToListAsync();
        }

        public async Task<List<ConsultaModel>> GetAllConsultasDay()
        {
            DateTime date = DateTime.Now.Date;
            string now = String.Format("{0:yyyy-MM-dd}", date);

            return await _db.Consulta.Where(x => x.Data == now).OrderBy(o => o.Hora).Select(consulta => new ConsultaModel()
            {
                Id = consulta.Id,
                IdMedico = consulta.IdMedico,
                IdTipoConsulta = consulta.IdTipoConsulta,
                IdAquista = consulta.IdAquista,
                IdTriagem = consulta.IdTriagem,
                Hora = consulta.Hora,
                Data = consulta.Data,
                Observacoes = consulta.Observacoes,
                PrescricaoTrue = consulta.PrescricaoTrue,
            }).ToListAsync();
        }

        public async Task<ConsultaModel> GetConsultaById(int? id)
        {
            return await _db.Consulta.Where(x => x.Id == id).Select(consulta => new ConsultaModel()
            {
                Id = consulta.Id,
                IdMedico = consulta.IdMedico,
                IdTipoConsulta = consulta.IdTipoConsulta,
                IdAquista = consulta.IdAquista,
                IdTriagem = consulta.IdTriagem,
                Hora = consulta.Hora,
                Data = consulta.Data,
                Observacoes = consulta.Observacoes,
                PrescricaoTrue = consulta.PrescricaoTrue,
            }).FirstAsync();
        }

        public async Task<List<ConsultaModel>> GetConsultaByMedico(int? idFuncionario)
        {
            return await _db.Consulta.Where(x => x.IdMedico == idFuncionario).OrderBy(o => o.Data).Select(consulta => new ConsultaModel()
            {
                Id = consulta.Id,
                IdMedico = consulta.IdMedico,
                IdTipoConsulta = consulta.IdTipoConsulta,
                IdAquista = consulta.IdAquista,
                IdTriagem = consulta.IdTriagem,
                Hora = consulta.Hora,
                Data = consulta.Data,
                Observacoes = consulta.Observacoes,
                PrescricaoTrue = consulta.PrescricaoTrue,
            }).ToListAsync();
        }

        public async Task<List<ConsultaModel>> GetConsultaByMedicoDay(int? idFuncionario)
        {
            DateTime date = DateTime.Now.Date;
            string now = String.Format("{0:yyyy-MM-dd}", date);
            return await _db.Consulta.Where(x => x.IdMedico == idFuncionario && x.Data == now).OrderBy(o => o.Hora).Select(consulta => new ConsultaModel()
            {
                Id = consulta.Id,
                IdMedico = consulta.IdMedico,
                IdTipoConsulta = consulta.IdTipoConsulta,
                IdAquista = consulta.IdAquista,
                IdTriagem = consulta.IdTriagem,
                Hora = consulta.Hora,
                Data = consulta.Data,
                Observacoes = consulta.Observacoes,
                PrescricaoTrue = consulta.PrescricaoTrue,
            }).ToListAsync();
        }
        public async Task<List<ConsultaModel>> GetAllConsultaAquista(int idAquista)
        {
            return await _db.Consulta.Where(x => x.IdAquista == idAquista).OrderBy(o => o.Data).Select(consulta => new ConsultaModel()
            {
                Id = consulta.Id,
                IdMedico = consulta.IdMedico,
                IdTipoConsulta = consulta.IdTipoConsulta,
                IdAquista = consulta.IdAquista,
                IdTriagem = consulta.IdTriagem,
                Hora = consulta.Hora,
                Data = consulta.Data,
                Observacoes = consulta.Observacoes,
                PrescricaoTrue = consulta.PrescricaoTrue,
            }).ToListAsync();
        }
        public async Task<List<ConsultaModel>> GetAllConsultaTipo(int? idTipoConsulta)
        {
            return await _db.Consulta.Where(x => x.IdTipoConsulta == idTipoConsulta).OrderBy(o => o.Data).Select(consulta => new ConsultaModel()
            {
                Id = consulta.Id,
                IdMedico = consulta.IdMedico,
                IdTipoConsulta = consulta.IdTipoConsulta,
                IdAquista = consulta.IdAquista,
                IdTriagem = consulta.IdTriagem,
                Hora = consulta.Hora,
                Data = consulta.Data,
                Observacoes = consulta.Observacoes,
                PrescricaoTrue = consulta.PrescricaoTrue,
            }).ToListAsync();
        }
        public async Task<List<ConsultaModel>> GetConsultaAquistaDay(int idAquista)
        {
            DateTime date = DateTime.Now.Date;
            string now = String.Format("{0:yyyy-MM-dd}", date);
            return await _db.Consulta.Where(x => x.IdAquista == idAquista && x.Data == now).OrderBy(o => o.Hora).Select(consulta => new ConsultaModel()
            {
                Id = consulta.Id,
                IdMedico = consulta.IdMedico,
                IdTipoConsulta = consulta.IdTipoConsulta,
                IdAquista = consulta.IdAquista,
                IdTriagem = consulta.IdTriagem,
                Hora = consulta.Hora,
                Data = consulta.Data,
                Observacoes = consulta.Observacoes,
                PrescricaoTrue = consulta.PrescricaoTrue,
            }).ToListAsync();
        }

        public async Task<int> AddNewConsulta(ConsultaModel consulta)
        {
            var newConsulta = new Consulta()
            {
                Id = consulta.Id,
                IdMedico = consulta.IdMedico,
                IdTipoConsulta = consulta.IdTipoConsulta,
                IdAquista = consulta.IdAquista,
                IdTriagem = consulta.IdTriagem,
                Hora = consulta.Hora,
                Data = consulta.Data,
                Observacoes = consulta.Observacoes,
                PrescricaoTrue = consulta.PrescricaoTrue,
            };

            await _db.Consulta.AddAsync(newConsulta);
            await _db.SaveChangesAsync();

            int idTriagem = await _triagemRepository.CreatedTriagemConsulta(newConsulta.Id);

            var consultaId = _db.Consulta.Find(newConsulta.Id);
            consultaId.IdTriagem = idTriagem;
            _db.Consulta.Update(consultaId);
            await _db.SaveChangesAsync();

            return consultaId.Id;
        }

        public async Task<int> UpdateConsulta(ConsultaModel consulta)
        {
            var consultaId = _db.Consulta.Find(consulta.Id);

            consultaId.IdMedico = consulta.IdMedico;
            consultaId.IdTipoConsulta = consulta.IdTipoConsulta;
            consultaId.IdAquista = consulta.IdAquista;
            consultaId.IdTriagem = consulta.IdTriagem;
            consultaId.Hora = consulta.Hora;
            consultaId.Data = consulta.Data;
            consultaId.Observacoes = consulta.Observacoes;


            _db.Consulta.Update(consultaId);
            await _db.SaveChangesAsync();
            return consultaId.Id;
        }
        public async Task Delete(int id)
        {
            var consulta = await _db.Consulta.FindAsync(id);
            if (consulta != null)
            {
                _db.Consulta.Remove(consulta);
            }
            await _db.SaveChangesAsync();
        }

    }
}
