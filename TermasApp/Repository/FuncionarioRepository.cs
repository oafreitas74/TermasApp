using MessagePack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Security.Cryptography;
using TermasApp.Data;
using TermasApp.IRepository;
using TermasApp.Models;

namespace TermasApp.Repository
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly TermasAppContext _db;

        public FuncionarioRepository(TermasAppContext db)
        {
            _db = db;
        }

        public async Task<List<FuncionarioModel>> GetAllFuncionario()
        {
            return await _db.Funcionario.Where(x => x.Ativo == true).OrderBy(o => o.TipoFuncionario)
                    .Select(funcionario => new FuncionarioModel()
                    {
                        Id = funcionario.Id,
                        Classificacao = funcionario.Classificacao,
                        Telefone = funcionario.Telefone,
                        NIF = funcionario.NIF,
                        NSSocial = funcionario.NSSocial,
                        Nome = funcionario.Nome,
                        TipoFuncionario = funcionario.TipoFuncionario,
                        CC = funcionario.CC,
                        IBAN = funcionario.IBAN,
                        SeguroTrabalho = funcionario.SeguroTrabalho,
                        Email = funcionario.Email,
                        Rua = funcionario.Rua,
                        CPostal = funcionario.CPostal,
                        Concelho = funcionario.Concelho,
                        Localidade = funcionario.Localidade,
                        Pais = funcionario.Pais,
                        Nacionalidade = funcionario.Nacionalidade,
                        DataEntrada = funcionario.DataEntrada,
                        DataNascimento = funcionario.DataNascimento,
                        DataSaida = funcionario.DataSaida,
                        Posto = funcionario.Posto,
                        Hablitacoes = funcionario.Hablitacoes,
                        Especialidade = funcionario.Especialidade,
                        FotoSrc = funcionario.FotoSrc,
                        Genero = funcionario.Genero,

                    }).ToListAsync();
        }
        public async Task<List<FuncionarioModel>> GetAllFuncionarioTipo(string tipo)
        {
            return await _db.Funcionario.Where(x => x.TipoFuncionario == tipo).OrderBy(o => o.Ativo)
                    .Select(funcionario => new FuncionarioModel()
                    {
                        Id = funcionario.Id,
                        Classificacao = funcionario.Classificacao,
                        Telefone = funcionario.Telefone,
                        NIF = funcionario.NIF,
                        NSSocial = funcionario.NSSocial,
                        Nome = funcionario.Nome,
                        TipoFuncionario = funcionario.TipoFuncionario,
                        CC = funcionario.CC,
                        IBAN = funcionario.IBAN,
                        SeguroTrabalho = funcionario.SeguroTrabalho,
                        Email = funcionario.Email,
                        Rua = funcionario.Rua,
                        CPostal = funcionario.CPostal,
                        Concelho = funcionario.Concelho,
                        Localidade = funcionario.Localidade,
                        Pais = funcionario.Pais,
                        Nacionalidade = funcionario.Nacionalidade,
                        DataEntrada = funcionario.DataEntrada,
                        DataNascimento = funcionario.DataNascimento,
                        DataSaida = funcionario.DataSaida,
                        Posto = funcionario.Posto,
                        Hablitacoes = funcionario.Hablitacoes,
                        Especialidade = funcionario.Especialidade,
                        FotoSrc = funcionario.FotoSrc,
                        Genero = funcionario.Genero,

                    }).ToListAsync();
        }
        public async Task<FuncionarioModel> GetFuncionarioById(int? id)
        {
            return await _db.Funcionario.Where(x => x.Id == id)
                    .Select(funcionario => new FuncionarioModel()
                    {
                        Id = funcionario.Id,
                        Classificacao = funcionario.Classificacao,
                        Telefone = funcionario.Telefone,
                        NIF = funcionario.NIF,
                        NSSocial = funcionario.NSSocial,
                        Nome = funcionario.Nome,
                        TipoFuncionario = funcionario.TipoFuncionario,
                        CC = funcionario.CC,
                        IBAN = funcionario.IBAN,
                        SeguroTrabalho = funcionario.SeguroTrabalho,
                        Email = funcionario.Email,
                        Rua = funcionario.Rua,
                        CPostal = funcionario.CPostal,
                        Concelho = funcionario.Concelho,
                        Localidade = funcionario.Localidade,
                        Pais = funcionario.Pais,
                        Nacionalidade = funcionario.Nacionalidade,
                        DataEntrada = funcionario.DataEntrada,
                        DataNascimento = funcionario.DataNascimento,
                        DataSaida = funcionario.DataSaida,
                        Posto = funcionario.Posto,
                        Hablitacoes = funcionario.Hablitacoes,
                        Especialidade = funcionario.Especialidade,
                        FotoSrc = funcionario.FotoSrc,
                        Genero = funcionario.Genero,
                        Pass = funcionario.Pass,
                        Ativo = funcionario.Ativo,
                    }).FirstAsync();
        }
        public async Task<int> AddNewFuncionario(FuncionarioModel funcionario)
        {
            var newFuncionario = new Funcionario()
            {
                Classificacao = funcionario.Classificacao,
                Telefone = funcionario.Telefone,
                NIF = funcionario.NIF,
                NSSocial = funcionario.NSSocial,
                Nome = funcionario.Nome,
                TipoFuncionario = funcionario.TipoFuncionario,
                CC = funcionario.CC,
                IBAN = funcionario.IBAN,
                SeguroTrabalho = funcionario.SeguroTrabalho,
                Email = funcionario.Email,
                Rua = funcionario.Rua,
                CPostal = funcionario.CPostal,
                Concelho = funcionario.Concelho,
                Localidade = funcionario.Localidade,
                Pais = funcionario.Pais,
                Nacionalidade = funcionario.Nacionalidade,
                DataEntrada = funcionario.DataEntrada,
                DataNascimento = funcionario.DataNascimento,
                DataSaida = funcionario.DataSaida,
                Posto = funcionario.Posto,
                Hablitacoes = funcionario.Hablitacoes,
                Especialidade = funcionario.Especialidade,
                FotoSrc = funcionario.FotoSrc,
                Genero = funcionario.Genero,
                Ativo = true,
            };
            await _db.Funcionario.AddAsync(newFuncionario);
            await _db.SaveChangesAsync();
            return newFuncionario.Id;
        }

        public async Task<int> UpdateFuncionario(FuncionarioModel funcionario)
        {
            var funcionarioId = _db.Funcionario.Find(funcionario.Id);
            funcionarioId.Classificacao = funcionario.Classificacao;
            funcionarioId.Telefone = funcionario.Telefone;
            funcionarioId.NIF = funcionario.NIF;
            funcionarioId.NSSocial = funcionario.NSSocial;
            funcionarioId.Nome = funcionario.Nome;
            funcionarioId.TipoFuncionario = funcionario.TipoFuncionario;
            funcionarioId.CC = funcionario.CC;
            funcionarioId.IBAN = funcionario.IBAN;
            funcionarioId.SeguroTrabalho = funcionario.SeguroTrabalho;
            funcionarioId.Email = funcionario.Email;
            funcionarioId.Rua = funcionario.Rua;
            funcionarioId.CPostal = funcionario.CPostal;
            funcionarioId.Concelho = funcionario.Concelho;
            funcionarioId.Localidade = funcionario.Localidade;
            funcionarioId.Pais = funcionario.Pais;
            funcionarioId.Nacionalidade = funcionario.Nacionalidade;
            funcionarioId.DataEntrada = funcionario.DataEntrada;
            funcionarioId.DataNascimento = funcionario.DataNascimento;
            funcionarioId.DataSaida = funcionario.DataSaida;
            funcionarioId.Posto = funcionario.Posto;
            funcionarioId.Hablitacoes = funcionario.Hablitacoes;
            funcionarioId.Especialidade = funcionario.Especialidade;
            funcionarioId.FotoSrc = funcionario.FotoSrc;
            funcionarioId.Genero = funcionario.Genero;

            if(funcionario.DataSaida != null)
                funcionarioId.Ativo = false;

            _db.Funcionario.Update(funcionarioId);
            await _db.SaveChangesAsync();
            return funcionarioId.Id;
        }
        public bool FuncionarioExists(int id)
        {
            return _db.Funcionario.Any(e => e.Id == id);
        }
        public int FuncionarioCount()
        {
            return _db.Funcionario.Count();
        }
        public async Task Delete(int id)
        {
            var funcionario = await _db.Funcionario.FindAsync(id);
            if (funcionario != null)
            {
                _db.Funcionario.Remove(funcionario);
            }
            await _db.SaveChangesAsync();

        }
        public async Task<bool> FuncionarioLoginTrue(int? id)
        {
            try
            {
                var funcionarioId = _db.Funcionario.Find(id);
                funcionarioId.Pass = true;

                _db.Funcionario.Update(funcionarioId);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public Task<string> GetFotoUrlFuncionario(int? id)
        {
            if (id > 0)
            {
                var funcionarioId = _db.Funcionario.Find(id);
                return Task.FromResult(funcionarioId.FotoSrc);
            }
            return Task.FromResult("");
        }
        public Task<string> GetNomeFuncionario(int? id)
        {
            if (id > 0)
            {
                var funcionarioId = _db.Funcionario.Find(id);
                return Task.FromResult(funcionarioId.Nome);
            }
            return Task.FromResult("");
        }

        public Task<string> GetTipolFuncionario(int? id)
        {
            if (id > 0)
            {
                var funcionarioId = _db.Funcionario.Find(id);
                return Task.FromResult(funcionarioId.TipoFuncionario);
            }
            return Task.FromResult("");
        }
        public Task<string> GetPostolFuncionario(int? id)
        {
            if (id > 0)
            {
                var funcionarioId = _db.Funcionario.Find(id);
                return Task.FromResult(funcionarioId.Posto);
            }
            return Task.FromResult("");
        }
    }
}
