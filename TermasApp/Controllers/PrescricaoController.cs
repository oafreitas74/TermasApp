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
    public class PrescricaoController : Controller
    {
        public readonly ITipoTratamentoRepository _tipoTratamentoRepository;
        public readonly IPrescricaoRepository _prescricaoRepository;
        public PrescricaoController(ITipoTratamentoRepository tipoTratamentoRepository, 
                                    IPrescricaoRepository prescricaoRepository)
        {
            _tipoTratamentoRepository = tipoTratamentoRepository;
            _prescricaoRepository = prescricaoRepository;
        }

        // GET: Prescricao
        public async Task<IActionResult> Index()
        {
              return View(await _prescricaoRepository.GetAllPrecricao());
        }

        // GET: Prescricao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescricaoModel = await _prescricaoRepository.GetPrecricaoById(id);
            if (prescricaoModel == null)
            {
                return NotFound();
            }

            return View(prescricaoModel);
        }

        // GET: Prescricao/Create
        public async Task<IActionResult> CreateAsync(int id)
        {
            var model = new PrescricaoModel()
            {
                IdConsulta = id,
            };

            ViewBag.LTipoTratamento = new SelectList(await _tipoTratamentoRepository.GetAllTTratamento(), "Id", "Nome");
            return View(model);
        }

        // POST: Prescricao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PrescricaoModel prescricaoModel)
        {
            if (ModelState.IsValid)
            {
                int Id = await _prescricaoRepository.AddNewPrecricao(prescricaoModel);

                return RedirectToAction("Details", new { Id });
            }
            return View(prescricaoModel);
        }

        // GET: Prescricao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescricaoModel = await _prescricaoRepository.GetPrecricaoById(id);
            if (prescricaoModel == null)
            {
                return NotFound();
            }
            ViewBag.LTipoTratamento = new SelectList(await _tipoTratamentoRepository.GetAllTTratamento(), "Id", "Nome");
            return View(prescricaoModel);
        }

        // POST: Prescricao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,PrescricaoModel prescricaoModel)
        {
            if (id != prescricaoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _prescricaoRepository.UpdatePrecricao(prescricaoModel);
                }
                catch (DbUpdateConcurrencyException)
                {

                }
                return RedirectToAction(nameof(Index));
            }
            return View(prescricaoModel);
        }

        // GET: Prescricao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescricaoModel = await _prescricaoRepository.GetPrecricaoById(id);
            if (prescricaoModel == null)
            {
                return NotFound();
            }

            return View(prescricaoModel);
        }

        // POST: Prescricao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _prescricaoRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
