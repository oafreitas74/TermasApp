using Microsoft.EntityFrameworkCore;
using TermasApp.Data;
using TermasApp.IRepository;
using TermasApp.Models;

namespace TermasApp.Repository
{
    public class EquipamentoRepository : IEquipamentoRepository
    {
        private readonly TermasAppContext _db;

        public EquipamentoRepository(TermasAppContext db)
        {
            _db = db;
        }

        public async Task<List<EquipamentoModel>> GetAllEquipamento()
        {
            return await _db.Equipamento.OrderBy(o => o.Id)
                    .Select(equipamento => new EquipamentoModel()
                    {
                        Id = equipamento.Id,
                        NomeInterno = equipamento.NomeInterno,
                        Marca = equipamento.Marca,
                        Modelo = equipamento.Modelo,
                        NSerie = equipamento.NSerie,
                        Descricao = equipamento.Descricao,
                        DataFabrico = equipamento.DataFabrico,

                    }).ToListAsync();
        }

        public async Task<EquipamentoModel> GetEquipamentoById(int? id)
        {
            return await _db.Equipamento.Where(x => x.Id == id)
                .Select(equipamento => new EquipamentoModel()
                {
                    Id = equipamento.Id,
                    NomeInterno = equipamento.NomeInterno,
                    Marca = equipamento.Marca,
                    Modelo = equipamento.Modelo,
                    NSerie = equipamento.NSerie,
                    Descricao = equipamento.Descricao,
                    DataFabrico = equipamento.DataFabrico,

                }).FirstAsync();
        }
        public async Task<int> AddNewEquipamento(EquipamentoModel equipamento)
        {
            var newEquipamento = new Equipamento()
            {
                Id = equipamento.Id,
                NomeInterno = equipamento.NomeInterno,
                Marca = equipamento.Marca,
                Modelo = equipamento.Modelo,
                NSerie = equipamento.NSerie,
                Descricao = equipamento.Descricao,
                DataFabrico = equipamento.DataFabrico,
            };
            await _db.Equipamento.AddAsync(newEquipamento);
            await _db.SaveChangesAsync();
            return newEquipamento.Id;
        }

        public async Task<int> UpdateEquipamento(EquipamentoModel equipamento)
        {
            var equipamentoId = _db.Equipamento.Find(equipamento.Id);
            equipamentoId.NomeInterno = equipamento.NomeInterno;
            equipamentoId.Marca = equipamento.Marca;
            equipamentoId.Modelo = equipamento.Modelo;
            equipamentoId.NSerie = equipamento.NSerie;
            equipamentoId.Descricao = equipamento.Descricao;
            equipamentoId.DataFabrico = equipamento.DataFabrico;

            _db.Equipamento.Update(equipamentoId);
            await _db.SaveChangesAsync();
            return equipamentoId.Id;
        }

        public async Task Delete(int id)
        {
            var equipamento = await _db.Equipamento.FindAsync(id);
            if (equipamento != null)
            {
                _db.Equipamento.Remove(equipamento);
            }
            await _db.SaveChangesAsync();
        }
        public Task<string> GetNomeEquipamento(int? id)
        {
            if (id > 0)
            {
                var equipamento = _db.Equipamento.Find(id);
                return Task.FromResult(equipamento.NomeInterno);
            }
            return Task.FromResult("");
        }

