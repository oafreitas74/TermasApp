using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TermasApp.Data;
using TermasApp.IRepository;
using TermasApp.Models;

namespace TermasApp.Controllers
{
    public class EquipamentoController : Controller
    {
        public readonly IEquipamentoRepository _equipamentoRepository;

        public EquipamentoController(IEquipamentoRepository equipamentoRepository)
        {
            _equipamentoRepository = equipamentoRepository;
        }
        // GET: EquipamentoController
        public async Task<ActionResult> Index()
        {
            return View(await _equipamentoRepository.GetAllEquipamento());
        }

        // GET: EquipamentoController/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipamentoModel = await _equipamentoRepository.GetEquipamentoById(id);

            if (equipamentoModel == null)
            {
                return NotFound();
            }

            return View(equipamentoModel);
        }

        // GET: EquipamentoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EquipamentoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EquipamentoModel equipamentoModel)
        {
            if (ModelState.IsValid)
            {
                int Id = await _equipamentoRepository.AddNewEquipamento(equipamentoModel);

                return RedirectToAction("Details", new { Id });
            }
            return View(equipamentoModel);
        }

        // GET: EquipamentoController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipamentoModel = await _equipamentoRepository.GetEquipamentoById(id);

            if (equipamentoModel == null)
            {
                return NotFound();
            }

            return View(equipamentoModel);
        }

        // POST: EquipamentoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, EquipamentoModel equipamentoModel)
        {
            if (id != equipamentoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    int Id = await _equipamentoRepository.UpdateEquipamento(equipamentoModel);

                    return RedirectToAction("Details", new { Id });
                }
                catch (DbUpdateConcurrencyException)
                {

                }
                return RedirectToAction(nameof(Index));
            }
            return View(equipamentoModel);
        }

        // GET: EquipamentoController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipamentoModel = await _equipamentoRepository.GetEquipamentoById(id);

            if (equipamentoModel == null)
            {
                return NotFound();
            }

            return View(equipamentoModel);
        }

        // POST: EquipamentoController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _equipamentoRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        
    }
}
