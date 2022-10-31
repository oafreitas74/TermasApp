using MessagePack;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using TermasApp.Data;
using TermasApp.IRepository;
using TermasApp.Models;

namespace TermasApp.Repository
{

    public class AquistaRepository : IAquistaRepository
    {
        private readonly TermasAppContext _db;

        public AquistaRepository(TermasAppContext db)
        {
            _db = db;
        }

        public async Task<List<AquistaModel>> GetAllAquista()
        {
            return await _db.Aquista.OrderBy(o => o.Nome)
                    .Select(aquista => new AquistaModel()
                    {
                        Id = aquista.Id,
                        NIF = aquista.NIF,
                        NSSocial = aquista.NSSocial,
                        Telefone = aquista.Telefone,
                        Nome = aquista.Nome,
                        CC = aquista.CC,
                        Email = aquista.Email,
                        Rua = aquista.Rua,
                        CPostal = aquista.CPostal,
                        Concelho = aquista.Concelho,
                        Localidade = aquista.Localidade,
                        Pais = aquista.Pais,
                        Nacionalidade = aquista.Nacionalidade,
                        DataNascimento = aquista.DataNascimento,
                        SeguroSaude = aquista.SeguroSaude,
                        FotoSrc = aquista.FotoSrc,
                        Genero = aquista.Genero,
                        Pass = aquista.Pass,
                    }).ToListAsync();
        }
        public async Task<AquistaModel> GetAquistaById(int? id)
        {
            return await _db.Aquista.Where(x => x.Id == id)
                    .Select(aquista => new AquistaModel()
                    {
                        Id = aquista.Id,
                        NIF = aquista.NIF,
                        NSSocial = aquista.NSSocial,
                        Telefone = aquista.Telefone,
                        Nome = aquista.Nome,
                        CC = aquista.CC,
                        Email = aquista.Email,
                        Rua = aquista.Rua,
                        CPostal = aquista.CPostal,
                        Concelho = aquista.Concelho,
                        Localidade = aquista.Localidade,
                        Pais = aquista.Pais,
                        Nacionalidade = aquista.Nacionalidade,
                        DataNascimento = aquista.DataNascimento,
                        SeguroSaude = aquista.SeguroSaude,
                        FotoSrc = aquista.FotoSrc,
                        Genero = aquista.Genero,
                        Pass = aquista.Pass,
                    }).FirstAsync();
        }
        public async Task<int> AddNewAquista(AquistaModel aquista)
        {
            var newAquista = new Aquista()
            {
                Id = aquista.Id,
                NIF = aquista.NIF,
                NSSocial = aquista.NSSocial,
                Telefone = aquista.Telefone,
                Nome = aquista.Nome,
                CC = aquista.CC,
                Email = aquista.Email,
                Rua = aquista.Rua,
                CPostal = aquista.CPostal,
                Concelho = aquista.Concelho,
                Localidade = aquista.Localidade,
                Pais = aquista.Pais,
                Nacionalidade = aquista.Nacionalidade,
                DataNascimento = aquista.DataNascimento,
                SeguroSaude = aquista.SeguroSaude,
                FotoSrc = aquista.FotoSrc,
                Genero = aquista.Genero,

            };
            await _db.Aquista.AddAsync(newAquista);
            await _db.SaveChangesAsync();
            return newAquista.Id;
        }

        public async Task<int> UpdateAquista(AquistaModel aquista)
        {
            var aquistaId = _db.Aquista.Find(aquista.Id);
            aquistaId.Id = aquista.Id;
            aquistaId.NIF = aquista.NIF;
            aquistaId.NSSocial = aquista.NSSocial;
            aquistaId.Telefone = aquista.Telefone;
            aquistaId.Nome = aquista.Nome;
            aquistaId.CC = aquista.CC;
            aquistaId.Email = aquista.Email;
            aquistaId.Rua = aquista.Rua;
            aquistaId.CPostal = aquista.CPostal;
            aquistaId.Concelho = aquista.Concelho;
            aquistaId.Localidade = aquista.Localidade;
            aquistaId.Pais = aquista.Pais;
            aquistaId.Nacionalidade = aquista.Nacionalidade;
            aquistaId.DataNascimento = aquista.DataNascimento;
            aquistaId.SeguroSaude = aquista.SeguroSaude;
            aquistaId.FotoSrc = aquista.FotoSrc;
            aquistaId.Genero = aquista.Genero;


            _db.Aquista.Update(aquistaId);
            await _db.SaveChangesAsync();
            return aquistaId.Id;
        }
        public bool AquistaExists(int id)
        {
            return _db.Aquista.Any(e => e.Id == id);
        }

        public async Task Delete(int id)
        {
            var funcionario = await _db.Aquista.FindAsync(id);
            if (funcionario != null)
            {
                _db.Aquista.Remove(funcionario);
            }
            await _db.SaveChangesAsync();

        }
        public Task<string> GetFotoUrlAquista(int? id)
        {
            var aquistaId = _db.Aquista.Find(id);
            return Task.FromResult(aquistaId.FotoSrc);
        }
        public Task<string> GetNomeAquista(int? id)
        {
            var aquistaId = _db.Aquista.Find(id);
            return Task.FromResult(aquistaId.Nome);
        }

        public async Task<bool> AquistaLoginTrue(int? id)
        {
            try
            {
                var aquistaId = _db.Aquista.Find(id);
                aquistaId.Pass = true;

                _db.Aquista.Update(aquistaId);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }


    }

}