        public async Task<List<EquipamentoPreventivaModel>> GetAllEquipamentoPreventiva()
        {
            return await _db.Equipamento.OrderBy(o => o.Id)
                    .Select(equipamento => new EquipamentoPreventivaModel()
                    {
                        Id = equipamento.Id,
                        NomeInterno = equipamento.NomeInterno,
                        Jan = equipamento.Jan,
                        Fev = equipamento.Fev,
                        Mar = equipamento.Mar,
                        Abr = equipamento.Abr,
                        Mai = equipamento.Mai,
                        Jun = equipamento.Jun,
                        Jul = equipamento.Jul,
                        Ago = equipamento.Ago,
                        Set = equipamento.Set,
                        Out = equipamento.Out,
                        Nov = equipamento.Nov,
                        Dez = equipamento.Dez,

                    }).ToListAsync();
        }
        public async Task<List<int>> GetIdAllEquipamentoPreventivaJan()
        {
            List<int> ids = new List<int>();
            var allEquipamentos = await GetAllEquipamentoPreventiva();
            foreach (var equipamento in allEquipamentos)
            {
                if (equipamento.Jan == true)
                    ids.Add(equipamento.Id);
            }
            return ids;
        }
        public async Task<List<int>> GetIdAllEquipamentoPreventivaFev()
        {
            List<int> ids = new List<int>();
            var allEquipamentos = await GetAllEquipamentoPreventiva();
            foreach (var equipamento in allEquipamentos)
            {
                if (equipamento.Fev == true)
                    ids.Add(equipamento.Id);
            }
            return ids;
        }
        public async Task<List<int>> GetIdAllEquipamentoPreventivaMar()
        {
            List<int> ids = new List<int>();
            var allEquipamentos = await GetAllEquipamentoPreventiva();
            foreach (var equipamento in allEquipamentos)
            {
                if (equipamento.Mar == true)
                    ids.Add(equipamento.Id);
            }
            return ids;
        }
        public async Task<List<int>> GetIdAllEquipamentoPreventivaAbr()
        {
            List<int> ids = new List<int>();
            var allEquipamentos = await GetAllEquipamentoPreventiva();
            foreach (var equipamento in allEquipamentos)
            {
                if (equipamento.Abr == true)
                    ids.Add(equipamento.Id);
            }
            return ids;
        }
        public async Task<List<int>> GetIdAllEquipamentoPreventivaMai()
        {
            List<int> ids = new List<int>();
            var allEquipamentos = await GetAllEquipamentoPreventiva();
            foreach (var equipamento in allEquipamentos)
            {
                if (equipamento.Mai == true)
                    ids.Add(equipamento.Id);
            }
            return ids;
        }
        public async Task<List<int>> GetIdAllEquipamentoPreventivaJun()
        {
            List<int> ids = new List<int>();
            var allEquipamentos = await GetAllEquipamentoPreventiva();
            foreach (var equipamento in allEquipamentos)
            {
                if (equipamento.Jun == true)
                    ids.Add(equipamento.Id);
            }
            return ids;
        }
        public async Task<List<int>> GetIdAllEquipamentoPreventivaJul()
        {
            List<int> ids = new List<int>();
            var allEquipamentos = await GetAllEquipamentoPreventiva();
            foreach (var equipamento in allEquipamentos)
            {
                if (equipamento.Jul == true)
                    ids.Add(equipamento.Id);
            }
            return ids;
        }
        public async Task<List<int>> GetIdAllEquipamentoPreventivaAgo()
        {
            List<int> ids = new List<int>();
            var allEquipamentos = await GetAllEquipamentoPreventiva();
            foreach (var equipamento in allEquipamentos)
            {
                if (equipamento.Ago == true)
                    ids.Add(equipamento.Id);
            }
            return ids;
        }
        public async Task<List<int>> GetIdAllEquipamentoPreventivaSet()
        {
            List<int> ids = new List<int>();
            var allEquipamentos = await GetAllEquipamentoPreventiva();
            foreach (var equipamento in allEquipamentos)
            {
                if (equipamento.Set == true)
                    ids.Add(equipamento.Id);
            }
            return ids;
        }
        public async Task<List<int>> GetIdAllEquipamentoPreventivaOut()
        {
            List<int> ids = new List<int>();
            var allEquipamentos = await GetAllEquipamentoPreventiva();
            foreach (var equipamento in allEquipamentos)
            {
                if (equipamento.Out == true)
                    ids.Add(equipamento.Id);
            }
            return ids;
        }
        public async Task<List<int>> GetIdAllEquipamentoPreventivaNov()
        {
            List<int> ids = new List<int>();
            var allEquipamentos = await GetAllEquipamentoPreventiva();
            foreach (var equipamento in allEquipamentos)
            {
                if (equipamento.Nov == true)
                    ids.Add(equipamento.Id);
            }
            return ids;
        }
        public async Task<List<int>> GetIdAllEquipamentoPreventivaDez()
        {
            List<int> ids = new List<int>();
            var allEquipamentos = await GetAllEquipamentoPreventiva();
            foreach (var equipamento in allEquipamentos)
            {
                if (equipamento.Dez == true)
                    ids.Add(equipamento.Id);
            }
            return ids;
        }
        public async Task<EquipamentoPreventivaModel> GetEquipamentoPreventivaById(int? id)
        {
            return await _db.Equipamento.Where(x => x.Id == id)
                .Select(equipamento => new EquipamentoPreventivaModel()
                {
                    Id = equipamento.Id,
                    NomeInterno = equipamento.NomeInterno,
                    Jan = equipamento.Jan,
                    Fev = equipamento.Fev,
                    Mar = equipamento.Mar,
                    Abr = equipamento.Abr,
                    Mai = equipamento.Mai,
                    Jun = equipamento.Jun,
                    Jul = equipamento.Jul,
                    Ago = equipamento.Ago,
                    Set = equipamento.Set,
                    Out = equipamento.Out,
                    Nov = equipamento.Nov,
                    Dez = equipamento.Dez,

                }).FirstAsync();
        }
        public async Task<int> UpdateEquipamentoPreventiva(EquipamentoPreventivaModel equipamento)
        {
            var equipamentoId = _db.Equipamento.Find(equipamento.Id);
            equipamentoId.Jan = equipamento.Jan;
            equipamentoId.Fev = equipamento.Fev;
            equipamentoId.Mar = equipamento.Mar;
            equipamentoId.Abr = equipamento.Abr;
            equipamentoId.Mai = equipamento.Mai;
            equipamentoId.Jun = equipamento.Jun;
            equipamentoId.Jul = equipamento.Jul;
            equipamentoId.Ago = equipamento.Ago;
            equipamentoId.Set = equipamento.Set;
            equipamentoId.Out = equipamento.Out;
            equipamentoId.Nov = equipamento.Nov;
            equipamentoId.Dez = equipamento.Dez;

            _db.Equipamento.Update(equipamentoId);
            await _db.SaveChangesAsync();
            return equipamentoId.Id;
        }

