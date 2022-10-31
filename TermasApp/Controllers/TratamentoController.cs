using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TermasApp.Data;
using TermasApp.IRepository;
using TermasApp.Models;

namespace TermasApp.Controllers
{
    public class TratamentoController : Controller
    {
        private readonly ITratamentoRepository _tratamento;
        private readonly ITipoTratamentoRepository _tipoTratamentoRepository;
        public readonly IFuncionarioRepository _funcionarioRepository;
        public TratamentoController(ITratamentoRepository tratamento, 
                                IFuncionarioRepository funcionarioRepository, 
                                ITipoTratamentoRepository tipoTratamentoRepository)
        {
            _tratamento = tratamento;
            _funcionarioRepository = funcionarioRepository;
            _tipoTratamentoRepository = tipoTratamentoRepository;
        }

        // GET: Tratamento
        public async Task<IActionResult> Index()
        {
            return View(await _tratamento.GetAllTratamentoDay());
        }
        public async Task<IActionResult> AllTratamentos()
        {
            return View(await _tratamento.GetAllTratamento());
        }

        // GET: Tratamento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tratamentoModel = await _tratamento.GetTratamentoById(id);
            if (tratamentoModel == null)
            {
                return NotFound();
            }

            return View(tratamentoModel);
        }

        // GET: Tratamento/Especialidade
        public IActionResult Prescricao(int idAquista, int idPrescricao, int idTipo)
        {
            var tipoModel = new TipoModel()
            {
                IdAquista = idAquista,
                IdPrescricao = idPrescricao,
                IdTipo = idTipo,
            };
            return RedirectToAction("Create", tipoModel);
        }
        // GET: Tratamento/Especialidade
        public async Task<IActionResult> Especialidade(int idAquista, int? idPrescricao)
        {
            var model = new TipoModel()
            {
                IdAquista = idAquista,
                IdPrescricao = idPrescricao,
            };
            ViewBag.Especialidade = new SelectList(await _tipoTratamentoRepository.GetAllTTratamento(), "Id", "Nome");

            return View(model);
        }

        // POST: Tratamento/Especialidade
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Especialidade(TipoModel tipoModel)
        {
            return RedirectToAction("Create", tipoModel);
        }

        // GET: Tratamento/Create
        public async Task<IActionResult> CreateAsync(TipoModel tipoModel)
        {
            var model = new TratamentoModel()
            {
                IdAquista = tipoModel.IdAquista,
                IdTipoTratamento = tipoModel.IdTipo,
                IdPrescricao = tipoModel.IdPrescricao,
            };
            ViewBag.LTerapeuta = new SelectList(await _funcionarioRepository.GetAllFuncionarioTipo("Terapeuta"), "Id", "Nome");

            return View(model);
        }

        // POST: Tratamento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TratamentoModel tratamentoModel)
        {
            if (ModelState.IsValid)
            {
                int Id = await _tratamento.AddNewTratamento(tratamentoModel);

                return RedirectToAction("Details", new { Id });
            }
            return View(tratamentoModel);
        }

        // GET: Tratamento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tratamentoModel = await _tratamento.GetTratamentoById(id);
            if (tratamentoModel == null)
            {
                return NotFound();
            }
            ViewBag.LTerapeuta = new SelectList(await _funcionarioRepository.GetAllFuncionarioTipo("Terapeuta"), "Id", "Nome");
            return View(tratamentoModel);
        }

        // POST: Tratamento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TratamentoModel tratamentoModel)
        {
            if (id != tratamentoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _tratamento.UpdateTratamento(tratamentoModel);
                }
                catch (DbUpdateConcurrencyException)
                {

                }
                return RedirectToAction(nameof(Index));
            }
            return View(tratamentoModel);
        }

        // GET: Tratamento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tratamentoModel = await _tratamento.GetTratamentoById(id);
            if (tratamentoModel == null)
            {
                return NotFound();
            }

            return View(tratamentoModel);
        }

        // POST: Tratamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _tratamento.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
