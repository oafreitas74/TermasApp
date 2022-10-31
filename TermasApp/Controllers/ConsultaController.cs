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
    public class ConsultaController : Controller
    {

        private readonly IConsultaRepository _consulta;
        private readonly ITipoConsultaRepository _tipoConsultaRepository;
        public readonly IFuncionarioRepository _funcionarioRepository;
        public ConsultaController(IConsultaRepository consulta, 
                                IFuncionarioRepository funcionarioRepository, 
                                ITipoConsultaRepository tipoConsultaRepository)
        {
            _consulta = consulta;
            _funcionarioRepository = funcionarioRepository;
            _tipoConsultaRepository = tipoConsultaRepository;
        }

        // GET: Consulta
        public async Task<IActionResult> Index()
        {
              return View(await _consulta.GetAllConsultasDay());
        }

        public async Task<IActionResult> AllConsultas()
        {
            return View(await _consulta.GetAllConsultas());
        }
        // GET: Consulta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultaModel = await _consulta.GetConsultaById(id);

            if (consultaModel == null)
            {
                return NotFound();
            }

            return View(consultaModel);
        }
        // GET: Consulta/Especialidade
        public async Task<IActionResult> Especialidade(int idAquista)
        {
            var model = new TipoModel()
            {
                IdAquista = idAquista,
            };
            ViewBag.Especialidade = new SelectList(await _tipoConsultaRepository.GetAllTConsulta(), "Id", "Nome");

            return View(model);
        }

        // POST: Consulta/Especialidade
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Especialidade(TipoModel tipoModel)
        {
            return RedirectToAction("Create", new { idAquista = tipoModel.IdAquista, idTipoConsulta = tipoModel.IdTipo });
        }

        // GET: Consulta/Create
        public async Task<IActionResult> CreateAsync(int idAquista, int idTipoConsulta)
        {
            var model = new ConsultaModel()
            {
                IdAquista = idAquista,
                IdTipoConsulta = idTipoConsulta,
            };
            ViewBag.LMedicos = new SelectList(await _funcionarioRepository.GetAllFuncionarioTipo("Medico"), "Id", "Nome");

            return View(model);
        }

        // POST: Consulta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ConsultaModel consultaModel)
        {
            if (ModelState.IsValid)
            {
                int Id = await _consulta.AddNewConsulta(consultaModel);

                return RedirectToAction("Details", new { Id });
            }
            return View(consultaModel);
        }

        // GET: Consulta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var consultaModel = await _consulta.GetConsultaById(id);
            if (consultaModel == null)
            {
                return NotFound();
            }
            ViewBag.LMedicos = new SelectList(await _funcionarioRepository.GetAllFuncionarioTipo("Medico"), "Id", "Nome");
            return View(consultaModel);
        }

        // POST: Consulta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,ConsultaModel consultaModel)
        {
            if (id != consultaModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _consulta.UpdateConsulta(consultaModel);
                }
                catch (DbUpdateConcurrencyException)
                {

                }
                return RedirectToAction(nameof(Index));
            }
            return View(consultaModel);
        }

        // GET: Consulta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultaModel = await _consulta.GetConsultaById(id);
            if (consultaModel == null)
            {
                return NotFound();
            }

            return View(consultaModel);
        }

        // POST: Consulta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _consulta.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
