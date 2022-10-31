using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TermasApp.IRepository;
using TermasApp.Models;

namespace TermasApp.Controllers
{
    public class PedidoController : Controller
    {
        public readonly IEquipamentoRepository _equipamentoRepository;
        public readonly IPedidoRepository _pedidoRepository;
        public PedidoController(IEquipamentoRepository equipamentoRepository, 
                                IPedidoRepository pedidoRepository)
        {
            _equipamentoRepository = equipamentoRepository;
            _pedidoRepository = pedidoRepository;
        }

        // GET: PedidoController
        public async Task<ActionResult> Index()
        {
            return View(await _pedidoRepository.GetAllPedidosAberto());
        }
        public async Task<ActionResult> AlPedidos()
        {
            return View(await _pedidoRepository.GetAllPedidos());
        }
        // GET: PedidoController/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoModel = await _pedidoRepository.GetPedidosById(id);

            if (pedidoModel == null)
            {
                return NotFound();
            }

            return View(pedidoModel);
        }

        // GET: PedidoController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.Equipamentos = new SelectList(await _equipamentoRepository.GetAllEquipamento(), "Id", "NomeInterno");
            return View();
        }

        // POST: PedidoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PedidosReparacaoModel pedidoModel)
        {
            if (ModelState.IsValid)
            {
                int Id = await _pedidoRepository.AddNewPedido(pedidoModel);

                return RedirectToAction("Details", new { Id });
            }
            return View(pedidoModel);
        }

        // GET: PedidoController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoModel = await _pedidoRepository.GetPedidosById(id);

            if (pedidoModel == null)
            {
                return NotFound();
            }

            return View(pedidoModel);
        }

        // POST: PedidoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, PedidosReparacaoModel pedidoModel)
        {
            if (id != pedidoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    int Id = await _pedidoRepository.UpdatePedido(pedidoModel);

                    return RedirectToAction("Details", new { Id });
                }
                catch (DbUpdateConcurrencyException)
                {

                }
                return RedirectToAction(nameof(Index));
            }
            return View(pedidoModel);
        }

        // GET: PedidoController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoModel = await _pedidoRepository.GetPedidosById(id);

            if (pedidoModel == null)
            {
                return NotFound();
            }

            return View(pedidoModel);
        }

        // POST: PedidoController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _pedidoRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