        public async Task<bool> UpdateListEquipamentoPreventiva(List<EquipamentoPreventivaModel> ListEquipamento)
        {
            foreach (var equipamento in ListEquipamento)
            {
                var equipamentoId = _db.Equipamento.Find(equipamento.Id);
                equipamentoId.Jan = equipamento.Jan;
                equipamentoId.Fev = equipamento.Fev;
                equipamentoId.Mar = equipamento.Mar;
                equipamentoId.Abr = equipamento.Abr;
                equipamentoId.Mai = equipamento.Mai;
                equipamentoId.Jun = equipamento.Jun;
                equipamentoId.Jul = equipamento.Jul;
                equipamentoId.Ago = equipamento.Ago;
                equipamentoId.Set = equipamento.Set;
                equipamentoId.Out = equipamento.Out;
                equipamentoId.Nov = equipamento.Nov;
                equipamentoId.Dez = equipamento.Dez;

                _db.Equipamento.Update(equipamentoId);
                await _db.SaveChangesAsync();
            }

            return true;
        }

        public async Task<List<int>> GetListEQuipamentoPreventiva()
        {
            List<int> list = new List<int>();
            int month = DateTime.Now.Month;
            switch (month)
            {
                case 1:
                    return list = await GetIdAllEquipamentoPreventivaJan();
                case 2:
                    return list = await GetIdAllEquipamentoPreventivaFev(); ;
                case 3:
                    return list = await GetIdAllEquipamentoPreventivaMar();
                case 4:
                    return list = await GetIdAllEquipamentoPreventivaAbr();
                case 5:
                    return list = await GetIdAllEquipamentoPreventivaMai();
                case 6:
                    return list = await GetIdAllEquipamentoPreventivaJun();
                case 7:
                    return list = await GetIdAllEquipamentoPreventivaJul();
                case 8:
                    return list = await GetIdAllEquipamentoPreventivaAgo(); ;
                case 9:
                    return list = await GetIdAllEquipamentoPreventivaSet();
                case 10:
                    return list = await GetIdAllEquipamentoPreventivaOut();
                case 11:
                    return list = await GetIdAllEquipamentoPreventivaNov();
                case 12:
                    return list = await GetIdAllEquipamentoPreventivaDez();
            }
            return list;
        }

    }
}
