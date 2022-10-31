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
    public class TriagemController : Controller
    {
        private readonly ITriagemRepository _triagem;
        public readonly IFuncionarioRepository _funcionarioRepository;
        public TriagemController(ITriagemRepository triagem, IFuncionarioRepository funcionarioRepository)
        {
            _triagem = triagem;
            _funcionarioRepository = funcionarioRepository;
        }

        // GET: Triagem
        public async Task<IActionResult> Index()
        {
              return View(await _triagem.GetAllTriagemDay());
        }
        public async Task<IActionResult> AllTriagem()
        {
            return View(await _triagem.GetAllTriagem());
        }

        // GET: Triagem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var triagemModel = await _triagem.GetTriagemById(id);

            if (triagemModel == null)
            {
                return NotFound();
            }

            return View(triagemModel);
        }

        // GET: Triagem/Create
        public async Task<IActionResult> CreateAsync()
        {

            ViewBag.LEnfermeiros = new SelectList(await _funcionarioRepository.GetAllFuncionarioTipo("Enfermeiro"), "Id", "Nome");
            return View();
        }

        // POST: Triagem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TriagemModel triagemModel)
        {
            if (ModelState.IsValid)
            {
                int Id = await _triagem.AddNewTriagem(triagemModel);

                return RedirectToAction("Details", new { Id });
            }
            return View(triagemModel);
        }

        // GET: Triagem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var triagemModel = await _triagem.GetTriagemById(id);
            if (triagemModel == null)
            {
                return NotFound();
            }
            ViewBag.LEnfermeiros = new SelectList(await _funcionarioRepository.GetAllFuncionarioTipo("Enfermeiro"), "Id", "Nome");
            return View(triagemModel);
        }

        // POST: Triagem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TriagemModel triagemModel)
        {
            if (id != triagemModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    await _triagem.UpdateTriagem(triagemModel);
                }
                catch (DbUpdateConcurrencyException)
                {

                }
                return RedirectToAction(nameof(Index));
            }
            return View(triagemModel);
        }

        // GET: Triagem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var triagemModel = await _triagem.GetTriagemById(id);
            if (triagemModel == null)
            {
                return NotFound();
            }

            return View(triagemModel);
        }

        // POST: Triagem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            await _triagem.Delete(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
